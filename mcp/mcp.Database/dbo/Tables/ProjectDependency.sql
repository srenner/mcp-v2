CREATE TABLE [dbo].[ProjectDependency] (
    [ProjectDependencyID] INT IDENTITY (1, 1) NOT NULL,
    [DependsOnProjectID]  INT DEFAULT ((0)) NOT NULL,
    [ProjectID]           INT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ProjectDependency] PRIMARY KEY CLUSTERED ([ProjectDependencyID] ASC),
    CONSTRAINT [FK_ProjectDependency_Project_DependsOnProjectID] FOREIGN KEY ([DependsOnProjectID]) REFERENCES [dbo].[Project] ([ProjectID]),
    CONSTRAINT [FK_ProjectDependency_Project_ProjectID] FOREIGN KEY ([ProjectID]) REFERENCES [dbo].[Project] ([ProjectID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectDependency_ProjectID]
    ON [dbo].[ProjectDependency]([ProjectID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectDependency_DependsOnProjectID]
    ON [dbo].[ProjectDependency]([DependsOnProjectID] ASC);

