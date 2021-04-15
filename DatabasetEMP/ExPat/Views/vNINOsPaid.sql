CREATE VIEW [ExPat].[vNINOsPaid]
	AS SELECT 
		[NINOsPaidID],
		[EmployerID],
		[NIP].[TaxYearID],
		[TAX].[TaxYearName],
		[NumberPaid],
		[UpdatedBy],
		[DateUpdated]
	FROM 
		[ExPat].[NINOsPaid] AS [NIP]
	INNER JOIN [lst].[TaxYear] AS [TAX] 
		ON [TAX].[TaxYearID] = [NIP].[TaxYearID]