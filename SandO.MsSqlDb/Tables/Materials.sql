CREATE TABLE [dbo].[Materials]
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Code] nvarchar(40) NOT NULL,
	[GroupId] INT NOT NULL,
	[Name] varchar(100) NOT NULL,
	[Description] varchar(500) NULL,
	[MainMeasureUnit] nvarchar(10) NOT NULL,
	[GrossWeight] decimal(18, 2) NULL,
	[NetWeight] decimal(18, 2) NULL,

	[CreatedAt] datetime NOT NULL,
	[CreatedBy] int NOT NULL,

	check ([CreatedAt] <= getdate()),
	check ([GrossWeight] >= 0),
	check ([NetWeight] >= 0),

	constraint [UQ_Materials_Code] unique ([Code]),

	constraint [FK_Materials_GroupId] foreign key ([GroupId]) references [dbo].[MaterialGroups]([Id]),
	constraint [FK_Materials_CreatedBy] foreign key ([CreatedBy]) references [dbo].[Users]([Id]),
	constraint [FK_Materials_MainMeasureUnit] foreign key ([MainMeasureUnit]) references [dbo].[MeasurementUnits]([Code])
)
