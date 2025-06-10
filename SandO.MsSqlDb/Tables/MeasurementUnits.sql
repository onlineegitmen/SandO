CREATE TABLE [dbo].[MeasurementUnits]
(
	[Code] nvarchar(10) NOT NULL primary key,
	[Name] varchar(100) NOT NULL,

	constraint [UQ_MeasurementUnits_Code] unique ([Name])
)
