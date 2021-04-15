CREATE PROCEDURE [ExPat].[uspGetIndustrySectorsList]

AS
BEGIN
SET NOCOUNT ON

SELECT * FROM lst.IndustrySector
ORDER BY IndustrySectorName

END