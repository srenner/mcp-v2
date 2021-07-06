CREATE TABLE [dbo].[VehicleModification] (
    [VehicleModificationID] INT            IDENTITY (1, 1) NOT NULL,
    [VehicleID]             INT            NOT NULL,
    [UserCategoryID]        INT            NULL,
    [Name]                  NVARCHAR (MAX) NULL,
    [Description]           NVARCHAR (MAX) NULL,
    [SortOrder]             INT            NOT NULL,
    [IsHighlighted]         BIT            NOT NULL,
    CONSTRAINT [PK_VehicleModification] PRIMARY KEY CLUSTERED ([VehicleModificationID] ASC),
    CONSTRAINT [FK_VehicleModification_UserCategory_UserCategoryID] FOREIGN KEY ([UserCategoryID]) REFERENCES [dbo].[UserCategory] ([UserCategoryID]),
    CONSTRAINT [FK_VehicleModification_Vehicle_VehicleID] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicle] ([VehicleID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_VehicleModification_VehicleID]
    ON [dbo].[VehicleModification]([VehicleID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_VehicleModification_UserCategoryID]
    ON [dbo].[VehicleModification]([UserCategoryID] ASC);

