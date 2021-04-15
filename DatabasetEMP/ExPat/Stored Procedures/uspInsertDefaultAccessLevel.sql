CREATE PROCEDURE [ExPat].[uspInsertDefaultAccessLevel]

AS
	BEGIN
		SET IDENTITY_INSERT [adm].[AccessLevel] ON;

		INSERT INTO [adm].[AccessLevel] (
			[AccessLevelID],
			[AccessLevelTitle],
			[AccessLevelDescription]
  			)
		VALUES
			(-1,'Blank','Blank'),
			(0,'BDApp','BDApp Team'),
			(1,'Admin','Admin'),
			(2,'User','User')
		;

		SET IDENTITY_INSERT [adm].[AccessLevel] OFF;
	
	END
RETURN 0