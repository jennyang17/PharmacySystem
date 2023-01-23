CREATE PROCEDURE OSP_Create_Prescriber
	@PrescriberID INT OUTPUT,
	@Name NVARCHAR(100),
	@TypeOfPrescriber NVARCHAR(100),
	@PrescriberAddress NVARCHAR(100)

AS
BEGIN

	INSERT INTO 
		Prescriber
		([Name], TypeOfPrescriber, PrescriberAddress)
	VALUES
		(@Name, @TypeOfPrescriber, @PrescriberAddress);

	SET @PrescriberID = SCOPE_IDENTITY();


END;