using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    internal class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string facultyNumber { get; set; }
        public int role { get; set; }

        public DateTime Created { get; set; }
        public DateTime ActivUntil { get; set; }
    }
}
