﻿CREATE FUNCTION [dbo].[GetRoleList]
(	
	
)
RETURNS @roleList TABLE  (
	[ROLE_NAME]	VARCHAR(50),
	[ROLE_ACTIVE] BIT
	)
AS
BEGIN
	INSERT INTO @roleList (
		[ROLE_NAME], 
		[ROLE_ACTIVE]
		)
	SELECT
		[ROLE_NAME], 
		[ROLE_ACTIVE]
	FROM 
		[ViewLookupRole]
	ORDER BY 
		[ROLE_NAME]
		;

	RETURN;
END
