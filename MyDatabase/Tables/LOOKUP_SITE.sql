﻿CREATE TABLE [dbo].[LOOKUP_SITE]
(
	[SITE_ID] INT NOT NULL IDENTITY(-1,1) PRIMARY KEY, 
    [SITE_NAME] VARCHAR(3) NOT NULL,
	[SITE_ACTIVE] BIT NOT NULL
)
