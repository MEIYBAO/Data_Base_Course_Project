
INSERT INTO UserInfo 
VALUES 
	('meiyingbao', '÷Ӧ��','13914993851',HASHBYTES('SHA2_256', '123456'), '����Ա'),
	('dcc', '���ϳ�','2122854828@qq.com',HASHBYTES('SHA2_256', '123456'), '����Ա'),
	('li','����ʦ','12345678911',HASHBYTES('SHA2_256', '123456'),'��ͨ�û�'),
	('liu','����ʦ','12345678911',HASHBYTES('SHA2_256', '123456'),'��ͨ�û�');

-- ���ʵ����
INSERT INTO Lab (LabName, Location)
VALUES ('��ѧʵ����', '��ѧ¥ A-304'),
	   ('����ʵ����', '��ѧ¥ A-304');


-- ����豸
INSERT INTO Device (DeviceName, Model, PurchaseDate, Status, LabID, ManagerID)
VALUES ('���׷�����', 'SP-2000', '2022-09-01', '����', 1, 'li'),
       ('��΢��', 'SP-2021', '2024-08-21', '����', 2, 'liu');

INSERT INTO UserPermission(UserName,PermissionID)
VALUES('LI',1),
		('LI',2),
		('LI',3);