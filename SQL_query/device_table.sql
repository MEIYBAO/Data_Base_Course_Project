CREATE TABLE Device (
    DeviceID INT PRIMARY KEY,
    DeviceName NVARCHAR(100) NOT NULL,
    Model NVARCHAR(50),
    PurchaseDate DATE,
    Status NVARCHAR(20) NOT NULL CHECK (Status IN ('正常', '借出', '维修', '报废')),
    LabID INT FOREIGN KEY REFERENCES Lab(LabID),
    ManagerID INT FOREIGN KEY REFERENCES Manager(ManagerID)
);
