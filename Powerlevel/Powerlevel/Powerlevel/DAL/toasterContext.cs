namespace Powerlevel.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class toasterContext : DbContext
    {
        public toasterContext()
            : base("name=toasterContext")
        {
        }

        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<ExerciseEquipment> ExerciseEquipments { get; set; }
        public virtual DbSet<ExerciseFlag> ExerciseFlags { get; set; }
        public virtual DbSet<ExerciseImage> ExerciseImages { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserWorkout> UserWorkouts { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }
        public virtual DbSet<WorkoutExercise> WorkoutExercises { get; set; }

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

            modelBuilder.Entity<Plan>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Plan>()
                .Property(e => e.Type)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserWorkouts)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UsernameId);

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
        }
    }
}
