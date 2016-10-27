using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClinicalTrialsSchedulerClassLibrary
{
    public class Patient
    {
        public string firstName { get; set; }
        public string surName { get; set; }
        public string hospitalNumber { get; set; }
        public string trialNumber { get; set; }
        public string trial { get; set; }
        public string randomizationArm { get; set; }
        public string cycleLength { get; set; }
        public string cycle { get; set; }
        public string cycleOf { get; set; }
        public string dueDate { get; set; }
        public string fileLocation = @"C:\Users\Will\Documents\NHS\NHSApplication\WpfApplication1\patient.xml";

        public Patient(string firstName, string surName, string hospitalNumber, string trialNumber, string trial, string randomizationArm, string cycleLength, string cycle, string cycleOf, string dueDate)
        {
            //do validation

            this.firstName = firstName;
            this.surName = surName;
            this.hospitalNumber = hospitalNumber;
            this.trialNumber = trialNumber;
            this.trial = trial;
            this.randomizationArm = randomizationArm;
            this.cycleLength = cycleLength;
            this.cycle = cycle;
            this.cycleOf = cycleOf;
            this.dueDate = dueDate;
        }

        public Patient()
        {
            
        }

        public void SavePatient()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlElement newElem = doc.CreateElement("Patient");

            newElem.SetAttribute("firstName", firstName);
            newElem.SetAttribute("surName", surName);
            newElem.SetAttribute("hospitalNumber", hospitalNumber);
            newElem.SetAttribute("trialNumber", trialNumber);
            newElem.SetAttribute("trial", trial);
            newElem.SetAttribute("randomizationArm", randomizationArm);
            newElem.SetAttribute("cycleLength", cycleLength);
            newElem.SetAttribute("cycle", cycle);
            newElem.SetAttribute("cycleOf", cycleOf);
            newElem.SetAttribute("dueDate", dueDate);

            doc.DocumentElement.AppendChild(newElem);

            doc.Save(fileLocation);
        }

        public void SavePatient(string firstName, string surName, string hospitalNumber, string trialNumber, string trial, string randomizationArm, string cycleLength, string cycle, string cycleOf, string dueDate)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlElement newElem = doc.CreateElement("Patient");

            newElem.SetAttribute("firstName", firstName);
            newElem.SetAttribute("surName", surName);
            newElem.SetAttribute("hospitalNumber", hospitalNumber);
            newElem.SetAttribute("trialNumber", trialNumber);
            newElem.SetAttribute("trial", trial);
            newElem.SetAttribute("randomizationArm", randomizationArm);
            newElem.SetAttribute("cycleLength", cycleLength);
            newElem.SetAttribute("cycle", cycle);
            newElem.SetAttribute("cycleOf", cycleOf);
            newElem.SetAttribute("dueDate", dueDate);

            doc.DocumentElement.AppendChild(newElem);

            doc.Save(fileLocation);
        }

        public List<Patient> LoadPatients(string firstName, string surName)
        {
            List<Patient> patientsArray = new List<Patient>();
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlNodeList patients = doc.GetElementsByTagName("Patient");

            foreach (XmlElement patient in patients)
            {
                if (patient.Attributes["surName"].Value.ToString() == surName)
                {
                    Patient newPatient = new Patient(
                        patient.Attributes["firstName"].Value.ToString(),
                        patient.Attributes["surName"].Value.ToString(),
                        patient.Attributes["hospitalNumber"].Value.ToString(),
                        patient.Attributes["trialNumber"].Value.ToString(),
                        patient.Attributes["trial"].Value.ToString(),
                        patient.Attributes["randomizationArm"].Value.ToString(),
                        patient.Attributes["cycleLength"].Value.ToString(),
                        patient.Attributes["cycle"].Value.ToString(),
                        patient.Attributes["cycleOf"].Value.ToString(),
                        patient.Attributes["dueDate"].Value.ToString()
                        );

                    patientsArray.Add(newPatient);
                  }

            }

            return patientsArray;

        }

        public bool DeletePatient(string firstName, string surName, string trialNumber)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlNodeList patients = doc.GetElementsByTagName("Patient");

            foreach (XmlElement patient in patients)
            {

                if (patient.Attributes["surName"].Value.ToString() == surName && patient.Attributes["firstName"].Value.ToString() == firstName && patient.Attributes["trialNumber"].Value.ToString() == trialNumber)
                {
                    doc.DocumentElement.RemoveChild(patient);

                    doc.Save(fileLocation);

                    return true;
                }

            }

            return false;
        }

        public bool EditPatient(string firstName, string surName, string hospitalNumber, string trialNumber, string trial, string randomizationArm, string cycleLength, string cycle, string cycleOf, string dueDate)
        {

            if (DeletePatient(this.firstName, this.surName, this.trialNumber) == false) {
                return false;
            }

            SavePatient(firstName, surName, hospitalNumber, trialNumber, trial, randomizationArm, cycleLength, cycle, cycleOf, dueDate);

            return true;
        }

    }

}
