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
    /// Interaction logic for SelectedPatient.xaml
    /// </summary>
    public partial class SelectedPatient : Window
    {

        public Patient patient { get; set; }

        public SelectedPatient(Patient patient)
        {
            this.patient = patient;

            InitializeComponent();

            patientName.Text = patient.firstName + " " + patient.surName;

            textBoxNotes.Text = patient.GetPatientNotes();
        }

        public void editPatientOnClick(object sender, RoutedEventArgs e)
        {

        }

        public void exitOnClick(object sender, RoutedEventArgs e)
        {

        }

        public void OnSave(object sender, RoutedEventArgs e)
        {

            bool saved = patient.SavePatientNotes(textBoxNotes.Text.ToString());

            if (saved)
            {
                MessageBox.Show("The notes for " + patient.firstName + " " + patient.surName + " have been saved succesfully!", "Saved!");
            } else
            {
                MessageBox.Show("Something went wrong", "Error");
            }

        }

    }

}
