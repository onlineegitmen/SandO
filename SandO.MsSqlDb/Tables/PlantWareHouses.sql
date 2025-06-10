CREATE TABLE [dbo].[PlantWareHouses]
(
	[PlantId] INT NOT NULL,
	[WareHouseId] INT NOT NULL,

	constraint [PK_PlantWareHouses] primary key ([PlantId], [WareHouseId]),

	constraint [FK_PlantWareHouses_PlantId] foreign key ([PlantId]) references [dbo].[Plants]([Id]),
	constraint [FK_PlantWareHouses_WareHouseId] foreign key ([WareHouseId]) references [dbo].[WareHouses]([Id])
)
