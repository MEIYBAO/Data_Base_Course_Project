USE [master]
GO
/****** Object:  Database [LabDeviceManagement]    Script Date: 2025/6/6 11:17:21 ******/
CREATE DATABASE [LabDeviceManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LabDeviceManagement', FILENAME = N'D:\SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LabDeviceManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LabDeviceManagement_log', FILENAME = N'D:\SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LabDeviceManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LabDeviceManagement] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LabDeviceManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LabDeviceManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LabDeviceManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LabDeviceManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LabDeviceManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LabDeviceManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [LabDeviceManagement] SET  MULTI_USER 
GO
ALTER DATABASE [LabDeviceManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LabDeviceManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LabDeviceManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LabDeviceManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LabDeviceManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LabDeviceManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'LabDeviceManagement', N'ON'
GO
ALTER DATABASE [LabDeviceManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [LabDeviceManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LabDeviceManagement]
GO
/****** Object:  Table [dbo].[Device]    Script Date: 2025/6/6 11:17:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Device](
	[DeviceID] [int] IDENTITY(1,1) NOT NULL,
	[DeviceName] [nvarchar](100) NOT NULL,
	[Model] [nvarchar](50) NULL,
	[PurchaseDate] [date] NULL,
	[Status] [nvarchar](20) NOT NULL,
	[LabID] [int] NULL,
	[ManagerID] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[DeviceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeviceLog]    Script Date: 2025/6/6 11:17:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceLog](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[DeviceID] [int] NOT NULL,
	[Action] [nvarchar](50) NOT NULL,
	[Operator] [nvarchar](50) NOT NULL,
	[ActionDate] [datetime] NOT NULL,
	[Note] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lab]    Script Date: 2025/6/6 11:17:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lab](
	[LabID] [int] IDENTITY(1,1) NOT NULL,
	[LabName] [nvarchar](100) NOT NULL,
	[Location] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[LabID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 2025/6/6 11:17:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[PermissionID] [int] NOT NULL,
	[PermissionName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2025/6/6 11:17:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserName] [nvarchar](50) NOT NULL,
	[User_name] [nvarchar](50) NOT NULL,
	[Contact] [nvarchar](50) NULL,
	[PasswordHash] [varbinary](64) NOT NULL,
	[Role] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPermission]    Script Date: 2025/6/6 11:17:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPermission](
	[UserName] [nvarchar](50) NOT NULL,
	[PermissionID] [int] NOT NULL,
	[GrantTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC,
	[PermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Device] ON 

INSERT [dbo].[Device] ([DeviceID], [DeviceName], [Model], [PurchaseDate], [Status], [LabID], [ManagerID]) VALUES (2, N'光谱分析仪', N'SP-2001', CAST(N'2022-09-01' AS Date), N'正常', 1, N'li')
INSERT [dbo].[Device] ([DeviceID], [DeviceName], [Model], [PurchaseDate], [Status], [LabID], [ManagerID]) VALUES (3, N'显微镜', N'SP-2021', CAST(N'2024-08-21' AS Date), N'正常', 2, N'liu')
INSERT [dbo].[Device] ([DeviceID], [DeviceName], [Model], [PurchaseDate], [Status], [LabID], [ManagerID]) VALUES (8, N'光刻机', N'SF-10012', CAST(N'2025-05-26' AS Date), N'正常', 2, N'li')
INSERT [dbo].[Device] ([DeviceID], [DeviceName], [Model], [PurchaseDate], [Status], [LabID], [ManagerID]) VALUES (11, N'12312', N'21312', CAST(N'2025-05-28' AS Date), N'借出', 9, N'liu')
SET IDENTITY_INSERT [dbo].[Device] OFF
GO
SET IDENTITY_INSERT [dbo].[DeviceLog] ON 

INSERT [dbo].[DeviceLog] ([LogID], [DeviceID], [Action], [Operator], [ActionDate], [Note]) VALUES (1, 9, N'删除设备', N'li', CAST(N'2025-05-26T14:14:16.210' AS DateTime), N'删除设备：213421')
INSERT [dbo].[DeviceLog] ([LogID], [DeviceID], [Action], [Operator], [ActionDate], [Note]) VALUES (2, 10, N'创建设备', N'meiyingbao', CAST(N'2025-05-26T22:10:01.533' AS DateTime), N'通过编辑页面自动记录')
INSERT [dbo].[DeviceLog] ([LogID], [DeviceID], [Action], [Operator], [ActionDate], [Note]) VALUES (3, 10, N'修改设备信息', N'meiyingbao', CAST(N'2025-05-26T22:10:13.670' AS DateTime), N'通过编辑页面自动记录')
INSERT [dbo].[DeviceLog] ([LogID], [DeviceID], [Action], [Operator], [ActionDate], [Note]) VALUES (4, 10, N'删除设备', N'meiyingbao', CAST(N'2025-05-26T22:10:19.067' AS DateTime), N'删除设备：21412')
INSERT [dbo].[DeviceLog] ([LogID], [DeviceID], [Action], [Operator], [ActionDate], [Note]) VALUES (5, 11, N'创建设备', N'meiyingbao', CAST(N'2025-05-28T16:26:16.203' AS DateTime), N'通过编辑页面自动记录')
SET IDENTITY_INSERT [dbo].[DeviceLog] OFF
GO
SET IDENTITY_INSERT [dbo].[Lab] ON 

INSERT [dbo].[Lab] ([LabID], [LabName], [Location]) VALUES (1, N'化学实验室', N'教学楼 A-304')
INSERT [dbo].[Lab] ([LabID], [LabName], [Location]) VALUES (2, N'物理实验室', N'教学楼 A-304')
INSERT [dbo].[Lab] ([LabID], [LabName], [Location]) VALUES (9, N'test1', N'test1')
SET IDENTITY_INSERT [dbo].[Lab] OFF
GO
INSERT [dbo].[Permission] ([PermissionID], [PermissionName]) VALUES (1, N'查看设备')
INSERT [dbo].[Permission] ([PermissionID], [PermissionName]) VALUES (4, N'管理用户')
INSERT [dbo].[Permission] ([PermissionID], [PermissionName]) VALUES (3, N'删除设备')
INSERT [dbo].[Permission] ([PermissionID], [PermissionName]) VALUES (2, N'添加设备')
GO
INSERT [dbo].[UserInfo] ([UserName], [User_name], [Contact], [PasswordHash], [Role]) VALUES (N'dcc', N'丁诚诚', N'2122854828@qq.com', 0x8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92, N'管理员')
INSERT [dbo].[UserInfo] ([UserName], [User_name], [Contact], [PasswordHash], [Role]) VALUES (N'li', N'李老师', N'12345678911', 0x8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92, N'普通用户')
INSERT [dbo].[UserInfo] ([UserName], [User_name], [Contact], [PasswordHash], [Role]) VALUES (N'liu', N'刘老师', N'12345678911', 0x8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92, N'普通用户')
INSERT [dbo].[UserInfo] ([UserName], [User_name], [Contact], [PasswordHash], [Role]) VALUES (N'meiyingbao', N'梅应宝', N'13914993851', 0x8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92, N'管理员')
INSERT [dbo].[UserInfo] ([UserName], [User_name], [Contact], [PasswordHash], [Role]) VALUES (N'testuser', N'test', N'1243123', 0xEC278A38901287B2771A13739520384D43E4B078F78AFFE702DEF108774CCE24, N'普通用户')
GO
INSERT [dbo].[UserPermission] ([UserName], [PermissionID], [GrantTime]) VALUES (N'LI', 1, CAST(N'2025-05-26T14:06:16.337' AS DateTime))
INSERT [dbo].[UserPermission] ([UserName], [PermissionID], [GrantTime]) VALUES (N'LI', 2, CAST(N'2025-05-26T14:06:16.337' AS DateTime))
INSERT [dbo].[UserPermission] ([UserName], [PermissionID], [GrantTime]) VALUES (N'LI', 3, CAST(N'2025-05-26T14:06:16.337' AS DateTime))
INSERT [dbo].[UserPermission] ([UserName], [PermissionID], [GrantTime]) VALUES (N'testuser', 1, CAST(N'2025-05-26T22:11:00.787' AS DateTime))
INSERT [dbo].[UserPermission] ([UserName], [PermissionID], [GrantTime]) VALUES (N'testuser', 2, CAST(N'2025-05-26T22:11:00.787' AS DateTime))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Permissi__0FFDA35755738F47]    Script Date: 2025/6/6 11:17:22 ******/
ALTER TABLE [dbo].[Permission] ADD UNIQUE NONCLUSTERED 
(
	[PermissionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserPermission] ADD  DEFAULT (getdate()) FOR [GrantTime]
GO
ALTER TABLE [dbo].[Device]  WITH CHECK ADD FOREIGN KEY([LabID])
REFERENCES [dbo].[Lab] ([LabID])
GO
ALTER TABLE [dbo].[Device]  WITH CHECK ADD FOREIGN KEY([ManagerID])
REFERENCES [dbo].[UserInfo] ([UserName])
GO
ALTER TABLE [dbo].[UserPermission]  WITH CHECK ADD FOREIGN KEY([PermissionID])
REFERENCES [dbo].[Permission] ([PermissionID])
GO
ALTER TABLE [dbo].[Device]  WITH CHECK ADD CHECK  (([Status]='报废' OR [Status]='维修' OR [Status]='借出' OR [Status]='正常'))
GO
USE [master]
GO
ALTER DATABASE [LabDeviceManagement] SET  READ_WRITE 
GO
