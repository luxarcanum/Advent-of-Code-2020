﻿CREATE TABLE [dbo].[TABLE_DATES]
(
	[DATE_KEY] [int] NOT NULL,
	[DATE_DATE] [date] NOT NULL,
	[DATE_NAME] [varchar](10) NOT NULL,
 CONSTRAINT [PK_DATE_TABLE] PRIMARY KEY CLUSTERED 
(
	[DATE_KEY] ASC
)
) ON [PRIMARY]
