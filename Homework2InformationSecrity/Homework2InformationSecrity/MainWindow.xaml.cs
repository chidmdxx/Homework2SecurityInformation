using Homework2InformationSecrity.View;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Homework2InformationSecrity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            key.Focus();
        }

        private void playfairButton_Click(object sender, RoutedEventArgs e)
        {
            string keystring = string.IsNullOrEmpty(key.Text) ? string.Empty : key.Text.Replace("j", "i").ToLower();
            if (!string.IsNullOrEmpty(keystring) && keystring.Cast<char>().Distinct().Count() == keystring.Length && Regex.IsMatch(keystring, "^[a-z]+$"))
            {
                PlayfairWindow window = new PlayfairWindow(keystring);
                errordisplay.Text = string.Empty;
                window.ShowDialog();
            }
            else if (string.IsNullOrEmpty(keystring))
            {
                errordisplay.Text = "The key cannot be empty";
            }
            else if (!Regex.IsMatch(keystring, "^[a-z]+$"))
            {
                errordisplay.Text = "The key cannot be non letter alements";
            }
            else
            {
                errordisplay.Text = "The key cannot have repeated characters";
            }
        }

        private void vigenereButton_Click(object sender, RoutedEventArgs e)
        {
            string keystring = string.IsNullOrEmpty(key.Text) ? string.Empty : key.Text;
            if (!string.IsNullOrEmpty(keystring)  && Regex.IsMatch(keystring, "^[a-z]+$"))
            {
                VigenereWindow window = new VigenereWindow(keystring);
                errordisplay.Text = string.Empty;
                window.ShowDialog();
            }
            else if (!Regex.IsMatch(keystring, "^[a-z]+$"))
            {
                errordisplay.Text = "The key cannot be non letter alements";
            }
            else
            {
                errordisplay.Text = "The key cannot be empty";
            }
        }
    }
}
