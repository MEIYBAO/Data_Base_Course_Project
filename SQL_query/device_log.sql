CREATE TABLE DeviceLog (
    LogID INT PRIMARY KEY,
    DeviceID INT FOREIGN KEY REFERENCES Device(DeviceID),
    UserID INT FOREIGN KEY REFERENCES UserInfo(UserID),
    Operation NVARCHAR(20) NOT NULL, -- ½è³ö¡¢¹é»¹¡¢±¨·Ï¡¢Î¬ÐÞ
    Time DATETIME DEFAULT GETDATE(),
    Note NVARCHAR(255)
);
