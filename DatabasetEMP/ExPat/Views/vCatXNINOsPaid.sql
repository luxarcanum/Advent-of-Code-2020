CREATE VIEW [ExPat].[vCatXNINOsPaid]
	AS SELECT 
		[CatXNINOsPaidID],
		[EmployerID],
		[XNI].[TaxYearID],
		[TAX].[TaxYearName],
		[NumberPaid],
		[UpdatedBy],
		[DateUpdated]
	FROM 
		[ExPat].[CatXNINOsPaid] AS [XNI]
	INNER JOIN [lst].[TaxYear] AS [TAX] 
		ON [TAX].[TaxYearID] = [XNI].[TaxYearID]