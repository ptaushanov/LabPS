using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class Log
    {
        public int LogId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public UserRoles Role { get; set; }
        public string Activity { get; set; }

        public Log(DateTime createdOn, string createdBy, UserRoles role, string activity)
        {
            CreatedOn = createdOn;
            CreatedBy = createdBy;
            Role = role;
            Activity = activity;
        }
    }
}
