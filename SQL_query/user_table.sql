CREATE TABLE UserInfo (
    UserName NVARCHAR(50) PRIMARY KEY,
	User_name NVARCHAR(50) NOT NULL,
	Contact NVARCHAR(50),
    PasswordHash VARBINARY(64) NOT NULL,
    Role NVARCHAR(20) NOT NULL -- 管理员 / 普通用户
);
