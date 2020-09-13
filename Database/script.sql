USE [master]
GO
/****** Object:  Database [RealEstateAgency]    Script Date: 13.09.2020 23:27:45 ******/
CREATE DATABASE [RealEstateAgency]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Real estate agency', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Real estate agency.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Real estate agency_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Real estate agency_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [RealEstateAgency] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RealEstateAgency].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RealEstateAgency] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RealEstateAgency] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RealEstateAgency] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RealEstateAgency] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RealEstateAgency] SET ARITHABORT OFF 
GO
ALTER DATABASE [RealEstateAgency] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RealEstateAgency] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RealEstateAgency] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RealEstateAgency] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RealEstateAgency] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RealEstateAgency] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RealEstateAgency] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RealEstateAgency] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RealEstateAgency] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RealEstateAgency] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RealEstateAgency] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RealEstateAgency] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RealEstateAgency] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RealEstateAgency] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RealEstateAgency] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RealEstateAgency] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RealEstateAgency] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RealEstateAgency] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RealEstateAgency] SET  MULTI_USER 
GO
ALTER DATABASE [RealEstateAgency] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RealEstateAgency] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RealEstateAgency] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RealEstateAgency] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RealEstateAgency] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RealEstateAgency] SET QUERY_STORE = OFF
GO
USE [RealEstateAgency]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 13.09.2020 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NULL,
	[LastName] [nvarchar](30) NULL,
	[MiddleName] [nvarchar](30) NULL,
	[Phone] [nchar](16) NULL,
	[Email] [nvarchar](60) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deal]    Script Date: 13.09.2020 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deal](
	[DemandId] [int] NOT NULL,
	[SupplyId] [int] NOT NULL,
	[Commission] [money] NOT NULL,
 CONSTRAINT [PK_Deal] PRIMARY KEY CLUSTERED 
(
	[DemandId] ASC,
	[SupplyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Demand]    Script Date: 13.09.2020 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Demand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[RealtorId] [int] NULL,
 CONSTRAINT [PK_Need] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estate]    Script Date: 13.09.2020 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estate](
	[SupplyId] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[Address] [nvarchar](80) NOT NULL,
	[Area] [float] NOT NULL,
 CONSTRAINT [PK_Property object] PRIMARY KEY CLUSTERED 
(
	[SupplyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Filter]    Script Date: 13.09.2020 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Filter](
	[DemandId] [int] NOT NULL,
	[Address] [nvarchar](80) NOT NULL,
	[MinPrice] [money] NOT NULL,
	[MaxPrice] [money] NOT NULL,
	[MinArea] [float] NOT NULL,
	[MaxArea] [float] NOT NULL,
 CONSTRAINT [PK_Filter] PRIMARY KEY CLUSTERED 
(
	[DemandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flat]    Script Date: 13.09.2020 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flat](
	[SupplyId] [int] NOT NULL,
	[Floor] [int] NOT NULL,
	[RoomCount] [int] NOT NULL,
 CONSTRAINT [PK_Flat] PRIMARY KEY CLUSTERED 
(
	[SupplyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FlatFilter]    Script Date: 13.09.2020 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlatFilter](
	[DemandId] [int] NOT NULL,
	[MinFloor] [int] NOT NULL,
	[MaxFloor] [int] NOT NULL,
	[MinRoomCount] [int] NOT NULL,
	[MaxRoomCount] [int] NOT NULL,
 CONSTRAINT [PK_FlatFilter] PRIMARY KEY CLUSTERED 
(
	[DemandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[House]    Script Date: 13.09.2020 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[House](
	[SupplyId] [int] NOT NULL,
	[FloorCount] [int] NOT NULL,
	[RoomCount] [int] NOT NULL,
 CONSTRAINT [PK_House] PRIMARY KEY CLUSTERED 
(
	[SupplyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HouseFilter]    Script Date: 13.09.2020 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HouseFilter](
	[DemandId] [int] NOT NULL,
	[MinFloorCount] [int] NOT NULL,
	[MaxFloorCount] [int] NOT NULL,
	[MinRoomCount] [int] NOT NULL,
	[MaxRoomCount] [int] NOT NULL,
 CONSTRAINT [PK_HouseFilter] PRIMARY KEY CLUSTERED 
(
	[DemandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Land plot]    Script Date: 13.09.2020 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Land plot](
	[SupplyId] [int] NOT NULL,
 CONSTRAINT [PK_Land plot] PRIMARY KEY CLUSTERED 
(
	[SupplyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LandPlotFilter]    Script Date: 13.09.2020 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LandPlotFilter](
	[DemandId] [int] NOT NULL,
 CONSTRAINT [PK_LandPlotFilter] PRIMARY KEY CLUSTERED 
(
	[DemandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Realtor]    Script Date: 13.09.2020 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Realtor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[MiddleName] [nvarchar](30) NOT NULL,
	[DealShare] [float] NOT NULL,
 CONSTRAINT [PK_Realtor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supply]    Script Date: 13.09.2020 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supply](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[RealtorId] [int] NULL,
 CONSTRAINT [PK_Supply] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (2, N'Евгений ', N'Семенов', N'Николаевич', N'32-25-55        ', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (3, N'Олеся', N'Денисова', N'Леонидовна', N'                ', N'dummy@email.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (5, N'Алексей', N'Сафронов', N'Вячеславович', N'                ', N'client@esoft.tech')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (6, N'Александр', N'Кудряшов', N'Витальевич', N'551988          ', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (8, N'Алексей', N'Фёдоров', N'Николаевич', N'                ', N'fedorov@mail.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (10, N'Светлана', N'Пелымская', N'Александровна', N'83452112233     ', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (12, N'Татьяна', N'Коновальчик', N'Геннадьевна', N'                ', N'dummy@email.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (14, N'Светлана', N'Молоковская', N'Михайловна', N'898489848       ', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (16, N'Анастасия', N'Моторина', N'Сергеевна', N'895159848       ', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (17, N'Ольга', N'Поспелова', N'Александровна', N'                ', N'angel@mail.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (18, N'Владимир', N'Жиляков', N'Владимирович', N'445588          ', N'445588@email.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (20, N'Владислав', N'Ефремов', N'Николаевич', N'                ', N'parampampam@mail.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (21, N'Валентина', N'Баль', N'Сергеевна', N'7998888444      ', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (22, N'Артем', N'Стрелков', N'Николаевич', N'                ', N'test@test.test')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (23, N'Павел', N'Луканин', N'Валерьевич', N'                ', N'foo@bar.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (25, N'Эльвира', N'Шарипова', N'Закирчановна', N'12345678910     ', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (26, N'Маргарита', N'Фомина', N'Николаевна', N'                ', N'fomina@email.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (27, N'Владислав', N'Кремлев', N'Юрьевич', N'777             ', N'kremlevvu@gmail.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (28, N'Елена', N'Пономарева', N'Сергеевна', N'                ', N'ponomareva@gmail.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (29, N'Тамара', N'Шелест', N'Васильевна', N'112             ', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (30, N'Рустам', N'Шарипов', N'Владимирович', N'                ', N'sharipov@yandex.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (31, N'Сергей', N'Романов', N'Федорович', N'2               ', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (32, N'Иван', N'Кручинин', N'Андреевич', N'                ', N'kruch@list.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (33, N'Алексей', N'Алферов', N'Николаевич', N'688899444       ', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (35, N'Алексей', N'Попов ', N'Николаевич', N'489848565       ', N'popovan@bik.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [MiddleName], [Phone], [Email]) VALUES (36, N'Наталья', N'Неезжала', N'Леонидовна', N'                ', N'neez@mail.ru')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Realtor] ON 

INSERT [dbo].[Realtor] ([Id], [FirstName], [LastName], [MiddleName], [DealShare]) VALUES (1, N'Роман', N'Фахрутдинов', N'Рубинович', 20)
INSERT [dbo].[Realtor] ([Id], [FirstName], [LastName], [MiddleName], [DealShare]) VALUES (4, N'Максим', N'Устинов', N'Алексеевич', 40)
INSERT [dbo].[Realtor] ([Id], [FirstName], [LastName], [MiddleName], [DealShare]) VALUES (7, N'Людмила', N'Сысоева', N'Валентиновна', 45)
INSERT [dbo].[Realtor] ([Id], [FirstName], [LastName], [MiddleName], [DealShare]) VALUES (9, N'Илья', N'Додонов', N'Геннадьевич', 45)
INSERT [dbo].[Realtor] ([Id], [FirstName], [LastName], [MiddleName], [DealShare]) VALUES (11, N'Руслан', N'Мухтаруллин', N'Расыхович', 45)
INSERT [dbo].[Realtor] ([Id], [FirstName], [LastName], [MiddleName], [DealShare]) VALUES (13, N'Любовь', N'Мосеева', N'Александровна', 45)
INSERT [dbo].[Realtor] ([Id], [FirstName], [LastName], [MiddleName], [DealShare]) VALUES (15, N'Алексей', N'Киселев', N'Геннадьевич', 45)
INSERT [dbo].[Realtor] ([Id], [FirstName], [LastName], [MiddleName], [DealShare]) VALUES (19, N'Евгений', N'Клюйков', N'Николаевич', 50)
INSERT [dbo].[Realtor] ([Id], [FirstName], [LastName], [MiddleName], [DealShare]) VALUES (24, N'Галина', N'Жданова', N'Николаевна', 45)
INSERT [dbo].[Realtor] ([Id], [FirstName], [LastName], [MiddleName], [DealShare]) VALUES (34, N'Елена', N'Басырова', N'Азатовна', 45)
INSERT [dbo].[Realtor] ([Id], [FirstName], [LastName], [MiddleName], [DealShare]) VALUES (37, N'Виталий', N'Швецов', N'Олегович', 45)
SET IDENTITY_INSERT [dbo].[Realtor] OFF
GO
ALTER TABLE [dbo].[Deal]  WITH CHECK ADD  CONSTRAINT [FK_Deal_Need] FOREIGN KEY([DemandId])
REFERENCES [dbo].[Demand] ([Id])
GO
ALTER TABLE [dbo].[Deal] CHECK CONSTRAINT [FK_Deal_Need]
GO
ALTER TABLE [dbo].[Demand]  WITH CHECK ADD  CONSTRAINT [FK_Demand_Filter] FOREIGN KEY([Id])
REFERENCES [dbo].[Filter] ([DemandId])
GO
ALTER TABLE [dbo].[Demand] CHECK CONSTRAINT [FK_Demand_Filter]
GO
ALTER TABLE [dbo].[Demand]  WITH CHECK ADD  CONSTRAINT [FK_Need_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Demand] CHECK CONSTRAINT [FK_Need_Client]
GO
ALTER TABLE [dbo].[Demand]  WITH CHECK ADD  CONSTRAINT [FK_Need_Realtor] FOREIGN KEY([RealtorId])
REFERENCES [dbo].[Realtor] ([Id])
GO
ALTER TABLE [dbo].[Demand] CHECK CONSTRAINT [FK_Need_Realtor]
GO
ALTER TABLE [dbo].[Estate]  WITH CHECK ADD  CONSTRAINT [FK_Estate_Flat] FOREIGN KEY([SupplyId])
REFERENCES [dbo].[Flat] ([SupplyId])
GO
ALTER TABLE [dbo].[Estate] CHECK CONSTRAINT [FK_Estate_Flat]
GO
ALTER TABLE [dbo].[Estate]  WITH CHECK ADD  CONSTRAINT [FK_Estate_House] FOREIGN KEY([SupplyId])
REFERENCES [dbo].[House] ([SupplyId])
GO
ALTER TABLE [dbo].[Estate] CHECK CONSTRAINT [FK_Estate_House]
GO
ALTER TABLE [dbo].[Estate]  WITH CHECK ADD  CONSTRAINT [FK_Estate_Land plot] FOREIGN KEY([SupplyId])
REFERENCES [dbo].[Land plot] ([SupplyId])
GO
ALTER TABLE [dbo].[Estate] CHECK CONSTRAINT [FK_Estate_Land plot]
GO
ALTER TABLE [dbo].[Filter]  WITH CHECK ADD  CONSTRAINT [FK_Filter_HouseFilter] FOREIGN KEY([DemandId])
REFERENCES [dbo].[HouseFilter] ([DemandId])
GO
ALTER TABLE [dbo].[Filter] CHECK CONSTRAINT [FK_Filter_HouseFilter]
GO
ALTER TABLE [dbo].[Filter]  WITH CHECK ADD  CONSTRAINT [FK_Filter_LandPlotFilter] FOREIGN KEY([DemandId])
REFERENCES [dbo].[LandPlotFilter] ([DemandId])
GO
ALTER TABLE [dbo].[Filter] CHECK CONSTRAINT [FK_Filter_LandPlotFilter]
GO
ALTER TABLE [dbo].[FlatFilter]  WITH CHECK ADD  CONSTRAINT [FK_FlatFilter_Filter] FOREIGN KEY([DemandId])
REFERENCES [dbo].[Filter] ([DemandId])
GO
ALTER TABLE [dbo].[FlatFilter] CHECK CONSTRAINT [FK_FlatFilter_Filter]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_Client] FOREIGN KEY([RealtorId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_Client]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_Property object] FOREIGN KEY([Id])
REFERENCES [dbo].[Estate] ([SupplyId])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_Property object]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_Realtor] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Realtor] ([Id])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_Realtor]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [CK_Client_PhoneOrEmailNotNull] CHECK  (([Phone] IS NOT NULL OR [Email] IS NOT NULL))
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [CK_Client_PhoneOrEmailNotNull]
GO
ALTER TABLE [dbo].[Estate]  WITH CHECK ADD  CONSTRAINT [CK_Estate_NoMinus] CHECK  (([Price]>=(0) AND [Area]>=(0)))
GO
ALTER TABLE [dbo].[Estate] CHECK CONSTRAINT [CK_Estate_NoMinus]
GO
ALTER TABLE [dbo].[Filter]  WITH CHECK ADD  CONSTRAINT [CK_Filter_MaxAreaMin] CHECK  (([MaxArea]>=[MinArea]))
GO
ALTER TABLE [dbo].[Filter] CHECK CONSTRAINT [CK_Filter_MaxAreaMin]
GO
ALTER TABLE [dbo].[Filter]  WITH CHECK ADD  CONSTRAINT [CK_Filter_MaxPriceMin] CHECK  (([MaxPrice]>=[MinPrice]))
GO
ALTER TABLE [dbo].[Filter] CHECK CONSTRAINT [CK_Filter_MaxPriceMin]
GO
ALTER TABLE [dbo].[Filter]  WITH CHECK ADD  CONSTRAINT [CK_Filter_NoMinus] CHECK  (([MinPrice]>=(0) AND [MaxPrice]>=(0) AND [MaxArea]>=(0) AND [MinArea]>=(0)))
GO
ALTER TABLE [dbo].[Filter] CHECK CONSTRAINT [CK_Filter_NoMinus]
GO
ALTER TABLE [dbo].[FlatFilter]  WITH CHECK ADD  CONSTRAINT [CK_FlatFilter_MaxFloorHeigherMin] CHECK  (([MaxFloor]>=[MinFloor]))
GO
ALTER TABLE [dbo].[FlatFilter] CHECK CONSTRAINT [CK_FlatFilter_MaxFloorHeigherMin]
GO
ALTER TABLE [dbo].[FlatFilter]  WITH CHECK ADD  CONSTRAINT [CK_FlatFilter_MaxRoomHeigherMin] CHECK  (([MaxRoomCount]>=[MinRoomCount]))
GO
ALTER TABLE [dbo].[FlatFilter] CHECK CONSTRAINT [CK_FlatFilter_MaxRoomHeigherMin]
GO
ALTER TABLE [dbo].[FlatFilter]  WITH CHECK ADD  CONSTRAINT [CK_FlatFilter_NoMinus] CHECK  (([MinFloor]>=(0) AND [MaxFloor]>=(0) AND [MinRoomCount]>=(0) AND [MaxRoomCount]>=(0)))
GO
ALTER TABLE [dbo].[FlatFilter] CHECK CONSTRAINT [CK_FlatFilter_NoMinus]
GO
ALTER TABLE [dbo].[House]  WITH CHECK ADD  CONSTRAINT [CK_House_NoMinus] CHECK  (([FloorCount]>=(0) AND [RoomCount]>=(0)))
GO
ALTER TABLE [dbo].[House] CHECK CONSTRAINT [CK_House_NoMinus]
GO
ALTER TABLE [dbo].[HouseFilter]  WITH CHECK ADD  CONSTRAINT [CK_HouseFilter_MaxFloorCountMin] CHECK  (([MaxFloorCount]>=[MinFloorCount]))
GO
ALTER TABLE [dbo].[HouseFilter] CHECK CONSTRAINT [CK_HouseFilter_MaxFloorCountMin]
GO
ALTER TABLE [dbo].[HouseFilter]  WITH CHECK ADD  CONSTRAINT [CK_HouseFilter_MaxRoomCountMin] CHECK  (([MaxRoomCount]>=[MinRoomCount]))
GO
ALTER TABLE [dbo].[HouseFilter] CHECK CONSTRAINT [CK_HouseFilter_MaxRoomCountMin]
GO
ALTER TABLE [dbo].[HouseFilter]  WITH CHECK ADD  CONSTRAINT [CK_HouseFilter_NoMinus] CHECK  (([MinFloorCount]>=(0) AND [MaxFloorCount]>=(0) AND [MinRoomCount]>=(0) AND [MaxRoomCount]>=(0)))
GO
ALTER TABLE [dbo].[HouseFilter] CHECK CONSTRAINT [CK_HouseFilter_NoMinus]
GO
ALTER TABLE [dbo].[Realtor]  WITH CHECK ADD  CONSTRAINT [CK_Realtor_DealShareMinMaxValue] CHECK  (([DealShare]>=(0) AND [DealShare]<=(100)))
GO
ALTER TABLE [dbo].[Realtor] CHECK CONSTRAINT [CK_Realtor_DealShareMinMaxValue]
GO
USE [master]
GO
ALTER DATABASE [RealEstateAgency] SET  READ_WRITE 
GO
