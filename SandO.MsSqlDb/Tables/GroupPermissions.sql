CREATE TABLE [dbo].[GroupPermissions]
(
	[GroupId] INT NOT NULL,
	[PermissionClass] INT NOT NULL,
	[PermissionEvent] INT NOT NULL,
	[NeedParameters] BIT NOT NULL,

	CONSTRAINT [PK_GroupPermissions] PRIMARY KEY CLUSTERED ([GroupId], [PermissionClass], [PermissionEvent]),
	CONSTRAINT [FK_GroupPermissions_Groups] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id]),
)
