CREATE PROCEDURE [ExPat].[uspInsertDefaultUserRole]

AS
	BEGIN
		SET IDENTITY_INSERT [adm].[UserRole] ON;

		INSERT INTO [adm].[UserRole] (
			[UserRoleID],
			[UserRoleTitle],
			[UserRoleDescription]
  			)
		VALUES
			(-1,'Blank','Blank'),
			(0,'BDApp','BDApp Team'),
			(1,'Admin','Admin'),
			(2,'User','User')
		;

		SET IDENTITY_INSERT [adm].[UserRole] OFF;
	
	END
RETURN 0