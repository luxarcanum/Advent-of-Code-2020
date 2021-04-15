
CREATE PROCEDURE [ExPat].[uspGetNINOsPaidList]
	@inEmployerID INT

AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE 
		@EmployerID INT = @inEmployerID;

	SELECT *
	FROM 
		[ExPat].[vNINOsPaid]
	WHERE 
		[EmployerID] = @EmployerID
	ORDER BY 
		[TaxYearName] DESC

END