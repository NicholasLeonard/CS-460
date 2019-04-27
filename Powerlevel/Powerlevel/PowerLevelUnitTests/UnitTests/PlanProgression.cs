using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using Powerlevel.Infastructure;
using Powerlevel.Controllers;
using Powerlevel.Models;
using System.Linq;
using System.Web.Mvc;

namespace PowerLevelUnitTests.UnitTests
{
    [TestClass]
    public class PlanProgression
    {
        [TestMethod]//PBI 222
        public void Current_Plan_Stage_Advances_By_1()
        {
            //arrange
            string user = "tester";
            //sets up the table return for the controller
            Mock<IToasterRepository> mock = new Mock<IToasterRepository>();
            mock.Setup(x => x.UserWorkoutPlans).Returns(new UserWorkoutPlan[] { new UserWorkoutPlan { PlanStage = 0, MaxStage = 2, UserName = user } }.AsQueryable);

            //sets up the user for the controller so that it can be used for querying comparisons
            Mock<ControllerContext> context = new Mock<ControllerContext>();
            context.Setup(o => o.HttpContext.User.Identity.Name).Returns(user);

            var controller = new UserWorkoutsController(mock.Object);

            //sets the context of the mocked controller
            controller.ControllerContext = context.Object;

            //act
            //var result = controller.AdvanceStage(0);

            //assert
            //Assert.AreEqual(1, result);
        }

        [TestMethod]//PBI 243
        public void Plan_Finished_Returns_True_When_PlanStage_Equal_MaxStage()
        {
            //arrange
            Mock<IToasterRepository> mock = new Mock<IToasterRepository>();
            mock.Setup(x => x.UserWorkoutPlans).Returns(new UserWorkoutPlan[] { new UserWorkoutPlan { PlanStage = 2, MaxStage = 2 } }.AsQueryable);

            UserWorkoutsController controller = new UserWorkoutsController(mock.Object);

            //act
            var result = controller.IsPlanFinished(mock.Object.UserWorkoutPlans.First());

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]//PBI 243
        public void Plan_Finished_Returns_False_When_PlanStage_Not_Equal_MaxStage()
        {
            //arrange
            Mock<IToasterRepository> mock = new Mock<IToasterRepository>();
            mock.Setup(x => x.UserWorkoutPlans).Returns(new UserWorkoutPlan[] { new UserWorkoutPlan { PlanStage = 1, MaxStage = 2 } }.AsQueryable);

            UserWorkoutsController controller = new UserWorkoutsController(mock.Object);

            //act
            var result = controller.IsPlanFinished(mock.Object.UserWorkoutPlans.First());

            //assert
            Assert.IsFalse(result);
        }
    }
}
