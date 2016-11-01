using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ClinicalTrialsSchedulerClassLibrary
{
    public static class Auth
    {
        public static string fileLocation = @"C:\Users\Will\Documents\NHS\NHSApplication\WpfApplication1\users.xml";

        public static bool AuthenticateUser(string hash, string salt, string password)
        {
            string userLoginHashAttempt = CreateHash(password, salt);
            if (hash == userLoginHashAttempt) return true;
            return false;
        }

        public static string CreateHash(string password, string salt)
        {
            password = password + salt;
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
