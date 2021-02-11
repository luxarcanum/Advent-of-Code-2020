﻿CREATE PROCEDURE [dbo].[PopulateLookupTeam]

AS

	MERGE  [LOOKUP_TEAM] AS [TARGET]
	USING (
		VALUES 
			('N/A','TRUE'),
			('BGC001','TRUE'),('BGC002','TRUE'),('BGC003','TRUE'),('BGC004','TRUE'),('BGC005','TRUE'),
			('DDC001','FALSE'),('DDC002','FALSE'),('DDC003','FALSE'),('DDC004','FALSE'),('DDC005','FALSE'),
			('EDH001','TRUE'),('EDH002','TRUE'),('EDH003','TRUE'),('EDH004','TRUE'),('EDH005','TRUE'),
			('LGB001','TRUE'),('LGB002','TRUE'),('LGB003','TRUE'),('LGB004','TRUE'),('LGB005','TRUE'),
			('MCC001','TRUE'),('MCC002','TRUE'),('MCC003','TRUE'),('MCC004','TRUE'),('MCC005','TRUE')
		) AS [SOURCE] (	
			[TEAM_NAME],
			[TEAM_ACTIVE]
			)
	ON ([TARGET].[TEAM_NAME] = [SOURCE].[TEAM_NAME])
	WHEN NOT MATCHED THEN 
		INSERT ( 
			[TEAM_NAME],
			[TEAM_ACTIVE]
			)
		VALUES (
			[SOURCE].[TEAM_NAME], 
			[SOURCE].[TEAM_ACTIVE]
			)
		;

RETURN 0
