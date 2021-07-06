CREATE TABLE [dbo].[ProjectPart] (
    [ProjectPartID]     INT             IDENTITY (1, 1) NOT NULL,
    [ProjectID]         INT             NOT NULL,
    [Name]              NVARCHAR (MAX)  NULL,
    [Description]       NVARCHAR (MAX)  NULL,
    [Price]             DECIMAL (10, 2) NULL,
    [Link]              NVARCHAR (MAX)  NULL,
    [Quantity]          INT             CONSTRAINT [DF__ProjectPa__Quant__6383C8BA] DEFAULT ((1)) NOT NULL,
    [QuantityPurchased] INT             DEFAULT ((0)) NOT NULL,
    [Manufacturer]      NVARCHAR (MAX)  NULL,
    [PartNumber]        NVARCHAR (MAX)  NULL,
    [QuantityInstalled] INT             DEFAULT ((0)) NOT NULL,
    [ExtraCost]         DECIMAL (10, 2) NULL,
    [ExcludeFromTotal]  BIT             DEFAULT (CONVERT([bit],(0))) NOT NULL,
    CONSTRAINT [PK_ProjectPart] PRIMARY KEY CLUSTERED ([ProjectPartID] ASC),
    CONSTRAINT [FK_ProjectPart_Project_ProjectID] FOREIGN KEY ([ProjectID]) REFERENCES [dbo].[Project] ([ProjectID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectPart_ProjectID]
    ON [dbo].[ProjectPart]([ProjectID] ASC);

