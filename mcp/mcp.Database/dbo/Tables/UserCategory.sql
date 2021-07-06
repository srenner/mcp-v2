CREATE TABLE [dbo].[UserCategory] (
    [UserCategoryID] INT            IDENTITY (1, 1) NOT NULL,
    [CategoryID]     INT            NULL,
    [UserID]         NVARCHAR (450) NULL,
    [Name]           NVARCHAR (MAX) NULL,
    [SortOrder]      INT            NOT NULL,
    [IsDeleted]      BIT            NOT NULL,
    CONSTRAINT [PK_UserCategory] PRIMARY KEY CLUSTERED ([UserCategoryID] ASC),
    CONSTRAINT [FK_UserCategory_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_UserCategory_Category_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Category] ([CategoryID])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserCategory_UserID]
    ON [dbo].[UserCategory]([UserID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserCategory_CategoryID]
    ON [dbo].[UserCategory]([CategoryID] ASC);

