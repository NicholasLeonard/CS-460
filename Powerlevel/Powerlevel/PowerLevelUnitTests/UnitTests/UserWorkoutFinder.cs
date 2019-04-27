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
            Assert.AreEqual(RightNow.Day, getCurrentTime.Day);

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

        [TestMethod]
        public void test_stuff()
        {
            Mock<IToasterRepository> mock = new Mock<IToasterRepository>();
            mock.Setup(x => x.UserWorkouts).Returns(new UserWorkout[]
            {
                new UserWorkout { UWId = 1, UserId = 1, UserActiveWorkout = 2, ActiveWorkoutStage = 3, WorkoutCompleted = true }
            }.AsQueryable);
            UserWorkoutsController controller = new UserWorkoutsController(mock.Object);

            var result = controller.Create(1) as ViewResult;

            Assert.IsNotNull(result);

            /*
            Mock<IToasterRepository> mock = new Mock<IToasterRepository>();
            mock.Setup(x => x.UserWorkouts).Returns(new UserWorkout[]
            {
                new UserWorkout { UWId = 1, UserId = 1, UserActiveWorkout = 2, ActiveWorkoutStage = 3, WorkoutCompleted = true },
            new UserWorkout { UWId = 2, UserId = 1, UserActiveWorkout = 2, ActiveWorkoutStage = 2, WorkoutCompleted = false },
            new UserWorkout { UWId = 3, UserId = 2, UserActiveWorkout = 8, ActiveWorkoutStage = 5, WorkoutCompleted = false }
            }.AsQueryable());

            UserWorkoutsController controller = new UserWorkoutsController(mock.Object);

            controller.FinishedWorkout(mock.Object.UserWorkouts.First());

            Assert.AreEqual();
            */
        }
    }
}
