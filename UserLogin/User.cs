using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public int? UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FacultyNumber { get; set; }
        public int? Role { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? ActivUntil { get; set; }
    }
}
