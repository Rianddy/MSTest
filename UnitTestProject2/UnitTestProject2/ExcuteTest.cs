using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBehave.Narrator.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CPOPQR.FuntionalTests
{
    [TestClass]
    public class ExcuteTest
    { 
        [TestMethod]
        public void LoginTest()
        {
            Assert.AreEqual(true,@"features\Login.feature"
                .ExecuteTest()
                .FeatureFaildOrNot());
        }

        [TestMethod]
        public void ResetPasswordTest()
        {
            Assert.AreEqual(true, @"features\ResetPassword.feature"
                .ExecuteTest()
                .FeatureFaildOrNot());
        }

        [TestMethod]
        public void Dashboard()
        {
            Assert.AreEqual(true, @"features\Dashboard.feature"
                .ExecuteTest()
                .FeatureFaildOrNot());
        }

        [TestMethod]
        public void SchedulesFunction()
        {
            Assert.AreEqual(true, @"features\SchedulesFunction.feature"
                .ExecuteTest()
                .FeatureFaildOrNot());
        }

        [TestMethod]
        public void DataFunction()
        {
            Assert.AreEqual(true,  @"features\DataFunction.feature"
                .ExecuteTest()
                .FeatureFaildOrNot());
        }

        [TestMethod]
        public void EFileFunction()
        {
            Assert.AreEqual(true, @"features\EFile.feature"
                .ExecuteTest()
                .FeatureFaildOrNot());
        }

        [TestMethod]
        public void AdministrationFunction()
        {
            Assert.AreEqual(true, @"features\AdministrationFunction.feature"
                .ExecuteTest()
                .FeatureFaildOrNot());
        }
    }
}
