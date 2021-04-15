
CREATE PROCEDURE [ExPat].[uspGetVisaApplicationsList]
	@inEmployerID INT

AS
BEGIN
	SET NOCOUNT ON

	DECLARE 
		@EmployerID INT = @inEmployerID;

	SELECT *
	FROM 
		[ExPat].[vVisaApplications]
	WHERE
		[EmployerID] = @EmployerID
	ORDER BY 
		[TaxYearName] DESC

END