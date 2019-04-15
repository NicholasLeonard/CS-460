using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Powerlevel.Controllers;
using System.Web.Mvc;
using NUnit;
using Powerlevel.Models;

namespace PowerLevelUnitTests.UnitTests
{
    [TestClass]
    public class CheckThatRoutesHaveProperIncomingRequests
    {

        [TestMethod]
        public void Check_Home_Routing_To_Index_Returns_Correctly() {

            string expected = "Index";
            HomeController controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual(expected, result.ViewName);
        }   
    }
}
