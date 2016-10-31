using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ClinicalTrialsSchedulerClassLibrary;

namespace NHSApplication
{
    /// <summary>
    /// Interaction logic for NewPatientWindow.xaml
    /// </summary>
    public partial class NewPatientWindow : Window
    {
        public bool newPatient { get; set; }

        public NewPatientWindow()
        {
            newPatient = true;
            InitializeComponent();
        }

        public NewPatientWindow(Patient patient)
        {
            newPatient = false;

            InitializeComponent();

            textBoxFirstName.Text = patient.firstName;
            textBoxSurName.Text = patient.surName;
            textBoxHospitalNumber.Text = patient.hospitalNumber;
            textBoxTrialNumber.Text = patient.trialNumber;
            textBoxTrial.Text = patient.trial;
            textBoxRandomizationArm.Text = patient.randomizationArm;
            textBoxCycleLength.Text = patient.cycleLength;
            textBoxCycle.Text = patient.cycle;
            textBoxCycleOf.Text = patient.cycleOf;
            dueDate.SelectedDate = Patient.ConvertStringToDateStatic(patient.dueDate);
            textBoxDelayInDays.Text = patient.GetDelayInDays();

            radioButtonPrescripYes.IsChecked = patient.GetPrescriptionPrescriped();
            radioButtonPrescripNo.IsChecked = !patient.GetPrescriptionPrescriped();

            radioButtonDispenceYes.IsChecked = patient.GetDispenced();
            radioButtonDispenceNo.IsChecked = !patient.GetDispenced();

            radioButtonBloodYes.IsChecked = patient.GetBloodWarranty();
            radioButtonBloodNo.IsChecked = !patient.GetBloodWarranty();

            textBoxNotes.Text = patient.GetPatientNotes();
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
            DateTime dueDateSelected = (DateTime)dueDate.SelectedDate;

            Patient newPatient = new Patient(firstName, surName, hospitalNumber, trialNumber, trial, randomizationArm, cycleLength, cycle, cycleOf, dueDateSelected);

            if (this.newPatient)
            {
                newPatient.SavePatient();
            }
            else
            {
                newPatient.EditPatient(firstName, surName, hospitalNumber, trialNumber, trial, randomizationArm, cycleLength, cycle, cycleOf, dueDateSelected);
            }


            string delayInDays = textBoxDelayInDays.Text;
            bool prescriptionPrescriped = Convert.ToBoolean(radioButtonPrescripYes.IsChecked);
            bool dispenced = Convert.ToBoolean(radioButtonDispenceYes.IsChecked);
            bool bloodWarranty = Convert.ToBoolean(radioButtonBloodYes.IsChecked);
            string patientNotes = textBoxNotes.Text;

            newPatient.SaveDelayInDays(delayInDays);
            newPatient.SavePrescriptionPrescriped(prescriptionPrescriped);
            newPatient.SaveDispenced(dispenced);
            newPatient.SaveBloodWarranty(bloodWarranty);
            newPatient.SavePatientNotes(patientNotes);

            HomeScreen();
        }

        private void HomeScreenOnClick(object sender, RoutedEventArgs e)
        {
            MainWindow Home = new MainWindow();
            Home.Show();
            Close();
        }

    }
    
}
