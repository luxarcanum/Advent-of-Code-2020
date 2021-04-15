CREATE TABLE [lst].[SearchParameter] (
    [MainID]            INT           IDENTITY (0, 1) NOT NULL,
    [FriendlyParameter] NVARCHAR (50) NOT NULL,
    [ColumnParameter]   NVARCHAR (50) NOT NULL,
    [Inactive]          BIT           NULL,
    [InactiveDate]      DATETIME2 (7) NULL
);

