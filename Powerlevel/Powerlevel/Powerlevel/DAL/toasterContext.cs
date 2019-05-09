namespace Powerlevel.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class toasterContext : DbContext
    {
        public toasterContext()
            : base("name=toaster")
        {
        }

        public virtual DbSet<Avatar> Avatars { get; set; }
        public virtual DbSet<AvatarUnlock> AvatarUnlocks { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<ExerciseEquipment> ExerciseEquipments { get; set; }
        public virtual DbSet<ExerciseFlag> ExerciseFlags { get; set; }
        public virtual DbSet<ExerciseImage> ExerciseImages { get; set; }
        public virtual DbSet<LevelExp> LevelExps { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAvatar> UserAvatars { get; set; }
        public virtual DbSet<UserWorkout> UserWorkouts { get; set; }
        public virtual DbSet<UserWorkoutPlan> UserWorkoutPlans { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }
        public virtual DbSet<WorkoutEvent> WorkoutEvents { get; set; }
        public virtual DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public virtual DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public virtual DbSet<WorkoutPlanWorkout> WorkoutPlanWorkouts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Type)
                .IsFixedLength();

            modelBuilder.Entity<Exercise>()
                .Property(e => e.MainMuscleWorked)
                .IsFixedLength();

            modelBuilder.Entity<ExerciseEquipment>()
                .Property(e => e.EquipmentName)
                .IsFixedLength();

            modelBuilder.Entity<ExerciseFlag>()
                .Property(e => e.FlagName)
                .IsFixedLength();

            modelBuilder.Entity<ExerciseImage>()
                .Property(e => e.ImageName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.WorkoutEvents)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Workout>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Workout>()
                .Property(e => e.Type)
                .IsFixedLength();

            modelBuilder.Entity<Workout>()
                .Property(e => e.MainMuscleFocus)
                .IsFixedLength();

            modelBuilder.Entity<Workout>()
                .Property(e => e.TimeEstimate)
                .IsFixedLength();

            modelBuilder.Entity<Workout>()
                .HasMany(e => e.UserWorkouts)
                .WithRequired(e => e.Workout)
                .HasForeignKey(e => e.UserActiveWorkout);

            modelBuilder.Entity<Workout>()
                .HasMany(e => e.WorkoutEvents)
                .WithRequired(e => e.Workout)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkoutEvent>()
                .Property(e => e.Title)
                .IsFixedLength();

            modelBuilder.Entity<WorkoutPlan>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<WorkoutPlan>()
                .Property(e => e.Type)
                .IsFixedLength();
        }
    }
}
