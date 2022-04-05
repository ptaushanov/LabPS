using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    static internal class StudentData
    {
        static public List<Student> TestStudents { get; private set; } = new List<Student>()
        {
            new Student("Ivan",
                "Todorov",
                "Petkov",
                "FKST",
                "KSI",
                "Bachelor",
                "заверил",
                "121230140",
                2, 17, 43),

            new Student("Kircho",
                "Todorov",
                "Petkov",
                "FKST",
                "KSI",
                "Bachelor",
                "заверил",
                "121219080",
                2, 17, 43),
        };

    }
}
