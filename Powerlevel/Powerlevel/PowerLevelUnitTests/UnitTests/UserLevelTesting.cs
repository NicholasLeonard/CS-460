using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Powerlevel.Models;
using Powerlevel.Controllers;
namespace PowerLevelUnitTests.UnitTests
{
    [TestClass]
    public class UserLevelAndExp
    {
        //User Story ID: 179
        [TestMethod]
        public void User_DefaultExp_Returns_Zero()
        {
            //arrange
            User user1 = new User();           
            int correctDefaultExp = 0;

            //act
            var getUserDefaultExp = user1.Experience;

            //assert, compare and see if the default exp is 0
            Assert.AreEqual(correctDefaultExp, getUserDefaultExp);
        }

        [TestMethod]
        public void User_DefaultLevel_Returns_Zero()
        {
            //arrange
            User user1 = new User();
            int correctDefaultLevel = 0;

            //act
            var getUserDefaultLevel = user1.Level;

            //assert
            Assert.AreEqual(correctDefaultLevel, getUserDefaultLevel);
        }

        [TestMethod]
        public void User_DefaultSession_UserName_Returns_null()
        {
            //arrange
            User user1 = new User();
            string correctDefaultAnswer = null;

            //act
            var getDefaultUserName = user1.UserName;

            //assert
            Assert.AreEqual(correctDefaultAnswer, getDefaultUserName);
        }

    }

}
