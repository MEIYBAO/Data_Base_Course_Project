
INSERT INTO UserInfo 
VALUES 
	('meiyingbao', '梅应宝','13914993851',HASHBYTES('SHA2_256', '123456'), '管理员'),
	('dcc', '丁诚诚','2122854828@qq.com',HASHBYTES('SHA2_256', '123456'), '管理员'),
	('li','李老师','12345678911',HASHBYTES('SHA2_256', '123456'),'普通用户'),
	('liu','刘老师','12345678911',HASHBYTES('SHA2_256', '123456'),'普通用户');

-- 添加实验室
INSERT INTO Lab (LabName, Location)
VALUES ('化学实验室', '教学楼 A-304'),
	   ('物理实验室', '教学楼 A-304');


-- 添加设备
INSERT INTO Device (DeviceName, Model, PurchaseDate, Status, LabID, ManagerID)
VALUES ('光谱分析仪', 'SP-2000', '2022-09-01', '正常', 1, 'li'),
       ('显微镜', 'SP-2021', '2024-08-21', '正常', 2, 'liu');

INSERT INTO UserPermission(UserName,PermissionID)
VALUES('LI',1),
		('LI',2),
		('LI',3);