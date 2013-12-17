using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Viginer
{
    class Viginer
    {
        string alphabet;      // Алфавит, заданный пользователем
        string key;

        public Viginer(string _alphabet)
        {
            alphabet = _alphabet;
        }

        public string getEncryption(string Clear, string FirstKey)
        {
            string cipher = "";
            key = GetKey(FirstKey, Clear.Length);

            for (int i = 0; i < Clear.Length; i++)
                cipher += alphabet[(alphabet.IndexOf(Clear[i]) + alphabet.IndexOf(key[i])) % alphabet.Length];
            

            return cipher;
        }


        public string getDecryption(string cipher, string FirstKey)
        {

            string text = "";
            key = GetKey(FirstKey, cipher.Length);
            for (int i = 0; i < cipher.Length; i++)
            {
                text += alphabet[(alphabet.IndexOf(cipher[i]) - alphabet.IndexOf(key[i]) + alphabet.Length) % alphabet.Length];
            }
            return text;
        }

        string GetKey(string Word, int ClearLength)
        {
            string Key = Word, Temp_key = Key;
            if (Key.Length == 0) throw new Exception("Ключ должен иметь длину больше 0!");
            if (ClearLength >= Key.Length)
            {
                int k = ClearLength / Key.Length;
                int r = ClearLength - (Key.Length * k);

                for (int i = 0; i < k - 1; i++)
                    Key += Temp_key;

                for (int i = 0; i < r; i++)
                    Key += Temp_key[i];
            }
            return Key;
        }
    }
}
