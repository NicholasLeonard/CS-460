using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using NUnit;
using Powerlevel.Infastructure;
using Powerlevel.Controllers;
using Powerlevel.Models;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;

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
        

        [TestMethod]
        public void GetWorkouts_Returns_List_of_Events()
        {
            //arrange
            Mock<IToasterRepository> test = new Mock<IToasterRepository>();
            test.Setup(x => x.WorkoutEvents).Returns(events.AsQueryable());

            var testAgain = new CalendarController(test.Object);
            
            //act
            var secondTest = testAgain.GetWorkouts();

            //assert
            CollectionAssert.AllItemsAreInstancesOfType(secondTest, typeof(Event));
            
        }
    }
}
