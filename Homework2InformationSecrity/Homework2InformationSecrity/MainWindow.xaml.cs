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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Homework2InformationSecrity.View;

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
            string keystring = string.IsNullOrEmpty(key.Text) ? string.Empty : key.Text.Replace("j","i");
            if (!string.IsNullOrEmpty(keystring) && keystring.Cast<char>().Distinct().Count() == keystring.Length)
            {
                PlayfairWindow window = new PlayfairWindow(keystring);
                errordisplay.Text = string.Empty;
                window.ShowDialog();
            }
            else if (string.IsNullOrEmpty(keystring))
            {
                errordisplay.Text = "The key cannot be empty";
            }
            else
            {
                errordisplay.Text = "The key cannot have repeated characters";
            }
        }

        private void vigenereButton_Click(object sender, RoutedEventArgs e)
        {
            string keystring = string.IsNullOrEmpty(key.Text) ? string.Empty : key.Text;
            if (!string.IsNullOrEmpty(keystring))
            {
                VigenereWindow window = new VigenereWindow(keystring);
                errordisplay.Text = string.Empty;
                window.ShowDialog();
            }
            else
            {
                errordisplay.Text = "The key cannot be empty";
            }
        }
    }
}
