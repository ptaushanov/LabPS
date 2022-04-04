using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseIt
{
    public class Person
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
