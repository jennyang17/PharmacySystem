CREATE PROCEDURE OSP_Create_Prescription
	@PrescriptionID INT OUTPUT,
	@PatientID INT,
	@PrescriberID INT,
	@Date DATE

AS
BEGIN

	INSERT INTO 
		Prescription
		(PatientID, PrescriberID, [Date])
	VALUES
		(@PatientID, @PrescriberID, @Date);

	SET @PrescriptionID = SCOPE_IDENTITY();


END;