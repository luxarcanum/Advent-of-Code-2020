CREATE PROCEDURE [ExPat].[uspInsertDefaultEntity]

AS
	BEGIN
	SET IDENTITY_INSERT [lst].[Entity] ON;

	INSERT INTO [lst].[Entity] (
		[EntityID] ,
		[EntityName]
		)
	VALUES
		(-1,'Blank'),
		(0,'Ltd Company'),
		(1,'LLP'),
		(2,'PLC'),
		(3,'Branch/Representative Office')
	;		

	SET IDENTITY_INSERT [lst].[Entity] OFF;
	
	END
RETURN 0