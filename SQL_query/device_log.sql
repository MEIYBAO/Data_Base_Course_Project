CREATE TABLE DeviceLog (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    DeviceID INT NOT NULL,  -- 外键：设备编号
    Action NVARCHAR(50) NOT NULL,      -- 操作类型：创建、修改、借出、归还等
    Operator NVARCHAR(50) NOT NULL,    -- 操作人用户名
    ActionDate DATETIME NOT NULL,      -- 操作时间
    Note NVARCHAR(255),                -- 备注信息
);
