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
using UserLogin;


namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void handleGoToLogin(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordPasswordBox.Password;

            LoginValidation loginValidation = new LoginValidation(username, password, Console.WriteLine);
            User user = new User();

            if (loginValidation.ValidateUserInput(ref user))
            {
                StudentValidation studentValidation = new StudentValidation();
                Student student = studentValidation.GetStudentDataByUser(user);

                if (student == null)
                {
                    MessageBox.Show("Няма такъв студент!", "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MainWindow mainWindow = new MainWindow(student, false);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Грешно потребителско име или парола!", "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
