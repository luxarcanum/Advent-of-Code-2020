CREATE PROCEDURE [adm].[uspGetUserDetails]
	@inPID Int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @PID Int = @inPID;

	SELECT 
		[PID],
		[FirstName],
		[Surname],
		CONCAT([FirstName], ' ', [Surname]) AS [FullName],
		[Active],
		[UserRoleID],
		[UserRoleTitle],
		[UserRoleDescription],
		[AccessLevelID],
		[AccessLevelTitle],
		[AccessLevelDescription],
		[UpdatedBy],
		[DateUpdated]
	FROM 
		[adm].[vwAllUsers]
	WHERE 
		[PID] = @PID
END
RETURN 0