CREATE PROCEDURE [dbo].[GenerateCSharpClassFromTable]
    @TableName NVARCHAR(128),
    @ComputedColumns INT = 2
AS
BEGIN
    DECLARE @Result NVARCHAR(MAX) = ''
    DECLARE @Line NVARCHAR(MAX)

    -- Header
    SET @Result = 'public class ' + @TableName + CHAR(13) + '{' + CHAR(13)

    -- Query to get columns information
    DECLARE @ColumnDefinitions TABLE (
        ColumnName NVARCHAR(128),
        DataType NVARCHAR(128),
        IsNullable NVARCHAR(3)
    )

    INSERT INTO @ColumnDefinitions (ColumnName, DataType, IsNullable)
    SELECT COLUMN_NAME,
           CASE
               WHEN DATA_TYPE IN ('int', 'tinyint', 'smallint') THEN 'int'
               WHEN DATA_TYPE IN ('bigint') THEN 'long'
               WHEN DATA_TYPE IN ('float', 'real') THEN 'double'
               WHEN DATA_TYPE IN ('decimal', 'numeric', 'smallmoney', 'money') THEN 'decimal'
               WHEN DATA_TYPE IN ('bit') THEN 'bool'
               WHEN DATA_TYPE IN ('char', 'varchar', 'text', 'nchar', 'nvarchar', 'ntext') THEN 'string'
               WHEN DATA_TYPE IN ('datetime', 'smalldatetime', 'date', 'time', 'datetime2', 'datetimeoffset') THEN 'DateTime'
               WHEN DATA_TYPE IN ('binary', 'varbinary', 'image') THEN 'byte[]'
               ELSE 'object'
           END,
           IS_NULLABLE
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = @TableName
    AND (@ComputedColumns = 2 or COLUMNPROPERTY(OBJECT_ID(TABLE_SCHEMA + '.' + TABLE_NAME), COLUMN_NAME, 'IsComputed') = @ComputedColumns)
    ORDER BY ORDINAL_POSITION

    -- Append columns to result
    DECLARE cur CURSOR FOR
    SELECT concat(DataType, 
    CASE 
		WHEN IsNullable = 'YES' and DataType <> 'string' THEN '?'
		ELSE ''
	END
    , ' ', ColumnName)
    FROM @ColumnDefinitions

    OPEN cur

    FETCH NEXT FROM cur INTO @Line

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @Result = @Result + '    public ' + @Line + ' { get; set; }' + CHAR(13)
        FETCH NEXT FROM cur INTO @Line
    END

    CLOSE cur
    DEALLOCATE cur

    -- Footer
    SET @Result = @Result + '}'

    -- Print the result
    PRINT @Result
END