CREATE VIEW [adm].[vwAllUsers]
	AS 
		SELECT
			[PID],
			[FirstName],
			[Surname],
			[Active],
			[Users].[UserRoleID],
			[UserRoleTitle],
			[UserRoleDescription],
			[Users].[AccessLevelID],
			[AccessLevelTitle],
			[AccessLevelDescription],
			[UpdatedBy],
			[DateUpdated]
		FROM 
			[adm].[Users]
		INNER JOIN 
			[adm].[UserRole] ON [UserRole].[UserRoleID] = [Users].[UserRoleID]
		INNER JOIN 
			[adm].[AccessLevel] ON [AccessLevel].[AccessLevelID] = [Users].[AccessLevelID]