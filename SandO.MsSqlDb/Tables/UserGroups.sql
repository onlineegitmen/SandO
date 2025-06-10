CREATE TABLE [dbo].[UserGroups]
(
	[UserId] INT NOT NULL,
	[GroupId] INT NOT NULL,

	constraint [PK_UserGroups] primary key clustered ([UserId], [GroupId]),

	constraint [FK_UserGroups_Users] foreign key ([UserId]) references [dbo].[Users] ([Id]),
	constraint [FK_UserGroups_Groups] foreign key ([GroupId]) references [dbo].[Groups] ([Id])
)
