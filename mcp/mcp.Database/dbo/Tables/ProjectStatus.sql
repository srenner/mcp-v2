CREATE TABLE [dbo].[ProjectStatus] (
    [ProjectStatusID] INT            NOT NULL,
    [Name]            NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ProjectStatus] PRIMARY KEY CLUSTERED ([ProjectStatusID] ASC)
);

