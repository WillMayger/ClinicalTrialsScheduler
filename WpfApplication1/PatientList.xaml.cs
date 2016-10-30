using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PatientList.xaml
    /// </summary>
    public partial class PatientList : Window
    {
        public PatientList()
        {
            InitializeComponent();

            dataGrid.ItemsSource = Patient.AllPatients();

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

        private void PatientSearchOnClick(object sender, RoutedEventArgs e)
        {
            string firstName = textBoxPatientFirstName.Text.ToString();
            string lastName = textBoxPatientLastName.Text.ToString();

            Patient patientObj = new Patient();

            dataGrid.ItemsSource = patientObj.LoadPatients(firstName, lastName);

            dataGrid.Items.Refresh();

        }

        private void TrialSearchOnClick(object sender, RoutedEventArgs e)
        {
            string trial = textBoxTrials.Text.ToString();

            Patient patientObj = new Patient();

            dataGrid.ItemsSource = patientObj.LoadPatients(trial);

            dataGrid.Items.Refresh();

        }

        private void SelectedPatientEvent(object sender, RoutedEventArgs e)
        {
            int selected = dataGrid.SelectedIndex;

            Patient selectedPatient = (Patient)dataGrid.Items[selected];

            SelectedPatient selectedPatientWin = new SelectedPatient(selectedPatient);

            selectedPatientWin.Show();

        }

        private void HomeScreen()
        {
            MainWindow Home = new MainWindow();
            Home.Show();
            Close();
        }


    }

}
