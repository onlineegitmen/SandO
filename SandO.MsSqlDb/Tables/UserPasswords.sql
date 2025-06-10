CREATE TABLE [dbo].[UserPasswords]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	[UserId] INT NOT NULL,
	[Password] NVARCHAR(255) NOT NULL,
	[CreatedAt] DATETIME NOT NULL,
	[ExpiresAt] DATETIME NOT NULL default '9999-12-31 23:59:59',
	[Active] BIT NOT NULL default 1,
	[IsExpired] as case when (ExpiresAt < getdate() and Active = 0 ) then 1 else 0 end,

	CONSTRAINT [FK_UserPasswords_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users]([Id])
)
