using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using MinimalMVVM.ViewModel;

namespace MinimalMVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _mode = "upper";
        private Presenter _presenter = new Presenter();
        private Presenter2 _presenter2 = new Presenter2();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _presenter;
        }

        private void handleSwitchMode(object sender, RoutedEventArgs e)
        {
            if (_mode == "upper")
            {
                DataContext = _presenter2;
                _mode = "lower";
            }
            else if (_mode == "lower")
            {
                DataContext = _presenter;
                _mode = "upper";

            }
        }
    }
}
