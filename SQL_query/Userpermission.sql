CREATE TABLE UserPermission (
    UserID INT,
    PermissionID INT,
    GrantTime DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (UserID, PermissionID),
    FOREIGN KEY (UserID) REFERENCES UserInfo(UserID),
    FOREIGN KEY (PermissionID) REFERENCES Permission(PermissionID)
);
