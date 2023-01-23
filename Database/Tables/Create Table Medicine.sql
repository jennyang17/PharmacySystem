
IF NOT EXISTS (SELECT 'X' FROM sys.tables WHERE name = 'Medicine')
BEGIN
	CREATE TABLE Medicine (
		MedicineID INT IDENTITY(1,1) NOT NULL,
		[Name] NVARCHAR(100) NOT NULL,
		Strength NVARCHAR(100) NOT NULL,
		Formulation NVARCHAR(100) NOT NULL,
		PRIMARY KEY (MedicineID)
	);
END

IF NOT EXISTS (SELECT 'X' FROM sys.columns WHERE object_id = OBJECT_ID('Medicine') AND name = 'IsDeleted')
BEGIN
	ALTER TABLE Medicine ADD IsDeleted BIT NOT NULL DEFAULT(0)
END