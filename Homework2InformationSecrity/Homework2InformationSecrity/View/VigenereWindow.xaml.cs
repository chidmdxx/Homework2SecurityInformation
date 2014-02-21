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
    /// Interaction logic for VigenereWindow.xaml
    /// </summary>
    public partial class VigenereWindow : Window
    {
        Vigenere vignere;
        public VigenereWindow(string key)
        {
            InitializeComponent();
            textbox.Focus();
            vignere = new Vigenere(key);
        }

        private void cipherbutton_Click(object sender, RoutedEventArgs e)
        {
            string text = string.IsNullOrEmpty(textbox.Text) ? string.Empty : textbox.Text;
            string toPrint=string.Empty;
            result.Text = toPrint;
            if (!string.IsNullOrEmpty(text))
            {
                vignere.Cipher(text);
                toPrint += string.Format("The plaintext was: {0} \n", vignere.Plaintext);
                toPrint += string.Format("The cyphertext is: {0} \n", vignere.Ciphertext);
                toPrint += string.Format("Using the key: {0} \n", vignere.Key);
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
                vignere.Cipher(text);
                toPrint += string.Format("The cyphertext was: {0} \n", vignere.Ciphertext);
                toPrint += string.Format("The plaintext is: {0} \n", vignere.Plaintext);
                toPrint += string.Format("Using the key: {0} \n", vignere.Key);
                result.Text = toPrint;
            }
        }
    }
}
