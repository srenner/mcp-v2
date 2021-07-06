CREATE TABLE [dbo].[Vehicle] (
    [VehicleID]               INT             IDENTITY (1, 1) NOT NULL,
    [UserID]                  NVARCHAR (450)  NULL,
    [Name]                    NVARCHAR (MAX)  NULL,
    [PurchaseDate]            DATETIME2 (7)   NULL,
    [PurchasePrice]           DECIMAL (10, 2) NULL,
    [TotalInvested]           DECIMAL (10, 2) NULL,
    [EstimatedValue]          DECIMAL (10, 2) NULL,
    [IsForSale]               BIT             NOT NULL,
    [ForSaleLink]             NVARCHAR (MAX)  NULL,
    [ForSaleAskingPrice]      DECIMAL (10, 2) NULL,
    [ForSaleTransactionPrice] DECIMAL (10, 2) NULL,
    [IsSold]                  BIT             NOT NULL,
    [IsDeleted]               BIT             NOT NULL,
    [Notes]                   NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED ([VehicleID] ASC),
    CONSTRAINT [FK_Vehicle_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_UserID]
    ON [dbo].[Vehicle]([UserID] ASC);

