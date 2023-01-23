CREATE PROCEDURE OSP_Create_Patient
	@PatientID INT OUTPUT,
	@Name NVARCHAR(100),
	@DOB DATE,
	@Address NVARCHAR(100),
	@NHSnumber NVARCHAR(10),
	@Exemption NVARCHAR(1)

AS
BEGIN

	INSERT INTO 
		Patient
		([Name], DOB, [Address], NHSnumber, Exemption)
	VALUES
		(@Name, @DOB, @Address, @NHSnumber, @Exemption);

	SET @PatientID = SCOPE_IDENTITY();


END;