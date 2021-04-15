CREATE PROCEDURE [ExPat].[uspGetMaintainListTables] 
	-- Add the parameters for the stored procedure here
	@inBDAppTeamOnly bit
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE
		@BDAppTeamOnly bit = @inBDAppTeamOnly;

	IF @BDAppTeamOnly = 1 
		BEGIN
			SELECT 
				[TableName], 
				[Query], 
				[MainKey], 
				[BDAppTeamOnly]
			FROM 
				[ExPat].[MaintainListTables]
			WHERE 
				[BDAppTeamOnly] = @BDAppTeamOnly
			ORDER BY 
				[TableName]
		END
	ELSE
		BEGIN
			SELECT 
				[TableName], 
				[Query], 
				[MainKey], 
				[BDAppTeamOnly]
			FROM 
				[ExPat].[MaintainListTables]
			ORDER BY 
				[TableName]
		END

END