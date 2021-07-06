CREATE TABLE [dbo].[Project] (
    [ProjectID]         INT             IDENTITY (1, 1) NOT NULL,
    [VehicleID]         INT             NOT NULL,
    [Name]              NVARCHAR (MAX)  NULL,
    [Description]       NVARCHAR (MAX)  NULL,
    [UserCategoryID]    INT             NULL,
    [TargetCost]        DECIMAL (10, 2) NULL,
    [ActualCost]        DECIMAL (10, 2) NULL,
    [StartDate]         DATETIME2 (7)   NULL,
    [TargetEndDate]     DATETIME2 (7)   NULL,
    [ActualEndDate]     DATETIME2 (7)   NULL,
    [IsPublic]          BIT             NOT NULL,
    [IsCostPublic]      BIT             NOT NULL,
    [IsDeleted]         BIT             NOT NULL,
    [ParentProjectID]   INT             NULL,
    [ProjectStatusID]   INT             DEFAULT ((1)) NOT NULL,
    [InstallationNotes] NVARCHAR (MAX)  NULL,
    [LastUpdate]        DATETIME2 (7)   DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED ([ProjectID] ASC),
    CONSTRAINT [FK_Project_Project_ParentProjectID] FOREIGN KEY ([ParentProjectID]) REFERENCES [dbo].[Project] ([ProjectID]),
    CONSTRAINT [FK_Project_ProjectStatus_ProjectStatusID] FOREIGN KEY ([ProjectStatusID]) REFERENCES [dbo].[ProjectStatus] ([ProjectStatusID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Project_UserCategory_UserCategoryID] FOREIGN KEY ([UserCategoryID]) REFERENCES [dbo].[UserCategory] ([UserCategoryID]),
    CONSTRAINT [FK_Project_Vehicle_VehicleID] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicle] ([VehicleID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Project_ProjectStatusID]
    ON [dbo].[Project]([ProjectStatusID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Project_ParentProjectID]
    ON [dbo].[Project]([ParentProjectID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Project_VehicleID]
    ON [dbo].[Project]([VehicleID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Project_UserCategoryID]
    ON [dbo].[Project]([UserCategoryID] ASC);

