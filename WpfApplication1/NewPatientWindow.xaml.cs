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
    /// Interaction logic for NewPatientWindow.xaml
    /// </summary>
    public partial class NewPatientWindow : Window
    {
        public NewPatientWindow()
        {
            InitializeComponent();
        }

        private void HomeScreen()
        {
            MainWindow Home = new MainWindow();
            Home.Show();
            Close();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            string firstName = textBoxFirstName.Text;
            string surName = textBoxSurName.Text;
            string hospitalNumber = textBoxHospitalNumber.Text;
            string trialNumber = textBoxTrialNumber.Text;
            string trial = textBoxTrial.Text;
            string randomizationArm = textBoxRandomizationArm.Text;
            string cycleLength = textBoxCycleLength.Text;
            string cycle = textBoxCycle.Text;
            string cycleOf = textBoxCycleOf.Text;
            string dueDateSelected = dueDate.SelectedDate.ToString();

            Patient newPatient = new Patient(firstName, surName, hospitalNumber, trialNumber, trial, randomizationArm, cycleLength, cycle, cycleOf, dueDateSelected);

            newPatient.SavePatient();

            HomeScreen();
        }
    }
}
