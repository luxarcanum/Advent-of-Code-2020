CREATE PROCEDURE [dbo].[PopulateTableDates]
	@inStartDate DATE,
	@inStopDate DATE
AS

	DECLARE 
		@startDate DATE = @inStartDate,
		@stopDate DATE = @inStopDate;

	MERGE [TABLE_DATES] AS [TARGET]
	USING (
		SELECT 
			CONVERT(INT, CONVERT(VARCHAR(8),DATEADD(DAY, [NUMBER], @startDate),112), 112) AS [DATE_KEY], 
			DATEADD(DAY, [NUMBER], @startDate) AS [DATE_DATE], 
			CONVERT(VARCHAR(10), DATEADD(DAY, [NUMBER], @startDate), 111) AS [DATE_NAME]
		FROM
			[TABLE_NUMBERS]
		WHERE 
			[NUMBER] BETWEEN 0 AND (SELECT DATEDIFF(Day, @startDate, @stopDate))
		) AS [SOURCE] (	
			[DATE_KEY], 
			[DATE_DATE], 
			[DATE_NAME]
			)
	ON ([TARGET].[DATE_KEY] = [SOURCE].[DATE_KEY])
	WHEN NOT MATCHED THEN 
		INSERT ( 
			[DATE_KEY], 
			[DATE_DATE], 
			[DATE_NAME]
			)
		VALUES (
			[SOURCE].[DATE_KEY], 
			[SOURCE].[DATE_DATE], 
			[SOURCE].[DATE_NAME]
			)
		;

RETURN 0
