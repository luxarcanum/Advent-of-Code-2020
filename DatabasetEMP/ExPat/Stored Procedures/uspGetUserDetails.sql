CREATE PROCEDURE [ExPat].[uspGetUserDetails]
	@inPID Int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @PID Int = @inPID;

    -- Insert statements for procedure here
	SELECT 
		[PID], 
		CONCAT([FirstName],' ',[Surname]) AS [Full Name], 
		'Scotland' AS [BusinessUnit],
		1 AS [Manager],
		1 AS [Admin]
	FROM 
		[adm].[Users] AS [USERS]
	INNER JOIN [adm].[UserRole] 
		ON [UserRole].[UserRoleID] = [USERS].[UserRoleID]
	INNER JOIN [adm].[AccessLevel] 
		ON [AccessLevel].[AccessLevelID] = [USERS].[AccessLevelID]
	WHERE 
		[PID] = @PID
		AND
		[Active] = 'True'
END
RETURN 0