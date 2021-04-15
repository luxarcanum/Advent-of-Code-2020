CREATE PROCEDURE [ExPat].[uspInsertDefaultIndustrySector]

AS
	BEGIN
	SET IDENTITY_INSERT [lst].[IndustrySector] ON;

	INSERT INTO [lst].[IndustrySector] (
		[IndustrySectorID] ,
		[IndustrySectorName]
		)
	VALUES
		(-1, 'Blank'),
		(0, 'Airline and Shipping'),
		(1, 'Automobile'),
		(2, 'Aviation'),
		(3, 'Commercial'),
		(4, 'Commercial Banking'),
		(5, 'Commercial Investment Banking'),
		(6, 'Commercial Pharmaceutical'),
		(7, 'Electrical Manufacturing'),
		(8, 'Food and Drink Consumer Products'),
		(9, 'Fund Management'),
		(10, 'IT Suppliers'),
		(11, 'Manufacturing'),
		(12, 'Marketing and Advertising'),
		(13, 'Media and Entertainment'),
		(14, 'Oil and Gas'),
		(15, 'Other'),
		(16, 'Other Financial Institutions'),
		(17, 'Pharmaceutical'),
		(18, 'Stockbroker')
	;		

	SET IDENTITY_INSERT [lst].[IndustrySector] OFF;
	
	END
RETURN 0