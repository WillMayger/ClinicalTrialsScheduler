using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClinicalTrialsSchedulerClassLibrary;

namespace TestClinicalTrailsScheduler
{
    

    [TestClass]
    public class UserUnitTest
    {
        public string fileLocation = @"C:\Users\Will\Documents\NHS\NHSApplication\TestClinicalTrailsScheduler\users.xml";

        #region UserSuccess()

        [TestMethod]
        public void WhenUserExists()
        {
            string testEmail = "testuser@test.com";

            User user = new User(testEmail, fileLocation);

            Assert.IsTrue(user.exists);
        }

        [TestMethod]
        public void WhenUserFindsCorrectHash()
        {
            
            string testEmail = "testuser@test.com";
            string testHash = "7e46fabc0becb4a188b605f3d323d5a461c40fa27adaca6ec809e940d943208b";

            User user = new User(testEmail, fileLocation);

            Assert.AreEqual(testHash, user.GetHash());
        }

        [TestMethod]
        public void WhenUserFindsCorrectSalt()
        {
            
            string testEmail = "testuser@test.com";
            string testSalt = "ASDfgdhsERG3";

            User user = new User(testEmail, fileLocation);

            Assert.AreEqual(testSalt, user.GetSalt());
        }

        [TestMethod]
        public void WhenUserFindsCorrectEmail()
        {
            string testEmail = "testuser@test.com";

            User user = new User(testEmail, fileLocation);

            Assert.AreEqual(testEmail, user.GetEmail());
        }

        [TestMethod]
        public void WhenUserIsAnAdmin()
        {
            
            string testEmail = "testadmin@test.com";

            User user = new User(testEmail, fileLocation);

            Assert.IsTrue(user.GetAdmin());
        }

        [TestMethod]
        public void WhenUserIsNotAnAdmin()
        {
            
            string testEmail = "testuser@test.com";

            User user = new User(testEmail, fileLocation);

            Assert.IsFalse(user.GetAdmin());
        }


        #endregion
        #region UserFails()
        [TestMethod]
        public void WhenTheUserDoesNotExist()
        {
            string nonExistantEmail = "imnotreal@nonexistant.com";

            User user = new User(nonExistantEmail, fileLocation);

            Assert.IsFalse(user.exists);
        }

        [TestMethod]
        public void WhenTheUserHashDoesNotExist()
        {
            string nonExistantHashEmail = "ihavenohash@nonexistant.com";

            User user = new User(nonExistantHashEmail, fileLocation);

            Assert.IsNull(user.GetHash());
        }

        [TestMethod]
        public void WhenTheUserSaltDoesNotExist()
        {
            string nonExistantSaltEmail = "ihavenosalt@nonexistant.com";

            User user = new User(nonExistantSaltEmail, fileLocation);

            Assert.IsNull(user.GetSalt());
        }

        [TestMethod]
        public void WhenUserFindsNoCorrectEmail()
        {
            string nonExistantEmail = "ihavenoemail@nonexistant.com";

            User user = new User(nonExistantEmail, fileLocation);

            Assert.IsNull(user.GetEmail());
        }

        [TestMethod]
        public void WhenTheUserAdminDoesNotExist()
        {
            string nonExistantAdminEmail = "ihavenoadmin@nonexistant.com";

            User user = new User(nonExistantAdminEmail, fileLocation);

            Assert.IsFalse(user.GetAdmin());
        }
        #endregion
    }
}