CREATE PROCEDURE [ExPat].[uspReportFilter]
	-- Add the parameters for the stored procedure here
	@inFilterStr nvarchar(100),
	@inFilterID INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE 
		@filterStr NVARCHAR(100) = @inFilterStr,
		@filterID INT = @inFilterID,
		@sql NVARCHAR(1000)
		;

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

	IF @filterStr = 'appendix4'  SET @sql += ' AND [Appendix4] IS NOT NULL'
	IF @filterStr = 'appendix6'  SET @sql += ' AND [Appendix6] IS NOT NULL'
	IF @filterStr = 'appendix8'  SET @sql += ' AND [Appendix8] IS NOT NULL'
	IF @filterStr = 'country' SET @sql += ' AND [CountryID] = ' + CONVERT(VARCHAR, @filterID)
	

	--IF LOWER(@SearchColumn) = 'payeref' SET @sql += ' AND [PAYERef] LIKE ''%' + @SearchStr + '%'''
	--IF LOWER(@SearchColumn) = 'employername' SET @sql += ' AND [EmployerName] LIKE ''%' + @SearchStr + '%'''
	--IF LOWER(@SearchColumn) = 'countryname' SET @sql += ' AND [CountryName] = ''' + @SearchStr + ''''
	--IF LOWER(@SearchColumn) = 'entityname' SET @sql += ' AND [EntityName] = ''' + @SearchStr + ''''

	--IF @entity > -1 SET @sql += ' AND [EntityID] = ' + CONVERT(VARCHAR,@entity)
	--IF @customerGroup > -1 SET @sql += ' AND [CustomerGroupID] = ' + CONVERT(VARCHAR,@customerGroup)
	--IF @industrySector > -1 SET @sql += ' AND [IndustrySectorID] = ' + CONVERT(VARCHAR,@industrySector)

	--IF @appendix4 = 1 SET @sql += ' AND [Appendix4] IS NOT NULL'
	--IF @appendix6 = 1 SET @sql += ' AND [Appendix6] IS NOT NULL'
	--IF @appendix8 = 1 SET @sql += ' AND [Appendix8] IS NOT NULL'

	--SET @sql += ' ORDER BY [EmployerID] OFFSET ' + CONVERT(VARCHAR, @nOffset) + ' ROWS FETCH Next ' + CONVERT(VARCHAR, @nRows) + ' ROWS Only'

	BEGIN
		PRINT @sql
		EXEC (@sql)
	END

END