CREATE VIEW [ExPat].[vwEmployers]
	AS SELECT 
		[EMP].[EmployerID],
		[EMP].[PAYERef],
		[EMP].[EmployerName],
		[EMP].[ParentGroupID],
		[EMP].[IsParent],
		CASE WHEN [EMP].[ParentGroupID] < 0 THEN NULL ELSE [PAR].[EmployerName] END AS [ParentGroupName],
		[EMP].[EntityID],
		CASE WHEN [EMP].[EntityID] < 0 THEN NULL ELSE [EntityName] END AS [EntityName],
		[EMP].[CountryID],
		CASE WHEN [EMP].[CountryID] < 0 THEN NULL ELSE [CountryName] END AS [CountryName],
		[EMP].[COTAXUTR],
		[EMP].[CustomerGroupID],
		CASE WHEN [EMP].[CustomerGroupID] < 0 THEN NULL ELSE [CustomerGroupName] END AS [CustomerGroupName],
		[EMP].[IndustrySectorID],
		CASE WHEN [EMP].[IndustrySectorID] < 0 THEN NULL ELSE [IndustrySectorName] END AS [IndustrySectorName],
		[EMP].[DedicatedScheme],
		[EMP].[Appendix4],
		[EMP].[Appendix5],
		[EMP].[Appendix6],
		[EMP].[Appendix7A],
		[EMP].[Appendix7B],
		[EMP].[Appendix8],
		[EMP].[NonResidentDirector],
		[EMP].[ConcessionaryCashBasis],
		[EMP].[BespokeScaleRateAgreement],
		[EMP].[S690],
		[EMP].[Notes],
		[EMP].[ActiveScheme],
		[EMP].[UpdatedBy],
		[EMP].[DateUpdated]
	FROM 
		[ExPat].[Employers] AS [EMP]
	INNER JOIN [lst].[Entity] AS [ENT] 
		ON [ENT].[EntityID] = [EMP].[EntityID]
    INNER JOIN [lst].[Country] AS [COU] 
		ON [COU].[CountryID] = [EMP].[CountryID]
    INNER JOIN [lst].[CustomerGroup] AS [CUS] 
		ON [CUS].[CustomerGroupID] = [EMP].[CustomerGroupID]
	INNER JOIN [lst].[IndustrySector] AS [IND]
		ON [IND].[IndustrySectorID] = [EMP].[IndustrySectorID]
	INNER JOIN [ExPat].[Employers] AS [PAR]
		ON [PAR].[EmployerID] = [EMP].[ParentGroupID]