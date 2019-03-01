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

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<ExerciseEquipment> ExerciseEquipments { get; set; }
        public virtual DbSet<ExerciseFlag> ExerciseFlags { get; set; }
        public virtual DbSet<ExerciseImage> ExerciseImages { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<WorkoutPlan> Plans { get; set; }
        public virtual DbSet<WorkoutPlanWorkout> PlanWorkouts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserWorkout> UserWorkouts { get; set; }
        public virtual DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.UserWorkouts)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UsernameId);

            modelBuilder.Entity<ExerciseImage>()
                .Property(e => e.ImageName)
                .IsFixedLength();

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Type)
                .IsFixedLength();

            modelBuilder.Entity<Exercise>()
                .Property(e => e.MainMuscleWorked)
                .IsFixedLength();

            modelBuilder.Entity<WorkoutPlan>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<WorkoutPlan>()
                .Property(e => e.Type)
                .IsFixedLength();

            modelBuilder.Entity<WorkoutPlanWorkout>()
                .HasMany(e => e.UserWorkouts)
                .WithRequired(e => e.PlanWorkout)
                .HasForeignKey(e => e.UserCurrentPlan);

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
