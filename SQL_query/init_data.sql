-- 添加2个管理员
INSERT INTO UserInfo (UserID,UserName, PasswordHash, Role)
VALUES (01,'meiyingbao', HASHBYTES('SHA2_256', '123456'), '管理员');

INSERT INTO UserInfo (UserID,UserName, PasswordHash, Role)
VALUES (02,'dcc', HASHBYTES('SHA2_256', '123456'), '管理员');

-- 添加实验室
INSERT INTO Lab (LabID,LabName, Location)
VALUES (01,'化学实验室', '教学楼 A-304');

-- 添加管理员信息
INSERT INTO Manager (ManagerID,Name, Contact)
VALUES (01,'李老师', '13888888888');

-- 添加设备
INSERT INTO Device (DeviceID,DeviceName, Model, PurchaseDate, Status, LabID, ManagerID)
VALUES (01,'光谱分析仪', 'SP-2000', '2022-09-01', '正常', 1, 1);
