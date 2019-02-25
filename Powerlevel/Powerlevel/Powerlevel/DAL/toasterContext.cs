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

        public virtual DbSet<ExerciseEquipment> ExerciseEquipments { get; set; }
        public virtual DbSet<ExerciseFlag> ExerciseFlags { get; set; }
        public virtual DbSet<ExerciseImage> ExerciseImages { get; set; }
        public virtual DbSet<Exercis> Exercises { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<PlanWorkout> PlanWorkouts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkoutExercis> WorkoutExercises { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseImage>()
                .Property(e => e.ImageName)
                .IsFixedLength();

            modelBuilder.Entity<Exercis>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Exercis>()
                .Property(e => e.Type)
                .IsFixedLength();

            modelBuilder.Entity<Exercis>()
                .Property(e => e.MainMuscleWorked)
                .IsFixedLength();

            modelBuilder.Entity<Plan>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Plan>()
                .Property(e => e.Type)
                .IsFixedLength();

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
