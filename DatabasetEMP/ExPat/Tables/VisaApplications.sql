﻿CREATE TABLE [ExPat].[VisaApplications] (
    [VisaApplicationsID] INT      IDENTITY (-1, 1) NOT NULL,
    [EmployerID]         INT      NOT NULL,
    [TaxYearID]          INT      NOT NULL,
    [NumberPaid]         INT      NOT NULL,
    [UpdatedBy]          INT      NOT NULL,
    [DateUpdated]        DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([VisaApplicationsID] ASC),
    CONSTRAINT [FK_VisaApplications_to_Employers] FOREIGN KEY ([EmployerID]) REFERENCES [ExPat].[Employers] ([EmployerID]),
    CONSTRAINT [FK_VisaApplications_to_TaxYear] FOREIGN KEY ([TaxYearID]) REFERENCES [lst].[TaxYear] ([TaxYearID])
);

