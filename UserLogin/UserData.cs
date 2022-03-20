using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static internal class UserData
    {
        static private List<User> _testUsers = new List<User>();
        static public List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        static private void ResetTestUserData()
        {
            if (_testUsers != null)
            {
                _testUsers.Add(new User());
                _testUsers[0].username = "Admin";
                _testUsers[0].password = "admin";
                _testUsers[0].facultyNumber = "N/A";
                _testUsers[0].role = 1;
                _testUsers[0].Created = DateTime.Now;
                _testUsers[0].ActivUntil = DateTime.MaxValue;

                _testUsers.Add(new User());
                _testUsers[1].username = "Student1";
                _testUsers[1].password = "student1";
                _testUsers[1].facultyNumber = "121219080";
                _testUsers[1].role = 4;
                _testUsers[1].Created = DateTime.Now;
                _testUsers[1].ActivUntil = DateTime.MaxValue;

                _testUsers.Add(new User());
                _testUsers[2].username = "Student2";
                _testUsers[2].password = "student2";
                _testUsers[2].facultyNumber = "121219081";
                _testUsers[2].role = 4;
                _testUsers[2].Created = DateTime.Now;
                _testUsers[2].ActivUntil = DateTime.MaxValue;

            }
        }

        static public User IsUserPassCorrect(string username, string password)
        {
            foreach (User currentUser in TestUsers)
            {
                bool areUsanamesMatching = currentUser.username == username;
                bool arePasswordsMatching = currentUser.password == password;

                if (areUsanamesMatching && arePasswordsMatching)
                {
                    return currentUser;
                }
            }
            return null;
        }

        static public void SetUserActiveTo(string username, DateTime activeTo)
        {
            foreach (User currentUser in TestUsers)
            {
                if (currentUser.username.Equals(username))
                {
                    currentUser.ActivUntil = activeTo;
                    Logger.LogActivity("Промяна на активност на " + username);
                    return;
                }
            }
            Console.WriteLine("Потребителят не е намерен");
        }

        static public void AssignUserRole(string username, UserRoles role)
        {
            foreach (User currentUser in TestUsers)
            {
                if (currentUser.username.Equals(username))
                {
                    currentUser.role = Convert.ToInt32(role);
                    Logger.LogActivity("Промяна на роля на " + username);
                    return;
                }
            }
            Console.WriteLine("Потребителят не е намерен");
        }
    }
}
