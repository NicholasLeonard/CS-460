using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Powerlevel.Infastructure;
using Powerlevel.Models;
using Powerlevel.Controllers;
using Moq;
using System.Linq;
using System.Web.Mvc;

namespace PowerLevelUnitTests.UnitTests
{
    [TestClass]
    public class AvatarTesting
    {
    //    [TestMethod]
    //    public void SetAvatarRedirectsToIndexAfterChange()
    //    {
    //        //arrange
    //        Mock<IToasterRepository> mock = new Mock<IToasterRepository>();

    //        //Setup the user identity
    //        var user = "tester";
    //        ManageController controller = new ManageController(mock.Object);
    //        Mock<ControllerContext> ControllerContext = new Mock<ControllerContext>();
    //        ControllerContext.Setup(o => o.HttpContext.User.Identity.Name).Returns(user);
            
    //        //Populate the Datatables
    //        mock.Setup(x => x.UserAvatars).Returns(new UserAvatar[] { new UserAvatar { UAId = 1, UserId = 1, Body = "human1.PNG", Armor = "none", Weapon = "none" } }.AsQueryable);
    //        mock.Setup(x => x.Avatars).Returns(new Avatar[] { new Avatar{ AvaId = 1, Name = "human1.PNG", Type = "Body" } }.AsQueryable);
    //        mock.Setup(x => x.Users).Returns(new User[] { new User { UserId = 1, UserName = "tester" } }.AsQueryable);

    //        //act
    //        var result = controller.SetAvatar() as ViewResult;

    //        //Assert
    //        Assert.IsNotNull(result);
    //    }

        [TestMethod]
        public void CheckIfTheDefaultAvatarCreationIsValid()
        {
            //arrage 
            Mock<IToasterRepository> mock = new Mock<IToasterRepository>();
            ManageController controller = new ManageController(mock.Object);

            //act
            int test = 1;
            var result = controller.CreateDefaultAvatar(test);
            string expected = "human1.PNG";

            //Assert
            Assert.AreEqual(result.Body, expected);
        }
    }
}
