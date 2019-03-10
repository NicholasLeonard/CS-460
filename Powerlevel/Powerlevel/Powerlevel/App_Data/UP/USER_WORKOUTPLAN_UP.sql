CREATE TABLE [dbo].[UserWorkoutPlan] 
(
    [PlanId] INT IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR(256) NOT NULL,
    [Name] NCHAR(64) NOT NULL,
    [Type] NCHAR(64) NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    [DaysToComplete] INT NOT NULL,
    [NumberOfWorkouts] INT NOT NULL, 
 	CONSTRAINT [PK_dbo.UserWorkoutPlan] PRIMARY KEY CLUSTERED ([PlanId] ASC)
);

