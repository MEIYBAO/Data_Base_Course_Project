-- ���2������Ա
INSERT INTO UserInfo (UserName, PasswordHash, Role)
VALUES ('meiyingbao', HASHBYTES('SHA2_256', '123456'), '����Ա');

INSERT INTO UserInfo (UserName, PasswordHash, Role)
VALUES ('dcc', HASHBYTES('SHA2_256', '123456'), '����Ա');

-- ���ʵ����
INSERT INTO Lab (LabName, Location)
VALUES ('��ѧʵ����', '��ѧ¥ A-304');

-- ��ӹ���Ա��Ϣ
INSERT INTO Manager (Name, Contact)
VALUES ('����ʦ', '13888888888');

-- ����豸
INSERT INTO Device (DeviceName, Model, PurchaseDate, Status, LabID, ManagerID)
VALUES ('���׷�����', 'SP-2000', '2022-09-01', '����', 1, 1);
