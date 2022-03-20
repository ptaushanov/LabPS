using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UserLogin;

namespace StudentInfoSystem
{
    internal class StudentValidation
    {
        Student GetStudentDataByUser(User user)
        {
            if (String.IsNullOrEmpty(user.facultyNumber))
            {
                Console.WriteLine("Даденият потребител няма факултетен номер");
                return null;
            }
            else
            {
                Student foundStudent = (from student in StudentData.TestStudents
                                        where student.facultyNumber == user.facultyNumber
                                        select student).FirstOrDefault();

                if (foundStudent == null)
                {
                    Console.WriteLine("Няма намерен потребител по дадения факултетен номер");
                }

                return foundStudent;
            }
        }
    }
}
