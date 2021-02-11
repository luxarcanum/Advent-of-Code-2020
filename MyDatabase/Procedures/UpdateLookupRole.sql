CREATE PROCEDURE [dbo].[UpdateLookupRole]
	@inID int,
	@inName VARCHAR(5),
	@inActive BIT
AS
	DECLARE 
		@roleId int = @inID,
		@roleName VARCHAR(5) = @inName,
		@roleActive BIT = @inActive,
		@sql varchar(4000),	
		@SuccessIndicator tinyint = 1

	SET @sql = N'
		MERGE [LOOKUP_ROLE] AS [TARGET]  
		USING (
			SELECT @roleId, @roleName, @roleActive
			) AS [SOURCE] ([ROLE_ID], [ROLE_NAME], [ROLE_ACTIVE])  
		ON (
			[TARGET].[ROLE_ID] = [SOURCE].[ROLE_ID]
			)  
		WHEN MATCHED THEN
			UPDATE SET 
				[TARGET].[ROLE_NAME] = [SOURCE].[ROLE_NAME],
				[TARGET].[ROLE_ACTIVE] = [SOURCE].[ROLE_ACTIVE]
		WHEN NOT MATCHED THEN  
			INSERT ([ROLE_NAME], [ROLE_ACTIVE])  
			VALUES ([SOURCE].[ROLE_NAME], [SOURCE].[ROLE_ACTIVE]) 
		--OUTPUT DELETED.*, $action, inserted.* INTO [#OUTPUT_TABLE]
		;  

		-- Return the ID
		SELECT SCOPE_IDENTITY() AS ID
		SELECT @roleId AS ID
	'

	BEGIN TRY
		BEGIN TRANSACTION
			EXEC sp_executesql @sql, N'
				@roleId INT,
				@roleName varchar(50),
				@roleActive BIT',
				@roleId,
				@roleName,
				@roleActive
		COMMIT
	END TRY	
	BEGIN CATCH	-- SQL failed - roll it back
		SELECT @@TRANCOUNT AS [TRANSACTIONS], @@ROWCOUNT
		IF @@TRANCOUNT > 0
			ROLLBACK
			SET @SuccessIndicator = 0; 
			SELECT @SuccessIndicator AS SuccessIndicator
	END CATCH;
RETURN 0
