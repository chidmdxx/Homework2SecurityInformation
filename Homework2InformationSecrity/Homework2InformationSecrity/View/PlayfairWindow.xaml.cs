using Homework2InformationSecrity.Model;
using System.Windows;

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
            textbox.Focus();
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
                toPrint += string.Format("Using the matrix:\n");

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        toPrint += string.Format("| {0} |", playfair.Matrix[i, j]);
                    }
                    toPrint += string.Format("\n");

                }
                toPrint += string.Format("Using the following digrams \n");
                foreach (var d in playfair.Digrams){
                    toPrint += string.Format("{0} and {1} \n", d.First,d.Second);
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
                toPrint += string.Format("Using the following digrams \n");
                foreach (var d in playfair.Digrams)
                {
                    toPrint += string.Format("{0} and {1} \n", d.First, d.Second);
                }


                result.Text = toPrint;
            }
        }
    }
}
