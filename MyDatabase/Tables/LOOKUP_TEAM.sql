﻿CREATE TABLE [dbo].[LOOKUP_TEAM]
(
	[TEAM_ID] INT NOT NULL IDENTITY(-1,1) PRIMARY KEY, 
    [TEAM_NAME] VARCHAR(6) NOT NULL,
	[TEAM_ACTIVE] BIT NOT NULL
)
