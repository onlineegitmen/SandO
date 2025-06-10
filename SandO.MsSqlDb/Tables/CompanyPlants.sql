CREATE TABLE [dbo].[CompanyPlants]
(
	[CompanyId] int NOT NULL,
	[PlantId] int NOT NULL,

	CONSTRAINT [PK_CompanyPlants] PRIMARY KEY CLUSTERED ([CompanyId], [PlantId]),

	CONSTRAINT [FK_CompanyPlants_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([Id]),
	CONSTRAINT [FK_CompanyPlants_Plants] FOREIGN KEY ([PlantId]) REFERENCES [dbo].[Plants] ([Id])
)
