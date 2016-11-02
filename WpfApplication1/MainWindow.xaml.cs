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
using ClinicalTrialsSchedulerClassLibrary;
using NHSApplication;

namespace NHSApplication
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

        private void AddNewPatientWindow(object sender, RoutedEventArgs e)
        {
            NewPatientWindow NewPatient = new NewPatientWindow();
            NewPatient.Show();
            Close();
        }

        private void PatientListWindow(object sender, RoutedEventArgs e)
        {
            PatientList patientList = new PatientList();
            patientList.Show();
            Close();
        }

        private void PatientByDueDateWindow(object sender, RoutedEventArgs e)
        {
            PatientByDate patientByDate = new PatientByDate();
            patientByDate.Show();
            Close();
        }

        private void EditUsersWindow(object sender, RoutedEventArgs e)
        {
            UserAccounts userAccounts = new UserAccounts();
            userAccounts.Show();
            Close();
        }

    }

}
