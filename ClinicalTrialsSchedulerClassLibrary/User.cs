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
        public string hash { get; set; }
        public string salt { get; set; }
        public string email { get; set; }
        public string fileLocation = @"C:\Program Files\clinicaltrialsdata\users.xml";
        public static string fileLocationStatic = @"C:\Program Files\clinicaltrialsdata\users.xml";

        public User(string email, string password)
        {

            this.email = email;
            this.salt = password.Substring(0, 2) + email.Substring(0, 3);
            this.hash = Auth.CreateHash(password, this.salt);

        }

        private User(string email, string salt, string hash)
        {

            this.email = email;
            this.salt = salt;
            this.hash = hash;

        }

        public static int UserCount()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocationStatic);

            XmlNodeList users = doc.GetElementsByTagName("User");

            return users.Count;
        }

        public bool CreateNewUser()
        {
            XmlDocument xmlUsers = new XmlDocument();
            xmlUsers.Load(fileLocation);

            if (UserEmailExists(email)) return false;

            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            XmlElement newElem = doc.CreateElement("User");

            newElem.SetAttribute("email", email);
            newElem.SetAttribute("hash", hash);
            newElem.SetAttribute("salt", salt);

            doc.DocumentElement.AppendChild(newElem);

            doc.Save(fileLocation);

            return true;
        }

        public static User LoadUser(string email)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocationStatic);

            XmlNodeList users = doc.GetElementsByTagName("User");

            foreach (XmlElement user in users)
            {
                if (user.Attributes["email"].Value.ToString().ToLower() == email.ToLower())
                {
                    User newUser = new User(
                        user.Attributes["email"].Value.ToString(),
                        user.Attributes["salt"].Value.ToString(),
                        user.Attributes["hash"].Value.ToString()
                        );

                    return newUser;
                }

            }
            User nullUser = new User("null@null", "null");
            return nullUser;
            
        }

        public static bool UserEmailExists(string email)
        {
            User thisUser = LoadUser(email);

            if (thisUser.email == "null@null") return false;

            return true;
        }

        public static bool DeleteUser(string email)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocationStatic);

            XmlNodeList users = doc.GetElementsByTagName("User");

            foreach (XmlElement user in users)
            {

                if (user.Attributes["email"].Value.ToString().ToLower() == email)
                {
                    doc.DocumentElement.RemoveChild(user);

                    doc.Save(fileLocationStatic);

                    return true;
                }

            }

            return false;
        }

    }

}
