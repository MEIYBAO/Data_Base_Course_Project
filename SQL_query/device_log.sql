CREATE TABLE DeviceLog (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    DeviceID INT NOT NULL,  -- ������豸���
    Action NVARCHAR(50) NOT NULL,      -- �������ͣ��������޸ġ�������黹��
    Operator NVARCHAR(50) NOT NULL,    -- �������û���
    ActionDate DATETIME NOT NULL,      -- ����ʱ��
    Note NVARCHAR(255),                -- ��ע��Ϣ
);
