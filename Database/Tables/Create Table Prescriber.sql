IF NOT EXISTS (SELECT 'X' FROM sys.tables WHERE name = 'Prescriber')

BEGIN
	CREATE TABLE Prescriber (
		PrescriberID INT IDENTITY(1,1) NOT NULL,
		[Name] NVARCHAR(100) NOT NULL,
		TypeOfPrescriber NVARCHAR(100) NOT NULL,
		PrescriberAddress NVARCHAR(100) NOT NULL,
		PRIMARY KEY (PrescriberID)

);
END

IF NOT EXISTS (SELECT 'X' FROM sys.columns WHERE object_id = OBJECT_ID('Prescriber') AND name = 'IsDeleted')
BEGIN
	ALTER TABLE Prescriber ADD IsDeleted BIT NOT NULL DEFAULT(0)
END