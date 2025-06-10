CREATE TABLE [dbo].[MaterialTransactions]
(
    [Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [TransactionType] int NOT NULL,
    [TransactionDate] datetime NOT NULL,
    [TransactionBy] int NOT NULL,
	[CompanyId] [int] NOT NULL,
	[PlantId] [int] NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[MaterialId] INT NOT NULL,
	[MeasurementUnit] nvarchar(10) NOT NULL,
    [Quantity] [decimal](18, 2) NOT NULL,

    check (Quantity >= 0),

    constraint [FK_MaterialTransactions_Companies] foreign key ([CompanyId]) references [dbo].[Companies]([Id]),
    constraint [FK_MaterialTransactions_Plants] foreign key ([PlantId]) references [dbo].[Plants]([Id]),
    constraint [FK_MaterialTransactions_Warehouses] foreign key ([WarehouseId]) references [dbo].[Warehouses]([Id]),
    constraint [FK_MaterialTransactions_Users] foreign key ([TransactionBy]) references [dbo].[Users]([Id]),
    constraint [FK_MaterialTransactions_Materials] foreign key ([MaterialId]) references [dbo].[Materials]([Id]),
    constraint [FK_MaterialTransactions_MeasurementUnits] foreign key ([MeasurementUnit]) references [dbo].[MeasurementUnits]([Code])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Malzeme stok hareketleri',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'MaterialTransactions',
    @level2type = NULL,
    @level2name = NULL