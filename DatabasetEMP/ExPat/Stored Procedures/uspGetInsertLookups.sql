CREATE PROCEDURE [ExPat].[uspGetInsertLookups]

AS
BEGIN

	SET NOCOUNT ON;
	---- table 0
	SELECT 
		[EmployerID],
		[PAYERef]
	FROM
		[ExPat].[Employers]
		;
	-- table 1
	SELECT 
		[TaxYearID],
		[TaxYearName]
	FROM
		[lst].[TaxYear]
		;
	-- table 2
	
END