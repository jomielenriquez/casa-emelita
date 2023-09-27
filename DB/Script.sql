USE [CASAEMELITA]
GO
/****** Object:  Table [dbo].[TBL_ADMIN]    Script Date: 27/09/2023 8:33:11 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_ADMIN](
	[ADMINID] [uniqueidentifier] NOT NULL,
	[FIRSTNAME] [nvarchar](50) NOT NULL,
	[MIDDLENAME] [nvarchar](50) NULL,
	[LASTNAME] [nvarchar](50) NOT NULL,
	[USERNAME] [nvarchar](50) NOT NULL,
	[PASSWORD] [nvarchar](50) NOT NULL,
	[CREATEDDATE] [datetime] NOT NULL,
	[CREATEDBY] [nvarchar](50) NULL,
	[UPDATEDDATE] [datetime] NULL,
	[UPDATEDBY] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ADMINID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_CATEGORY]    Script Date: 27/09/2023 8:33:11 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_CATEGORY](
	[CATEGORYID] [uniqueidentifier] NOT NULL,
	[CATEGORYNAME] [nvarchar](50) NOT NULL,
	[CATEGORYDESCRIPTION] [nvarchar](max) NULL,
	[CREATEDDATE] [datetime] NOT NULL,
	[CREATEDBY] [nvarchar](50) NULL,
	[UPDATEDDATE] [datetime] NULL,
	[UPDATEDBY] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CATEGORYID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_EVENTTYPE]    Script Date: 27/09/2023 8:33:11 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_EVENTTYPE](
	[EVENTTYPEID] [uniqueidentifier] NOT NULL,
	[EVENTNAME] [nvarchar](50) NOT NULL,
	[EVENTDESCRIPTION] [nvarchar](max) NULL,
	[CREATEDDATE] [datetime] NOT NULL,
	[CREATEDBY] [nvarchar](50) NULL,
	[UPDATEDDATE] [datetime] NULL,
	[UPDATEDBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_TBL_EVENTTYPE] PRIMARY KEY CLUSTERED 
(
	[EVENTTYPEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_INCLUSION]    Script Date: 27/09/2023 8:33:11 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_INCLUSION](
	[INCLUSIONID] [uniqueidentifier] NOT NULL,
	[PACKAGEINCLUSION] [uniqueidentifier] NOT NULL,
	[MENUID] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[INCLUSIONID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_MENU]    Script Date: 27/09/2023 8:33:11 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_MENU](
	[MENUID] [uniqueidentifier] NOT NULL,
	[MENUNAME] [nvarchar](50) NOT NULL,
	[MENUCODE] [nvarchar](50) NOT NULL,
	[MENUIMAGE] [nvarchar](250) NOT NULL,
	[MENUCATEGORY] [uniqueidentifier] NOT NULL,
	[MENUDESCRIPTION] [nvarchar](max) NULL,
	[PRICE] [decimal](10, 2) NOT NULL,
	[CREATEDDATE] [datetime] NOT NULL,
	[CREATEDBY] [nvarchar](50) NULL,
	[UPDATEDDATE] [datetime] NULL,
	[UPDATEDBY] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MENUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_PACKAGE]    Script Date: 27/09/2023 8:33:11 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_PACKAGE](
	[PACKAGEID] [uniqueidentifier] NOT NULL,
	[PACKAGECODE] [nvarchar](50) NOT NULL,
	[PACKAGENAME] [nvarchar](50) NOT NULL,
	[EVENTTYPE] [uniqueidentifier] NOT NULL,
	[INCLUSIONSDESCRIPTION] [nvarchar](max) NULL,
	[INCLUSIONS] [uniqueidentifier] NOT NULL,
	[ACCOMODATION] [int] NULL,
	[PRICE] [decimal](10, 2) NOT NULL,
	[CREATEDDATE] [datetime] NOT NULL,
	[CREATEDBY] [nvarchar](50) NULL,
	[UPDATEDDATE] [datetime] NULL,
	[UPDATEDBY] [nvarchar](50) NULL,
 CONSTRAINT [PK__TBL_PACK__35387D7000B87006] PRIMARY KEY CLUSTERED 
(
	[PACKAGEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[TBL_ADMIN] ([ADMINID], [FIRSTNAME], [MIDDLENAME], [LASTNAME], [USERNAME], [PASSWORD], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'0b07a14a-6864-4cbb-9e40-baa7e53de9e7', N'Administrator', NULL, N'Administrator', N'Administrator', N'test', CAST(N'2023-09-16T11:14:37.313' AS DateTime), NULL, CAST(N'2023-09-23T21:33:27.263' AS DateTime), N'0b07a14a-6864-4cbb-9e40-baa7e53de9e7')
INSERT [dbo].[TBL_CATEGORY] ([CATEGORYID], [CATEGORYNAME], [CATEGORYDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'84be9017-f6d9-4ef7-80c9-0a4a7dd21f83', N'Fish', N'Fish', CAST(N'2023-09-16T18:47:50.163' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_CATEGORY] ([CATEGORYID], [CATEGORYNAME], [CATEGORYDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'b2a40c02-fdcd-4ffd-b039-28d5bf263e6a', N'Ala Carte', N'Ala Carte', CAST(N'2023-09-16T18:47:50.163' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_CATEGORY] ([CATEGORYID], [CATEGORYNAME], [CATEGORYDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'1244ac51-de57-46ce-aab3-3b0905bb6831', N'Chicken', N'Chicken', CAST(N'2023-09-16T18:47:50.163' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_CATEGORY] ([CATEGORYID], [CATEGORYNAME], [CATEGORYDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'89f701c1-7dc3-4320-a5e4-43b79566b23c', N'Pork', N'Pork', CAST(N'2023-09-16T18:47:50.163' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_CATEGORY] ([CATEGORYID], [CATEGORYNAME], [CATEGORYDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'd9951ff5-dc77-4f3f-b087-459f663c60fb', N'Noodles and Pasta', N'Noodles and Pasta', CAST(N'2023-09-16T18:47:50.163' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_CATEGORY] ([CATEGORYID], [CATEGORYNAME], [CATEGORYDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'f659b4da-7a87-4881-9db3-4ae62e39ddb1', N'Drinks', N'Drinks', CAST(N'2023-09-16T18:47:50.163' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_CATEGORY] ([CATEGORYID], [CATEGORYNAME], [CATEGORYDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'a7d9b51d-948a-4316-85c1-77afeb8967bb', N'Shakes', N'Shakes', CAST(N'2023-09-16T18:47:50.163' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_CATEGORY] ([CATEGORYID], [CATEGORYNAME], [CATEGORYDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'f1e7419d-c81b-4887-b770-ba4f6f0e281c', N'Dessert', N'Dessert', CAST(N'2023-09-16T18:47:50.163' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_CATEGORY] ([CATEGORYID], [CATEGORYNAME], [CATEGORYDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'dc51c31e-169b-4c4f-84ce-c466b57e6693', N'Soup', N'Soup', CAST(N'2023-09-16T18:47:50.163' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_CATEGORY] ([CATEGORYID], [CATEGORYNAME], [CATEGORYDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'10a94c1d-1bc1-48e0-9f4f-c809ba1a7bda', N'Rice', N'Rice', CAST(N'2023-09-16T18:47:50.163' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_CATEGORY] ([CATEGORYID], [CATEGORYNAME], [CATEGORYDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'1faf0b62-82d1-4325-8ef5-d35ad37f0e59', N'Fries', N'Fries', CAST(N'2023-09-16T18:47:50.163' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_CATEGORY] ([CATEGORYID], [CATEGORYNAME], [CATEGORYDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'f4fcc82e-c679-466d-844e-d70585dd5ac0', N'Wine', N'Wine', CAST(N'2023-09-16T18:47:50.163' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_CATEGORY] ([CATEGORYID], [CATEGORYNAME], [CATEGORYDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'1dd264f3-858f-44d0-ad72-de6e599ef010', N'Appetizer', N'Appetizer', CAST(N'2023-09-16T18:47:50.163' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_EVENTTYPE] ([EVENTTYPEID], [EVENTNAME], [EVENTDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'0a476157-ff4a-416f-92b3-01da00157dd3', N'Birthday catering', N'Birthday catering', CAST(N'2023-09-16T18:27:09.453' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_EVENTTYPE] ([EVENTTYPEID], [EVENTNAME], [EVENTDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'739bcfdb-9f5a-4e12-8247-410cf79e47c1', N'Corporate service', N'Corporate service', CAST(N'2023-09-16T18:27:09.453' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_EVENTTYPE] ([EVENTTYPEID], [EVENTNAME], [EVENTDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'9335b565-fa4c-4460-afd7-62a563ebc005', N'Party catering', N'Party catering', CAST(N'2023-09-16T18:27:09.453' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_EVENTTYPE] ([EVENTTYPEID], [EVENTNAME], [EVENTDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'e8a634b9-18e0-4dbd-9bf0-a0a03451bfaf', N'Other services', N'Other services', CAST(N'2023-09-16T18:27:09.453' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_EVENTTYPE] ([EVENTTYPEID], [EVENTNAME], [EVENTDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'8b9362d9-147c-44d6-be95-b1410c638b05', N'All events', N'All events', CAST(N'2023-09-16T18:27:09.453' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_EVENTTYPE] ([EVENTTYPEID], [EVENTNAME], [EVENTDESCRIPTION], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'47e2c21b-9928-4a61-9024-ef1a4e457e08', N'Wedding service', N'Wedding service', CAST(N'2023-09-16T18:27:09.453' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_INCLUSION] ([INCLUSIONID], [PACKAGEINCLUSION], [MENUID]) VALUES (N'f28b5881-3ae2-442a-9d22-0dbefe4fdd03', N'78dd291f-33eb-42b3-8487-f2dfb56ca06c', N'65772b83-825d-4d49-9ce9-f16e3290f6b8')
INSERT [dbo].[TBL_INCLUSION] ([INCLUSIONID], [PACKAGEINCLUSION], [MENUID]) VALUES (N'69ea93f6-8625-44a1-a5bc-4650b376719e', N'78dd291f-33eb-42b3-8487-f2dfb56ca06c', N'5739c738-e977-45a0-8b92-f3f79c30161a')
INSERT [dbo].[TBL_INCLUSION] ([INCLUSIONID], [PACKAGEINCLUSION], [MENUID]) VALUES (N'0f8b2777-e4a3-474a-b38e-8f05e3245e3e', N'78dd291f-33eb-42b3-8487-f2dfb56ca06c', N'741121db-c3c3-466e-997c-c71244d6e28f')
INSERT [dbo].[TBL_MENU] ([MENUID], [MENUNAME], [MENUCODE], [MENUIMAGE], [MENUCATEGORY], [MENUDESCRIPTION], [PRICE], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'741121db-c3c3-466e-997c-c71244d6e28f', N'TEst123123', N'Test123', N'092323122341.png', N'b2a40c02-fdcd-4ffd-b039-28d5bf263e6a', N'Te', CAST(200.00 AS Decimal(10, 2)), CAST(N'2023-09-23T12:23:41.507' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TBL_MENU] ([MENUID], [MENUNAME], [MENUCODE], [MENUIMAGE], [MENUCATEGORY], [MENUDESCRIPTION], [PRICE], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'65772b83-825d-4d49-9ce9-f16e3290f6b8', N'TEst123123', N'Menu_Code', N'092223151538.jpg', N'f4fcc82e-c679-466d-844e-d70585dd5ac0', N'TEst', CAST(200.00 AS Decimal(10, 2)), CAST(N'2023-09-22T15:15:27.840' AS DateTime), NULL, CAST(N'2023-09-22T15:15:38.037' AS DateTime), N'0b07a14a-6864-4cbb-9e40-baa7e53de9e7')
INSERT [dbo].[TBL_MENU] ([MENUID], [MENUNAME], [MENUCODE], [MENUIMAGE], [MENUCATEGORY], [MENUDESCRIPTION], [PRICE], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'5739c738-e977-45a0-8b92-f3f79c30161a', N'Menu Name123', N'Test_Code', N'092323203340.png', N'1dd264f3-858f-44d0-ad72-de6e599ef010', N'te', CAST(1312.12 AS Decimal(10, 2)), CAST(N'2023-09-23T20:33:09.457' AS DateTime), NULL, CAST(N'2023-09-23T20:38:15.540' AS DateTime), N'0b07a14a-6864-4cbb-9e40-baa7e53de9e7')
INSERT [dbo].[TBL_PACKAGE] ([PACKAGEID], [PACKAGECODE], [PACKAGENAME], [EVENTTYPE], [INCLUSIONSDESCRIPTION], [INCLUSIONS], [ACCOMODATION], [PRICE], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY]) VALUES (N'78dd291f-33eb-42b3-8487-f2dfb56ca06c', N'PACKAGE1', N'PACKAGE 1', N'8b9362d9-147c-44d6-be95-b1410c638b05', N'*Crispy Pata*Lumpiang Shanghai*Okra and Talong (w/ bagoong)', N'717461b0-3775-428e-a4b0-428774f1bb93', 5, CAST(1200.51 AS Decimal(10, 2)), CAST(N'2023-09-23T09:22:18.917' AS DateTime), NULL, CAST(N'2023-09-23T19:38:41.670' AS DateTime), N'0b07a14a-6864-4cbb-9e40-baa7e53de9e7')
/****** Object:  Index [UQ__TBL_PACK__C566C5647CE53BAD]    Script Date: 27/09/2023 8:33:11 am ******/
ALTER TABLE [dbo].[TBL_PACKAGE] ADD  CONSTRAINT [UQ__TBL_PACK__C566C5647CE53BAD] UNIQUE NONCLUSTERED 
(
	[INCLUSIONS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TBL_ADMIN] ADD  DEFAULT (newid()) FOR [ADMINID]
GO
ALTER TABLE [dbo].[TBL_ADMIN] ADD  DEFAULT (getdate()) FOR [CREATEDDATE]
GO
ALTER TABLE [dbo].[TBL_CATEGORY] ADD  DEFAULT (newid()) FOR [CATEGORYID]
GO
ALTER TABLE [dbo].[TBL_CATEGORY] ADD  DEFAULT (getdate()) FOR [CREATEDDATE]
GO
ALTER TABLE [dbo].[TBL_EVENTTYPE] ADD  DEFAULT (newid()) FOR [EVENTTYPEID]
GO
ALTER TABLE [dbo].[TBL_EVENTTYPE] ADD  DEFAULT (getdate()) FOR [CREATEDDATE]
GO
ALTER TABLE [dbo].[TBL_INCLUSION] ADD  DEFAULT (newid()) FOR [INCLUSIONID]
GO
ALTER TABLE [dbo].[TBL_MENU] ADD  DEFAULT (newid()) FOR [MENUID]
GO
ALTER TABLE [dbo].[TBL_MENU] ADD  DEFAULT (getdate()) FOR [CREATEDDATE]
GO
ALTER TABLE [dbo].[TBL_PACKAGE] ADD  CONSTRAINT [DF__TBL_PACKA__PACKA__59FA5E80]  DEFAULT (newid()) FOR [PACKAGEID]
GO
ALTER TABLE [dbo].[TBL_PACKAGE] ADD  CONSTRAINT [DF__TBL_PACKA__INCLU__5AEE82B9]  DEFAULT (newid()) FOR [INCLUSIONS]
GO
ALTER TABLE [dbo].[TBL_PACKAGE] ADD  CONSTRAINT [DF__TBL_PACKA__CREAT__5BE2A6F2]  DEFAULT (getdate()) FOR [CREATEDDATE]
GO
ALTER TABLE [dbo].[TBL_INCLUSION]  WITH CHECK ADD  CONSTRAINT [FK_TBL_INCLUSION_TBL_MENU] FOREIGN KEY([MENUID])
REFERENCES [dbo].[TBL_MENU] ([MENUID])
GO
ALTER TABLE [dbo].[TBL_INCLUSION] CHECK CONSTRAINT [FK_TBL_INCLUSION_TBL_MENU]
GO
ALTER TABLE [dbo].[TBL_MENU]  WITH CHECK ADD  CONSTRAINT [FK_TBL_MENU_MENUCATEGORY] FOREIGN KEY([MENUCATEGORY])
REFERENCES [dbo].[TBL_CATEGORY] ([CATEGORYID])
GO
ALTER TABLE [dbo].[TBL_MENU] CHECK CONSTRAINT [FK_TBL_MENU_MENUCATEGORY]
GO
ALTER TABLE [dbo].[TBL_PACKAGE]  WITH CHECK ADD  CONSTRAINT [FK_TBL_PACKAGE] FOREIGN KEY([EVENTTYPE])
REFERENCES [dbo].[TBL_EVENTTYPE] ([EVENTTYPEID])
GO
ALTER TABLE [dbo].[TBL_PACKAGE] CHECK CONSTRAINT [FK_TBL_PACKAGE]
GO
USE [master]
GO
ALTER DATABASE [CASAEMELITA] SET  READ_WRITE 
GO
