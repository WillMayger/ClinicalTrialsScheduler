using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace ClinicalTrialsSchedulerClassLibrary
{
    public class User
    {
        public string hash { get; private set; }
        public string salt { get; private set; }
        public bool admin { get; private set; }

        public User(string email, string fileLocation)
        {
            string newEmail = email.Replace("@", "_");
            newEmail = newEmail.Replace(".", "_");

            XmlDocument xmlUsers = new XmlDocument();
            xmlUsers.Load(fileLocation);

            XmlNodeList user = xmlUsers.GetElementsByTagName(newEmail);
            salt = user[0].Attributes["salt"].Value.ToString();
            hash = user[0].Attributes["hash"].Value.ToString();
            admin = Convert.ToBoolean(user[0].Attributes["admin"].Value);
        }
    }
}
