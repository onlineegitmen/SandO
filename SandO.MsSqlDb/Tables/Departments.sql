CREATE TABLE [dbo].[Departments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(1000) NULL,
	[CreatedOn] DATETIME NOT NULL DEFAULT GETDATE(),
	[CreatedBy] int NOT NULL,

	constraint [UQ_Departments_Name] unique ([Name]),

	constraint [FK_Departments_Users_CreatedBy] foreign key ([CreatedBy]) references [dbo].[Users]([Id]),

	check ([CreatedOn] <= GETDATE())
)
