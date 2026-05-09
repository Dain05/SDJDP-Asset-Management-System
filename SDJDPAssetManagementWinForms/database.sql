CREATE DATABASE SDJDPAssetDB;
GO

USE SDJDPAssetDB;
GO

CREATE TABLE Assets (
    AssetID VARCHAR(20) PRIMARY KEY,
    AssetType VARCHAR(50) NOT NULL,
    SerialNumber VARCHAR(50) NOT NULL,
    Department VARCHAR(50) NOT NULL,
    Status VARCHAR(30) NOT NULL
);
GO

INSERT INTO Assets (AssetID, AssetType, SerialNumber, Department, Status)
VALUES
('A100', 'Laptop', 'SN100', 'ICT', 'Available'),
('A101', 'Printer', 'SN200', 'Administration', 'In Use'),
('A102', 'Desktop PC', 'SN300', 'Finance', 'Available');
GO

SELECT * FROM Assets;
GO