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
    public class CalendarWorkoutEvents
    {
        private WorkoutEvent[] events = new WorkoutEvent[]
        {
            new WorkoutEvent { Title = "Test event 1", Start = DateTime.Parse("04/10/19"), User = new User { UserId = 2, UserName = "tester", DOB = DateTime.Parse("04/25/2000"), Level = 0 }, UserId = 2, WorkoutId = 1 },
            new WorkoutEvent { Title = "Test event 2", Start = DateTime.Parse("04/12/19"), User = new User { UserId = 2, UserName = "tester", DOB = DateTime.Parse("04/25/2000"), Level = 0 }, UserId = 2, WorkoutId = 1 },
            new WorkoutEvent { Title = "Test event 3", Start = DateTime.Parse("04/14/19"), User = new User { UserId = 2, UserName = "tester", DOB = DateTime.Parse("04/25/2000"), Level = 0 }, UserId = 2, WorkoutId = 1 }
        };

        //PBI 139
        [TestMethod]
        public void GetWorkouts_Returns_List_of_Events()
        {
            //arrange
            Mock<IToasterRepository> test = new Mock<IToasterRepository>();
            test.Setup(x => x.WorkoutEvents).Returns(events.AsQueryable());

            var user = "tester";

            Mock<ControllerContext> ControllerContext = new Mock<ControllerContext>();

            ControllerContext.Setup(o => o.HttpContext.User.Identity.Name).Returns(user);

            var testAgain = new CalendarController(test.Object);
            testAgain.ControllerContext = ControllerContext.Object;
            
            //act
            var secondTest = testAgain.GetWorkouts();

            //assert
            CollectionAssert.AllItemsAreInstancesOfType(secondTest, typeof(Event));
        }

        //PBI 224
        [TestMethod]
        public void Workout_Event_Color_Changes_To_Green()
        {
            //arrange
            Mock<IToasterRepository> mock = new Mock<IToasterRepository>();
            mock.Setup(x => x.WorkoutEvents).Returns(new WorkoutEvent[] { new WorkoutEvent { Title = "Test event 1", Description = "test event 1 description", StatusColor = "red" } }.AsQueryable);

            var controller = new CalendarController(mock.Object);

            //act
            var ActualColor = controller.ChangeEventStatus(mock.Object.WorkoutEvents.First());

            //assert
            Assert.AreEqual("green", ActualColor.StatusColor);
        }
    }
}
