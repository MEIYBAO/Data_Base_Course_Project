-- ���2������Ա
INSERT INTO UserInfo (UserID,UserName, PasswordHash, Role)
VALUES (01,'meiyingbao', HASHBYTES('SHA2_256', '123456'), '����Ա');

INSERT INTO UserInfo (UserID,UserName, PasswordHash, Role)
VALUES (02,'dcc', HASHBYTES('SHA2_256', '123456'), '����Ա');

-- ���ʵ����
INSERT INTO Lab (LabID,LabName, Location)
VALUES (01,'��ѧʵ����', '��ѧ¥ A-304');

-- ��ӹ���Ա��Ϣ
INSERT INTO Manager (ManagerID,Name, Contact)
VALUES (01,'����ʦ', '13888888888');

-- ����豸
INSERT INTO Device (DeviceID,DeviceName, Model, PurchaseDate, Status, LabID, ManagerID)
VALUES (01,'���׷�����', 'SP-2000', '2022-09-01', '����', 1, 1);
