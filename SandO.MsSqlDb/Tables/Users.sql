CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[IdentityId] CHAR(11) NOT NULL,
	[Username] NVARCHAR(100) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Surname] NVARCHAR(100) NOT NULL,
	[CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
	[CreatedBy] int null,
	[Active] BIT NOT NULL DEFAULT 1,
	[Deleted] BIT NOT NULL DEFAULT 0,

	[UpdatedAt] DATETIME null,
	[UpdatedBy] int null,

	[DeletedAt] DATETIME null,
	[DeletedBy] int null,

	[FullName] AS concat_ws(' ', [Name], [Surname]), 

	constraint [UQ_Users_IdentityId] unique ([IdentityId]),
	constraint [UQ_Users_Username] unique ([Username]),

	constraint [FK_Users_CreatedBy] foreign key ([CreatedBy]) references [dbo].[Users]([Id]),

	check ([IdentityId] like '[1-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	check ([Username] = 'admin' or [CreatedBy] is not null),
	check ([UpdatedAt] is null and [UpdatedBy] is null or [UpdatedAt] is not null and [UpdatedBy] is not null),
	check([CreatedAt] <= getdate()),
	check([UpdatedAt] is null or [UpdatedAt] >= [CreatedAt]),
	check([DeletedAt] is null or [DeletedAt] >= [CreatedAt]),
	check([DeletedAt] is null and [DeletedBy] is null or [DeletedAt] is not null and [DeletedBy] is not null),
	CHECK (([Deleted] = 0 AND [Active] IN (0, 1)) OR ([Deleted] = 1 AND [Active] = 0))
)
