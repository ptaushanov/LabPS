﻿using System;
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
            ListBoxItem james = new ListBoxItem();
            ListBoxItem david = new ListBoxItem();

            james.Content = "James";
            david.Content = "David";

            peopleListBox.Items.Add(james);
            peopleListBox.Items.Add(david);

            peopleListBox.SelectedItem = james;
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


        private void handleShowName(object sender, RoutedEventArgs e)
        {
            string greeting = (peopleListBox.SelectedValue as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi " + greeting);

            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();
        }
    }
}
