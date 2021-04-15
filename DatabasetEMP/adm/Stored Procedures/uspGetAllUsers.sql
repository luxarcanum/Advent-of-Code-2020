CREATE PROCEDURE [adm].[uspGetAllUsers]

AS
	SELECT 
		[PID],
		[FirstName],
		[Surname],
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
		[PID] > -1
	ORDER BY
		[UserRoleID],
		[Active],
		[PID]
		;
RETURN 0