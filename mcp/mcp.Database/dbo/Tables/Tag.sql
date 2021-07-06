CREATE TABLE [dbo].[Tag] (
    [TagID]       INT            NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [SortOrder]   INT            NOT NULL,
    [IsDeleted]   BIT            NOT NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED ([TagID] ASC)
);

