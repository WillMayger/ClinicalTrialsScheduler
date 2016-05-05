using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalTrialsSchedulerClassLibrary
{
    public class Patient
    {
        private string firstName { get; set; }
        private string surName { get; set; }
        private string hospitalNumber { get; set; }
        private string trialNumber { get; set; }
        private string trial { get; set; }
        private string randomizationArm { get; set; }
        private string cycleLength { get; set; }
        private string cycle { get; set; }
        private string cycleOf { get; set; }
        private string dueDate { get; set; }

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

    }
}
