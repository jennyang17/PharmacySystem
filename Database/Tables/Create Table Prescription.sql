IF NOT EXISTS (SELECT 'X' FROM sys.tables WHERE name = 'Prescription')

BEGIN
CREATE TABLE Prescription (
	PrescriptionID INT IDENTITY(1,1) NOT NULL,
	PatientID INT NOT NULL,
	PrescriberID INT NOT NULL,
	[Date] DATE NOT NULL,
	PRIMARY KEY (PrescriptionID),
	FOREIGN KEY(PatientID) REFERENCES Patient(PatientID),
	FOREIGN KEY(PrescriberID) REFERENCES Prescriber(PrescriberID)

);
END

IF NOT EXISTS (SELECT 'X' FROM sys.columns WHERE object_id = OBJECT_ID('Prescription') AND name = 'IsDeleted')
BEGIN
	ALTER TABLE Prescription ADD IsDeleted BIT NOT NULL DEFAULT(0)
END