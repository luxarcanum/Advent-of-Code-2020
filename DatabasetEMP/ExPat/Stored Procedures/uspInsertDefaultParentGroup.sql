CREATE PROCEDURE [ExPat].[uspInsertDefaultParentGroup]

AS
	BEGIN
	SET IDENTITY_INSERT [lst].[ParentGroup] ON;

	INSERT INTO [lst].[ParentGroup] (
		[ParentGroupID] ,
		[ParentGroupName]
		)
	VALUES
		(-1,'Blank')
	;		

	SET IDENTITY_INSERT [lst].[ParentGroup] OFF;
	
	END
RETURN 0