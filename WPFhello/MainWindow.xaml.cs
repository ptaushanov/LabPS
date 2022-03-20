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

namespace WPFhello
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

        private void handleBtnClick(object sender, RoutedEventArgs e)
        {
            string inputMessage = "";

            foreach (var item in myGrid.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    string name = textBox.Text;

                    inputMessage += name;
                    inputMessage += " ";
                }
            }

            MessageBox.Show("Здрасти " + inputMessage);
        }

        private void handleFactoralCalculation(object sender, KeyEventArgs e)
        {
            int input;
            int.TryParse(txtFactorial.Text, out input);

            int result = input;
            for (int i = input - 1; i > 0; i--)
            {
                result *= i;
            }

            lblFactorial.Content = result.ToString();
        }

        private void handlePowerCalculation(object sender, KeyEventArgs e)
        {
            // X^Y
            int x = 0, y = 0;

            int.TryParse(txtX.Text, out x);
            int.TryParse(txtY.Text, out y);

            lblPow.Content = Math.Pow(x, y).ToString();
        }
    }
}
