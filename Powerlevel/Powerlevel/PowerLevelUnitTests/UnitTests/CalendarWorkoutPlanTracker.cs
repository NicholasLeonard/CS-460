using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Powerlevel.Controllers;
using System.Web.Mvc;
using NUnit;

namespace PowerLevelUnitTests.UnitTests
{//User story ID 139
    [TestClass]
    public class CalendarWorkoutPlanTracker
    {
        private CalendarController getTestObject()
        {
            return new CalendarController();
        }

        [TestMethod]
        public void Workout_Not_Started_Message()
        {
            //arrange
            CalendarController calendar = getTestObject();
            string targetMessage = "Not started";

            //act
            var actualMessage = calendar.GetStateMessage(0);

            //assert
            Assert.AreEqual(targetMessage, actualMessage);
        }

        [TestMethod]
        public void Workout_Started_Message()
        {
            //arrange
            CalendarController calendar = getTestObject();
            string targetMessage = "In progress";

            //act
            var actualMessage = calendar.GetStateMessage(1);

            //assert
            Assert.AreEqual(targetMessage, actualMessage);
        }

        [TestMethod]
        public void Workout_Completed_Message()
        {
            //arrange
            CalendarController calendar = getTestObject();
            string targetMessage = "Completed";

            //act
            var actualMessage = calendar.GetStateMessage(2);

            //assert
            Assert.AreEqual(targetMessage, actualMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Unknown_Workout_State_Message_With_Negative_Input()
        {
            //arrange
            CalendarController calendar = getTestObject();

            //act
            calendar.GetStateMessage(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Unknown_Workout_State_Message_With_Input_Greater_Than_2()
        {
            //arrange
            CalendarController calendar = getTestObject();

            //act
            calendar.GetStateMessage(3);
        }
    }
}
