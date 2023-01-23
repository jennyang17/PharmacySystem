IF NOT EXISTS (SELECT 'X' FROM sys.tables WHERE name = 'PrescriptionItem')

BEGIN
CREATE TABLE PrescriptionItem (
	PrescriptionItemID INT IDENTITY(1,1) NOT NULL,
	PrescriptionID INT NOT NULL,
	MedicineID INT NOT NULL,
	Dosage NVARCHAR(1000) NOT NULL,
	Quantity INT NOT NULL,
	PRIMARY KEY (PrescriptionItemID),
	FOREIGN KEY (PrescriptionID) REFERENCES Prescription(PrescriptionID),
	FOREIGN KEY (MedicineID) REFERENCES Medicine(MedicineID)

);
END

IF NOT EXISTS (SELECT 'X' FROM sys.columns WHERE object_id = OBJECT_ID('PrescriptionItem') AND name = 'IsDeleted')
BEGIN
	ALTER TABLE PrescriptionItem ADD IsDeleted BIT NOT NULL DEFAULT(0)
END