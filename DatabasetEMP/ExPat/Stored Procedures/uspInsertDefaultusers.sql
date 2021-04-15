CREATE PROCEDURE [ExPat].[uspInsertDefaultusers]

AS
	BEGIN
	--SET IDENTITY_INSERT [adm].[Users] ON;

	INSERT INTO [adm].[Users] (
		[PID],
		[FirstName],
		[Surname],
		[Active],
		[UserRoleID],
		[AccessLevelID],
		[UpdatedBy],
		[DateUpdated]
  		)
	VALUES
		(-1,'Blank','Blank','True',2,2,6074887,'2021-01-15'),
		(6074887,'Andrew','Wilson','True',0,0,6074887,'2021-01-15'),
		(7223003,'John','hopper','True',0,0,6074887,'2021-01-15')
	;		

	--SET IDENTITY_INSERT [adm].[Users] OFF;
	
	END
RETURN 0