using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ComponentModel;
using System.Globalization;

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

        public static string fileLocation = @"C:\Users\Will\Documents\NHS\NHSApplication\WpfApplication1\patient.xml";

        public Patient(string firstName, string surName, string hospitalNumber, string trialNumber, string trial, string randomizationArm, string cycleLength, string cycle, string cycleOf, DateTime dueDate)
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
            this.dueDate = ConvertDateToString(dueDate);
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

            string dueDt = dueDate.ToString();

            if (dueDt == "")
            {
                dueDt = "01/08/2016 00:00:00.00";
            }

            newElem.SetAttribute("dueDate", dueDt);

            doc.DocumentElement.AppendChild(newElem);

            doc.Save(fileLocation);
        }

        public void SavePatient(string firstName, string surName, string hospitalNumber, string trialNumber, string trial, string randomizationArm, string cycleLength, string cycle, string cycleOf, DateTime dueDate)
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
            newElem.SetAttribute("dueDate", ConvertDateToString(dueDate));

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
                if (patient.Attributes["surName"].Value.ToString().ToLower() == surName.ToLower())
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
                        ConvertStringToDate(patient.Attributes["dueDate"].Value.ToString())
                        );

                    patientsArray.Add(newPatient);
                  }

            }

            return patientsArray;

        }

        public List<Patient> LoadPatients(string trial)
        {
            List<Patient> patientsArray = new List<Patient>();
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlNodeList patients = doc.GetElementsByTagName("Patient");

            foreach (XmlElement patient in patients)
            {
                if (patient.Attributes["trial"].Value.ToString().ToLower() == trial.ToLower())
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
                        ConvertStringToDate(patient.Attributes["dueDate"].Value.ToString())
                        );

                    patientsArray.Add(newPatient);
                }

            }

            return patientsArray;

        }

        public List<Patient> LoadPatients(DateTime fromDate, DateTime toDate)
        {
            List<Patient> patientsArray = new List<Patient>();
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlNodeList patients = doc.GetElementsByTagName("Patient");

            foreach (XmlElement patient in patients)
            {
                long patientTimeStamp = TimeStamp(ConvertStringToDate(patient.Attributes["dueDate"].Value.ToString()));
                if (patientTimeStamp >= TimeStamp(fromDate) && patientTimeStamp <= TimeStamp(toDate))
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
                        ConvertStringToDate(patient.Attributes["dueDate"].Value.ToString())
                        );

                    patientsArray.Add(newPatient);
                }

            }

            return patientsArray;

        }

        public static List<Patient> AllPatients()
        {
            List<Patient> patientsArray = new List<Patient>();
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlNodeList patients = doc.GetElementsByTagName("Patient");

            foreach (XmlElement patient in patients)
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
                        ConvertStringToDateStatic(patient.Attributes["dueDate"].Value.ToString())
                        );

                    patientsArray.Add(newPatient);

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

                if (patient.Attributes["surName"].Value.ToString().ToLower() == surName.ToLower() && patient.Attributes["firstName"].Value.ToString().ToLower() == firstName.ToLower() && patient.Attributes["trialNumber"].Value.ToString() == trialNumber)
                {
                    doc.DocumentElement.RemoveChild(patient);

                    doc.Save(fileLocation);

                    return true;
                }

            }

            return false;
        }

        public bool DeletePatient()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlNodeList patients = doc.GetElementsByTagName("Patient");

            foreach (XmlElement patient in patients)
            {

                if (patient.Attributes["surName"].Value.ToString().ToLower() == surName.ToLower() && patient.Attributes["firstName"].Value.ToString().ToLower() == firstName.ToLower() && patient.Attributes["trialNumber"].Value.ToString() == trialNumber)
                {
                    doc.DocumentElement.RemoveChild(patient);

                    doc.Save(fileLocation);

                    return true;
                }

            }

            return false;
        }

        public bool EditPatient(string firstName, string surName, string hospitalNumber, string trialNumber, string trial, string randomizationArm, string cycleLength, string cycle, string cycleOf, DateTime dueDate)
        {

            if (DeletePatient(this.firstName, this.surName, this.trialNumber) == false) {
                return false;
            }

            SavePatient(firstName, surName, hospitalNumber, trialNumber, trial, randomizationArm, cycleLength, cycle, cycleOf, dueDate);

            return true;
        }

        #region notes

        public string GetPatientNotes()
        {
            string notes = "";

            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlNodeList patients = doc.GetElementsByTagName("Patient");

            foreach (XmlElement patient in patients)
            {

                if (patient.Attributes["surName"].Value.ToString().ToLower() == surName.ToLower() && patient.Attributes["firstName"].Value.ToString().ToLower() == firstName.ToLower() && patient.Attributes["trialNumber"].Value.ToString() == trialNumber)
                {

                    try
                    {
                        notes = patient.Attributes["notes"].Value.ToString();
                        return notes;
                    }
                    catch
                    {
                        return notes;
                    }

                }

            }

            return notes;

        }

        public bool SavePatientNotes(string notes)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlNodeList patients = doc.GetElementsByTagName("Patient");

            foreach (XmlElement patient in patients)
            {

                if (patient.Attributes["surName"].Value.ToString().ToLower() == surName.ToLower() && patient.Attributes["firstName"].Value.ToString().ToLower() == firstName.ToLower() && patient.Attributes["trialNumber"].Value.ToString() == trialNumber)
                {

                    patient.SetAttribute("notes", notes);

                    doc.Save(fileLocation);

                    return true;

                }

            }

            return false;

        }

#endregion

        #region Delay

        public string GetDelayInDays()
        {
            string delayInDays = "";

            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlNodeList patients = doc.GetElementsByTagName("Patient");

            foreach (XmlElement patient in patients)
            {

                if (patient.Attributes["surName"].Value.ToString().ToLower() == surName.ToLower() && patient.Attributes["firstName"].Value.ToString().ToLower() == firstName.ToLower() && patient.Attributes["trialNumber"].Value.ToString() == trialNumber)
                {

                    try
                    {
                        delayInDays = patient.Attributes["delayInDays"].Value.ToString();
                        return delayInDays;
                    }
                    catch
                    {
                        return delayInDays;
                    }

                }

            }

            return delayInDays;

        }

        public bool SaveDelayInDays(string delayInDays)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlNodeList patients = doc.GetElementsByTagName("Patient");

            foreach (XmlElement patient in patients)
            {

                if (patient.Attributes["surName"].Value.ToString().ToLower() == surName.ToLower() && patient.Attributes["firstName"].Value.ToString().ToLower() == firstName.ToLower() && patient.Attributes["trialNumber"].Value.ToString() == trialNumber)
                {

                    patient.SetAttribute("delayInDays", delayInDays);

                    doc.Save(fileLocation);

                    return true;

                }

            }

            return false;

        }

        #endregion

        #region Prescription

        public bool GetPrescriptionPrescriped()
        {
            bool prescriptionPrescriped = false;

            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlNodeList patients = doc.GetElementsByTagName("Patient");

            foreach (XmlElement patient in patients)
            {

                if (patient.Attributes["surName"].Value.ToString().ToLower() == surName.ToLower() && patient.Attributes["firstName"].Value.ToString().ToLower() == firstName.ToLower() && patient.Attributes["trialNumber"].Value.ToString() == trialNumber)
                {

                    try
                    {
                        prescriptionPrescriped = Convert.ToBoolean(patient.Attributes["prescriptionPrescriped"].Value.ToString());
                        return prescriptionPrescriped;
                    }
                    catch
                    {
                        return prescriptionPrescriped;
                    }

                }

            }

            return prescriptionPrescriped;

        }

        public bool SavePrescriptionPrescriped(bool prescriptionPrescriped)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlNodeList patients = doc.GetElementsByTagName("Patient");

            foreach (XmlElement patient in patients)
            {

                if (patient.Attributes["surName"].Value.ToString().ToLower() == surName.ToLower() && patient.Attributes["firstName"].Value.ToString().ToLower() == firstName.ToLower() && patient.Attributes["trialNumber"].Value.ToString() == trialNumber)
                {

                    patient.SetAttribute("prescriptionPrescriped", prescriptionPrescriped.ToString());

                    doc.Save(fileLocation);

                    return true;

                }

            }

            return false;

        }
#endregion

        #region Dispenced

        public bool GetDispenced()
        {
            bool despenced = false;

            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlNodeList patients = doc.GetElementsByTagName("Patient");

            foreach (XmlElement patient in patients)
            {

                if (patient.Attributes["surName"].Value.ToString().ToLower() == surName.ToLower() && patient.Attributes["firstName"].Value.ToString().ToLower() == firstName.ToLower() && patient.Attributes["trialNumber"].Value.ToString() == trialNumber)
                {

                    try
                    {
                        despenced = Convert.ToBoolean(patient.Attributes["despenced"].Value.ToString());
                        return despenced;
                    }
                    catch
                    {
                        return despenced;
                    }

                }

            }

            return despenced;

        }

        public bool SaveDispenced(bool despenced)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlNodeList patients = doc.GetElementsByTagName("Patient");

            foreach (XmlElement patient in patients)
            {

                if (patient.Attributes["surName"].Value.ToString().ToLower() == surName.ToLower() && patient.Attributes["firstName"].Value.ToString().ToLower() == firstName.ToLower() && patient.Attributes["trialNumber"].Value.ToString() == trialNumber)
                {

                    patient.SetAttribute("despenced", despenced.ToString());

                    doc.Save(fileLocation);

                    return true;

                }

            }

            return false;

        }
        #endregion

        #region blood
        public bool GetBloodWarranty()
        {
            bool bloodWarranty = false;

            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlNodeList patients = doc.GetElementsByTagName("Patient");

            foreach (XmlElement patient in patients)
            {

                if (patient.Attributes["surName"].Value.ToString().ToLower() == surName.ToLower() && patient.Attributes["firstName"].Value.ToString().ToLower() == firstName.ToLower() && patient.Attributes["trialNumber"].Value.ToString() == trialNumber)
                {

                    try
                    {
                        bloodWarranty = Convert.ToBoolean(patient.Attributes["bloodWarranty"].Value.ToString());
                        return bloodWarranty;
                    }
                    catch
                    {
                        return bloodWarranty;
                    }

                }

            }

            return bloodWarranty;

        }

        public bool SaveBloodWarranty(bool bloodWarranty)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlNodeList patients = doc.GetElementsByTagName("Patient");

            foreach (XmlElement patient in patients)
            {

                if (patient.Attributes["surName"].Value.ToString().ToLower() == surName.ToLower() && patient.Attributes["firstName"].Value.ToString().ToLower() == firstName.ToLower() && patient.Attributes["trialNumber"].Value.ToString() == trialNumber)
                {

                    patient.SetAttribute("bloodWarranty", bloodWarranty.ToString());

                    doc.Save(fileLocation);

                    return true;

                }

            }

            return false;

        }
        #endregion

        public string ConvertDateToString(DateTime dt)
        {
            return dt.ToString("dd/MM/yyyy");
        }

        public DateTime ConvertStringToDate(string dt)
        {
            return DateTime.ParseExact(dt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public static string ConvertDateToStringStatic(DateTime dt)
        {
            return dt.ToString("dd/MM/yyyy");
        }

        public static DateTime ConvertStringToDateStatic(string dt)
        {
            return DateTime.ParseExact(dt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }


        private long TimeStamp (DateTime dateObj)
        {
            long ticks = dateObj.Ticks - DateTime.ParseExact("01/01/1970 00:00:00", "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture).Ticks;
            ticks /= 10000000; //Convert windows ticks to seconds
            return ticks;
        }
    }

}
