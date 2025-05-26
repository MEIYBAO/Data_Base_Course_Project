-- 添加2个管理员
INSERT INTO UserInfo (UserName, PasswordHash, Role)
VALUES ('meiyingbao', HASHBYTES('SHA2_256', '123456'), '管理员');

INSERT INTO UserInfo (UserName, PasswordHash, Role)
VALUES ('dcc', HASHBYTES('SHA2_256', '123456'), '管理员');

-- 添加实验室
INSERT INTO Lab (LabName, Location)
VALUES ('化学实验室', '教学楼 A-304');

-- 添加管理员信息
INSERT INTO Manager (Name, Contact)
VALUES ('李老师', '13888888888');

-- 添加设备
INSERT INTO Device (DeviceName, Model, PurchaseDate, Status, LabID, ManagerID)
VALUES ('光谱分析仪', 'SP-2000', '2022-09-01', '正常', 1, 1);
