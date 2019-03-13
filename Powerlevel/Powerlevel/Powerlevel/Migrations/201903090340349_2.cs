namespace Powerlevel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExerciseEquipment",
                c => new
                    {
                        RequirementId = c.Int(nullable: false, identity: true),
                        ExerciseId = c.Int(nullable: false),
                        EquipmentName = c.String(maxLength: 64, fixedLength: true),
                    })
                .PrimaryKey(t => t.RequirementId)
                .ForeignKey("dbo.Exercise", t => t.ExerciseId, cascadeDelete: true)
                .Index(t => t.ExerciseId);
            
            CreateTable(
                "dbo.Exercise",
                c => new
                    {
                        ExerciseId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128, fixedLength: true),
                        Type = c.String(nullable: false, maxLength: 64, fixedLength: true),
                        MainMuscleWorked = c.String(nullable: false, maxLength: 64, fixedLength: true),
                        Instructions = c.String(nullable: false, maxLength: 3000),
                    })
                .PrimaryKey(t => t.ExerciseId);
            
            CreateTable(
                "dbo.ExerciseFlag",
                c => new
                    {
                        FlagId = c.Int(nullable: false, identity: true),
                        ExerciseId = c.Int(nullable: false),
                        FlagName = c.String(maxLength: 64, fixedLength: true),
                    })
                .PrimaryKey(t => t.FlagId)
                .ForeignKey("dbo.Exercise", t => t.ExerciseId, cascadeDelete: true)
                .Index(t => t.ExerciseId);
            
            CreateTable(
                "dbo.ExerciseImage",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ExerciseId = c.Int(nullable: false),
                        ImageName = c.String(nullable: false, maxLength: 128, fixedLength: true),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Exercise", t => t.ExerciseId, cascadeDelete: true)
                .Index(t => t.ExerciseId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Height = c.Int(),
                        Weight = c.Int(),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserWorkoutPlan",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Name = c.String(nullable: false, maxLength: 128),
                        Type = c.String(nullable: false, maxLength: 64),
                        Description = c.String(nullable: false),
                        DaysToComplete = c.Int(nullable: false),
                        NumberOfWorkouts = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanId);
            
            CreateTable(
                "dbo.WorkoutPlanWorkout",
                c => new
                    {
                        LinkID = c.Int(nullable: false, identity: true),
                        PlanId = c.Int(nullable: false),
                        WorkoutId = c.Int(nullable: false),
                        DayOfPlan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LinkID)
                .ForeignKey("dbo.Workout", t => t.WorkoutId, cascadeDelete: true)
                .ForeignKey("dbo.WorkoutPlan", t => t.PlanId, cascadeDelete: true)
                .ForeignKey("dbo.UserWorkoutPlan", t => t.PlanId, cascadeDelete: true)
                .Index(t => t.PlanId)
                .Index(t => t.WorkoutId);
            
            CreateTable(
                "dbo.Workout",
                c => new
                    {
                        WorkoutId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128, fixedLength: true),
                        Type = c.String(nullable: false, maxLength: 64, fixedLength: true),
                        MainMuscleFocus = c.String(nullable: false, maxLength: 64, fixedLength: true),
                        TimeEstimate = c.String(nullable: false, maxLength: 64, fixedLength: true),
                    })
                .PrimaryKey(t => t.WorkoutId);
            
            CreateTable(
                "dbo.WorkoutExercise",
                c => new
                    {
                        LinkId = c.Int(nullable: false, identity: true),
                        WorkoutId = c.Int(nullable: false),
                        ExerciseId = c.Int(nullable: false),
                        OrderNumber = c.Int(),
                    })
                .PrimaryKey(t => t.LinkId)
                .ForeignKey("dbo.Workout", t => t.WorkoutId, cascadeDelete: true)
                .Index(t => t.WorkoutId);
            
            CreateTable(
                "dbo.WorkoutPlan",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128, fixedLength: true),
                        Type = c.String(nullable: false, maxLength: 64, fixedLength: true),
                        Description = c.String(nullable: false, maxLength: 3000),
                        DaysToComplete = c.Int(nullable: false),
                        NumberOfWorkouts = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkoutPlanWorkout", "PlanId", "dbo.UserWorkoutPlan");
            DropForeignKey("dbo.WorkoutPlanWorkout", "PlanId", "dbo.WorkoutPlan");
            DropForeignKey("dbo.WorkoutPlanWorkout", "WorkoutId", "dbo.Workout");
            DropForeignKey("dbo.WorkoutExercise", "WorkoutId", "dbo.Workout");
            DropForeignKey("dbo.ExerciseImage", "ExerciseId", "dbo.Exercise");
            DropForeignKey("dbo.ExerciseFlag", "ExerciseId", "dbo.Exercise");
            DropForeignKey("dbo.ExerciseEquipment", "ExerciseId", "dbo.Exercise");
            DropIndex("dbo.WorkoutExercise", new[] { "WorkoutId" });
            DropIndex("dbo.WorkoutPlanWorkout", new[] { "WorkoutId" });
            DropIndex("dbo.WorkoutPlanWorkout", new[] { "PlanId" });
            DropIndex("dbo.ExerciseImage", new[] { "ExerciseId" });
            DropIndex("dbo.ExerciseFlag", new[] { "ExerciseId" });
            DropIndex("dbo.ExerciseEquipment", new[] { "ExerciseId" });
            DropTable("dbo.WorkoutPlan");
            DropTable("dbo.WorkoutExercise");
            DropTable("dbo.Workout");
            DropTable("dbo.WorkoutPlanWorkout");
            DropTable("dbo.UserWorkoutPlan");
            DropTable("dbo.User");
            DropTable("dbo.ExerciseImage");
            DropTable("dbo.ExerciseFlag");
            DropTable("dbo.Exercise");
            DropTable("dbo.ExerciseEquipment");
        }
    }
}
