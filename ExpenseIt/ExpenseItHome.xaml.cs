using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExpenseIt
{
    public partial class ExpenseItHome : Window
    {
        public string MainCaptionText { get; set; }
        public List<Person> ExpenseDataSource { get; set; }
        public DateTime LastChecked { get; set; }

        public ExpenseItHome()
        {
            InitializeComponent();
            this.DataContext = this;

            MainCaptionText = "View Expense Report :";

            ExpenseDataSource = new List<Person>(){
                new Person(){ Name = "Mike", Department ="Legal", Expenses = new List<Expense>(){
                    new Expense() { ExpenseType="Lunch", ExpenseAmount =50 },
                    new Expense() { ExpenseType="Transportation", ExpenseAmount=50 }
                }},
                new Person(){ Name = "Lisa", Department ="Marketing", Expenses = new List<Expense>(){
                    new Expense() { ExpenseType="Document printing", ExpenseAmount=50 },
                    new Expense() { ExpenseType="Gift", ExpenseAmount=125 }
                }},
                new Person(){ Name = "John", Department ="Engineering", Expenses = new List<Expense>(){
                    new Expense() { ExpenseType="Magazine subscription", ExpenseAmount=50 },
                    new Expense() { ExpenseType="New machine", ExpenseAmount=600 },
                    new Expense() { ExpenseType="Software", ExpenseAmount=500 }
                }},
                new Person(){ Name = "Mary", Department ="Finance", Expenses = new List<Expense>(){
                    new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                }},
                new Person(){ Name = "Theo", Department ="Marketing", Expenses = new List<Expense>(){
                    new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                }},
                new Person(){ Name = "David", Department ="Sales", Expenses = new List<Expense>(){
                    new Expense() { ExpenseType="Car repair", ExpenseAmount=400 }
                }},
                new Person(){ Name = "James", Department ="Legal", Expenses = new List<Expense>(){
                    new Expense() { ExpenseType="New costume", ExpenseAmount=1500 }
                }},
            };

            LastChecked = DateTime.Now;

        }

        private void handleViewReport(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = peopleListBox.SelectedItem as Person;

            ExpenseReport expenseReport = new ExpenseReport(selectedPerson);
            expenseReport.Width = this.Width;
            expenseReport.Height = this.Height;

            expenseReport.Show();
            this.Close();
        }
    }
}
