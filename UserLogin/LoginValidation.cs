using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    internal class LoginValidation
    {
        private string username;
        private string password;
        private string errorMessage;

        public static UserRoles currentUserRole { get; private set; }
        public static string currentUserUsername { get; private set; } = "";
        public delegate void ActionOnError(string errorMsg);
        private ActionOnError actionOnError;

        public LoginValidation(string username, string password, ActionOnError actionOnError)
        {
            this.username = username;
            this.password = password;
            this.actionOnError = actionOnError;
        }

        public bool ValidateUserInput(ref User user)
        {
            bool emptyUsername = username.Equals(String.Empty);
            if (emptyUsername == true)
            {
                errorMessage = "He e посочено потребителско име";
                currentUserRole = UserRoles.ANONYMOUS;
                this.actionOnError(errorMessage);
                return false;
            }
            else if (username.Length < 5)
            {
                errorMessage = "Потребителското име трябва да е поне 5 символа дълго";
                currentUserRole = UserRoles.ANONYMOUS;
                this.actionOnError(errorMessage);
                return false;
            }

            bool emptyPassword = password.Equals(String.Empty);
            if (emptyPassword == true)
            {
                errorMessage = "Не е посочена парола";
                currentUserRole = UserRoles.ANONYMOUS;
                this.actionOnError(errorMessage);
                return false;
            }
            else if (password.Length < 5)
            {
                errorMessage = "Паролата трябва да е поне 5 символа дълга";
                currentUserRole = UserRoles.ANONYMOUS;
                this.actionOnError(errorMessage);
                return false;
            }

            user = UserData.IsUserPassCorrect(username, password);
            if (user == null)
            {
                errorMessage = "Невалидно потребителско име или парола";
                currentUserRole = UserRoles.ANONYMOUS;
                this.actionOnError(errorMessage);
                return false;
            }

            currentUserRole = (UserRoles)user.role;
            currentUserUsername = user.username;

            Logger.LogActivity("Успешен Login");
            return true;
        }
    }
}
