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
        public static bool AuthenticateUser(string email, string password)
        {
            string salt = GetSalt(email, @"C:\Users\Will\Documents\NHS\NHSApplication\WpfApplication1\users.xml");
            string hashedPassword = CreateHash(password, salt);
            if (CheckCredentials(hashedPassword, email)) return true;
            return false;
        }

        public static string GetSalt(string email, string fileLocation)
        {
            User user = new User(email, fileLocation);

            return user.salt;


        }
        public static string GetHash(string email, string fileLocation)
        {
            User user = new User(email, fileLocation);
            return user.hash;
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

        public static bool CheckCredentials(string hash, string email)
        {
            string userSavedHash = GetHash(email, @"C:\Users\Will\Documents\NHS\NHSApplication\WpfApplication1\users.xml");
            if (hash == userSavedHash) return true;
            return false;
        }

    }
}
