CREATE TABLE Permission (
    PermissionID INT PRIMARY KEY,
    PermissionName NVARCHAR(50) NOT NULL UNIQUE
);

INSERT INTO Permission (PermissionID,PermissionName)
VALUES (1,N'查看设备'), (2,N'添加设备'), (3,N'删除设备'), (4,N'管理用户');

