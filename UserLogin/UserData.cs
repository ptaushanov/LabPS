using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static public class UserData
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
                _testUsers[0].Username = "Admin";
                _testUsers[0].Password = "admin";
                _testUsers[0].FacultyNumber = "N/A";
                _testUsers[0].Role = 1;
                _testUsers[0].Created = DateTime.Now;
                _testUsers[0].ActivUntil = DateTime.MaxValue;

                _testUsers.Add(new User());
                _testUsers[1].Username = "Student1";
                _testUsers[1].Password = "student1";
                _testUsers[1].FacultyNumber = "121219080";
                _testUsers[1].Role = 4;
                _testUsers[1].Created = DateTime.Now;
                _testUsers[1].ActivUntil = DateTime.MaxValue;

                _testUsers.Add(new User());
                _testUsers[2].Username = "Student2";
                _testUsers[2].Password = "student2";
                _testUsers[2].FacultyNumber = "121219081";
                _testUsers[2].Role = 4;
                _testUsers[2].Created = DateTime.Now;
                _testUsers[2].ActivUntil = DateTime.MaxValue;

            }
        }

        static public User IsUserPassCorrect(string username, string password)
        {
            UserContext context = new UserContext();

            User foundUser = (from currentUser in context.Users
                              where currentUser.Username == username &&
                              currentUser.Password == password
                              select currentUser).FirstOrDefault();

            return foundUser;
        }

        static public void SetUserActiveTo(string username, DateTime activeTo)
        {
            UserContext context = new UserContext();
            User currentUser = (from user in context.Users
                                where user.Username == username
                                select user)
                                .FirstOrDefault();

            if (currentUser != null)
            {
                currentUser.ActivUntil = activeTo;
                context.SaveChanges();
                Logger.LogActivity("Промяна на активност на " + username);
                return;
            }
            Console.WriteLine("Потребителят не е намерен");
        }

        static public void AssignUserRole(string username, UserRoles role)
        {
            UserContext context = new UserContext();

            User currentUser = (from u in context.Users
                                where u.Username.Equals(username)
                                select u).FirstOrDefault();

            if (currentUser != null)
            {
                currentUser.Role = Convert.ToInt32(role);
                context.SaveChanges();
                Logger.LogActivity("Промяна на роля на " + username);
                return;
            }
            Console.WriteLine("Потребителят не е намерен");
        }
    }
}
