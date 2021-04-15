CREATE PROCEDURE [ExPat].[uspGetSearchCriteria]

AS
	SET NOCOUNT ON;

/** table 0 - for SearchBy combo **/
	BEGIN
		SELECT [MainID], [FriendlyParameter] FROM
		(
			SELECT 
				0 AS 'MainID', 
				'SEARCH BY' AS 'FriendlyParameter', 
				0 AS 'ord'
			UNION ALL
			SELECT 
				[MainID], [FriendlyParameter], 1 AS 'ord'
			FROM 
				[lst].[SearchParameter]
			WHERE
				[Inactive] = 0 
				OR
				[Inactive] IS NULL
			) AS [Results]
		ORDER BY [ord], [FriendlyParameter]
	END

	/** table 1 - for extended lookup of SearchBy selection **/
	BEGIN
		SELECT [MainID], [FriendlyParameter], [ColumnParameter] FROM
		(
			SELECT 
				0 AS 'MainID', 
				'SELECT' AS 'FriendlyParameter', 
				'' AS 'ColumnParameter', 
				0 AS 'ord'
			UNION ALL
			SELECT [MainID], [FriendlyParameter], [ColumnParameter], 1 AS 'ord'
			FROM 
				[lst].[SearchParameter]
			WHERE
				[Inactive] = 0 
				OR
				[Inactive] IS NULL
			) AS [Results]
		ORDER BY [ord], [FriendlyParameter]
	END

	/** table 2 - for PAYE Ref combo **/
	BEGIN
		SELECT [EmployerID], [PAYERef] FROM
		(
			SELECT 0 AS 'EmployerID', 'SELECT BY PAYE Ref' AS 'PAYERef', 0 AS 'ord'
			UNION ALL
			SELECT DISTINCT TOP (100) PERCENT 
				[EmployerID], [PAYERef], 1 AS 'ord'
			FROM [ExPat].[Employers]
			) AS [results]
		ORDER BY [ord], [PAYERef]
	END

	/** table 3 - for Employer Name combo **/
	BEGIN
		SELECT [EmployerID], [EmployerName] FROM
		(
			SELECT 0 AS 'EmployerID', 'SELECT BY NAME' AS 'EmployerName', 0 AS 'ord'
			UNION ALL
			SELECT DISTINCT TOP (100) PERCENT 
				[EmployerID], [EmployerName], 1 AS 'ord'
			FROM [ExPat].[Employers]
		) AS [results]
		ORDER BY [ord], [EmployerName]
	END

	/** table 4 - for Entity combo **/
	BEGIN
		SELECT [EntityID], [EntityName] FROM
		(
			SELECT 0 AS 'EntityID', 'SELECT ENTITY' AS 'EntityName', 0 AS 'ord'
			UNION ALL
			SELECT TOP (100) PERCENT [EntityID], [EntityName], 1 AS 'ord'
			FROM [lst].[Entity]
		) AS [results]
		ORDER BY [ord], [EntityName]
	END

	/** table 5 - for Country combo **/
	BEGIN
		SELECT [CountryID], [CountryName] FROM
		(
			SELECT 0 AS 'CountryID', 'SELECT COUNTRY' AS 'CountryName', 0 AS 'ord'
			UNION ALL
			SELECT TOP (100) PERCENT[CountryID], [CountryName], 1 AS 'ord'
			FROM [lst].[Country]
		) AS [results]
		ORDER BY [ord], [CountryName]
	END

	/** table 6 - for Appendix8 combo **/
	BEGIN
		SELECT [EmployerID], [EmployerName] FROM
		(
			SELECT 0 AS 'EmployerID', 'SELECT BY NAME' AS 'EmployerName', 0 AS 'ord'
			UNION ALL
			SELECT DISTINCT TOP (100) PERCENT  [EmployerID], [EmployerName], 1 AS 'ord'
			FROM [ExPat].[Employers]
		) AS [results]
		ORDER BY [ord], [EmployerName]
	END