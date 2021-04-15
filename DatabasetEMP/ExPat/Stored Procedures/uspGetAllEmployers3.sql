CREATE PROCEDURE [ExPat].[uspGetAllEmployers3]
	-- Add the parameters for the stored procedure here
	@inSearchStr nvarchar(100),
	@inSearchColumn nvarchar(100),
	@innRows int,
	@innOffset int,

	@inEntity INT,
	@inCustomerGroup INT,
	@inIndustrySector INT,
	@inAppendix4 BIT, 
	@inAppendix6 BIT,
	@inAppendix8 BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE 
		@SearchStr nvarchar(100) = @inSearchStr,
		@SearchColumn nvarchar(100) = @inSearchColumn,
		@nRows int = @innRows,		-- Number of rows to return
		@nOffset int = @innOffset,	-- OFFSET FOR START RECORD

		@entity INT = @inEntity,
		@customerGroup INT = @inCustomerGroup,
		@industrySector INT = @inIndustrySector,
		@appendix4 BIT = @inAppendix4, 
		@appendix6 BIT = @inAppendix6,
		@appendix8 BIT = @inAppendix8,
		@sql VARCHAR(4000);

    -- Insert statements for procedure here
	SET @sql = N'SELECT
		[EmployerID],
		[PAYERef],
		[EmployerName],
		[ParentGroupName],
		[EntityName],
		[CountryName],
		[COTAXUTR],
		[CustomerGroupName],
		[IndustrySectorName],
		[DedicatedScheme] ,
		[Appendix4],
		[Appendix5],
		[Appendix6],
		[Appendix7A],
		[Appendix7B],
		[Appendix8],
		[NonResidentDirector],
		[ConcessionaryCashBasis],
		[BespokeScaleRateAgreement],
		[S690],
		[Notes],
		[ActiveScheme],
		[UpdatedBy],
		[DateUpdated],
		[AllRowsCount] = Count(*) OVER()
	FROM 
		[ExPat].[vwEmployers]
	WHERE
		[EmployerID] > -1'
		;

	IF LOWER(@SearchColumn) = 'payeref' SET @sql += ' AND [PAYERef] LIKE ''%' + @SearchStr + '%'''
	IF LOWER(@SearchColumn) = 'employername' SET @sql += ' AND [EmployerName] LIKE ''%' + @SearchStr + '%'''
	IF LOWER(@SearchColumn) = 'countryname' SET @sql += ' AND [CountryName] = ''' + @SearchStr + ''''
	IF LOWER(@SearchColumn) = 'entityname' SET @sql += ' AND [EntityName] = ''' + @SearchStr + ''''

	IF @entity > -1 SET @sql += ' AND [EntityID] = ' + CONVERT(VARCHAR,@entity)
	IF @customerGroup > -1 SET @sql += ' AND [CustomerGroupID] = ' + CONVERT(VARCHAR,@customerGroup)
	IF @industrySector > -1 SET @sql += ' AND [IndustrySectorID] = ' + CONVERT(VARCHAR,@industrySector)

	IF @appendix4 = 1 SET @sql += ' AND [Appendix4] IS NOT NULL'
	IF @appendix6 = 1 SET @sql += ' AND [Appendix6] IS NOT NULL'
	IF @appendix8 = 1 SET @sql += ' AND [Appendix8] IS NOT NULL'

	SET @sql += ' ORDER BY [EmployerID] OFFSET ' + CONVERT(VARCHAR, @nOffset) + ' ROWS FETCH Next ' + CONVERT(VARCHAR, @nRows) + ' ROWS Only'

	BEGIN
		PRINT @sql
		EXEC (@sql)
	END

END