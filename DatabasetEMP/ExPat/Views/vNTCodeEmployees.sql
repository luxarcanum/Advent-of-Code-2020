CREATE VIEW [ExPat].[vNTCodeEmployees]
	AS SELECT 
		[NTCodeEmployeesID],
		[EmployerID],
		[NTE].[TaxYearID],
		[TAX].[TaxYearName],
		[NumberPaid],
		[UpdatedBy],
		[DateUpdated]
	FROM 
		[ExPat].[NTCodeEmployees] AS [NTE]
	INNER JOIN [lst].[TaxYear] AS [TAX] 
		ON [TAX].[TaxYearID] = [NTE].[TaxYearID]