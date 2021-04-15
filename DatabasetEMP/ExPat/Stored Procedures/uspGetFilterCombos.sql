CREATE PROCEDURE [ExPat].[uspGetFilterCombos]
	@inListType VARCHAR(10)
AS
BEGIN

	SET NOCOUNT ON;
	DECLARE 
		@ListType VARCHAR(10) = @inListType
		;
	-- Retrieve Filter dropdowns
	---- table 0
	IF  LEN(ISNULL(@ListType, '')) = 0 
		BEGIN
			SELECT [EntityID], [EntityName]
			FROM [lst].[Entity] 
			WHERE [EntityID] IS NOT NULL 
			ORDER BY [EntityName]
		END
	ELSE 
		BEGIN 
			SELECT [EntityID], [EntityName] FROM
			(
				SELECT -2 AS 'EntityID', @ListType AS 'EntityName', 0 AS 'ord'
				UNION ALL
				SELECT [EntityID], [EntityName], 1 AS 'ord'
				FROM [lst].[Entity] 
				WHERE [EntityID] IS NOT NULL 
			) AS [results]
			ORDER BY [ord], [EntityName]
		END

	-- table 1
	IF  LEN(ISNULL(@ListType, '')) = 0 
		BEGIN
			SELECT [CustomerGroupID], [CustomerGroupName]
			FROM [lst].[CustomerGroup]
			WHERE [CustomerGroupID] IS NOT NULL
			ORDER BY [CustomerGroupName]
		END
	ELSE 
		BEGIN 
			SELECT [CustomerGroupID], [CustomerGroupName] FROM
			(
				SELECT -2 AS 'CustomerGroupID', @ListType AS 'CustomerGroupName', 0 AS 'ord'
				UNION ALL
				SELECT [CustomerGroupID], [CustomerGroupName], 1 AS 'ord'
				FROM [lst].[CustomerGroup]
				WHERE [CustomerGroupID] IS NOT NULL
			) AS [results]
			ORDER BY [ord], [CustomerGroupName]
		END

	-- table 2
	IF  LEN(ISNULL(@ListType, '')) = 0 
		BEGIN
			SELECT [IndustrySectorID], [IndustrySectorName]
			FROM [lst].[IndustrySector]
			WHERE [IndustrySectorID] IS NOT NULL
			ORDER BY [IndustrySectorName]
		END
	ELSE 
		BEGIN 
			SELECT [IndustrySectorID], [IndustrySectorName] FROM
			(
				SELECT -2 AS 'IndustrySectorID', @ListType AS 'IndustrySectorName', 0 AS 'ord'
				UNION ALL
				SELECT [IndustrySectorID], [IndustrySectorName], 1 AS 'ord'
				FROM [lst].[IndustrySector]
				WHERE [IndustrySectorID] IS NOT NULL
			) AS [results]
			ORDER BY [ord], [IndustrySectorName]
		END
END