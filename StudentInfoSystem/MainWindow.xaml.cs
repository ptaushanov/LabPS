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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void handleTextBoxClearAll(object sender, RoutedEventArgs e)
        {
            foreach (var item in mainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = String.Empty;
                }
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

        private void handleTextBoxDisabled(object sender, RoutedEventArgs e)
        {
            foreach (var item in mainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }
            }
        }

        private void handleTextBoxEnabled(object sender, RoutedEventArgs e)
        {
            foreach (var item in mainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
                }
            }
        }

        private void handleShowTestStudent(object sender, RoutedEventArgs e)
        {
            Student testStudent = StudentData.TestStudents.First();
            handleFillTextBoxData(testStudent);
        }

    }
}
