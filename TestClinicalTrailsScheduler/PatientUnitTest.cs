using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClinicalTrialsSchedulerClassLibrary;

namespace TestClinicalTrailsScheduler
{
    /// <summary>
    /// Summary description for PatientUnitTest
    /// </summary>
    [TestClass]
    public class PatientUnitTest
    {
        private string fileLocation = @"C:\Users\Will\Documents\NHS\NHSApplication\WpfApplication1\patient.xml";

        #region write

        [TestMethod]
        public void FileExists()
        {
            Assert.IsTrue(File.Exists(fileLocation));
        }

        [TestMethod]
        public void WritesToFile()
        {
            string firstName = "will";
            string surName = "Mayger";
            string hospitalNumber = "00";
            string trialNumber = "00";
            string trial = "00";
            string randomizationArm = "00";
            string cycleLength = "00";
            string cycle = "00";
            string cycleOf = "00";
            DateTime dueDate = Patient.ConvertStringToDateStatic("01/01/1970 00:00:00");
            Patient patient = new Patient(firstName, surName, hospitalNumber, trialNumber, trial, randomizationArm, cycleLength, cycle, cycleOf, dueDate);

            patient.SavePatient();

            Patient loadPatient = new Patient();

            List<Patient> patientsList = loadPatient.LoadPatients(firstName, surName);

            Patient loadedPatient = patientsList[0];

            Assert.AreEqual(loadedPatient.firstName, firstName);
            Assert.AreEqual(loadedPatient.surName, surName);
            Assert.AreEqual(loadedPatient.hospitalNumber, hospitalNumber);
            Assert.AreEqual(loadedPatient.cycleLength, cycleLength);
            Assert.AreEqual(loadedPatient.trialNumber, trialNumber);
            Assert.AreEqual(loadedPatient.dueDate, dueDate);
        }

        [TestMethod]
        public void DeletesPatient()
        {
            string firstName = "ToBe";
            string surName = "Deleted";
            string hospitalNumber = "00";
            string trialNumber = "00";
            string trial = "00";
            string randomizationArm = "00";
            string cycleLength = "00";
            string cycle = "00";
            string cycleOf = "00";
            DateTime dueDate = Patient.ConvertStringToDateStatic("01/01/1970 00:00:00");

            Patient patient = new Patient(firstName, surName, hospitalNumber, trialNumber, trial, randomizationArm, cycleLength, cycle, cycleOf, dueDate);

            patient.SavePatient();

            bool deleted = patient.DeletePatient(firstName, surName, trialNumber);

            Assert.AreEqual(deleted, true);

        }

        [TestMethod]
        public void DosentDeletePatient()
        {
            string firstName = "ToBeNot";
            string surName = "Deleted";
            string hospitalNumber = "00";
            string trialNumber = "00";
            string trial = "00";
            string randomizationArm = "00";
            string cycleLength = "00";
            string cycle = "00";
            string cycleOf = "00";
            DateTime dueDate = Patient.ConvertStringToDateStatic("01/01/1970 00:00:00");

            Patient patient = new Patient(firstName, surName, hospitalNumber, trialNumber, trial, randomizationArm, cycleLength, cycle, cycleOf, dueDate);

            patient.SavePatient();
            firstName = "hi";

            bool deleted = patient.DeletePatient(firstName, surName, trialNumber);

            Assert.AreEqual(deleted, false);

        }

        [TestMethod]
        public void EditingPatient()
        {
            string firstName = "ToBe";
            string surName = "Edited";
            string hospitalNumber = "00";
            string trialNumber = "00";
            string trial = "00";
            string randomizationArm = "00";
            string cycleLength = "00";
            string cycle = "00";
            string cycleOf = "00";
            DateTime dueDate = Patient.ConvertStringToDateStatic("01/01/1970 00:00:00");

            Patient patient = new Patient(firstName, surName, hospitalNumber, trialNumber, trial, randomizationArm, cycleLength, cycle, cycleOf, dueDate);

            patient.SavePatient();

            Patient loadPatient = new Patient();

            List<Patient> patientsList = loadPatient.LoadPatients(firstName, surName);

            Patient loadedPatient = patientsList[0];

            Assert.AreEqual(loadedPatient.firstName, firstName);
            Assert.AreEqual(loadedPatient.surName, surName);
            Assert.AreEqual(loadedPatient.hospitalNumber, hospitalNumber);
            Assert.AreEqual(loadedPatient.cycleLength, cycleLength);
            Assert.AreEqual(loadedPatient.trialNumber, trialNumber);
            Assert.AreEqual(loadedPatient.dueDate, dueDate);

            string firstNameNew = "HasBeenEdited";
            string randomizationArmNew = "01";

            bool edited = patient.EditPatient(firstNameNew, surName, hospitalNumber, trialNumber, trial, randomizationArmNew, cycleLength, cycle, cycleOf, dueDate);

            Patient loadPatientEdited = new Patient();

            List<Patient> patientsListEdited = loadPatient.LoadPatients(firstName, surName);

            Patient loadedPatientEdited = patientsList[0];

            Assert.AreEqual(loadedPatientEdited.firstName, firstName);
            Assert.AreEqual(loadedPatientEdited.surName, surName);
            Assert.AreEqual(loadedPatientEdited.hospitalNumber, hospitalNumber);
            Assert.AreEqual(loadedPatientEdited.cycleLength, cycleLength);
            Assert.AreEqual(loadedPatientEdited.trialNumber, trialNumber);
            Assert.AreEqual(loadedPatientEdited.dueDate, dueDate);

        }

        #endregion
    }
}
