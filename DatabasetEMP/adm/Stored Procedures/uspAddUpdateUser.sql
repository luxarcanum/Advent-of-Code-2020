CREATE PROCEDURE [adm].[uspAddUpdateUser]
	@inPID INT = NULL,
	@inFirstName VARCHAR(50),
	@inSurname VARCHAR(50),
	@inActive BIT,
	@inUserRoleID INT,
	@inAccessLevelID INT,
	@inUpdatedBy INT

AS
BEGIN
	SET NOCOUNT ON;
	DECLARE 
		@Query NVARCHAR(1000),
		@SuccessIndicator BIT = 0,
		@PID INT = @inPID,
		@FirstName VARCHAR(50) = @inFirstName,
		@Surname VARCHAR(50) = @inSurname,
		@Active BIT = @inActive,
		@UserRoleID INT = @inUserRoleID,
		@AccessLevelID INT = @inAccessLevelID,
		@UpdatedBy INT = @inUpdatedBy
		;
	
	IF EXISTS(SELECT [PID] FROM [adm].[Users] WHERE [PID] = @PID AND @PID <> -1)
		BEGIN
			SET @Query=N'
			UPDATE [adm].[Users] 
			SET	
				[FirstName] = @FirstName,
				[Surname] = @Surname,
				[Active] = @Active,
				[UserRoleID] = @UserRoleID,
				[AccessLevelID]	= @AccessLevelID,
				[UpdatedBy]	= @UpdatedBy,
				[DateUpdated] = SYSDATETIME()
			WHERE  [PID] = @PID
			;'
		END
	ELSE
		BEGIN
			SET @Query=N'
			INSERT INTO [adm].[Users] 
			(
				[PID],
				[FirstName],
				[Surname],
				[Active],
				[UserRoleID],
				[AccessLevelID],
				[UpdatedBy],
				[DateUpdated]
			)
			VALUES
			(
				@PID,
				@FirstName,
				@Surname,
				@Active,
				@UserRoleID,
				@AccessLevelID,
				@UpdatedBy,
				SYSDATETIME()
			)'
		END
END

BEGIN TRY
	BEGIN TRANSACTION
		Execute sp_Executesql @Query, N'
			@PID INT,
			@FirstName VARCHAR(50),
			@Surname VARCHAR(50),
			@Active BIT,
			@UserRoleID INT,
			@AccessLevelID INT,
			@UpdatedBy INT',
			@PID ,
			@FirstName,
			@Surname,
			@Active,
			@UserRoleID,
			@AccessLevelID,
			@UpdatedBy
	COMMIT
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0
		ROLLBACK
		SET @SuccessIndicator = 1; -- Return value is 0 if successful and 1 if unsuccessful
END CATCH

SELECT @SuccessIndicator AS SuccessIndicator