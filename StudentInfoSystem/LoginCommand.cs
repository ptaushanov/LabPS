using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserLogin;
using System.Windows;


namespace StudentInfoSystem
{
    public class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LoginVM loginVM = parameter as LoginVM;

            MessageBox.Show(loginVM.Username + loginVM.Password);

            LoginValidation loginValidation = new LoginValidation(loginVM.Username, loginVM.Password, Console.WriteLine);
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
                //this.Close();
            }
            else
            {
                MessageBox.Show("Грешно потребителско име или парола!", "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
