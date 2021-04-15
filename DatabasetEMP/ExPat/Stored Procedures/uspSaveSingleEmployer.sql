

CREATE PROCEDURE [ExPat].[uspSaveSingleEmployer]
	@EmployerID int = NULL,
	@PAYERef varchar(50) = NULL,
	@EmployerName varchar(50) = NULL,
	@ParentGroupID int = NULL,
	@IsParent bit = NULL,
	@EntityID int = NULL,
	@CountryID int = NULL,
	@COTAXUTR varchar(50) = NULL,
	@CustomerGroupID int = NULL,
	@IndustrySectorID int = NULL,
	@DedicatedScheme bit = NULL,
	@Appendix4 date = NULL,
	@Appendix5 date = NULL,
	@Appendix6 date = NULL,
	@Appendix7A date = NULL,
	@Appendix7B date = NULL,
	@Appendix8 date = NULL,
	@NonResidentDirector bit = NULL,
	@ConcessionaryCashBasis date = NULL,
	@BespokeScaleRateAgreement date = NULL,
	@S690 date = NULL,
	@Notes varchar(50) = NULL,
	@ActiveScheme bit = NULL,
	@UpdatedBy int = NULL,
    @DateUpdated date = NULL
AS
BEGIN
SET NOCOUNT ON;
DECLARE @Query NVARCHAR(1000)
DECLARE @SuccessIndicator tinyint = 0,
@NewRecord BIT;

-- Check if an entry exists
IF EXISTS(SELECT EmployerID FROM ExPat.Employers WHERE EmployerID = @EmployerID AND @EmployerID <> -1)
	BEGIN
		SET @Query=N'
		UPDATE ExPat.Employers 
		SET	
			PAYERef=@PAYERef,
			EmployerName=@EmployerName,
			ParentGroupID=@ParentGroupID,
			IsParent=@IsParent,
			EntityID=@EntityID,
			CountryID=@CountryID,
			COTAXUTR=@COTAXUTR,
			CustomerGroupID=@CustomerGroupID,
			IndustrySectorID=@IndustrySectorID,
			DedicatedScheme=@DedicatedScheme,
			Appendix4=@Appendix4,
			Appendix5=@Appendix5,
			Appendix6=@Appendix6,
			Appendix7A=@Appendix7A,
			Appendix7B=@Appendix7B,
			Appendix8=@Appendix8,
			NonResidentDirector=@NonResidentDirector,
			ConcessionaryCashBasis=@ConcessionaryCashBasis,
			BespokeScaleRateAgreement=@BespokeScaleRateAgreement,
			S690=@S690,
			Notes=@Notes,
			ActiveScheme=@ActiveScheme,
			UpdatedBy=@UpdatedBy,
			DateUpdated=SYSDATETIME()

		WHERE  EmployerID=@EmployerID;'
   END
ELSE
	BEGIN
		SET @NewRecord = 1;
		SET @Query=N'
		INSERT INTO ExPat.Employers
		(
			PAYERef,
			EmployerName,
			ParentGroupID,
			IsParent,
			EntityID,
			CountryID,
			COTAXUTR,
			CustomerGroupID,
			IndustrySectorID,
			DedicatedScheme,
			Appendix4,
			Appendix5,
			Appendix6,
			Appendix7A,
			Appendix7B,
			Appendix8,
			NonResidentDirector,
			ConcessionaryCashBasis,
			BespokeScaleRateAgreement,
			S690,
			Notes,
			ActiveScheme,
			UpdatedBy, 
			DateUpdated
		)
		VALUES
		(
			@PAYERef,
			@EmployerName,
			@ParentGroupID,
			@IsParent,
			@EntityID,
			@CountryID,
			@COTAXUTR,
			@CustomerGroupID,
			@IndustrySectorID,
			@DedicatedScheme,
			@Appendix4,
			@Appendix5,
			@Appendix6,
			@Appendix7A,
			@Appendix7B,
			@Appendix8,
			@NonResidentDirector,
			@ConcessionaryCashBasis,
			@BespokeScaleRateAgreement,
			@S690,
			@Notes,
			@ActiveScheme,
			@UpdatedBy,
			SYSDATETIME()
		)'
	END
END

-- Standardised method of executing a transaction
BEGIN TRY
   BEGIN TRANSACTION
   Execute sp_Executesql @Query, N'
	@EmployerID int,
	@PAYERef varchar(50),
	@EmployerName varchar(50),
	@ParentGroupID int,
	@IsParent bit,
	@EntityID int,
	@CountryID int,
	@COTAXUTR varchar(50),
	@CustomerGroupID int,
	@IndustrySectorID int,
	@DedicatedScheme bit,
	@Appendix4 date,
	@Appendix5 date,
	@Appendix6 date,
	@Appendix7A date,
	@Appendix7B date,
	@Appendix8 date,
	@NonResidentDirector bit,
	@ConcessionaryCashBasis date,
	@BespokeScaleRateAgreement date,
	@S690 date,
	@Notes varchar(50),
	@ActiveScheme bit,
	@UpdatedBy int,
    @DateUpdated date',
	@EmployerID,
	@PAYERef,
	@EmployerName,
	@ParentGroupID,
	@IsParent,
	@EntityID,
	@CountryID,
	@COTAXUTR,
	@CustomerGroupID,
	@IndustrySectorID,
	@DedicatedScheme,
	@Appendix4,
	@Appendix5,
	@Appendix6,
	@Appendix7A,
	@Appendix7B,
	@Appendix8,
	@NonResidentDirector,
	@ConcessionaryCashBasis,
	@BespokeScaleRateAgreement,
	@S690,
	@Notes,
	@ActiveScheme,
	@UpdatedBy,
    @DateUpdated
   COMMIT
END TRY
BEGIN CATCH
   IF @@TRANCOUNT > 0
      ROLLBACK
      SET @SuccessIndicator = 1; -- Return value is 0 if successful and 1 if unsuccessful
END CATCH

IF @NEWRECORD = 1 AND @IsParent = 1
	BEGIN
		SELECT @@IDENTITY AS NEW_ID;

		UPDATE [ExPat].[Employers]
		SET ParentGroupID = @@IDENTITY 
		WHERE EmployerID = @@IDENTITY
	END 

SELECT @SuccessIndicator AS SuccessIndicator