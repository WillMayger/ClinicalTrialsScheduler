using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ClinicalTrialsSchedulerClassLibrary
{
    public class Auth
    {
        private string email { get; set; }
        private string hash { get; set; }
        private string salt { get; set; }
        private User user { get; set; }
        private string userLoginHashAttempt { get; set; }
        private string fileLocation { get; set; }

        public Auth(string email, string password)
        {
            fileLocation = @"C:\Users\Will\Documents\NHS\NHSApplication\WpfApplication1\users.xml";

            User user = new User(email, fileLocation);

            this.user = user;
            this.email = email;
            this.hash = user.GetHash();
            this.salt = user.GetSalt();
            this.userLoginHashAttempt = CreateHash(password);
            
        }

        public bool AuthenticateUser()
        {
            if (this.hash == this.userLoginHashAttempt) return true;
            return false;
        }

        public string CreateHash(string password)
        {
            password = password + this.salt;
            SHA256Managed crypt = new SHA256Managed();
            string hashedPassword = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));

            foreach (byte byt in crypto)
            {
                hashedPassword += byt.ToString("x2");
            }
            return hashedPassword;
        }
    }
}
