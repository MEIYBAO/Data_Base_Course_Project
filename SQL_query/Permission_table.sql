CREATE TABLE Permission (
    PermissionID INT PRIMARY KEY,
    PermissionName NVARCHAR(50) NOT NULL UNIQUE
);

INSERT INTO Permission (PermissionID,PermissionName)
VALUES (1,N'�鿴�豸'), (2,N'����豸'), (3,N'ɾ���豸'), (4,N'�����û�');

