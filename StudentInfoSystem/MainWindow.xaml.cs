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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static private bool testModeOn = false;
        public List<string> StudStatusChoices { get; set; } = new List<string>();

        private void FillStudStatusChoices()
        {
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr
                FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        private bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;

            int countStudents = queryStudents.Count();
            return !(countStudents > 0);
        }

        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student student in StudentData.TestStudents)
            {
                context.Students.Add(student);
            }

            context.SaveChanges();
        }

        public MainWindow()
        {
            InitializeComponent();
            FillStudStatusChoices();
            this.DataContext = this;

            btnShowUser.Visibility = Visibility.Hidden;
            btnClear.Visibility = Visibility.Hidden;
            btnDisable.Visibility = Visibility.Hidden;
            btnEnable.Visibility = Visibility.Hidden;

            if (TestStudentsIfEmpty())
            {
                CopyTestStudents();
            }
        }

        public MainWindow(object data, bool turnOnTestMode) : this()
        {
            if (turnOnTestMode)
            {
                handeleTestModeOn();
            }
            handleFillTextBoxData(data as Student);
        }

        private void clearTextBox(object item)
        {
            if (item is TextBox)
            {
                ((TextBox)item).Text = String.Empty;
            }
        }

        private void handleTextBoxClearAll(object sender, RoutedEventArgs e)
        {
            foreach (var item in gridStudentInfo.Children)
            {
                clearTextBox(item);
            }
            foreach (var item in gridPersonalDetails.Children)
            {
                clearTextBox(item);
            }
        }

        public void handleFillTextBoxData(Student student)
        {
            txtFirstName.Text = student.FirstName;
            txtMiddleName.Text = student.MiddleName;
            txtLastName.Text = student.LastName;

            txtFaculty.Text = student.Faculty;
            txtSpecialty.Text = student.Specialty;
            txtQualificationLevel.Text = student.QualificationLevel;
            //txtStatus.Text = student.status;
            txtFacultyNumber.Text = student.FacultyNumber;

            txtCourse.Text = student.Course.ToString();
            txtStream.Text = student.Stream.ToString();
            txtGroup.Text = student.Group.ToString();
        }

        private void toggleTextBox(object item, bool isEnabled)
        {
            if (item is TextBox)
            {
                ((TextBox)item).IsEnabled = isEnabled;
            }
        }

        private void handleTextBoxDisabled(object sender, RoutedEventArgs e)
        {
            foreach (var item in gridStudentInfo.Children)
            {
                toggleTextBox(item, false);
            }

            foreach (var item in gridPersonalDetails.Children)
            {
                toggleTextBox(item, false);
            }
        }

        private void handleTextBoxEnabled(object sender, RoutedEventArgs e)
        {
            foreach (var item in gridStudentInfo.Children)
            {
                toggleTextBox(item, true);
            }

            foreach (var item in gridPersonalDetails.Children)
            {
                toggleTextBox(item, true);
            }
        }

        private void handleShowTestStudent(object sender, RoutedEventArgs e)
        {
            Student testStudent = StudentData.TestStudents.First();
            handleFillTextBoxData(testStudent);
        }

        private void handeleTestModeOn()
        {
            if (testModeOn)
            {
                btnTestMode.Visibility = Visibility.Hidden;
                btnShowUser.Visibility = Visibility.Hidden;
                btnClear.Visibility = Visibility.Hidden;
                btnDisable.Visibility = Visibility.Hidden;
                btnEnable.Visibility = Visibility.Hidden;
                return;
            }

            testModeOn = true;
            btnTestMode.Content = "Излез от тестов режим";

            btnShowUser.Visibility = Visibility.Visible;
            btnClear.Visibility = Visibility.Visible;
            btnDisable.Visibility = Visibility.Visible;
            btnEnable.Visibility = Visibility.Visible;

        }

        private void handeleTestModeOn(object sender, RoutedEventArgs e)
        {
            handeleTestModeOn();
        }

    }
}
