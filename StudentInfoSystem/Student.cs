using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public string Specialty { get; set; }
        public string QualificationLevel { get; set; }
        public string Status { get; set; }
        public string FacultyNumber { get; set; }
        public int Course { get; set; }
        public int Stream { get; set; }
        public int Group { get; set; }

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
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Faculty = faculty;
            Specialty = specialty;
            QualificationLevel = qualificationLevel;
            Status = status;
            FacultyNumber = facultyNumber;
            Course = course;
            Stream = stream;
            Group = group;
        }
    }
}
