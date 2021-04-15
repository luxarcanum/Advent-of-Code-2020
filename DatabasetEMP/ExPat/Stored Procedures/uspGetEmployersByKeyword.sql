CREATE PROCEDURE [ExPat].[uspGetEmployersByKeyword]
	@inSearchStr nvarchar(100),
	@inSearchColumn nvarchar(100),
	@innRows int,
	@innOffset int
AS

	DECLARE 
		@SearchStr nvarchar(100) = @inSearchStr,
		@SearchColumn nvarchar(100) = @inSearchColumn,
		@nRows int = @innRows,		-- Number of rows to return
		@nOffset int = @innOffset	-- OFFSET FOR START RECORD
		;

	BEGIN

		SET NOCOUNT ON;

		IF LOWER(@SearchColumn) = 'PAYERef'
			BEGIN
				SELECT *, [AllRowsCount] = Count(*) OVER() FROM [ExPat].[vwEmployers]
				WHERE [vwEmployers].[PAYERef] LIKE '%' + @SearchStr + '%'
				ORDER BY [PAYERef] OFFSET @nOffset ROWS FETCH Next @nRows ROWS Only
			END
		ELSE IF LOWER(@SearchColumn) = 'EmployerName'
			BEGIN
				SELECT *, [AllRowsCount] = Count(*) OVER() FROM [ExPat].[vwEmployers]
				WHERE [vwEmployers].[EmployerName] LIKE '%' + @SearchStr + '%' 
				ORDER BY [PAYERef] OFFSET @nOffset ROWS FETCH Next @nRows ROWS Only
			END
		ELSE IF LOWER(@SearchColumn) = 'CountryName'
			BEGIN
				SELECT *, [AllRowsCount] = Count(*) OVER() FROM [ExPat].[vwEmployers]
				WHERE [vwEmployers].[CountryName] = @SearchStr 
				ORDER BY [PAYERef] OFFSET @nOffset ROWS FETCH Next @nRows ROWS Only
			END
		ELSE IF LOWER(@SearchColumn) = 'EntityName'
			BEGIN
				SELECT *, [AllRowsCount] = Count(*) OVER() FROM [ExPat].[vwEmployers]
				WHERE [vwEmployers].[EntityName] = @SearchStr 
				ORDER BY [PAYERef] OFFSET @nOffset ROWS FETCH Next @nRows ROWS Only
			END
		--ELSE IF LOWER(@SearchColumn) = 'Appendix8'
		--	BEGIN
		--		SELECT * FROM [ExPat].[vwEmployers]
		--		WHERE [vwEmployers].[Appendix8] = @SearchStr 
		--		ORDER BY [PAYERef] OFFSET @nOffset ROWS FETCH Next @nRows ROWS Only
		--	END

		--ELSE IF LOWER(@SearchColumn) = 'tradesector'
		--	BEGIN
		--		SELECT * FROM [ExPat].[vwEmployers]
		--		WHERE [vwEmployers].TradeSector = @SearchStr 
		--		ORDER BY [PAYERef] OFFSET @nOffset ROWS FETCH Next @nRows ROWS Only
		--	END

		--ELSE IF LOWER(@SearchColumn) = 'updatedbypid'
		--	BEGIN
		--		SELECT * FROM [ExPat].[vwEmployers]
		--		WHERE [vwEmployers].UpdatedByPID = @SearchStr 
		--		ORDER BY [PAYERef] OFFSET @nOffset ROWS FETCH Next @nRows ROWS Only
		--	END

		ELSE IF LOWER(@SearchColumn) = 'Appendix8'
			BEGIN
				SELECT *, [AllRowsCount] = Count(*) OVER() FROM [ExPat].[vwEmployers]
				WHERE [vwEmployers].[Appendix8] = @SearchStr 
				ORDER BY [PAYERef] OFFSET @nOffset ROWS FETCH Next @nRows ROWS Only
			END
	END

	--SELECT @@ROWCOUNT AS NumberOfRows;

	--BEGIN

	--IF LOWER(@SearchColumn) = 'vrn'
	--	BEGIN
	--	SELECT COUNT(*) AS NumberOfRows FROM [dbo].[vwAllCases]
	--	WHERE vwAllCases.VRN = @SearchStr 
	--	END

	--ELSE IF LOWER(@SearchColumn) = 'businessname'
	--	BEGIN
	--	SELECT COUNT(*) AS NumberOfRows FROM [dbo].[vwAllCases]
	--	WHERE vwAllCases.BusinessName LIKE '%' + @SearchStr + '%' 
	--	END

	--ELSE IF LOWER(@SearchColumn) = 'flmpid'
	--	BEGIN
	--	SELECT COUNT(*) AS NumberOfRows FROM [dbo].[vwAllCases]
	--	WHERE vwAllCases.FLMPID = @SearchStr 
	--	END

	--ELSE IF LOWER(@SearchColumn) = 'designatedcaseownerpid'
	--	BEGIN
	--	SELECT COUNT(*) AS NumberOfRows FROM [dbo].[vwAllCases]
	--	WHERE vwAllCases.PID = @SearchStr 
	--	END

	--ELSE IF LOWER(@SearchColumn) = 'projectorcluster'
	--	BEGIN
	--	SELECT COUNT(*) AS NumberOfRows FROM [dbo].[vwAllCases]
	--	WHERE vwAllCases.ProjectOrCluster = @SearchStr 
	--	END

	--ELSE IF LOWER(@SearchColumn) = 'tradesector'
	--	BEGIN
	--	SELECT COUNT(*) AS NumberOfRows FROM [dbo].[vwAllCases]
	--	WHERE vwAllCases.TradeSector = @SearchStr 
	--	END

	--ELSE IF LOWER(@SearchColumn) = 'updatedbypid'
	--	BEGIN
	--	SELECT COUNT(*) AS NumberOfRows FROM [dbo].[vwAllCases]
	--	WHERE vwAllCases.UpdatedByPID = @SearchStr 
	--	END

	--ELSE IF LOWER(@SearchColumn) = 'postcode'
	--	BEGIN
	--	SELECT COUNT(*) AS NumberOfRows FROM [dbo].[vwAllCases]
	--	WHERE vwAllCases.PostCode = @SearchStr 
	--	END

	--END