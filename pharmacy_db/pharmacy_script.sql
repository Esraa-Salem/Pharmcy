USE [PHARMACY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 8/16/2023 11:42:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[c_id] [int] IDENTITY(1,1) NOT NULL,
	[c_name] [varchar](50) NOT NULL,
	[c_email] [varchar](50) NULL,
	[c_phone] [varchar](11) NULL,
	[ph_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[c_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inv_Medicine]    Script Date: 8/16/2023 11:42:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inv_Medicine](
	[inv_id] [int] NOT NULL,
	[m_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[inv_id] ASC,
	[m_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 8/16/2023 11:42:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[in_id] [int] IDENTITY(1,1) NOT NULL,
	[in_name] [varchar](50) NOT NULL,
	[in_location] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[in_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicine]    Script Date: 8/16/2023 11:42:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicine](
	[m_id] [int] IDENTITY(1,1) NOT NULL,
	[m_name] [varchar](50) NOT NULL,
	[m_price] [float] NULL,
	[m_category] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[m_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ph_Inventory]    Script Date: 8/16/2023 11:42:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ph_Inventory](
	[ph_id] [int] NOT NULL,
	[inv_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ph_id] ASC,
	[inv_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ph_Medicine]    Script Date: 8/16/2023 11:42:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ph_Medicine](
	[ph_id] [int] NOT NULL,
	[m_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ph_id] ASC,
	[m_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pharmacist]    Script Date: 8/16/2023 11:42:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pharmacist](
	[ph_id] [int] IDENTITY(1,1) NOT NULL,
	[ph_name] [nvarchar](50) NULL,
	[ph_salary] [float] NULL,
	[ph_email] [varchar](50) NULL,
 CONSTRAINT [PK_Pharmacist] PRIMARY KEY CLUSTERED 
(
	[ph_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescription]    Script Date: 8/16/2023 11:42:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescription](
	[p_id] [int] IDENTITY(1,1) NOT NULL,
	[p_date] [date] NULL,
	[ph_id] [int] NULL,
	[cust_id] [int] NULL,
 CONSTRAINT [PK__Prescrip__82E06B91B2422400] PRIMARY KEY CLUSTERED 
(
	[p_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([c_id], [c_name], [c_email], [c_phone], [ph_id]) VALUES (1, N'Ahmed Samed', N'ahmed2@gmail.com', N'012345476', NULL)
INSERT [dbo].[Customer] ([c_id], [c_name], [c_email], [c_phone], [ph_id]) VALUES (2, N'Ahmed Samed', N'ahmed2@gmail.com', N'012345476', NULL)
INSERT [dbo].[Customer] ([c_id], [c_name], [c_email], [c_phone], [ph_id]) VALUES (3, N'Sara Johnson', N'sara.johnson@gmail.com', N'987654321', NULL)
INSERT [dbo].[Customer] ([c_id], [c_name], [c_email], [c_phone], [ph_id]) VALUES (4, N'Mohamed Ali', N'mohamed.ali@gmail.com', N'456789012', NULL)
INSERT [dbo].[Customer] ([c_id], [c_name], [c_email], [c_phone], [ph_id]) VALUES (5, N'Emily Smith', N'emily.smith@gmail.com', N'321098765', NULL)
INSERT [dbo].[Customer] ([c_id], [c_name], [c_email], [c_phone], [ph_id]) VALUES (6, N'Alex Anderson', N'alex.anderson@gmail.com', N'654321098', NULL)
INSERT [dbo].[Customer] ([c_id], [c_name], [c_email], [c_phone], [ph_id]) VALUES (7, N'Linda Wilson', N'linda.wilson@gmail.com', N'789012345', NULL)
INSERT [dbo].[Customer] ([c_id], [c_name], [c_email], [c_phone], [ph_id]) VALUES (8, N'David Brown', N'david.brown@gmail.com', N'210987654', NULL)
INSERT [dbo].[Customer] ([c_id], [c_name], [c_email], [c_phone], [ph_id]) VALUES (9, N'Olivia Davis', N'olivia.davis@gmail.com', N'543210987', NULL)
INSERT [dbo].[Customer] ([c_id], [c_name], [c_email], [c_phone], [ph_id]) VALUES (10, N'Jacob Taylor', N'jacob.taylor@gmail.com', N'876543210', NULL)
INSERT [dbo].[Customer] ([c_id], [c_name], [c_email], [c_phone], [ph_id]) VALUES (11, N'Sophia Thompson', N'sophia.thompson@gmail.com', N'109876543', NULL)
INSERT [dbo].[Customer] ([c_id], [c_name], [c_email], [c_phone], [ph_id]) VALUES (12, N'William Clark', N'william.clark@gmail.com', N'432109876', NULL)
INSERT [dbo].[Customer] ([c_id], [c_name], [c_email], [c_phone], [ph_id]) VALUES (13, N'Emma Turner', N'emma.turner@gmail.com', N'765432109', NULL)
INSERT [dbo].[Customer] ([c_id], [c_name], [c_email], [c_phone], [ph_id]) VALUES (14, N'Michael White', N'michael.white@gmail.com', N'098765432', NULL)
INSERT [dbo].[Customer] ([c_id], [c_name], [c_email], [c_phone], [ph_id]) VALUES (15, N'Mia Martinez', N'mia.martinez@gmail.com', N'321098765', NULL)
INSERT [dbo].[Customer] ([c_id], [c_name], [c_email], [c_phone], [ph_id]) VALUES (16, N'James Lee', N'james.lee@gmail.com', N'654321098', NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (1, 2)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (1, 3)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (1, 4)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (1, 6)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (1, 8)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (2, 1)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (2, 2)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (2, 3)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (2, 5)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (2, 7)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (3, 1)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (3, 2)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (3, 3)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (3, 4)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (3, 7)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (4, 2)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (4, 4)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (4, 5)
INSERT [dbo].[Inv_Medicine] ([inv_id], [m_id]) VALUES (4, 6)
GO
SET IDENTITY_INSERT [dbo].[Inventory] ON 

INSERT [dbo].[Inventory] ([in_id], [in_name], [in_location]) VALUES (1, N'Abaseery_branch', N'benisuef')
INSERT [dbo].[Inventory] ([in_id], [in_name], [in_location]) VALUES (2, N'inv2_branch', N'Cairo')
INSERT [dbo].[Inventory] ([in_id], [in_name], [in_location]) VALUES (3, N'Alexandria Medical Center - Alexandria', N'Alexandria')
INSERT [dbo].[Inventory] ([in_id], [in_name], [in_location]) VALUES (4, N'Giza Pharmacy - Giza', N'Giza')
SET IDENTITY_INSERT [dbo].[Inventory] OFF
GO
SET IDENTITY_INSERT [dbo].[Medicine] ON 

INSERT [dbo].[Medicine] ([m_id], [m_name], [m_price], [m_category]) VALUES (1, N'metformeen', 26, N'diabetes')
INSERT [dbo].[Medicine] ([m_id], [m_name], [m_price], [m_category]) VALUES (2, N'petadeen', 48, N'children_cold')
INSERT [dbo].[Medicine] ([m_id], [m_name], [m_price], [m_category]) VALUES (3, N'ibuprofen', 10, N'pain_relief')
INSERT [dbo].[Medicine] ([m_id], [m_name], [m_price], [m_category]) VALUES (4, N'amoxicillin', 15, N'antibiotics')
INSERT [dbo].[Medicine] ([m_id], [m_name], [m_price], [m_category]) VALUES (5, N'loratadine', 8, N'allergy')
INSERT [dbo].[Medicine] ([m_id], [m_name], [m_price], [m_category]) VALUES (6, N'omeprazole', 20, N'acid_reflux')
INSERT [dbo].[Medicine] ([m_id], [m_name], [m_price], [m_category]) VALUES (7, N'paracetamol', 5, N'fever')
INSERT [dbo].[Medicine] ([m_id], [m_name], [m_price], [m_category]) VALUES (8, N'vitamin C', 12, N'supplements')
SET IDENTITY_INSERT [dbo].[Medicine] OFF
GO
INSERT [dbo].[Ph_Inventory] ([ph_id], [inv_id]) VALUES (1, 2)
INSERT [dbo].[Ph_Inventory] ([ph_id], [inv_id]) VALUES (1, 4)
INSERT [dbo].[Ph_Inventory] ([ph_id], [inv_id]) VALUES (2, 3)
INSERT [dbo].[Ph_Inventory] ([ph_id], [inv_id]) VALUES (3, 1)
INSERT [dbo].[Ph_Inventory] ([ph_id], [inv_id]) VALUES (3, 2)
INSERT [dbo].[Ph_Inventory] ([ph_id], [inv_id]) VALUES (4, 3)
GO
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (1, 2)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (1, 3)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (1, 4)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (1, 5)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (2, 3)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (2, 6)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (2, 7)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (3, 2)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (3, 4)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (3, 8)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (4, 1)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (4, 3)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (4, 5)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (5, 2)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (5, 6)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (6, 1)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (6, 4)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (6, 7)
INSERT [dbo].[Ph_Medicine] ([ph_id], [m_id]) VALUES (6, 8)
GO
SET IDENTITY_INSERT [dbo].[Pharmacist] ON 

INSERT [dbo].[Pharmacist] ([ph_id], [ph_name], [ph_salary], [ph_email]) VALUES (1, N'mohamed ahmed', 3000, N'mohamed@gmail.com')
INSERT [dbo].[Pharmacist] ([ph_id], [ph_name], [ph_salary], [ph_email]) VALUES (2, N'john doe', 4000, N'john.doe@gmail.com')
INSERT [dbo].[Pharmacist] ([ph_id], [ph_name], [ph_salary], [ph_email]) VALUES (3, N'sara smith', 3500, N'sara.smith@gmail.com')
INSERT [dbo].[Pharmacist] ([ph_id], [ph_name], [ph_salary], [ph_email]) VALUES (4, N'ahmed ali', 5000, N'ahmed.ali@gmail.com')
INSERT [dbo].[Pharmacist] ([ph_id], [ph_name], [ph_salary], [ph_email]) VALUES (5, N'emily jones', 4500, N'emily.jones@gmail.com')
INSERT [dbo].[Pharmacist] ([ph_id], [ph_name], [ph_salary], [ph_email]) VALUES (6, N'alexander wang', 3200, N'alexander.wang@gmail.com')
INSERT [dbo].[Pharmacist] ([ph_id], [ph_name], [ph_salary], [ph_email]) VALUES (7, N'lisa parker', 3700, N'lisa.parker@gmail.com')
INSERT [dbo].[Pharmacist] ([ph_id], [ph_name], [ph_salary], [ph_email]) VALUES (8, N'david wilson', 7000, N'david.wilson@gmail.com')
INSERT [dbo].[Pharmacist] ([ph_id], [ph_name], [ph_salary], [ph_email]) VALUES (9, N'olivia brown', 6000, N'olivia.brown@gmail.com')
SET IDENTITY_INSERT [dbo].[Pharmacist] OFF
GO
SET IDENTITY_INSERT [dbo].[Prescription] ON 

INSERT [dbo].[Prescription] ([p_id], [p_date], [ph_id], [cust_id]) VALUES (1, CAST(N'2022-02-02' AS Date), 1, 1)
INSERT [dbo].[Prescription] ([p_id], [p_date], [ph_id], [cust_id]) VALUES (2, CAST(N'2022-02-03' AS Date), 1, 2)
INSERT [dbo].[Prescription] ([p_id], [p_date], [ph_id], [cust_id]) VALUES (3, CAST(N'2022-02-04' AS Date), 2, 3)
INSERT [dbo].[Prescription] ([p_id], [p_date], [ph_id], [cust_id]) VALUES (4, CAST(N'2022-02-05' AS Date), 2, 4)
INSERT [dbo].[Prescription] ([p_id], [p_date], [ph_id], [cust_id]) VALUES (5, CAST(N'2022-02-06' AS Date), 3, 5)
INSERT [dbo].[Prescription] ([p_id], [p_date], [ph_id], [cust_id]) VALUES (6, CAST(N'2022-02-07' AS Date), 3, 6)
INSERT [dbo].[Prescription] ([p_id], [p_date], [ph_id], [cust_id]) VALUES (7, CAST(N'2022-02-08' AS Date), 4, 7)
INSERT [dbo].[Prescription] ([p_id], [p_date], [ph_id], [cust_id]) VALUES (8, CAST(N'2022-02-09' AS Date), 4, 8)
INSERT [dbo].[Prescription] ([p_id], [p_date], [ph_id], [cust_id]) VALUES (9, CAST(N'2022-02-10' AS Date), 5, 9)
INSERT [dbo].[Prescription] ([p_id], [p_date], [ph_id], [cust_id]) VALUES (10, CAST(N'2022-02-11' AS Date), 5, 10)
INSERT [dbo].[Prescription] ([p_id], [p_date], [ph_id], [cust_id]) VALUES (11, CAST(N'2022-02-12' AS Date), 6, 11)
INSERT [dbo].[Prescription] ([p_id], [p_date], [ph_id], [cust_id]) VALUES (12, CAST(N'2022-02-13' AS Date), 6, 12)
INSERT [dbo].[Prescription] ([p_id], [p_date], [ph_id], [cust_id]) VALUES (13, CAST(N'2022-02-14' AS Date), 7, 13)
INSERT [dbo].[Prescription] ([p_id], [p_date], [ph_id], [cust_id]) VALUES (14, CAST(N'2022-02-15' AS Date), 7, 14)
INSERT [dbo].[Prescription] ([p_id], [p_date], [ph_id], [cust_id]) VALUES (15, CAST(N'2022-02-16' AS Date), 8, 15)
SET IDENTITY_INSERT [dbo].[Prescription] OFF
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Pharmacist] FOREIGN KEY([ph_id])
REFERENCES [dbo].[Pharmacist] ([ph_id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Pharmacist]
GO
ALTER TABLE [dbo].[Inv_Medicine]  WITH CHECK ADD  CONSTRAINT [FK_Inv_Medicine_Inventory] FOREIGN KEY([inv_id])
REFERENCES [dbo].[Inventory] ([in_id])
GO
ALTER TABLE [dbo].[Inv_Medicine] CHECK CONSTRAINT [FK_Inv_Medicine_Inventory]
GO
ALTER TABLE [dbo].[Inv_Medicine]  WITH CHECK ADD  CONSTRAINT [FK_Inv_Medicine_Medicine] FOREIGN KEY([m_id])
REFERENCES [dbo].[Medicine] ([m_id])
GO
ALTER TABLE [dbo].[Inv_Medicine] CHECK CONSTRAINT [FK_Inv_Medicine_Medicine]
GO
ALTER TABLE [dbo].[Ph_Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Ph_Inventory_Inventory] FOREIGN KEY([inv_id])
REFERENCES [dbo].[Inventory] ([in_id])
GO
ALTER TABLE [dbo].[Ph_Inventory] CHECK CONSTRAINT [FK_Ph_Inventory_Inventory]
GO
ALTER TABLE [dbo].[Ph_Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Ph_Inventory_Pharmacist] FOREIGN KEY([ph_id])
REFERENCES [dbo].[Pharmacist] ([ph_id])
GO
ALTER TABLE [dbo].[Ph_Inventory] CHECK CONSTRAINT [FK_Ph_Inventory_Pharmacist]
GO
ALTER TABLE [dbo].[Ph_Medicine]  WITH CHECK ADD  CONSTRAINT [FK_Ph_Medicine_Medicine] FOREIGN KEY([m_id])
REFERENCES [dbo].[Medicine] ([m_id])
GO
ALTER TABLE [dbo].[Ph_Medicine] CHECK CONSTRAINT [FK_Ph_Medicine_Medicine]
GO
ALTER TABLE [dbo].[Ph_Medicine]  WITH CHECK ADD  CONSTRAINT [FK_Ph_Medicine_Pharmacist] FOREIGN KEY([ph_id])
REFERENCES [dbo].[Pharmacist] ([ph_id])
GO
ALTER TABLE [dbo].[Ph_Medicine] CHECK CONSTRAINT [FK_Ph_Medicine_Pharmacist]
GO
ALTER TABLE [dbo].[Prescription]  WITH CHECK ADD  CONSTRAINT [FK_Prescription_Customer] FOREIGN KEY([cust_id])
REFERENCES [dbo].[Customer] ([c_id])
GO
ALTER TABLE [dbo].[Prescription] CHECK CONSTRAINT [FK_Prescription_Customer]
GO
ALTER TABLE [dbo].[Prescription]  WITH CHECK ADD  CONSTRAINT [FK_Prescription_Pharmacist] FOREIGN KEY([ph_id])
REFERENCES [dbo].[Pharmacist] ([ph_id])
GO
ALTER TABLE [dbo].[Prescription] CHECK CONSTRAINT [FK_Prescription_Pharmacist]
GO
