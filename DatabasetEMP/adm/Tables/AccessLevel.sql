CREATE TABLE [adm].[AccessLevel] (
    [AccessLevelID]          INT           IDENTITY (-1, 1) NOT NULL,
    [AccessLevelTitle]       VARCHAR (50)  NOT NULL,
    [AccessLevelDescription] VARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([AccessLevelID] ASC)
);

