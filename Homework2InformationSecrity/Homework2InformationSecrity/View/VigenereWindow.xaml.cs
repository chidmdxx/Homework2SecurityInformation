using Homework2InformationSecrity.Model;
using System.Windows;

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
                toPrint += string.Format("Work:\n {0}", vignere.Work);
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
                vignere.Decipher(text);
                toPrint += string.Format("The cyphertext was: {0} \n", vignere.Ciphertext);
                toPrint += string.Format("The plaintext is: {0} \n", vignere.Plaintext);
                toPrint += string.Format("Using the key: {0} \n", vignere.Key);
                toPrint += string.Format("Work:\n {0}", vignere.Work);
                result.Text = toPrint;
            }
        }
    }
}
