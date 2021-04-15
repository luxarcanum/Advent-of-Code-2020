CREATE PROCEDURE [ExPat].[uspReportView]
	-- Add the parameters for the stored procedure here
	@inSearchString nvarchar(100),
	@inSearchColumn nvarchar(100),

	@inEntityID INT,
	@inCustomerGroupID INT,
	@inIndustrySectorID INT,
	@inAppendix4 BIT, 
	@inAppendix5 BIT,
	@inAppendix6 BIT,
	@inAppendix7a BIT,
	@inAppendix7b BIT,
	@inAppendix8 BIT,

	@inDedicatedScheme BIT,
	@inNonResidentDirector BIT,
	@inConcessionaryCashBasis BIT,
	@inBespokeScaleRateAgreement BIT,
	@inS690 BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE 
		@SearchStr nvarchar(100) = @inSearchString,
		@SearchColumn nvarchar(100) = @inSearchColumn,

		@entity INT = @inEntityID,
		@customerGroup INT = @inCustomerGroupID,
		@industrySector INT = @inIndustrySectorID,
		@appendix4 BIT = @inAppendix4, 
		@appendix5 BIT = @inAppendix5,
		@appendix6 BIT = @inAppendix6,
		@appendix7a BIT = @inAppendix7a,
		@appendix7b BIT = @inAppendix7b,
		@appendix8 BIT = @inAppendix8,
		@dedicatedScheme BIT = @inDedicatedScheme,
		@nonResidentDirector BIT = @inNonResidentDirector,
		@concessionaryCashBasis BIT = @inConcessionaryCashBasis,
		@bespokeScaleRateAgreement BIT = @inBespokeScaleRateAgreement,
		@S690 BIT = @inS690,

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
	IF @appendix5 = 1 SET @sql += ' AND [Appendix5] IS NOT NULL'
	IF @appendix6 = 1 SET @sql += ' AND [Appendix6] IS NOT NULL'
	IF @appendix7a = 1 SET @sql += ' AND [Appendix7A] IS NOT NULL'
	IF @appendix7b = 1 SET @sql += ' AND [Appendix7B] IS NOT NULL'
	IF @appendix8 = 1 SET @sql += ' AND [Appendix8] IS NOT NULL'

	IF @dedicatedScheme = 1 SET @sql += ' AND [DedicatedScheme] = 1'
	IF @nonResidentDirector = 1 SET @sql += ' AND [NonResidentDirector] = 1'
	IF @concessionaryCashBasis = 1 SET @sql += ' AND [ConcessionaryCashBasis] IS NOT NULL'
	IF @bespokeScaleRateAgreement = 1 SET @sql += ' AND [BespokeScaleRateAgreement] IS NOT NULL'
	IF @S690 = 1 SET @sql += ' AND [S690] IS NOT NULL'

	SET @sql += ' ORDER BY [EmployerID]'

	BEGIN
		PRINT @sql
		EXEC (@sql)
	END

END