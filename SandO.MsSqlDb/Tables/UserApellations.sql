CREATE TABLE [dbo].[UserApellations]
(
	[Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UserId] int NOT NULL,
	[CompanyId] int NOT NULL,
	[PlantId] int NULL,
	[DepartmentId] int NULL,
	[ApellationId] int NOT NULL,
	[IsPrimary] bit NOT NULL DEFAULT 0,
	[BeginDate] datetime NOT NULL DEFAULT GETDATE(),
	[EndDate] datetime not null DEFAULT '9999-12-31',

	[CreatedBy] int NOT NULL,
	[CreatedDate] datetime NOT NULL DEFAULT GETDATE(),

	check ([BeginDate] <= [EndDate]),
	check ([CreatedDate] <= getdate()),

	constraint [FK_UserApellations_Users] foreign key ([UserId]) references [dbo].[Users]([Id]),
	constraint [FK_UserApellations_Companies] foreign key ([CompanyId]) references [dbo].[Companies]([Id]),
	constraint [FK_UserApellations_Plants] foreign key ([PlantId]) references [dbo].[Plants]([Id]),
	constraint [FK_UserApellations_Departments] foreign key ([DepartmentId]) references [dbo].[Departments]([Id]),
	constraint [FK_UserApellations_Apellations] foreign key ([ApellationId]) references [dbo].[Apellations]([Id]),
	constraint [FK_UserApellations_Users_CreatedBy] foreign key ([CreatedBy]) references [dbo].[Users]([Id]),

	constraint [UQ_UserApellations_UserId_ApellationId] unique ([UserId], [CompanyId], [PlantId], [DepartmentId], [ApellationId])
)
