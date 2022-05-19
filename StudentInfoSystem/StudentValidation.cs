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
        public Student GetStudentDataByUser(User user)
        {
            if (String.IsNullOrEmpty(user.FacultyNumber))
            {
                Console.WriteLine("Даденият потребител няма факултетен номер");
                return null;
            }
            else
            {
                Student foundStudent = (from student in StudentData.TestStudents
                                        where student.FacultyNumber == user.FacultyNumber
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
