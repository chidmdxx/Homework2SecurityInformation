using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Homework2InformationSecrity.Model;

namespace Homework2InformationSecrity.View
{
    /// <summary>
    /// Interaction logic for PlayfairWindow.xaml
    /// </summary>
    public partial class PlayfairWindow : Window
    {
        Playfair playfair;
        public PlayfairWindow(string key)
        {
            InitializeComponent();
            playfair = new Playfair(key);
        }

        private void cipherbutton_Click(object sender, RoutedEventArgs e)
        {
            string text = string.IsNullOrEmpty(textbox.Text) ? string.Empty : textbox.Text;
            string toPrint = string.Empty;
            result.Text = toPrint;
            if (!string.IsNullOrEmpty(text))
            {
                playfair.Cipher(text);
                toPrint += string.Format("The plaintext was: {0} \n", playfair.Plaintext);
                toPrint += string.Format("The cyphertext is: {0} \n", playfair.Ciphertext);
                toPrint += string.Format("Using the key: {0} \n", playfair.Key);
                toPrint += string.Format("Using the matrix:\n", playfair.Key);

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        toPrint += string.Format("| {0} |", playfair.Matrix[i, j]);
                    }
                    toPrint += string.Format("\n");

                }
                result.Text = toPrint;
            }
        }

        private void decipherbutton_Click(object sender, RoutedEventArgs e)
        {
            string text = string.IsNullOrEmpty(textbox.Text) ? string.Empty : textbox.Text;
            string toPrint = string.Empty;
            result.Text = toPrint;
            if (!string.IsNullOrEmpty(text))
            {
                playfair.Decipher(text);
                toPrint += string.Format("The cyphertext was: {0} \n", playfair.Ciphertext);
                toPrint += string.Format("The plaintext is: {0} \n", playfair.Plaintext);
                toPrint += string.Format("Using the key: {0} \n", playfair.Key);
                toPrint += string.Format("Using the matrix:\n", playfair.Key);

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        toPrint += string.Format("| {0} |", playfair.Matrix[i, j]);
                    }
                    toPrint += string.Format("\n");

                }
                result.Text = toPrint;
            }
        }
    }
}
