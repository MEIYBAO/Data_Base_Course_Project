CREATE TABLE UserInfo (
    UserID INT PRIMARY KEY,
    UserName NVARCHAR(50) NOT NULL,
    PasswordHash VARBINARY(64) NOT NULL,
    Role NVARCHAR(20) NOT NULL -- ����Ա / ��ͨ�û�
);
