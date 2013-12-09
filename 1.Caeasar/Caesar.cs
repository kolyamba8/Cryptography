using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.Caesar
{
    class Caesar
    {
        string alphabet;      // Алфавит, заданный пользователем

        public Caesar(string _alphabet)
        {
            alphabet = _alphabet;
        }

        public string getEncryption(string text, int position)
        {
            string cipher = "";
            for (int i = 0; i < text.Length; i++)
            {
                cipher += alphabet[(alphabet.IndexOf(text[i]) + position) % alphabet.Length].ToString();
            }
            return cipher;
        }


        public string getDecryption(string cipher, int position)
        {
            string text = "";
            for (int i = 0; i < cipher.Length; i++)
            {
                if (alphabet.IndexOf(cipher[i]) - position < 0)
                {
                    text += alphabet[alphabet.Length - 1 +
                            (alphabet.IndexOf(cipher[i]) - position + 1) % alphabet.Length];
                }
                else
                {
                    text += alphabet[(alphabet.IndexOf(cipher[i]) - position) % alphabet.Length];
                }
            }
            return text;
        }
    }
}
