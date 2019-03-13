using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Powerlevel.Models.ViewModels
{
    public class WorkoutPlanVM
    {
        //declare this function to get access to the WorkoutExercise table data.
        public IEnumerable<WorkoutExercise> WorkoutExercises { get; set; }

        //declare this function to get access to the WorkoutPlan table data.
        public List<WorkoutPlan> WorkoutPlans { get; set; }


        public int WorkoutName { get; set; }

    }
}