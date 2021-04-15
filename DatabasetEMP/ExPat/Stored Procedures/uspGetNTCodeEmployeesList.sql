
CREATE PROCEDURE [ExPat].[uspGetNTCodeEmployeesList]
	@inEmployerID INT

AS
BEGIN
	SET NOCOUNT ON

	DECLARE 
		@EmployerID INT = @inEmployerID;

	SELECT *
	FROM 
		[ExPat].[vNTCodeEmployees]
	WHERE 
		[EmployerID] = @EmployerID
	ORDER BY 
		[TaxYearName] DESC

END