﻿CREATE PROCEDURE [ExPat].[uspGetCountrysList]

AS
BEGIN
SET NOCOUNT ON

SELECT * FROM lst.Country
ORDER BY CountryName

END