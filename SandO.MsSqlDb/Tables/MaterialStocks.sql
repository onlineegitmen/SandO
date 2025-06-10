CREATE TABLE [dbo].[MaterialStocks]
(
	[CompanyId] [int] NOT NULL,
	[PlantId] [int] NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[MaterialId] INT NOT NULL,
	[MeasurementUnit] [nvarchar](10) NOT NULL,
	[Stock] [decimal](18, 2) NOT NULL,

	check ([Stock] >= 0),

	CONSTRAINT [PK_MaterialStocks] PRIMARY KEY CLUSTERED ([CompanyId] ASC, [PlantId] ASC, [WarehouseId] ASC, [MaterialId] ASC, [MeasurementUnit] ASC),

	CONSTRAINT [FK_MaterialStocks_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([Id]),
	CONSTRAINT [FK_MaterialStocks_Plants] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Plants] ([Id]),
	CONSTRAINT [FK_MaterialStocks_Warehouses] FOREIGN KEY ([WarehouseId]) REFERENCES [dbo].[Warehouses] ([Id]),
	CONSTRAINT [FK_MaterialStocks_Materials] FOREIGN KEY ([MaterialId]) REFERENCES [dbo].[Materials] ([Id]),
	CONSTRAINT [FK_MaterialStocks_MeasurementUnits] FOREIGN KEY ([MeasurementUnit]) REFERENCES [dbo].[MeasurementUnits] ([Code])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Üretim yerleri için malzeme stokları',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'MaterialStocks',
    @level2type = NULL,
    @level2name = NULL