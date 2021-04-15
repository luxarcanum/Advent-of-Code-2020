CREATE PROCEDURE [ExPat].[uspGetCustomerGroupsList]

AS
BEGIN
SET NOCOUNT ON

SELECT * FROM lst.CustomerGroup
ORDER BY CustomerGroupName

END