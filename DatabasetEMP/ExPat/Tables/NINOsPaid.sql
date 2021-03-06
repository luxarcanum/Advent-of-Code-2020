﻿CREATE TABLE [ExPat].[NINOsPaid] (
    [NINOsPaidID] INT      IDENTITY (-1, 1) NOT NULL,
    [EmployerID]  INT      NOT NULL,
    [TaxYearID]   INT      NOT NULL,
    [NumberPaid]  INT      NOT NULL,
    [UpdatedBy]   INT      NOT NULL,
    [DateUpdated] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([NINOsPaidID] ASC),
    CONSTRAINT [FK_NINOsPaid_to_Employers] FOREIGN KEY ([EmployerID]) REFERENCES [ExPat].[Employers] ([EmployerID]),
    CONSTRAINT [FK_NINOsPaid_to_TaxYear] FOREIGN KEY ([TaxYearID]) REFERENCES [lst].[TaxYear] ([TaxYearID])
);

