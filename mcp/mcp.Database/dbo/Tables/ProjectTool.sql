CREATE TABLE [dbo].[ProjectTool] (
    [ProjectToolID]     INT             IDENTITY (1, 1) NOT NULL,
    [ProjectID]         INT             NOT NULL,
    [Name]              NVARCHAR (MAX)  NULL,
    [Description]       NVARCHAR (MAX)  NULL,
    [Manufacturer]      NVARCHAR (MAX)  NULL,
    [PartNumber]        NVARCHAR (MAX)  NULL,
    [Price]             DECIMAL (10, 2) NULL,
    [AppliedPrice]      DECIMAL (10, 2) NULL,
    [Link]              NVARCHAR (MAX)  NULL,
    [Quantity]          INT             DEFAULT ((1)) NOT NULL,
    [QuantityPurchased] INT             NOT NULL,
    [IsDeleted]         BIT             NOT NULL,
    CONSTRAINT [PK_ProjectTool] PRIMARY KEY CLUSTERED ([ProjectToolID] ASC),
    CONSTRAINT [FK_ProjectTool_Project_ProjectID] FOREIGN KEY ([ProjectID]) REFERENCES [dbo].[Project] ([ProjectID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectTool_ProjectID]
    ON [dbo].[ProjectTool]([ProjectID] ASC);

