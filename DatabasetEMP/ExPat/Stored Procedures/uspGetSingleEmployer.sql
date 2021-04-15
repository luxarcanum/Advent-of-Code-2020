CREATE PROCEDURE [ExPat].[uspGetSingleEmployer] 
	@inEmployerID INT

AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @EmployerID INT = @inEmployerID;

	SELECT *
	FROM 
		[ExPat].[vwEmployers]
	WHERE 
		[EmployerID] = @EmployerID
END