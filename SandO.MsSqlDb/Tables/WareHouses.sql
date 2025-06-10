CREATE TABLE [dbo].[WareHouses]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(100) NOT NULL,
	[Code] NVARCHAR(10) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	[IsActive] BIT NOT NULL DEFAULT 1,
	[CreatedOn] DATETIME NOT NULL DEFAULT GETDATE(),
	[CreatedBy] int NOT NULL,

	constraint [UQ_WareHouses_Code] unique ([Code]),
	constraint [UQ_WareHouses_Name] unique ([Name]),

	constraint [FK_WareHouses_CreatedBy] foreign key ([CreatedBy]) references [dbo].[Users]([Id]),

	check ([CreatedOn] <= GETDATE())
)
