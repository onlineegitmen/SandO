CREATE TABLE [dbo].[PermissionParameters]
(
	[GroupId] INT NOT NULL,
	[PermissionClass] INT NOT NULL,
	[PermissionEvent] INT NOT NULL,
	[Parameter] int NOT NULL,
	[Value] NVARCHAR(255) NOT NULL,

	CONSTRAINT [PK_PermissionParameters] PRIMARY KEY CLUSTERED ([GroupId], [PermissionClass], [PermissionEvent], [Parameter], [Value]),

	CONSTRAINT [FK_PermissionParameters_GroupPermissions] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id]),
)
