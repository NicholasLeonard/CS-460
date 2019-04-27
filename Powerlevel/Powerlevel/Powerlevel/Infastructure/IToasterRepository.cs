using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Powerlevel.Models;
using System.Data.Entity;

namespace Powerlevel.Infastructure
{
     public interface IToasterRepository
    {
          
        IQueryable<WorkoutEvent> WorkoutEvents { get; }
        IQueryable<Exercise> Exercises { get;  }
        IQueryable<ExerciseEquipment> ExerciseEquipments { get;  }
        IQueryable<ExerciseFlag> ExerciseFlags { get;  }
        IQueryable<ExerciseImage> ExerciseImages { get;  }
        IQueryable<LevelExp> LevelExps { get;  }
        IQueryable<User> Users { get;  }
        IQueryable<UserWorkout> UserWorkouts { get;  }
        IQueryable<UserWorkoutPlan> UserWorkoutPlans { get;  }
        IQueryable<Workout> Workouts { get;  }
        IQueryable<WorkoutExercise> WorkoutExercises { get;  }
        IQueryable<WorkoutPlan> WorkoutPlans { get;  }
        IQueryable<WorkoutPlanWorkout> WorkoutPlanWorkouts { get;  }
        void Dispose(bool disposing);
    }
}
