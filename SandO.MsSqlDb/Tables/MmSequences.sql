CREATE TABLE [dbo].[MmSequences]
(
	SequenceName NVARCHAR(128) NOT NULL primary key,
	CurrentValue int NOT NULL,
	Increment int NOT NULL,
	MinValue int NOT NULL,
	MaxValue int NOT NULL,
	Cycle bit NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Malzeme yönetiminde sıralı numara yönetimi',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'MmSequences',
    @level2type = NULL,
    @level2name = NULL