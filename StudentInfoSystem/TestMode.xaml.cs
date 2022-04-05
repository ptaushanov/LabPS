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

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for TestMode.xaml
    /// </summary>
    public partial class TestMode : Window
    {
        public TestMode()
        {
            InitializeComponent();
        }

        private void handleEnterTestMode(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(StudentData.TestStudents.FirstOrDefault(), true);
            mainWindow.Show();
            this.Close();
        }

        private void handleGoToLogin(object sender, RoutedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
