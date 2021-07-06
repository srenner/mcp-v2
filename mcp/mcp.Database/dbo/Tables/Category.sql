CREATE TABLE [dbo].[Category] (
    [CategoryID] INT            NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [SortOrder]  INT            NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([CategoryID] ASC)
);

