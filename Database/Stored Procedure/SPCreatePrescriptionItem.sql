CREATE PROCEDURE OSP_Create_PrescriptionItem
	@PrescriptionItemID INT OUTPUT,
	@PrescriptionID INT,
	@MedicineID INT,
	@Dosage NVARCHAR(100),
	@Quantity INT

AS
BEGIN

	INSERT INTO 
		PrescriptionItem
		(PrescriptionID, MedicineID, Dosage, Quantity)
	VALUES
		(@PrescriptionID, @MedicineID, @Dosage, @Quantity);

	SET @PrescriptionItemID = SCOPE_IDENTITY();


END;