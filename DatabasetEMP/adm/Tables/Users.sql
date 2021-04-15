CREATE TABLE [adm].[Users] (
    [PID]           INT          NOT NULL,
    [FirstName]     VARCHAR (50) NOT NULL,
    [Surname]       VARCHAR (50) NOT NULL,
    [Active]        BIT          NOT NULL,
    [UserRoleID]    INT          NOT NULL,
    [AccessLevelID] INT          NOT NULL,
    [UpdatedBy]     INT          NOT NULL,
    [DateUpdated]   DATETIME     NOT NULL,
    PRIMARY KEY CLUSTERED ([PID] ASC),
    CONSTRAINT [FK_Users_to_AccessLevel] FOREIGN KEY ([AccessLevelID]) REFERENCES [adm].[AccessLevel] ([AccessLevelID]),
    CONSTRAINT [FK_Users_to_UserRole] FOREIGN KEY ([UserRoleID]) REFERENCES [adm].[UserRole] ([UserRoleID]),
    UNIQUE NONCLUSTERED ([PID] ASC)
);

