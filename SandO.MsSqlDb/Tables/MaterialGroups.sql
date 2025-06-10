CREATE TABLE [dbo].[MaterialGroups]
(
    [Id] int NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Code] nvarchar(40) NOT NULL,
    [Name] varchar(100) NOT NULL,

    [CreatedAt] datetime NOT NULL,
    [CreatedBy] int NOT NULL,

    constraint [UQ_MaterialGroups_Code] unique ([Code]),

    constraint [FK_MaterialGroups_CreatedBy] foreign key ([CreatedBy]) references [dbo].[Users]([Id]),

    check ([CreatedAt] <= getdate())
)
