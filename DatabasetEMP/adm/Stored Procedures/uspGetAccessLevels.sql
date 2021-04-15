CREATE PROCEDURE [adm].[uspGetAccessLevels]

AS
BEGIN
	SET NOCOUNT ON

	SELECT
		[AccessLevelID],
		[AccessLevelTitle]
	FROM 
		[adm].[AccessLevel]
	ORDER BY 
		[AccessLevelID]

END