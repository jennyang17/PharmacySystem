CREATE PROCEDURE OSP_Create_Medicine
	@MedicineID INT OUTPUT,
	@Name NVARCHAR(100),
	@Strength NVARCHAR(100),
	@Formulation NVARCHAR(100)

AS
BEGIN

	INSERT INTO 
		Medicine
		([Name], Strength, Formulation)
	VALUES
		(@Name, @Strength, @Formulation);

	SET @MedicineID = SCOPE_IDENTITY();


END;

