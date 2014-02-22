using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2InformationSecrity.Model
{
    class Playfair
    {
        private string key;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private char[,] matrix;
        public char[,] Matrix
        {
            get { return matrix; }
            set { matrix = value; }
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

        private List<Digram> digrams;

        public List<Digram> Digrams
        {
            get { return digrams; }
            set { digrams = value; }
        }

        private char extraChar;
        public char ExtraChar
        {
            get { return extraChar; }
            set { extraChar = value; }
        }

        public Playfair(string key, char extraChar = 'x')
        {
            Plaintext = string.Empty;
            Ciphertext = string.Empty;
            Key = key;
            ExtraChar = extraChar;
            CreateMatrix();
        }

        private void CreateMatrix()
        {
            Matrix = new char[5, 5];
            string letters = "abcdefghiklmnopqrstuvwxyz";
            int count = 0;
            int col;
            int row;
            foreach (char letter in Key)
            {
                col = count % 5;
                row = count / 5;
                letters = letters.Replace(letter, '-'); //esto es una limitacion del replace(char,char) ya que no deja poner vacio en el segundo char
                Matrix[row, col] = letter;
                count++;
            }
            letters = letters.Replace("-", ""); //arregla la limitacion cambiando a vacio
            foreach (char letter in letters)
            {
                col = count % 5;
                row = count / 5;
                Matrix[row, col] = letter;
                count++;
            }
        }

        public string Cipher(string plaintext)
        {
            Plaintext = plaintext.Replace('j', 'i');
            foreach (var letter in Plaintext)
            {
                int ascii = letter;
                if (ascii < 97 || ascii > 122)
                {
                    Plaintext = Plaintext.Replace(letter, '-');
                }
            }
            Plaintext = Plaintext.Replace("-", "");
            Ciphertext = string.Empty;
            doDigrams(Plaintext);

            Cordinate firstCordinate;
            Cordinate secondCordinate;
            char firstChar;
            char secondChar;
            foreach (var pair in Digrams)
            {
                firstCordinate = getCordinate(pair.First);
                secondCordinate = getCordinate(pair.Second);
                if (firstCordinate.Row == secondCordinate.Row)
                {
                    firstChar = Matrix[firstCordinate.Row, (firstCordinate.Column + 1) % 5];
                    secondChar = Matrix[secondCordinate.Row, (secondCordinate.Column + 1) % 5];
                }
                else if (firstCordinate.Column == secondCordinate.Column)
                {
                    firstChar = Matrix[(firstCordinate.Row + 1) % 5, firstCordinate.Column];
                    secondChar = Matrix[(secondCordinate.Row + 1) % 5, secondCordinate.Column];
                }
                else
                {
                    firstChar = Matrix[firstCordinate.Row, secondCordinate.Column];
                    secondChar = Matrix[secondCordinate.Row, firstCordinate.Column];
                }
                Ciphertext += string.Format("{0}{1}", firstChar, secondChar);
            }

            return Ciphertext;
        }

        public string Decipher(string ciphertext)
        {
            Ciphertext = ciphertext;
            Ciphertext = ciphertext.Replace('j', 'i');
            foreach (var letter in Ciphertext)
            {
                int ascii = letter;
                if (ascii < 97 || ascii > 122)
                {
                    Ciphertext = Ciphertext.Replace(letter, '-');
                }
            }
            Ciphertext = Ciphertext.Replace("-", "");

            Plaintext = string.Empty;
            doDigrams(Ciphertext);

            Cordinate firstCordinate;
            Cordinate secondCordinate;
            char firstChar;
            char secondChar;
            foreach (var pair in Digrams)
            {
                firstCordinate = getCordinate(pair.First);
                secondCordinate = getCordinate(pair.Second);
                if (firstCordinate.Row == secondCordinate.Row)
                {
                    firstChar = Matrix[firstCordinate.Row, (firstCordinate.Column + 5 - 1) % 5];
                    secondChar = Matrix[secondCordinate.Row, (secondCordinate.Column + 5 - 1) % 5];
                }
                else if (firstCordinate.Column == secondCordinate.Column)
                {
                    firstChar = Matrix[(firstCordinate.Row + 5 - 1) % 5, firstCordinate.Column];
                    secondChar = Matrix[(secondCordinate.Row + 5 - 1) % 5, secondCordinate.Column];
                }
                else
                {
                    firstChar = Matrix[firstCordinate.Row, secondCordinate.Column];
                    secondChar = Matrix[secondCordinate.Row, firstCordinate.Column];
                }
                Plaintext += string.Format("{0}{1}", firstChar, secondChar);
            }

            return Plaintext;
        }

        private void doDigrams(string work)
        {
            Digrams = new List<Digram>();
            char first;
            Digram temp;
            for (int i = 0; i < work.Length; i++)
            {
                temp = new Digram();
                first = work[i];
                if (i == work.Length - 1 || first.Equals(work[i + 1]))
                {
                    temp.First = first;
                    temp.Second = ExtraChar;
                }
                else
                {
                    temp.First = first;
                    temp.Second = work[++i];
                }
                Digrams.Add(temp);
            }
        }

        private Cordinate getCordinate(char c)
        {
            Cordinate toReturn = new Cordinate();
            for (int i = 0; i < 25; i++)
            {
                int col = i % 5;
                int row = i / 5;
                if (Matrix[row, col].Equals(c))
                {
                    toReturn.Row = row;
                    toReturn.Column = col;
                    break;
                }
            }
            return toReturn;
        }
    }

    class Cordinate
    {
        private int row;
        private int col;
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        public int Column
        {
            get { return col; }
            set { col = value; }
        }
        public Cordinate(int col, int row)
        {
            Column = col;
            Row = row;
        }
        public Cordinate()
        {

        }
    }

    class Digram
    {
        private char first;
        private char second;
        public char First
        {
            get { return first; }
            set { first = value; }
        }
        public char Second
        {
            get { return second; }
            set { second = value; }
        }
        public Digram(char first, char second = 'x')
        {
            First = first;
            Second = second;
        }
        public Digram()
        {

        }
    }
}
