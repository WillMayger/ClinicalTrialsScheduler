using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClinicalTrialsSchedulerClassLibrary;

namespace TestClinicalTrailsScheduler
{
    

    [TestClass]
    public class UserUnitTest
    {

        [TestMethod]
        public void createUser()
        {
            string email = "admin@admin";
            string password = "admin";


            User admin = new User(email, password);

            admin.CreateNewUser();

            User adminCreated = User.LoadUser(email);

            Assert.AreEqual(adminCreated.hash, admin.hash);

        }


    }

}