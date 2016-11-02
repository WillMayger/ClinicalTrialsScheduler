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
using ClinicalTrialsSchedulerClassLibrary;

namespace NHSApplication
{
    /// <summary>
    /// Interaction logic for PatientByDate.xaml
    /// </summary>
    public partial class PatientByDate : Window
    {
        public PatientByDate()
        {
            InitializeComponent();

            try
            {
                dataGrid.ItemsSource = Patient.AllPatients();
            }
            catch
            {

            }
        }

        private void grid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "firstName":
                    e.Column.Header = "First Name";
                    break;

                case "surName":
                    e.Column.Header = "Last Name";
                    break;
                case "hospitalNumber":
                    e.Column.Header = "Hospital No";
                    break;
                case "trialNumber":
                    e.Column.Header = "Trial No";
                    break;
                case "trial":
                    e.Column.Header = "Trial";
                    break;
                case "randomizationArm":
                    e.Column.Header = "Randomization Arm";
                    break;
                case "cycleLength":
                    e.Column.Header = "Cycle Length";
                    break;
                case "cycle":
                    e.Column.Header = "Cycle";
                    break;
                case "cycleOf":
                    e.Column.Header = "Cycle Of";
                    break;
                case "dueDate":
                    e.Column.Header = "Due Date";
                    break;

                default:
                    break;
            }
        }

        public void SearchPatientsOnClick(object sender, RoutedEventArgs e)
        {
            DateTime fromDateVar = fromDate.SelectedDate.Value;
            DateTime toDateVar = toDate.SelectedDate.Value;

            Patient patientObj = new Patient();
            try
            {
                dataGrid.ItemsSource = patientObj.LoadPatients(fromDateVar, toDateVar);
            }
            catch
            {

            }

            dataGrid.Items.Refresh();
        }

        private void SelectedPatientEvent(object sender, RoutedEventArgs e)
        {
            int selected = dataGrid.SelectedIndex;

            Patient selectedPatient = (Patient)dataGrid.Items[selected];

            NewPatientWindow patientWindow = new NewPatientWindow(selectedPatient);
            patientWindow.Show();
            Close();

        }

        private void HomeScreenOnClick(object sender, RoutedEventArgs e)
        {
            MainWindow Home = new MainWindow();
            Home.Show();
            Close();
        }
    }
}
