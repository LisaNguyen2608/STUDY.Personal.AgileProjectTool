CREATE TABLE [dbo].[PERSON] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) NOT NULL,
    [Role] NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);        
CREATE TABLE [dbo].[PROJECT] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100) NOT NULL,
    [Description] NVARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[PROJECT_TEAM] (
    [ProjectId] INT NOT NULL,
    [PersonId]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ProjectId] ASC, [PersonId] ASC),
    FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[PROJECT] ([Id]),
    FOREIGN KEY ([PersonId]) REFERENCES [dbo].[PERSON] ([Id])
);

CREATE TABLE [dbo].[USER_STORY] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ProjectId]   INT            NOT NULL,
    [Description] NVARCHAR (500) NULL,
    [State]       INT            NOT NULL,
    [Priority]    INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[PROJECT] ([Id])

);
CREATE TABLE [dbo].[TASK] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [UserStoryId]      INT             NOT NULL,
    [Description]      NVARCHAR (500)  NULL,
    [State]            INT             NOT NULL,
    [Priority]         INT             NULL,
    [Difficulty]       INT             NULL,
    [PlannedStartDate] DATETIME        NULL,
    [PlannedEndDate]   DATETIME        NULL,
    [ActualStartDate]  DATETIME        NULL,
    [ActualEndDate]    DATETIME        NULL,
    [PlannedTime]      DECIMAL (10, 2) NULL,
    [ActualTime]       DECIMAL (10, 2) NULL,
    [Category]         NVARCHAR (100)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserStoryId]) REFERENCES [dbo].[USER_STORY] ([Id])
);
CREATE TABLE [dbo].[TASK_ASSIGNMENT] (
    [TaskId]   INT NOT NULL,
    [PersonId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([TaskId] ASC, [PersonId] ASC),
    FOREIGN KEY ([TaskId]) REFERENCES [dbo].[TASK] ([Id]),
    FOREIGN KEY ([PersonId]) REFERENCES [dbo].[PERSON] ([Id])
);

CREATE TABLE [dbo].[STORY_DEPENDENCY] (
    [StoryId]          INT NOT NULL,
    [DependsOnStoryId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([StoryId] ASC, [DependsOnStoryId] ASC),
    FOREIGN KEY ([StoryId]) REFERENCES [dbo].[USER_STORY] ([Id]),
    FOREIGN KEY ([DependsOnStoryId]) REFERENCES [dbo].[USER_STORY] ([Id])
);