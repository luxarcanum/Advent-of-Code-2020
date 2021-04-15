CREATE PROCEDURE [ExPat].[uspGetParentGroupsList]

AS
BEGIN
	SET NOCOUNT ON

	SELECT *
	FROM 
		[ExPat].[Employers]
	WHERE 
		[IsParent] = 'True'
	ORDER BY 
		[EmployerName]

END