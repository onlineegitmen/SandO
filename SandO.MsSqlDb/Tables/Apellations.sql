CREATE TABLE [dbo].[Apellations]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(1000) NULL,
	[CreatedOn] DATETIME NOT NULL DEFAULT GETDATE(),
	[CreatedBy] int NOT NULL,

	constraint [UQ_Apellations_Name] unique ([Name]),

	constraint [FK_Apellations_Users_CreatedBy] foreign key ([CreatedBy]) references [dbo].[Users]([Id]),

	check ([CreatedOn] <= GETDATE())
)
