using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClinicalTrialsSchedulerClassLibrary;

namespace TestClinicalTrailsScheduler
{
    [TestClass]
    public class AuthUnitTest
    {
        #region CreateHash()

        [TestMethod]
        public void CreateHashToNotBeThePassword()
        {
            string testPassword = "ThisIs0urT3stPassword1!*";
            string testSalt = "SDFahahmG3";

            string testHash = Auth.CreateHash(testPassword, testSalt);

            Assert.AreNotSame(testPassword, testHash);
        }

        [TestMethod]
        public void CreateHashWithDifferentSalts()
        {
            string testPassword = "ThisIs0urT3stPassword1!*";
            string testSalt = "SDFahahmG3";
            string differentTestSalt = "WERGHfg4dg";

            string testHash = Auth.CreateHash(testPassword, testSalt);
            string testHashWithDifferentSalt = Auth.CreateHash(testPassword, differentTestSalt);

            Assert.AreNotSame(testHashWithDifferentSalt, testHash);
        }

        #endregion
        #region GetHash()
        [TestMethod]
        public void GetUsersHashReturnsTheCorrectHash()
        {
            string fileLocation = @"C:\Users\Will\Documents\NHS\NHSApplication\TestClinicalTrailsScheduler\users.xml";
            string email = "testuser@test.com";

            string excpectedHash = "7e46fabc0becb4a188b605f3d323d5a461c40fa27adaca6ec809e940d943208b";

            string actualHash = Auth.GetHash(email, fileLocation);

            Assert.AreEqual(excpectedHash, actualHash);
        }

        [TestMethod]
        public void GetUsersHashWhenUserDoesNotExist()
        {
            string fileLocation = @"C:\Users\Will\Documents\NHS\NHSApplication\TestClinicalTrailsScheduler\users.xml";
            string nonExistantEmail = "imnotreal@nonexistant.com";

            string actualHash = Auth.GetHash(nonExistantEmail, fileLocation);

            Assert.IsNull(actualHash);
        }
        #endregion
        #region GetSalt()
        [TestMethod]
        public void GetUsersSaltReturnsTheCorrectSalt()
        {
            string fileLocation = @"C:\Users\Will\Documents\NHS\NHSApplication\TestClinicalTrailsScheduler\users.xml";
            string email = "testuser@test.com";

            string excpectedSalt = "ASDfgdhsERG3";

            string actualSalt = Auth.GetSalt(email, fileLocation);

            Assert.AreEqual(excpectedSalt, actualSalt);
        }

        [TestMethod]
        public void GetUsersSaltWhenUserDoesNotExist()
        {
            string fileLocation = @"C:\Users\Will\Documents\NHS\NHSApplication\TestClinicalTrailsScheduler\users.xml";
            string nonExistantEmail = "imnotreal@nonexistant.com";

            string actualSalt = Auth.GetSalt(nonExistantEmail, fileLocation);

            Assert.IsNull(actualSalt);
        }
        #endregion
        #region CheckCredentials()
        [TestMethod]
        public void CheckCredentialsSuceccfullyAllowsAccess()
        {
            string email = "testuser@test.com";
            string hash = "7e46fabc0becb4a188b605f3d323d5a461c40fa27adaca6ec809e940d943208b";

            bool authenticated = Auth.CheckCredentials(hash, email);

            Assert.IsTrue(authenticated);
        }

        [TestMethod]
        public void CheckCredentialsDenysAccess()
        {
            string email = "testuser@test.com";
            string hash = "SDFG34twegsfdhg45WRTHwey75gsdfhSSSHjWRTY3456GDE45gFHfsdfg4234sD";

            bool authenticated = Auth.CheckCredentials(hash, email);

            Assert.IsFalse(authenticated);
        }

        [TestMethod]
        public void CheckCredentialsUserDoesNotExist()
        {
            string nonExistantEmail = "imnotreal@nonexistant.com";
            string hash = "SDFG34twegsfdhg45WRTHwey78gsdfhSSSHjWRTY3456GDE45gFHfsdfg4234sD";

            bool authenticated = Auth.CheckCredentials(hash, nonExistantEmail);

            Assert.IsFalse(authenticated);
        }
        #endregion
        #region AuthenticateUser()
        [TestMethod]
        public void AuthenticateUserIsAuthenticated()
        {
            string email = "testuser@test.com";
            string password = "Test1";

            bool authenticated = Auth.AuthenticateUser(email, password);

            Assert.IsTrue(authenticated);
        }

        [TestMethod]
        public void AuthenticateUserIsNotAuthenticated()
        {
            string email = "testuser@test.com";
            string password = "Test2";

            bool authenticated = Auth.AuthenticateUser(email, password);

            Assert.IsFalse(authenticated);
        }
        #endregion
    }
}
