using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClinicalTrialsSchedulerClassLibrary;

namespace TestClinicalTrailsScheduler
{
    [TestClass]
    public class UserUnitTest
    {
        string fileLocation = @"C:\Users\Will\Documents\NHS\NHSApplication\TestClinicalTrailsScheduler\users.xml";

        #region UserSuccess()

        [TestMethod]
        public void WhenUserExists()
        {
            string fileLocation = @"C:\Users\Will\Documents\NHS\NHSApplication\TestClinicalTrailsScheduler\users.xml";
            string testEmail = "testuser@test.com";

            User user = new User(testEmail, fileLocation);

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void WhenUserFindsCorrectHash()
        {
            string fileLocation = @"C:\Users\Will\Documents\NHS\NHSApplication\TestClinicalTrailsScheduler\users.xml";
            string testEmail = "testuser@test.com";
            string testHash = "7e46fabc0becb4a188b605f3d323d5a461c40fa27adaca6ec809e940d943208b";

            User user = new User(testEmail, fileLocation);

            Assert.AreEqual(testHash, user.hash);
        }

        [TestMethod]
        public void WhenUserFindsCorrectSalt()
        {
            string fileLocation = @"C:\Users\Will\Documents\NHS\NHSApplication\TestClinicalTrailsScheduler\users.xml";
            string testEmail = "testuser@test.com";
            string testSalt = "ASDfgdhsERG3";

            User user = new User(testEmail, fileLocation);

            Assert.AreEqual(testSalt, user.salt);
        }

        [TestMethod]
        public void WhenUserIsAnAdmin()
        {
            string fileLocation = @"C:\Users\Will\Documents\NHS\NHSApplication\TestClinicalTrailsScheduler\users.xml";
            string testEmail = "testadmin@test.com";

            User user = new User(testEmail, fileLocation);

            Assert.IsTrue(user.admin);
        }

        [TestMethod]
        public void WhenUserIsNotAnAdmin()
        {
            string fileLocation = @"C:\Users\Will\Documents\NHS\NHSApplication\TestClinicalTrailsScheduler\users.xml";
            string testEmail = "testuser@test.com";

            User user = new User(testEmail, fileLocation);

            Assert.IsFalse(user.admin);
        }


        #endregion
        #region UserFails()
        [TestMethod]
        public void WhenTheUserDoesNotExist()
        {
            string nonExistantEmail = "imnotreal@nonexistant.com";

            User user = new User(nonExistantEmail, fileLocation);

            Assert.IsNull(user);
        }

        [TestMethod]
        public void WhenTheUserHashDoesNotExist()
        {
            string nonExistantHashEmail = "ihavenohash@nonexistant.com";

            User user = new User(nonExistantHashEmail, fileLocation);

            Assert.IsNull(user.hash);
        }

        [TestMethod]
        public void WhenTheUserSaltDoesNotExist()
        {
            string nonExistantSaltEmail = "ihavenosalt@nonexistant.com";

            User user = new User(nonExistantSaltEmail, fileLocation);

            Assert.IsNull(user.salt);
        }

        [TestMethod]
        public void WhenTheUserAdminDoesNotExist()
        {
            string nonExistantAdminEmail = "ihavenoadmin@nonexistant.com";

            User user = new User(nonExistantAdminEmail, fileLocation);

            Assert.IsNull(user.admin);
        }
        #endregion
    }
}