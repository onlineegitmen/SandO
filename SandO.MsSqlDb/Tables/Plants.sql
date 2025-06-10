CREATE TABLE [dbo].[Plants]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(100) NOT NULL,
	[Code] NVARCHAR(10) NOT NULL,
	[Description] NVARCHAR(1000) NULL,
	[CreatedOn] DATETIME NOT NULL default getdate(),
	[CreatedBy] int NOT NULL,

	constraint [UC_Plants_Name] unique ([Name]),
	constraint [UC_Plants_Code] unique ([Code]),

	constraint [FK_Plants_CreatedBy] foreign key ([CreatedBy]) references [dbo].[Users]([Id]),

	check ([CreatedOn] <= getdate())
)
