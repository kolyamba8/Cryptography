using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DES
{
    static public class Des
    {
        //таблицы
        private static int[] P10 = { 3, 5, 2, 7, 4, 10, 1, 9, 8, 6 };
        private static int[] P8 = { 6, 3, 7, 4, 8, 5, 10, 9 };
        private static int[] IP = { 2, 6, 3, 1, 4, 8, 5, 7 };
        private static int[] EP = { 4, 1, 2, 3, 2, 3, 4, 1 };
        private static int[] P4 = { 2, 4, 3, 1 };
        private static int[] IP_Inverse = { 4, 1, 3, 5, 7, 2, 8, 6 };
        private static int[,] S0 = new int[,] { { 1, 0, 3, 2 }, { 3, 2, 1, 0, }, { 0, 2, 1, 3 }, { 3, 1, 3, 2 } };
        private static int[,] S1 = new int[,] { { 0, 1, 2, 3 }, { 2, 0, 1, 3, }, { 3, 0, 1, 0 }, { 2, 1, 0, 3 } };
        private static int maxKeyLen = 10;
        private static int maxMessageLen = 8;
        private static int maxCodeLen = 8;
        private static int maxIVLen = 8;
        public static byte key1;
        public static byte key2;

        

        //стоку в байты
        static public byte Convert_String_To_Byte(string input)
        {
            byte result = 0;
            int len = input.Length;
            for (int i = 0; i < len; i++)
            {
                if (input[i] == '1')
                {
                    result <<= 1;
                    result |= 1;
                }
                else
                    result <<= 1;
            }
            return result;
        }

        //байты в строку
        static public string Convert_Byte_To_String(byte input)
        {
            string result = "";
            for (int i = 0; i < maxMessageLen; i++)
            {
                if (Get_Bit(input, i + 1) == 0)
                    result += '0';
                else
                    result += '1';
            }
            return result;
        }

        //генерируем ключ
        static public void Generate_Key(string skey, ref byte key1, ref byte key2)
        {
            //замена p10
            int len = skey.Length;
            char[] key = new char[len];
            for (int i = 0; i < len; i++)
            {
                key[i] = skey[P10[i] - 1];
            }


            //
            char t1 = key[0];
            char t2 = key[len / 2];
            for (int i = 0; i < len - 1; i++)
                key[i] = key[i + 1];
            key[len / 2 - 1] = t1;
            key[len - 1] = t2;


            //p8
            string skey1 = "";
            int P8len = P8.Length;
            for (int i = 0; i < P8len; i++)
                skey1 += key[P8[i] - 1];
            key1 = Convert_String_To_Byte(skey1);





            t1 = key[0];
            t2 = key[1];
            char t3 = key[len / 2];
            char t4 = key[len / 2 + 1];
            for (int i = 0; i < len - 2; i++)
                key[i] = key[i + 2];
            key[len / 2 - 2] = t1;
            key[len / 2 - 1] = t2;
            key[len - 2] = t3;
            key[len - 1] = t4;



            //p8 для k2
            string skey2 = "";
            for (int i = 0; i < P8len; i++)
                skey2 += key[P8[i] - 1];
            key2 = Convert_String_To_Byte(skey2);

        }


        //получить бит из позиции
        static private int Get_Bit(byte input, int pos)
        {
            input >>= (maxMessageLen - pos);
            input &= 0x1;
            return (int)input;
        }

        //установить бит
        static private void Set_Bit(ref byte input, int pos, int value)
        {
            byte flag = (byte)value;
            flag <<= (maxMessageLen - pos);
            input |= flag;
        }

        //бит в инт
        static private int Convert_Bit_To_Int(int i, int j)
        {
            int result = i;
            result <<= 1;
            result |= j;
            return result;
        }

        //объеденяем байты с 2 битами
       static private byte Merge_Two_Byte2(byte i, byte j)
        {
            byte result = i;
            result <<= (maxMessageLen - 2);
            j <<= (maxMessageLen - 4);
            result |= j;
            return result;
        }

        // объеденяем байты с 4 битами
        static private byte Merge_Two_Byte4(byte i, byte j)
        {
            byte result = j;
            result >>= 4;
            result &= 0xf;
            result |= i;
            return result;
        }

        //меняем младшие и старшие местами
        static private byte Swap_High_Low(byte input)
        {
            byte result = 0;
            result = input;
            result <<= 4;
            input >>= 4;
            input &= 0xf;
            result |= input;
            return result;
        }

        //Шифрование 8 битового блока
        static public byte Single_Block_Encode(byte input)
        {
            //начальная перестановка IP
            byte result = 0;
            for (int i = 0; i < maxMessageLen; i++)
            {
                int flag = Get_Bit(input, IP[i]);
                Set_Bit(ref result, i + 1, flag);
            }


            //Функция FK
            result = FunctionK(result, key1);
            //Обмен старших и младших битов
            result = Swap_High_Low(result);
            //FK
            result = FunctionK(result, key2);

            byte tresult = result;
            result = 0;
            for (int i = 0; i < maxMessageLen; i++)
            {
                int flag = Get_Bit(tresult, IP_Inverse[i]);
                Set_Bit(ref result, i + 1, flag);
            }

            return result;
        }

        //Декодирование блока 8 бит
        static public byte Single_Block_Decode(byte input)
        {
            //Перестановка IP
            byte result = 0;
            for (int i = 0; i < maxMessageLen; i++)
            {
                int flag = Get_Bit(input, IP[i]);
                Set_Bit(ref result, i + 1, flag);
            }


            //FK
            result = FunctionK(result, key2);
            //
            result = Swap_High_Low(result);
            //Обмен старших и младших битов
            result = FunctionK(result, key1);
            //IP
            byte tresult = result;
            result = 0;
            for (int i = 0; i < maxMessageLen; i++)
            {
                int flag = Get_Bit(tresult, IP_Inverse[i]);
                Set_Bit(ref result, i + 1, flag);
            }

            return result;
        }


        //FK
        static private byte FunctionK(byte input, byte key)
        {
            //делим байт на 2 части
            byte result = 0;
            byte presult1 = input;
            presult1 &= 0xf0;
            byte presult2 = input;
            presult2 <<= 4;
            presult2 &= 0xf0;



            //для младших 4 бит
            byte tresult = 0;
            for (int i = 0; i < maxMessageLen; i++)
            {
                int flag = Get_Bit(presult2, EP[i]);
                Set_Bit(ref tresult, i + 1, flag);
            }



            //xor с ключом
            tresult ^= key;

            //
            byte presult3 = tresult;
            presult3 &= 0xf0;
            byte presult4 = tresult;
            presult4 <<= 4;
            presult4 &= 0xf0;


            //
            int row = Convert_Bit_To_Int(Get_Bit(presult3, 1), Get_Bit(presult3, 4));
            int col = Convert_Bit_To_Int(Get_Bit(presult3, 2), Get_Bit(presult3, 3));
            byte presult5 = (byte)S0[row, col];


            row = Convert_Bit_To_Int(Get_Bit(presult4, 1), Get_Bit(presult4, 4));
            col = Convert_Bit_To_Int(Get_Bit(presult4, 2), Get_Bit(presult4, 3));
            byte presult6 = (byte)S1[row, col];

            byte presult7 = Merge_Two_Byte2(presult5, presult6);

            byte presult8 = 0;
            for (int i = 0; i < maxMessageLen / 2; i++)
            {
                int flag = Get_Bit(presult7, P4[i]);
                Set_Bit(ref presult8, i + 1, flag);
            }

            presult8 ^= presult1;



            result = Merge_Two_Byte4(presult8, presult2);
            return result;

        }
    }
}
