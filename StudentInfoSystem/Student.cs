using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal class Student
    {
        public string firstName;
        public string middleName;
        public string lastName;
        public string faculty;
        public string specialty;
        public string qualificationLevel;
        public string status;
        public string facultyNumber;
        public int course;
        public int stream;
        public int group;

        public Student()
        {
        }

        public Student(
            string firstName,
            string middleName,
            string lastName,
            string faculty,
            string specialty,
            string qualificationLevel,
            string status,
            string facultyNumber,
            int course,
            int stream,
            int group
            )
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.faculty = faculty;
            this.specialty = specialty;
            this.qualificationLevel = qualificationLevel;
            this.status = status;
            this.facultyNumber = facultyNumber;
            this.course = course;
            this.stream = stream;
            this.group = group;
        }
    }
}
