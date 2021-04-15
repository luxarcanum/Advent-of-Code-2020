CREATE PROCEDURE [ExPat].[uspInsertDefaultMaintainTables]

AS
	BEGIN

	INSERT INTO [ExPat].[MaintainListTables] (
		[TableName],
		[Query],
		[MainKey],
		[BDAppTeamOnly]
  		)
	VALUES
		('Entity List', 'SELECT lst.Entity.* FROM lst.Entity', 'False', 0),
		('Country List', 'SELECT lst.Country.* FROM lst.Country', 'False', 0),
		('Indusrty/Sector List', 'SELECT lst.IndustrySector.* FROM lst.IndustrySector', 'False', 0),
		('Customer Group List', 'SELECT lst.CustomerGroup.* FROM lst.CustomerGroup', 'False', 0)
		;		
	
	END
RETURN 0