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
        }

        private void playfairButton_Click(object sender, RoutedEventArgs e)
        {
            string keystring = string.IsNullOrEmpty(key.Text) ? string.Empty : key.Text;
            if (!string.IsNullOrEmpty(keystring))
            {
                PlayfairWindow window = new PlayfairWindow(keystring);
                window.ShowDialog();
            }
        }

        private void vigenereButton_Click(object sender, RoutedEventArgs e)
        {
            string keystring=string.IsNullOrEmpty(key.Text)?string.Empty:key.Text;
            if (!string.IsNullOrEmpty(keystring))
            {
                VigenereWindow window = new VigenereWindow(keystring);
                window.ShowDialog();
            }
        }
    }
}
