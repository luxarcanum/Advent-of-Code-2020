CREATE TABLE [adm].[UserRole] (
    [UserRoleID]          INT           IDENTITY (-1, 1) NOT NULL,
    [UserRoleTitle]       VARCHAR (50)  NOT NULL,
    [UserRoleDescription] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([UserRoleID] ASC)
);

