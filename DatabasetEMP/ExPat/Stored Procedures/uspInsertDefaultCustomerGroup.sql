CREATE PROCEDURE [ExPat].[uspInsertDefaultCustomerGroup]

AS
	BEGIN
	SET IDENTITY_INSERT [lst].[CustomerGroup] ON;

	INSERT INTO [lst].[CustomerGroup] (
		[CustomerGroupID] ,
		[CustomerGroupName]
		)
	VALUES
		(-1,'Blank'),
		(0,'LB'),
		(1,'MSB'),
		(2,'ISBC'),
		(3,'Charity'),
		(4,'LPU')
	;		

	SET IDENTITY_INSERT [lst].[CustomerGroup] OFF;
	
	END
RETURN 0