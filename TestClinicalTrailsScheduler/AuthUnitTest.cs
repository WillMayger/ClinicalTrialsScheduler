using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClinicalTrialsSchedulerClassLibrary;

namespace TestClinicalTrailsScheduler
{
    [TestClass]
    public class AuthUnitTest
    {
        #region Auth()
        [TestMethod]
        public void HasConstructorMethodThatSetsAuthProps()
        {
            string email = "testuser@test.com";
            string password = "Test1";

            Auth auth = new Auth(email, password);

            Assert.IsTrue(auth.AuthenticateUser());
        }
        #endregion
        #region CreateHash()

        [TestMethod]
        public void CreateHashToNotBeThePassword()
        {
            string testPassword = "ThisIs0urT3stPassword1!*";
            string testEmail = "testuser@test.com";

            Auth auth = new Auth(testEmail, testPassword); 

            string testHash = auth.CreateHash(testPassword);

            Assert.AreNotEqual(testPassword, testHash);
        }

        [TestMethod]
        public void CreateHashWithDifferentSalts()
        {
            string testPassword = "Testdfgsdgsg**!1";
            string testEmail = "testuser@test.com";
            string testDifferentEmail = "testdifferentusersamepassword@test.com";

            Auth auth = new Auth(testEmail, testPassword);
            Auth differentSaltAuth = new Auth(testDifferentEmail, testPassword);

            string testHash = auth.CreateHash(testPassword);
            string testHashWithDifferentSalt = differentSaltAuth.CreateHash(testPassword);

            Assert.AreNotEqual(testHashWithDifferentSalt, testHash);
        }

        #endregion
        #region AuthenticateUser()
        [TestMethod]
        public void AuthenticateUserIsAuthenticated()
        {
            string testEmail = "testuser@test.com";
            string testPassword = "Test1";

            Auth auth = new Auth(testEmail, testPassword);

            bool authenticated = auth.AuthenticateUser();

            Assert.IsTrue(authenticated);
        }

        [TestMethod]
        public void AuthenticateUserIsNotAuthenticated()
        {
            string testEmail = "testuser@test.com";
            string testPassword = "Test2";

            Auth auth = new Auth(testEmail, testPassword);

            bool authenticated = auth.AuthenticateUser();

            Assert.IsFalse(authenticated);
        }
        #endregion
    }
}
