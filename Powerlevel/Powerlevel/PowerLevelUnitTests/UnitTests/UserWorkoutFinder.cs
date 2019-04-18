using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Powerlevel.Models;
using Powerlevel.Controllers;
using System.Web.Mvc;

namespace PowerLevelUnitTests.UnitTests
{
    [TestClass]
    public class UserWorkoutThings
    {
        // User Story ID: 166
        [TestMethod]
        public void Correct_Datetime()
        {
            //arrange
            UserWorkout WorkoutDate = new UserWorkout();
            DateTime RightNow = DateTime.Now;

            //act
            DateTime getCurrentTime = WorkoutDate.CompletedTime;

            //assert
            Assert.AreEqual(RightNow, getCurrentTime);
        }

        [TestMethod]
        public void Datetime_Is_Not_Past_Or_Future()
        {
            //arrange
            UserWorkout WorkoutDate = new UserWorkout();
            int CurrentYear = DateTime.Now.Year;

            //act
            int LastYear = 2018;
            int ThisYear = 2019;
            int NextYear = 2020;

            //assert
            Assert.AreNotEqual(LastYear, CurrentYear);
            Assert.AreEqual(ThisYear, CurrentYear);
            Assert.AreNotEqual(NextYear, CurrentYear);
        }

        // User Story ID: 164
        [TestMethod]
        public void Workout_Completed_Starts_As_False()
        {
            //arrange
            UserWorkout WorkoutNotCompleteCheck = new UserWorkout();

            //act
            bool NotComplete = WorkoutNotCompleteCheck.WorkoutCompleted;

            //assert
            Assert.IsFalse(NotComplete);
        }

        [TestMethod]
        public void Remainder_Of_UserWorkout_Is_Not_Null()
        {
            //arrange
            UserWorkout WorkoutNullCheck = new UserWorkout();

            //act
            var NotNullActive = WorkoutNullCheck.UserActiveWorkout;
            var NotNullUserId = WorkoutNullCheck.UserId;
            var NotNullPK = WorkoutNullCheck.UWId;

            //assert
            Assert.IsNotNull(NotNullActive);
            Assert.IsNotNull(NotNullUserId);
            Assert.IsNotNull(NotNullPK);
        }
    }
}
