using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Powerlevel.Models.ViewModels
{
    public class WorkoutVM
    {
        //this is the id of the active workout for a user
        public int UWId { get; set; }

        //Active Workout Stage passed into Progress view to do math and other things
        public int ActiveWorkoutStage { get; set; }

        //Max Workout Stage passed into Progress view to determine when the last workout will appear
        public int MaxWorkoutStage { get; set; }

        //Gets the Users Active Workout to the view
        public int UserActiveWorkout { get; set; }

        //Workout Name passed into Progress view to display on top of page
        public string WorkoutName { get; set; }

        //this is the current exercise in the current workout that the user is doing
        public virtual Exercise CurrentExercise { get; set; }
    }
}