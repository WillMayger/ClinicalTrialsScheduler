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
        private string hash { get; set; }
        private string salt { get; set; }
        private string email { get; set; }
        private bool admin { get; set; }
        public bool exists { get; private set; }

        public User(string email, string fileLocation)
        {
            string newEmail = email.Replace("@", "_");
            newEmail = newEmail.Replace(".", "_");

            XmlDocument xmlUsers = new XmlDocument();
            xmlUsers.Load(fileLocation);
            try
            {
                XmlNodeList user = xmlUsers.GetElementsByTagName(newEmail);
                salt = user[0].Attributes["salt"].Value.ToString();
                hash = user[0].Attributes["hash"].Value.ToString();
                admin = Convert.ToBoolean(user[0].Attributes["admin"].Value);
                this.email = email;
                exists = true;
            }
            catch (Exception)
            {
                exists = false;
                admin = false;
                salt = null;
                this.email = null;
                hash = null;
            }
        }

        public string GetHash()
        {
            return hash;
        }

        public string GetSalt()
        {
            return salt;
        }

        public string GetEmail()
        {
            return email;
        }

        public bool GetAdmin()
        {
            return admin;
        }

    }
}
