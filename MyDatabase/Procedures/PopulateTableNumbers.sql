CREATE PROCEDURE [dbo].[PopulateTableNumbers]

AS
	INSERT INTO [TABLE_NUMBERS] 
		([NUMBER])
	SELECT TOP 86400 ROW_NUMBER() OVER(ORDER BY [T1].[NUMBER]) AS [NUMBER]
	FROM master..spt_values [T1] 
    CROSS JOIN master..spt_values [T2];

RETURN 0
