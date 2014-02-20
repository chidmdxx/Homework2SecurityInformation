﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2InformationSecrity.Model
{
    class Vigenere
    {
        private string key;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string plaintext;

        public string Plaintext
        {
            get { return plaintext; }
            set { plaintext = value; }
        }
        private string ciphertext;

        public string Ciphertext
        {
            get { return ciphertext; }
            set { ciphertext = value; }
        }

        public Vigenere(string key)
        {
            Key = key;
            Plaintext = string.Empty;
            Ciphertext = string.Empty;
        }

        public string Cipher(string plaintext)
        {
            Plaintext = plaintext;
            Ciphertext = string.Empty;
            byte[] plainBytes = Encoding.ASCII.GetBytes(Plaintext);
            byte[] keyBytes = Encoding.ASCII.GetBytes(Key);
            int keyLenght = keyBytes.Length;
            int count = 0;
            foreach (var letter in plainBytes)
            {
                int ascii = letter;
                int k;
                if (ascii >= 97 && ascii <= 122 )
                {
                    k = keyBytes[count++ % keyLenght];
                    k -= 97;
                    ascii -= 97;
                    ascii += k;
                    ascii %= 26;
                    ascii += 97;
                }
                Ciphertext = Ciphertext + (char)ascii;              
            }
            return Ciphertext;
        }

        public string Decipher(string ciphertext)
        {
            Ciphertext = ciphertext;
            Plaintext = string.Empty;
            byte[] cipherBytes = Encoding.ASCII.GetBytes(Ciphertext);
            byte[] keyBytes = Encoding.ASCII.GetBytes(Key);
            int keyLenght = keyBytes.Length;
            int count = 0;
            foreach (var letter in cipherBytes)
            {
                int ascii = letter;
                int k;
                if (ascii >= 97 && ascii <= 122)
                {
                    k = keyBytes[count++ % keyLenght];
                    k -= 97;
                    ascii -= 97;
                    ascii += 26;
                    ascii -= k;
                    ascii %= 26;
                    ascii += 97;
                }
                Plaintext = Plaintext + (char)ascii;
            }
            return Plaintext;
        }
    }
}