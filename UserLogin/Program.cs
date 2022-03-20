using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            LoginValidation loginValidation = new LoginValidation(username, password, PrintErrorMessage);

            User user = null;

            if (loginValidation.ValidateUserInput(ref user))
            {
                Console.WriteLine(user.username);
                Console.WriteLine(user.password);
                Console.WriteLine(user.facultyNumber);
                Console.WriteLine((UserRoles)user.role);
                Console.WriteLine(user.Created.ToString());
                Console.WriteLine(user.ActivUntil.ToString());

                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("Ролята е \"анонимен\"");
                        break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("Ролята е \"админ\"");
                        DisplayAdminMenu();
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("Ролята е \"инспектор\"");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("Ролята е \"професор\"");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("Ролята е \"студент\"");
                        break;
                    default:
                        Console.WriteLine("Ролята е невалидна");
                        break;
                }
            }
        }

        static private void PrintErrorMessage(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }

        static private void OnLogRemoved(string removedLog)
        {
            Console.WriteLine("Премахнат лог: " + removedLog);
        }

        static private void DisplayAdminMenu()
        {
            Console.WriteLine("Изберете опция: ");
            Console.WriteLine("0: Изход");
            Console.WriteLine("1: Промяна на роля на потребител");
            Console.WriteLine("2: Промяна на активност на потребител");
            Console.WriteLine("3: Списък на потребители");
            Console.WriteLine("4: Преглед на лог на активностите");
            Console.WriteLine("5: Преглед на текуща активностите");
            Console.WriteLine("6: Премахване на стари лог файлове");

            Console.Write("Вашият избор: ");
            int choice;
            Int32.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 0:
                    return;
                case 1:
                    Console.WriteLine("Въведете потребителско име: ");
                    string usernameForCase1 = Console.ReadLine();
                    Console.WriteLine("Въведете номер на роля: ");

                    foreach (int i in Enum.GetValues(typeof(UserRoles)))
                    {
                        Console.WriteLine(i + ": " + (UserRoles)i);
                    }

                    UserRoles newRole = (UserRoles)Int32.Parse(Console.ReadLine());
                    UserData.AssignUserRole(usernameForCase1, newRole);
                    break;
                case 2:
                    Console.WriteLine("Въведете потребителско име: ");
                    string usernameForCase2 = Console.ReadLine();
                    Console.WriteLine("Въведете нова дата за активност: ");

                    DateTime newDateTime = DateTime.Parse(Console.ReadLine());
                    UserData.SetUserActiveTo(usernameForCase2, newDateTime);
                    break;

                case 3:
                    // TODO 
                    break;

                case 4:
                    IEnumerable<string> activities = Logger.ShowLogFileActivities();
                    activities.ToList().ForEach(activity => Console.WriteLine(activity));
                    break;

                case 5:
                    Console.Write("Филтър: ");
                    string filter = Console.ReadLine();
                    IEnumerable<string> currentSessionActivities = Logger.GetCurrentSessionActivities(filter);
                    StringBuilder stringBuilder = new StringBuilder();

                    foreach (string activityLine in currentSessionActivities)
                    {
                        stringBuilder.Append(activityLine);
                    }

                    Console.WriteLine(stringBuilder.ToString());
                    break;

                case 6:
                    Logger.RemoveOldLogs(DateTime.Today, OnLogRemoved);
                    break;

                default:
                    Console.WriteLine("Невалиден избор!");
                    break;
            }
        }
    }
}
