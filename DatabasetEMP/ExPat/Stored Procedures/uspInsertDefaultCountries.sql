CREATE PROCEDURE [ExPat].[uspInsertDefaultCountries]

AS
	BEGIN
	SET IDENTITY_INSERT [lst].[Country] ON;

	INSERT INTO [lst].[Country] (
		[CountryID] ,
		[CountryName]
		)
	VALUES
		(-1,'Blank'),
		(0,'America/USA'),
		(1,'Canada'),
		(2,'China'),
		(3,'France'),
		(4,'Germany'),
		(5,'Greece'),
		(6,'India'),
		(7,'Italy'),
		(8,'Japan'),
		(9,'South Korea'),
		(10,'Netherlands'),
		(11,'Russia'),
		(12,'Saudi Arabia'),
		(13,'South Africa'),
		(14,'Sweden'),
		(15,'Switzerland'),
		(16,'Other'),
		(17,'Australia'),
		(18,'Belgium'),
		(19,'Singapore'),
		(20,'United Kingdom'),
		(21,'Argentina'),
		(22,'Austria'),
		(23,'Czech Republic'),
		(24,'Denmark'),
		(25,'Finland'),
		(26,'Luxembourg'),
		(27,'Malaysia'),
		(28,'Norway')
	;		

	SET IDENTITY_INSERT [lst].[Country] OFF;
	
	END
RETURN 0