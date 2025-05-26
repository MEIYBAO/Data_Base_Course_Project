CREATE TABLE UserPermission (
    UserName NVARCHAR(50),
    PermissionID INT,
    GrantTime DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (UserName, PermissionID),
    FOREIGN KEY (PermissionID) REFERENCES Permission(PermissionID)
);
