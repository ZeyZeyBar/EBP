USE [EBP]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/8/2023 4:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 7/8/2023 4:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime2](7) NULL,
	[UpdateDate] [datetime2](7) NULL,
	[InventoryID] [int] NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 7/8/2023 4:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](100) NOT NULL,
	[CreateDate] [datetime2](7) NULL,
	[UpdateDate] [datetime2](7) NULL,
	[InventoryID] [int] NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 7/8/2023 4:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaterialTypeName] [nvarchar](100) NOT NULL,
	[MaterialCode] [nvarchar](100) NOT NULL,
	[Count] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[BrandID] [int] NOT NULL,
	[CreateDate] [datetime2](7) NULL,
	[UpdateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personels]    Script Date: 7/8/2023 4:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personels](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonelName] [nvarchar](150) NOT NULL,
	[PersonelLastName] [nvarchar](150) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[PersonelBirthDay] [datetime2](7) NOT NULL,
	[PersonelAddress] [nvarchar](150) NULL,
	[CreateDate] [datetime2](7) NULL,
	[UpdateDate] [datetime2](7) NULL,
	[RegisterNo] [int] NOT NULL,
 CONSTRAINT [PK_Personels] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/8/2023 4:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[UserLastName] [nvarchar](100) NOT NULL,
	[PersonelID] [int] NOT NULL,
	[CreateDate] [datetime2](7) NULL,
	[UpdateDate] [datetime2](7) NULL,
	[RolType] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230619132503_newTable', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230619133034_newTableRolAdd', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230619133956_newTableUserAdd', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230626094319_tabloUpdateUserv2', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230626100018_brandTableAdd', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230626100915_inventoryTableAdd', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230627125253_inventoryRelationDüzenlenme', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([ID], [BrandName], [CreateDate], [UpdateDate], [InventoryID]) VALUES (1, N'Delta', NULL, NULL, 9)
INSERT [dbo].[Brands] ([ID], [BrandName], [CreateDate], [UpdateDate], [InventoryID]) VALUES (2, N'Yılmaz Redüktör', NULL, NULL, 9)
INSERT [dbo].[Brands] ([ID], [BrandName], [CreateDate], [UpdateDate], [InventoryID]) VALUES (3, N'SKF', NULL, NULL, NULL)
INSERT [dbo].[Brands] ([ID], [BrandName], [CreateDate], [UpdateDate], [InventoryID]) VALUES (6, N'Tekmaksan', NULL, NULL, NULL)
INSERT [dbo].[Brands] ([ID], [BrandName], [CreateDate], [UpdateDate], [InventoryID]) VALUES (7, N'Intel', NULL, NULL, NULL)
INSERT [dbo].[Brands] ([ID], [BrandName], [CreateDate], [UpdateDate], [InventoryID]) VALUES (8, N'Schenider', NULL, NULL, NULL)
INSERT [dbo].[Brands] ([ID], [BrandName], [CreateDate], [UpdateDate], [InventoryID]) VALUES (9, N'Mutlusan', NULL, NULL, NULL)
INSERT [dbo].[Brands] ([ID], [BrandName], [CreateDate], [UpdateDate], [InventoryID]) VALUES (10, N'Kleamsan', NULL, NULL, NULL)
INSERT [dbo].[Brands] ([ID], [BrandName], [CreateDate], [UpdateDate], [InventoryID]) VALUES (11, N'Şafak', NULL, NULL, NULL)
INSERT [dbo].[Brands] ([ID], [BrandName], [CreateDate], [UpdateDate], [InventoryID]) VALUES (12, N'Logitech', NULL, NULL, NULL)
INSERT [dbo].[Brands] ([ID], [BrandName], [CreateDate], [UpdateDate], [InventoryID]) VALUES (13, N'Samsung', NULL, NULL, NULL)
INSERT [dbo].[Brands] ([ID], [BrandName], [CreateDate], [UpdateDate], [InventoryID]) VALUES (14, N'Connectors', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([ID], [DepartmentName], [CreateDate], [UpdateDate], [InventoryID]) VALUES (1, N'İnsan Kaynakları', NULL, NULL, NULL)
INSERT [dbo].[Departments] ([ID], [DepartmentName], [CreateDate], [UpdateDate], [InventoryID]) VALUES (2, N'Bilgi Sistemleri', NULL, NULL, NULL)
INSERT [dbo].[Departments] ([ID], [DepartmentName], [CreateDate], [UpdateDate], [InventoryID]) VALUES (3, N'Elektrik', NULL, NULL, NULL)
INSERT [dbo].[Departments] ([ID], [DepartmentName], [CreateDate], [UpdateDate], [InventoryID]) VALUES (4, N'Mekanik', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Inventory] ON 

INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (1, N'Asenkron Sürücü', N'VFD007CP4EA-21', 4, 3, 2, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (2, N'Planet Redüktör', N'PA070-C0058B1430', 4, 4, 1, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (3, N'Planet Redüktör', N'PA070-A020CB1430', 5, 4, 2, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (4, N'Asenkron Redüktör', N'1/20', 6, 4, 2, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (5, N'Piston', N'cetop RP 53p', 6, 4, 1, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (6, N'Piston', N'VDMA 24562-1', 4, 4, 1, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (8, N'Valf', N'TESY-62 1/4"', 4, 4, 6, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (9, N'Asenkron Sürücü', N'VFD055CP4EB21', 5, 3, 1, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (12, N'Planet Redüktör', N'PA90-C0108C1935', 4, 4, 1, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (13, N'Rulman', N'6204', 5, 4, 3, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (14, N'Rulman', N'6026', 4, 4, 3, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (15, N'Rulman', N'6028', 4, 4, 3, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (16, N'Endüstriyel Bilgisayar', N'DIAVH-PPC1105103', 2, 2, 7, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (17, N'Mouse', N'ABC-1205-36A', 7, 2, 12, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (18, N'Klavye', N'DEF-1205-36A', 8, 2, 12, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (19, N'Ekran', N'GHI-1205-36A', 4, 2, 13, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (22, N'RJ45', N'RJ', 5, 2, 14, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (23, N'CAT6 Kablo', N'CAT6', 7, 2, 14, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (24, N'Ekleme Switch', N'SW', 3, 2, 14, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (25, N'Haberleşme Kablo', N'UC-PRG020-12A', 5, 2, 7, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (26, N'Operatör Koltuk', N'KLTK', 3, 2, 14, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (27, N'Operatör Masa', N'MS', 3, 2, 14, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (28, N'Asenkron Sürücü', N'VFD075CP4EB-21', 3, 3, 1, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (29, N'Asenkron Motor', N'0,75 kw 2800 d/dk', 4, 3, 1, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (30, N'Servo Sürücü', N'ASD-B2-0221-B', 3, 3, 8, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (31, N'Servo Sürücü', N'ASD-B2-0721-B', 6, 3, 6, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (32, N'Servo Motor', N'ECMA-C20602-S', 3, 3, 6, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (33, N'Servo Motor', N'ECMA-C20807-S', 4, 3, 6, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (34, N'Servo Motor Kabloları', N'ASDBCP202-C', 4, 3, 14, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (35, N'Servo Motor Kabloları', N'ASD-CP13-CHL', 4, 3, 14, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (36, N'Kontrol Paneli', N'NC20AA-L1-AE', 6, 3, 8, NULL, NULL)
INSERT [dbo].[Inventory] ([ID], [MaterialTypeName], [MaterialCode], [Count], [DepartmentID], [BrandID], [CreateDate], [UpdateDate]) VALUES (37, N'Giriş Çıkış Modülü', N'DVP-RTU/R1', 4, 3, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Inventory] OFF
GO
SET IDENTITY_INSERT [dbo].[Personels] ON 

INSERT [dbo].[Personels] ([ID], [PersonelName], [PersonelLastName], [DepartmentID], [PersonelBirthDay], [PersonelAddress], [CreateDate], [UpdateDate], [RegisterNo]) VALUES (1, N'Zeynep ', N'BARAN', 2, CAST(N'1997-01-17T00:00:00.0000000' AS DateTime2), N'Küçükçekmece', NULL, NULL, 7752)
INSERT [dbo].[Personels] ([ID], [PersonelName], [PersonelLastName], [DepartmentID], [PersonelBirthDay], [PersonelAddress], [CreateDate], [UpdateDate], [RegisterNo]) VALUES (2, N'Sedef', N'BARAN', 4, CAST(N'2000-12-22T00:00:00.0000000' AS DateTime2), N'Küçükçekmece', NULL, NULL, 4545)
INSERT [dbo].[Personels] ([ID], [PersonelName], [PersonelLastName], [DepartmentID], [PersonelBirthDay], [PersonelAddress], [CreateDate], [UpdateDate], [RegisterNo]) VALUES (3, N'Murat', N'Kaya', 4, CAST(N'1997-12-20T00:00:00.0000000' AS DateTime2), N'Maltepe', NULL, NULL, 4444)
INSERT [dbo].[Personels] ([ID], [PersonelName], [PersonelLastName], [DepartmentID], [PersonelBirthDay], [PersonelAddress], [CreateDate], [UpdateDate], [RegisterNo]) VALUES (4, N'Çağrı', N'Tekin', 3, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Silivri', NULL, NULL, 1111)
INSERT [dbo].[Personels] ([ID], [PersonelName], [PersonelLastName], [DepartmentID], [PersonelBirthDay], [PersonelAddress], [CreateDate], [UpdateDate], [RegisterNo]) VALUES (5, N'Kemal', N'Kılıç', 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Silivri', NULL, NULL, 8989)
INSERT [dbo].[Personels] ([ID], [PersonelName], [PersonelLastName], [DepartmentID], [PersonelBirthDay], [PersonelAddress], [CreateDate], [UpdateDate], [RegisterNo]) VALUES (7, N'Hakan', N'Akkaya', 2, CAST(N'1992-01-06T00:00:00.0000000' AS DateTime2), N'Kağıthane', NULL, NULL, 2222)
INSERT [dbo].[Personels] ([ID], [PersonelName], [PersonelLastName], [DepartmentID], [PersonelBirthDay], [PersonelAddress], [CreateDate], [UpdateDate], [RegisterNo]) VALUES (8, N'Ahmet', N'Tekin', 3, CAST(N'1990-01-31T00:00:00.0000000' AS DateTime2), N'Büyükçekmece', NULL, NULL, 3333)
SET IDENTITY_INSERT [dbo].[Personels] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [UserName], [UserLastName], [PersonelID], [CreateDate], [UpdateDate], [RolType]) VALUES (2, N'admin', N'admin', 1, NULL, NULL, N'admin')
INSERT [dbo].[Users] ([ID], [UserName], [UserLastName], [PersonelID], [CreateDate], [UpdateDate], [RolType]) VALUES (3, N'mekanikPersonel', N'mekanikPersonel', 2, NULL, NULL, N'personel')
INSERT [dbo].[Users] ([ID], [UserName], [UserLastName], [PersonelID], [CreateDate], [UpdateDate], [RolType]) VALUES (5, N'mekanikSef', N'mekanikSef', 3, NULL, NULL, N'sef')
INSERT [dbo].[Users] ([ID], [UserName], [UserLastName], [PersonelID], [CreateDate], [UpdateDate], [RolType]) VALUES (7, N'bilgiSistemleriPersonel', N'bilgiSistemleriPersonel', 5, NULL, NULL, N'personel')
INSERT [dbo].[Users] ([ID], [UserName], [UserLastName], [PersonelID], [CreateDate], [UpdateDate], [RolType]) VALUES (8, N'elektrikSef', N'elektrikSef', 8, NULL, NULL, N'sef')
INSERT [dbo].[Users] ([ID], [UserName], [UserLastName], [PersonelID], [CreateDate], [UpdateDate], [RolType]) VALUES (9, N'elektrikPersonel', N'elektrikPersonel', 7, NULL, NULL, N'personel')
INSERT [dbo].[Users] ([ID], [UserName], [UserLastName], [PersonelID], [CreateDate], [UpdateDate], [RolType]) VALUES (10, N'bilgiSistemleriSef', N'bilgiSistemleriSef', 4, NULL, NULL, N'sef')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Personels] ADD  DEFAULT ((0)) FOR [RegisterNo]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [RolType]
GO
ALTER TABLE [dbo].[Brands]  WITH CHECK ADD  CONSTRAINT [FK_Brands_Inventory_InventoryID] FOREIGN KEY([InventoryID])
REFERENCES [dbo].[Inventory] ([ID])
GO
ALTER TABLE [dbo].[Brands] CHECK CONSTRAINT [FK_Brands_Inventory_InventoryID]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Inventory_InventoryID] FOREIGN KEY([InventoryID])
REFERENCES [dbo].[Inventory] ([ID])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Inventory_InventoryID]
GO
ALTER TABLE [dbo].[Personels]  WITH CHECK ADD  CONSTRAINT [FK_Personels_Departments_DepartmentID] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Personels] CHECK CONSTRAINT [FK_Personels_Departments_DepartmentID]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Personels_PersonelID] FOREIGN KEY([PersonelID])
REFERENCES [dbo].[Personels] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Personels_PersonelID]
GO
