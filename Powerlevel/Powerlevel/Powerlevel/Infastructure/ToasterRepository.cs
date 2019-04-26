using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Powerlevel.Infastructure;
using Powerlevel.Models;
using System.Data.Entity;

namespace Powerlevel.Infastructure
{
    public class ToasterRepository : IToasterRepository
    {
        private toasterContext db = new toasterContext();

        
        public IQueryable<WorkoutEvent> WorkoutEvents{ get { return db.WorkoutEvents; } }
        public IQueryable<Exercise> Exercises { get { return db.Exercises; } }
        public IQueryable<ExerciseEquipment> ExerciseEquipments { get { return db.ExerciseEquipments; } }
        public IQueryable<ExerciseFlag> ExerciseFlags { get { return db.ExerciseFlags; } }
        public IQueryable<ExerciseImage> ExerciseImages { get { return db.ExerciseImages; } }
        public IQueryable<LevelExp> LevelExps { get { return db.LevelExps; } }
        public IQueryable<User> Users { get { return db.Users; } }
        public IQueryable<UserWorkout> UserWorkouts { get { return db.UserWorkouts; } }
        public IQueryable<UserWorkoutPlan> UserWorkoutPlans { get { return db.UserWorkoutPlans; } }
        public IQueryable<Workout> Workouts { get { return db.Workouts; } }
        public IQueryable<WorkoutExercise> WorkoutExercises { get { return db.WorkoutExercises; } }
        public IQueryable<WorkoutPlan> WorkoutPlans { get { return db.WorkoutPlans; } }
        public IQueryable<WorkoutPlanWorkout> WorkoutPlanWorkouts { get { return db.WorkoutPlanWorkouts; } }
    }
}