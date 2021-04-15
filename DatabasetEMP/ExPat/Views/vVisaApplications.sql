CREATE VIEW [ExPat].[vVisaApplications]
	AS SELECT 
		[VisaApplicationsID],
		[EmployerID],
		[VAP].[TaxYearID],
		[TAX].[TaxYearName],
		[NumberPaid],
		[UpdatedBy],
		[DateUpdated]
	FROM 
		[ExPat].[VisaApplications] AS [VAP]
	INNER JOIN [lst].[TaxYear] AS [TAX] 
		ON [TAX].[TaxYearID] = [VAP].[TaxYearID]