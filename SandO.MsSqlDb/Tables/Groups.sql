CREATE TABLE [dbo].[Groups]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(100) NOT NULL,
	[Active] BIT NOT NULL,
	[IsReadOnly] BIT NOT NULL,
	[Description] NVARCHAR(1000) NULL,
	[CreatedOn] DATETIME NOT NULL DEFAULT getdate(),
	[CreatedBy] int NOT NULL,
	[ModifiedOn] DATETIME NULL,
	[ModifiedBy] int NULL,

	constraint [UQ_Groups_Name] unique ([Name]),


	constraint [FK_Groups_Users_CreatedBy] foreign key ([CreatedBy]) references [dbo].[Users]([Id]),
	constraint [FK_Groups_Users_ModifiedBy] foreign key ([ModifiedBy]) references [dbo].[Users]([Id]),

	check ([CreatedOn] <= getdate()),
	check ([ModifiedOn] is null and [ModifiedBy] is null or [ModifiedOn] is not null and [ModifiedBy] is not null),
	check ([ModifiedOn] is null or [ModifiedOn] > [CreatedOn])
)
