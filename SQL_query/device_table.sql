CREATE TABLE Device (
    DeviceID INT PRIMARY KEY IDENTITY(1,1),
    DeviceName NVARCHAR(100) NOT NULL,
    Model NVARCHAR(50),
    PurchaseDate DATE,
    Status NVARCHAR(20) NOT NULL CHECK (Status IN ('����', '���', 'ά��', '����')),
    LabID INT FOREIGN KEY REFERENCES Lab(LabID),
    ManagerID NVARCHAR(50) FOREIGN KEY REFERENCES UserInfo(UserName)
);