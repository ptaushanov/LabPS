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

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static private bool testModeOn = false;
        public MainWindow()
        {
            InitializeComponent();

            btnShowUser.Visibility = Visibility.Hidden;
            btnClear.Visibility = Visibility.Hidden;
            btnDisable.Visibility = Visibility.Hidden;
            btnEnable.Visibility = Visibility.Hidden;
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
            txtFirstName.Text = student.firstName;
            txtMiddleName.Text = student.middleName;
            txtLastName.Text = student.lastName;

            txtFaculty.Text = student.faculty;
            txtSpecialty.Text = student.specialty;
            txtQualificationLevel.Text = student.qualificationLevel;
            txtStatus.Text = student.status;
            txtFacultyNumber.Text = student.facultyNumber;

            txtCourse.Text = student.course.ToString();
            txtStream.Text = student.stream.ToString();
            txtGroup.Text = student.group.ToString();
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

        private void handeleTextModeOn(object sender, RoutedEventArgs e)
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
    }
}
