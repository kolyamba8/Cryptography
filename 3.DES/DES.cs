using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Des
{
    class DES
    {
       static private int[] pc = {  57,49,41,33,25,17,9,1,
                                   58,50,42,34,26,18,10,2,
                                   59,51,43,35,27,19,11,3,
                                   60,52,44,36,63,55,47,39,
                                   31,23,15,7,62,54,46,38,
                                   30,22,14,6,61,53,45,37,
                                   29,21,13,5,28,20,12,4};

       static private int[] pc1 = { 14,17,11,24,1,5,3,28,
                                   15,6,21,10,23,19,12,
                                   4,26,8,16,7,27,20,13,
                                   2,41,52,31,37,47,55,
                                   30,40,51,45,33,48,
                                   44,49,39,56,34,53,
                                   46,42,50,36,29,32 };

       static private int[] e = { 32,1,2,3,4,5,4,5,
                                 6,7,8,9,8,9,10,11,
                                 12,13,12,13,14,15,
                                 16,17,16,17,18,19,
                                 20,21,20,21,22,23,
                                 24,25,24,25,26,27,
                                 28,29,28,29,30,31,32,1 };

       static private int[] ip = { 58,50,42,34,26,18,10,
                                  2,60,52,44,36,28,20,12,
                                  4,62,54,46,38,30,22,14,
                                  6,64,56,48,40,32,24,16,8,
                                  57,49,41,33,25,17,9,1,59,
                                  51,43,35,27,19,11,3,61,53,
                                  45,37,29,21,13,5,63,55,47,
                                  39,31,23,15,7 };

       static private int[] shift = { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

       static private int[] sm = {
                    14,4,13,1,2,15,11,8,3,10,6,12,5,9,0,7,
                    0,15,7,4,14,2,13,1,10,6,12,11,9,5,3,8,
                    4,1,14,8,13,6,2,11,15,12,9,7,3,10,5,0,
                    15,12,8,2,4,9,1,7,5,11,3,14,10,0,6,13,
                    15,1,8,14,6,11,3,4,9,7,2,13,12,0,5,10,
                    3,13,4,7,15,2,8,14,12,0,1,10,6,9,11,5,
                    0,14,7,11,10,4,13,1,5,8,12,6,9,3,2,15,
                    13,8,10,1,3,15,4,2,11,6,7,12,0,5,14,9,
                    10,0,9,14,6,3,15,5,1,13,12,7,11,4,2,8,
                    13,7,0,9,3,4,6,10,2,8,5,14,12,11,15,1,
                    13,6,4,9,8,15,3,0,11,1,2,12,5,10,14,7,
                    1,10,13,0,6,9,8,7,4,15,14,3,11,5,2,12,
                    7,13,14,3,0,6,9,10,1,2,8,5,11,12,4,15,
                    13,8,11,5,6,15,0,3,4,7,2,12,1,10,14,9,
                    10,6,9,0,12,11,7,13,15,1,3,14,5,2,8,4,
                    3,15,0,6,10,1,13,8,9,4,5,11,12,7,2,14,
                    2,12,4,1,7,10,11,6,8,5,3,15,13,0,14,9,
                    14,11,2,12,4,7,13,1,5,0,15,10,3,9,8,6,
                    4,2,1,11,10,13,7,8,15,9,12,5,6,3,0,14,
                    11,8,12,7,1,14,2,13,6,15,0,9,10,4,5,3,
                    12,1,10,15,9,2,6,8,0,13,3,4,14,7,5,11,
                    10,15,4,2,7,12,9,5,6,1,13,14,0,11,3,8,
                    9,14,15,5,2,8,12,3,7,0,4,10,1,13,11,6,
                    4,3,2,12,9,5,15,10,11,14,1,7,6,0,8,13,
                    4,11,2,14,15,0,8,13,3,12,9,7,5,10,6,1,
                    13,0,11,7,4,9,1,10,14,3,5,12,2,15,8,6,
                    1,4,11,13,12,3,7,14,10,15,6,8,0,5,9,2,
                    6,11,13,8,1,4,10,7,9,5,0,15,14,2,3,12,
                    13,2,8,4,6,15,11,1,10,9,3,14,5,0,12,7,
                    1,15,13,8,10,3,7,4,12,5,6,11,0,14,9,2,
                    7,11,4,1,9,12,14,2,0,6,10,13,15,3,5,8,
                    2,1,14,7,4,10,8,13,15,12,9,0,3,5,6,11 };

       static private int[] p = { 16,7,20,21,29,12,28,17,
                                   1,15,23,26,5,18,31,10,
                                   2,8,24,14,32,27,3,9,
                                   19,13,30,6,22,11,4,25};

       static private int[] _ip = { 
                    40,	8,	48,	16,	56,	24,	64,	32,
					39,	7,	47,	15,	55,	23,	63,	31,
					38,	6,	46,	14,	54,	22,	62,	30,
					37,	5,	45,	13,	53,	21,	61,	29,
					36,	4,	44,	12,	52,	20,	60,	28,
					35,	3,	43,	11,	51,	19,	59,	27,
					34,	2,	42,	10,	50,	18,	58,	26,
					33,	1,	41,	9,	49,	17,	57,	25};

       static private int[,] key;

       static public string Encryprion(byte[] asciiBytes)
        {
            //byte[] unicodeBytes = Encoding.Unicode.GetBytes(str);
            //byte[] asciiBytes = Encoding.Convert(Encoding.Unicode, Encoding.Default, unicodeBytes);
            int[] asciiInt = new int[asciiBytes.Length];
            int[] bitMass = new int[64];
            int[] t_ip = new int[64];
            int[] l0 = new int[32];
            int[] r0 = new int[32];

            
            for (int i = 0; i < asciiBytes.Length; i++)
            {
                asciiInt[i] = Convert.ToInt32(asciiBytes[i]);
            }


            List<int> list = new List<int>();
            for (int j = asciiBytes.Length - 1; j > -1; j--)
                for (int i = 0; i < 8; ++i)
                    list.Add((asciiBytes[j] >> i) & 1);

            list.Reverse();
            int t = 0;
            foreach (var item in list)
            {
                bitMass[t] = item;
                t++;
            }

            //IP
            for (int i = 0; i < ip.Length; i++)
                t_ip[i] = bitMass[ip[i] - 1];

            //L0R0
            for (int i = 0; i < t_ip.Length; i++)
            {
                if (i < 32) l0[i] = t_ip[i];
                else r0[i - 32] = t_ip[i];
            }

            int[] buff = new int[32];
            int[] ff_f = new int[32];
            int[] keys_t = new int[key.GetLength(1)];

            for (int k = 0; k < 16; k++)
            {
                r0.CopyTo(buff, 0);
                for (int i = 0; i < keys_t.Length; i++)
                    keys_t[i] = key[k, i];
                ff_f = ff(buff, keys_t);
                for (int j = 0; j < ff_f.Length; j++)
                    r0[j] = l0[j] ^ ff_f[j];
                buff.CopyTo(l0, 0);
            }

            int[] liri = new int[64];
            for (int i = 0; i < 32; i++)
            {
                liri[i + 32] = l0[i];
                liri[i] = r0[i];
            }

            int[] out_txt = new int[64];
            for (int i = 0; i < 64; i++)
                out_txt[i] = liri[_ip[i] - 1];

            string text = "";
            for (int i = 0; i < 64; i++)
                text += out_txt[i].ToString();
            byte[] ss = new byte[text.Length / 8];
            for (int i = 0; i < 64; i += 8)
                ss[i / 8] = Convert.ToByte(text.Substring(i, 8), 2);
            text = "";
            text = Encoding.Default.GetString(ss);

            return text;
        }


       static public string Decryption(byte[] textIn)
        {
            //byte[] textIn = Encoding.Default.GetBytes(str);
            int[] bitMass = new int[64];
            int[] t_ip = new int[64];
            int[] l0 = new int[32];
            int[] r0 = new int[32];

            List<int> list = new List<int>();
            for (int j = textIn.Length - 1; j > -1; j--)
                for (int i = 0; i < 8; ++i)
                    list.Add((textIn[j] >> i) & 1);
            list.Reverse();
            int t = 0;
            foreach (var item in list)
            {
                bitMass[t] = item;
                t++;
            }

            for (int i = 0; i < ip.Length; i++)
                t_ip[i] = bitMass[ip[i] - 1];

            for (int i = 0; i < t_ip.Length; i++)
            {
                if (i < 32) r0[i] = t_ip[i];
                else l0[i - 32] = t_ip[i];
            }

            int[] buff = new int[32];
            int[] ff_f = new int[32];
            int[] keys_t = new int[key.GetLength(1)];

            for (int k = 0; k < 16; k++)
            {
                l0.CopyTo(buff, 0);
                for (int i = 0; i < keys_t.Length; i++)
                    keys_t[i] = key[15 - k, i];
                ff_f = ff(buff, keys_t);
                for (int j = 0; j < ff_f.Length; j++)
                    l0[j] = r0[j] ^ ff_f[j];
                buff.CopyTo(r0, 0);
            }

            int[] liri = new int[64];
            for (int i = 0; i < 32; i++)
            {
                liri[i + 32] = r0[i];
                liri[i] = l0[i];
            }

            int[] out_txt = new int[64];
            for (int i = 0; i < 64; i++)
                out_txt[i] = liri[_ip[i] - 1];

            string text = "";
            for (int i = 0; i < 64; i++)
                text += out_txt[i].ToString();
            byte[] ss = new byte[text.Length / 8];
            for (int i = 0; i < 64; i += 8)
                ss[i / 8] = Convert.ToByte(text.Substring(i, 8), 2);
            text = "";
            text = Encoding.Default.GetString(ss);
            return text;
        }


        static private int[] ff(int[] mass, int[] key)
        {
            int[] fe = new int[e.Length];
            int[] b0 = new int[e.Length];
            int[,] b1 = new int[8, 6];
            int[] b2 = new int[8];
            String b3 = "";
            int[] b4;
            int[] bp = new int[32];

            for (int i = 0; i < e.Length; i++)
                fe[i] = mass[e[i] - 1];

            for (int i = 0; i < e.Length; i++)
                b0[i] = fe[i] ^ key[i];

            int iStr = 0, iStb = 0;
            for (int i = 0; i < e.Length; i++, iStb++)
            {
                if (iStb == 6) { iStr++; iStb = 0; }
                b1[iStr, iStb] = b0[i];
            }

            int[] lines = new int[8];
            int[] columen = new int[8];
            int t = 8;
            for (int i = 0; i < b1.GetLength(0); i++)
            {
                for (int j = 0; j < b1.GetLength(1); j++)
                {

                    if (j == 0 || j == 5) { lines[i] += b1[i, j] * ((j == 0) ? 2 : 1); }
                    else
                    {
                        columen[i] += b1[i, j] * t;
                        t = t - t / 2;
                    }
                }
                t = 8;
            }

            for (int i = 0; i < b2.GetLength(0); i++)
            {
                b2[i] = sm[16 * (4 * i + lines[i]) + columen[i]];
                b3 += Convert.ToString(b2[i], 2).PadLeft(4, '0');
            }
            b4 = b3.Select(ch => int.Parse(ch.ToString())).ToArray();

            for (int i = 0; i < bp.Length; i++)
                bp[i] = b4[p[i] - 1];

            return bp;
        }

        static public void Setkey(string str)
        {
            byte[] unicodeBytes = Encoding.Unicode.GetBytes(str);
            byte[] asciiBytes = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, unicodeBytes);
            int[] asciiInt = new int[asciiBytes.Length];
            int[] bitMass = new int[64];
            int[] bitMass2 = new int[pc.Length];
            int[] c0 = new int[pc.Length / 2];
            int[] d0 = new int[pc.Length / 2];
            int[,] c = new int[shift.Length, pc.Length / 2];
            int[,] d = new int[shift.Length, pc.Length / 2];
            int[,] cd = new int[shift.Length, pc.Length];
            int[,] kkey = new int[shift.Length, pc1.Length];


            for (int i = 0; i < asciiBytes.Length; i++)
            {
                asciiInt[i] = Convert.ToInt32(asciiBytes[i]);
            }

            List<int> list = new List<int>();
            for (int j = asciiBytes.Length - 1; j > -1; j--)
                for (int i = 0; i < 8; ++i)
                    list.Add((asciiBytes[j] >> i) & 1);
            list.Reverse();
            int t = 0;
            foreach (var item in list)
            {
                bitMass[t] = item;
                t++;
            }

            for (int i = 0; i < pc.Length; i++)
                bitMass2[i] = bitMass[pc[i] - 1];

            for (int i = 0; i < bitMass2.Length; i++)
            {
                if (i < 28) c0[i] = bitMass2[i];
                else d0[i - 28] = bitMass2[i];
            }

            for (int tt = 0; tt < shift.Length; tt++)
            {
                for (int j = 0; j < shift[tt]; ++j)
                {
                    int temp = c0[0];
                    for (int i = 0; i < c0.Length - 1; i++)
                        c0[i] = c0[i + 1];
                    c0[c0.Length - 1] = temp;
                }
                for (int r = 0; r < pc.Length / 2; r++)
                    c[tt, r] = c0[r];
            }

            for (int tt = 0; tt < shift.Length; tt++)
            {
                for (int j = 0; j < shift[tt]; ++j)
                {
                    int temp = d0[0];
                    for (int i = 0; i < d0.Length - 1; i++)
                        d0[i] = d0[i + 1];
                    d0[d0.Length - 1] = temp;
                }
                for (int r = 0; r < pc.Length / 2; r++)
                    d[tt, r] = d0[r];
            }

            for (int i = 0; i < shift.Length; i++)
                for (int j = 0; j < pc.Length; j++)
                    cd[i, j] = (j > 27) ? d[i, j - 28] : c[i, j];

            for (int i = 0; i < shift.Length; i++)
                for (int j = 0; j < pc1.Length; j++)
                    kkey[i, j] = cd[i, pc1[j] - 1];

            key = kkey;
        }
    }
}
