CREATE PROCEDURE [ExPat].[uspInsertDefaultSearchParameters]

AS
	BEGIN
		SET IDENTITY_INSERT [lst].[SearchParameter] ON;

		INSERT INTO [lst].[SearchParameter] (
			[MainID],
			[FriendlyParameter],
			[ColumnParameter],
			[Inactive],
			[InactiveDate]
  			)
		VALUES
			(0, 'PAYE Ref *', 'PAYERef', 0, NULL),
			(1, 'Employer Name *', 'EmployerName', 0, NULL),
			(2, 'Entity Name', 'EntityName', 0, NULL),
			(3, 'Country Name', 'CountryName', 0, NULL)
		;

		SET IDENTITY_INSERT [lst].[SearchParameter] OFF;
	
	END
RETURN 0