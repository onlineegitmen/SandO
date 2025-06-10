CREATE TABLE [dbo].[Companies]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(100) NOT NULL,
	[Code] NVARCHAR(10) NOT NULL,
	[Active] BIT NOT NULL DEFAULT 1,
	[Description] NVARCHAR(500) NULL,
	[Guid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

	[CreatedOn] DATETIME NOT NULL DEFAULT GETDATE(),
	[CreatedBy] int NOT NULL,

	[ModifiedOn] DATETIME NULL,
	[ModifiedBy] int NULL,

	CONSTRAINT [UQ_Companies_Name] UNIQUE ([Name]),
	CONSTRAINT [UQ_Companies_Code] UNIQUE ([Code]),
	CONSTRAINT [UQ_Companies_Guid] UNIQUE ([Guid]),

	CONSTRAINT [FK_Companies_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users]([Id]),
	CONSTRAINT [FK_Companies_ModifiedBy] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[Users]([Id]),

	CHECK (ModifiedOn IS NULL AND ModifiedBy IS NULL OR ModifiedOn IS NOT NULL AND ModifiedBy IS NOT NULL),
	check(ModifiedOn IS NULL or ModifiedOn >= CreatedOn),
	check(createdOn <= getdate()) 
)
