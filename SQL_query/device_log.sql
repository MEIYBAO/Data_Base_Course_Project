CREATE TABLE DeviceLog (
    LogID INT PRIMARY KEY,
    DeviceID INT FOREIGN KEY REFERENCES Device(DeviceID),
    UserID INT FOREIGN KEY REFERENCES UserInfo(UserID),
    Operation NVARCHAR(20) NOT NULL, -- ������黹�����ϡ�ά��
    Time DATETIME DEFAULT GETDATE(),
    Note NVARCHAR(255)
);
