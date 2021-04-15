
CREATE PROCEDURE [ExPat].[uspGetCatXNINOsPaidList]
	@inEmployerID INT

AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE 
		@EmployerID INT = @inEmployerID;

	SELECT *
	FROM 
		[ExPat].[vCatXNINOsPaid]
	WHERE 
		[EmployerID] = @EmployerID
	ORDER BY 
		[TaxYearName] DESC

END