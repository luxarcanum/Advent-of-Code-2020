CREATE PROCEDURE [ExPat].[uspGetAllEmployers2]
	-- Add the parameters for the stored procedure here
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

	IF @entity > -1 SET @sql += ' AND [EntityID] = ' + CONVERT(VARCHAR,@entity)
	IF @customerGroup > -1 SET @sql += ' AND [CustomerGroupID] = ' + CONVERT(VARCHAR,@customerGroup)
	IF @industrySector > -1 SET @sql += ' AND [IndustrySectorID] = ' + CONVERT(VARCHAR,@industrySector)

	IF @appendix4 = 1 SET @sql += ' AND [Appendix4] IS NOT NULL'
	IF @appendix6 = 1 SET @sql += ' AND [Appendix6] IS NOT NULL'
	IF @appendix8 = 1 SET @sql += ' AND [Appendix8] IS NOT NULL'

	BEGIN
		PRINT @sql
		EXEC (@sql)
	END

END