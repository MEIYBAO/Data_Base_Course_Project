CREATE TABLE UserInfo (
    UserID INT PRIMARY KEY,
    UserName NVARCHAR(50) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) NOT NULL -- ����Ա / ��ͨ�û�
);
