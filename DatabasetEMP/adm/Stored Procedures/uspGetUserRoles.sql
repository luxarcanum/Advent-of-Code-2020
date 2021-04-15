CREATE PROCEDURE [adm].[uspGetUserRoles]

AS
BEGIN
	SET NOCOUNT ON

	SELECT
		[UserRoleID],
		[UserRoleTitle]
	FROM 
		[adm].[UserRole]
	ORDER BY 
		[UserRoleID]

END