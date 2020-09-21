USE [master]
GO
/****** Object:  Database [RealEstateAgency]    Script Date: 21.09.2020 9:41:54 ******/
CREATE DATABASE [RealEstateAgency]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RealEstateAgency', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\RealEstateAgency.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RealEstateAgency_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\RealEstateAgency_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [RealEstateAgency] SET AUTO_CLOSE ON 
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
ALTER DATABASE [RealEstateAgency] SET  ENABLE_BROKER 
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
ALTER DATABASE [RealEstateAgency] SET READ_COMMITTED_SNAPSHOT ON 
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
/****** Object:  Table [dbo].[AddressInfo]    Script Date: 21.09.2020 9:41:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](80) NULL,
	[Street] [nvarchar](80) NULL,
	[HouseNumber] [int] NULL,
	[FlatNumber] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 21.09.2020 9:41:54 ******/
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
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deal]    Script Date: 21.09.2020 9:41:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deal](
	[DemandId] [int] NOT NULL,
	[SupplyId] [int] NOT NULL,
	[Commission] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DemandId] ASC,
	[SupplyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Demand]    Script Date: 21.09.2020 9:41:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Demand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[RealtorId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estate]    Script Date: 21.09.2020 9:41:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estate](
	[SupplyId] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[Address] [int] NOT NULL,
	[Area] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Filter]    Script Date: 21.09.2020 9:41:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Filter](
	[DemandId] [int] NOT NULL,
	[Address] [int] NOT NULL,
	[MinPrice] [money] NOT NULL,
	[MaxPrice] [money] NOT NULL,
	[MinArea] [float] NOT NULL,
	[MaxArea] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DemandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flat]    Script Date: 21.09.2020 9:41:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flat](
	[SupplyId] [int] NOT NULL,
	[Floor] [int] NOT NULL,
	[RoomCount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FlatFilter]    Script Date: 21.09.2020 9:41:54 ******/
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
PRIMARY KEY CLUSTERED 
(
	[DemandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[House]    Script Date: 21.09.2020 9:41:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[House](
	[SupplyId] [int] NOT NULL,
	[FloorCount] [int] NOT NULL,
	[RoomCount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HouseFilter]    Script Date: 21.09.2020 9:41:54 ******/
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
PRIMARY KEY CLUSTERED 
(
	[DemandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LandPlot]    Script Date: 21.09.2020 9:41:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LandPlot](
	[SupplyId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LandPlotFilter]    Script Date: 21.09.2020 9:41:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LandPlotFilter](
	[DemandId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DemandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Realtor]    Script Date: 21.09.2020 9:41:54 ******/
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
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supply]    Script Date: 21.09.2020 9:41:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supply](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[RealtorId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Deal]  WITH CHECK ADD  CONSTRAINT [FK_Deal_Need] FOREIGN KEY([DemandId])
REFERENCES [dbo].[Demand] ([Id])
GO
ALTER TABLE [dbo].[Deal] CHECK CONSTRAINT [FK_Deal_Need]
GO
ALTER TABLE [dbo].[Deal]  WITH CHECK ADD  CONSTRAINT [FK_Deal_Supply] FOREIGN KEY([SupplyId])
REFERENCES [dbo].[Supply] ([Id])
GO
ALTER TABLE [dbo].[Deal] CHECK CONSTRAINT [FK_Deal_Supply]
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
ALTER TABLE [dbo].[Estate]  WITH CHECK ADD  CONSTRAINT [FK_Estate_AddressInfo] FOREIGN KEY([Address])
REFERENCES [dbo].[AddressInfo] ([Id])
GO
ALTER TABLE [dbo].[Estate] CHECK CONSTRAINT [FK_Estate_AddressInfo]
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
REFERENCES [dbo].[LandPlot] ([SupplyId])
GO
ALTER TABLE [dbo].[Estate] CHECK CONSTRAINT [FK_Estate_Land plot]
GO
ALTER TABLE [dbo].[Filter]  WITH CHECK ADD  CONSTRAINT [FK_Filter_Address] FOREIGN KEY([Address])
REFERENCES [dbo].[AddressInfo] ([Id])
GO
ALTER TABLE [dbo].[Filter] CHECK CONSTRAINT [FK_Filter_Address]
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
USE [master]
GO
ALTER DATABASE [RealEstateAgency] SET  READ_WRITE 
GO
