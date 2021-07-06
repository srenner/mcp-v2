CREATE TABLE [dbo].[ProjectChecklistItem] (
    [ProjectChecklistItemID] INT            IDENTITY (1, 1) NOT NULL,
    [ProjectID]              INT            NOT NULL,
    [Description]            NVARCHAR (MAX) NULL,
    [SortOrder]              INT            NOT NULL,
    [CheckedDateTime]        DATETIME2 (7)  NULL,
    [IsChecked]              BIT            DEFAULT (CONVERT([bit],(0))) NOT NULL,
    CONSTRAINT [PK_ProjectChecklistItem] PRIMARY KEY CLUSTERED ([ProjectChecklistItemID] ASC),
    CONSTRAINT [FK_ProjectChecklistItem_Project_ProjectID] FOREIGN KEY ([ProjectID]) REFERENCES [dbo].[Project] ([ProjectID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectChecklistItem_ProjectID]
    ON [dbo].[ProjectChecklistItem]([ProjectID] ASC);

