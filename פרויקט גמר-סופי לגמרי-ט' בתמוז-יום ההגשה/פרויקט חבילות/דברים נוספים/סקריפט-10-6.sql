USE [master]
GO
/****** Object:  Database [PackageProject4]    Script Date: 11/06/2023 00:28:19 ******/
CREATE DATABASE [PackageProject4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PackageProject4', FILENAME = N'C:\Users\מיכל דינר\PackageProject4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PackageProject4_log', FILENAME = N'C:\Users\מיכל דינר\PackageProject4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PackageProject4] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PackageProject4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PackageProject4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PackageProject4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PackageProject4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PackageProject4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PackageProject4] SET ARITHABORT OFF 
GO
ALTER DATABASE [PackageProject4] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PackageProject4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PackageProject4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PackageProject4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PackageProject4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PackageProject4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PackageProject4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PackageProject4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PackageProject4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PackageProject4] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PackageProject4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PackageProject4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PackageProject4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PackageProject4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PackageProject4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PackageProject4] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PackageProject4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PackageProject4] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PackageProject4] SET  MULTI_USER 
GO
ALTER DATABASE [PackageProject4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PackageProject4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PackageProject4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PackageProject4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PackageProject4] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PackageProject4] SET QUERY_STORE = OFF
GO
USE [PackageProject4]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [PackageProject4]
GO
/****** Object:  Table [dbo].[businessDays]    Script Date: 11/06/2023 00:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[businessDays](
	[businessDayId] [int] IDENTITY(1,1) NOT NULL,
	[businessDayNubmer] [int] NULL,
 CONSTRAINT [PK_businessDays] PRIMARY KEY CLUSTERED 
(
	[businessDayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 11/06/2023 00:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[clientId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[phone] [nvarchar](50) NULL,
	[mail] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_clients] PRIMARY KEY CLUSTERED 
(
	[clientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[collectingPoints]    Script Date: 11/06/2023 00:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[collectingPoints](
	[collectingPointId] [int] IDENTITY(1,1) NOT NULL,
	[collectingPointName] [nvarchar](50) NULL,
	[locationX] [decimal](18, 14) NULL,
	[locationY] [decimal](18, 14) NULL,
	[ColPointType] [int] NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[state] [int] NULL,
	[packageId] [int] NULL,
 CONSTRAINT [PK_CollectingPoints] PRIMARY KEY CLUSTERED 
(
	[collectingPointId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employees]    Script Date: 11/06/2023 00:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[employeeId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[companyEntryDate] [datetime] NULL,
	[phone] [nvarchar](50) NULL,
	[locationX] [decimal](18, 14) NULL,
	[locationY] [decimal](18, 14) NULL,
	[mail] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[userLevel] [int] NULL,
	[address] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_employees] PRIMARY KEY CLUSTERED 
(
	[employeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 11/06/2023 00:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[orderId] [int] IDENTITY(1,1) NOT NULL,
	[businessDayId] [int] NULL,
	[date] [datetime] NULL,
	[packageId] [int] NOT NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[packages]    Script Date: 11/06/2023 00:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[packages](
	[packageId] [int] IDENTITY(1,1) NOT NULL,
	[sourceLocationX] [decimal](18, 14) NULL,
	[sourceLocationY] [decimal](18, 14) NULL,
	[destinationLocationX] [decimal](18, 14) NULL,
	[destinationLocationY] [decimal](18, 14) NULL,
	[clientId] [int] NOT NULL,
	[addressDestination] [nvarchar](50) NOT NULL,
	[addressSource] [nvarchar](50) NOT NULL,
	[state] [int] NULL,
	[collectingPointId] [int] NULL,
 CONSTRAINT [PK_packages] PRIMARY KEY CLUSTERED 
(
	[packageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[partialDelivery]    Script Date: 11/06/2023 00:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[partialDelivery](
	[partialDeliveryId] [int] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NOT NULL,
	[EstimatedTimeOfArrival] [datetime] NULL,
	[collectingPointId] [int] NOT NULL,
	[indexOfDelivery] [int] NOT NULL,
	[businessDayId] [int] NULL,
 CONSTRAINT [PK_partialDelivery] PRIMARY KEY CLUSTERED 
(
	[partialDeliveryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartialDeliveryToPackages]    Script Date: 11/06/2023 00:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartialDeliveryToPackages](
	[PartialDeliveryToPackagesId] [int] IDENTITY(1,1) NOT NULL,
	[packageId] [int] NOT NULL,
	[isTakenOrDownloaded] [int] NOT NULL,
	[partialDeliveryId] [int] NOT NULL,
 CONSTRAINT [PK_PartialDeliveryToPackages] PRIMARY KEY CLUSTERED 
(
	[PartialDeliveryToPackagesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[clients] ON 
GO
INSERT [dbo].[clients] ([clientId], [firstName], [lastName], [phone], [mail], [Password]) VALUES (1, N'ישראל', N'ישראלי', N'', N'1234@gmail.com', N'1234')
GO
INSERT [dbo].[clients] ([clientId], [firstName], [lastName], [phone], [mail], [Password]) VALUES (2, N'מיכל', N'דינר', N'', N'm0556785959@gmail.com', N'1')
GO
INSERT [dbo].[clients] ([clientId], [firstName], [lastName], [phone], [mail], [Password]) VALUES (3, N'string', N'string', N'string', N'sthfhfhhhhring', N'string')
GO
INSERT [dbo].[clients] ([clientId], [firstName], [lastName], [phone], [mail], [Password]) VALUES (4, N'string', N'string', N'string', N'string', N'string')
GO
INSERT [dbo].[clients] ([clientId], [firstName], [lastName], [phone], [mail], [Password]) VALUES (5, N'אברהם', N'לוי', N'', N'12345@gmail.com', N'12345')
GO
INSERT [dbo].[clients] ([clientId], [firstName], [lastName], [phone], [mail], [Password]) VALUES (6, N'יעקב', N'ישראלוביץ', N'string', N'YY@gmail.com', N'yy')
GO
SET IDENTITY_INSERT [dbo].[clients] OFF
GO
SET IDENTITY_INSERT [dbo].[collectingPoints] ON 
GO
INSERT [dbo].[collectingPoints] ([collectingPointId], [collectingPointName], [locationX], [locationY], [ColPointType], [address], [state], [packageId]) VALUES (13, N'string', CAST(32.08493200000000 AS Decimal(18, 14)), CAST(34.83522600000000 AS Decimal(18, 14)), 1, N'הרב ישראל סלנט 1, בני ברק', 1, NULL)
GO
INSERT [dbo].[collectingPoints] ([collectingPointId], [collectingPointName], [locationX], [locationY], [ColPointType], [address], [state], [packageId]) VALUES (14, N'נקודת איסוף 12', CAST(34.87974808830368 AS Decimal(18, 14)), CAST(32.09552348840340 AS Decimal(18, 14)), 1, N'רוטשילד 2, פתח תקווה', 1, NULL)
GO
INSERT [dbo].[collectingPoints] ([collectingPointId], [collectingPointName], [locationX], [locationY], [ColPointType], [address], [state], [packageId]) VALUES (15, N'נקודת איסוף 13', CAST(34.81467417295748 AS Decimal(18, 14)), CAST(32.08828225991316 AS Decimal(18, 14)), 1, N'הרצל 123, רמת גן', 1, NULL)
GO
INSERT [dbo].[collectingPoints] ([collectingPointId], [collectingPointName], [locationX], [locationY], [ColPointType], [address], [state], [packageId]) VALUES (16, N'נקודת איסוף 14', CAST(34.77458738830500 AS Decimal(18, 14)), CAST(32.06395052626340 AS Decimal(18, 14)), 1, N'שדרות רוטשילד 46, תל אביב יפו', 1, NULL)
GO
INSERT [dbo].[collectingPoints] ([collectingPointId], [collectingPointName], [locationX], [locationY], [ColPointType], [address], [state], [packageId]) VALUES (17, N'נקודת איסוף 15', CAST(34.84875253248381 AS Decimal(18, 14)), CAST(32.16510722408051 AS Decimal(18, 14)), 1, N'שדרות העצמאות 85, הרצליה', 1, NULL)
GO
INSERT [dbo].[collectingPoints] ([collectingPointId], [collectingPointName], [locationX], [locationY], [ColPointType], [address], [state], [packageId]) VALUES (18, N'נקודת איסוף 16', CAST(34.76877788830655 AS Decimal(18, 14)), CAST(32.02379888697571 AS Decimal(18, 14)), 1, N'יוסף חיים ברנע 1, חולון', 1, NULL)
GO
INSERT [dbo].[collectingPoints] ([collectingPointId], [collectingPointName], [locationX], [locationY], [ColPointType], [address], [state], [packageId]) VALUES (19, N'נקודת איסוף 17', CAST(34.83264343063090 AS Decimal(18, 14)), CAST(32.08577137509302 AS Decimal(18, 14)), 1, N'רבי עקיבא 104, בני ברק', 1, NULL)
GO
INSERT [dbo].[collectingPoints] ([collectingPointId], [collectingPointName], [locationX], [locationY], [ColPointType], [address], [state], [packageId]) VALUES (20, N'נקודת איסוף 18', CAST(34.79513477667079 AS Decimal(18, 14)), CAST(32.07285516619666 AS Decimal(18, 14)), 1, N'דרך השלום 1, תל אביב יפו', 1, NULL)
GO
INSERT [dbo].[collectingPoints] ([collectingPointId], [collectingPointName], [locationX], [locationY], [ColPointType], [address], [state], [packageId]) VALUES (21, N'נקודת איסוף 19', CAST(34.83002984597704 AS Decimal(18, 14)), CAST(32.09091995440172 AS Decimal(18, 14)), 1, N'אבן גבירול 30, בני ברק', 1, NULL)
GO
INSERT [dbo].[collectingPoints] ([collectingPointId], [collectingPointName], [locationX], [locationY], [ColPointType], [address], [state], [packageId]) VALUES (22, N'נקודת איסוף 20', CAST(34.77006241714146 AS Decimal(18, 14)), CAST(32.06753488701178 AS Decimal(18, 14)), 1, N'רחוב נחלת בנימין 18, תל אביב יפו', 1, NULL)
GO
INSERT [dbo].[collectingPoints] ([collectingPointId], [collectingPointName], [locationX], [locationY], [ColPointType], [address], [state], [packageId]) VALUES (296, NULL, CAST(32.11551100000000 AS Decimal(18, 14)), CAST(34.84070040000000 AS Decimal(18, 14)), 1, N'הדף היומי 4, תל אביב-יפו', 1, NULL)
GO
INSERT [dbo].[collectingPoints] ([collectingPointId], [collectingPointName], [locationX], [locationY], [ColPointType], [address], [state], [packageId]) VALUES (297, N'ברקת', CAST(32.02993520000000 AS Decimal(18, 14)), CAST(34.85821480000000 AS Decimal(18, 14)), 1, N'ברקת 1, אור יהודה', 1, NULL)
GO
INSERT [dbo].[collectingPoints] ([collectingPointId], [collectingPointName], [locationX], [locationY], [ColPointType], [address], [state], [packageId]) VALUES (1389, NULL, CAST(32.06880930000000 AS Decimal(18, 14)), CAST(34.91427880000000 AS Decimal(18, 14)), 2, N'רוזובסקי 8, פתח תקוה', 1, 3)
GO
SET IDENTITY_INSERT [dbo].[collectingPoints] OFF
GO
SET IDENTITY_INSERT [dbo].[employees] ON 
GO
INSERT [dbo].[employees] ([employeeId], [firstName], [lastName], [companyEntryDate], [phone], [locationX], [locationY], [mail], [password], [userLevel], [address]) VALUES (4, N'חיים', N'ישראלי', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'054-123-4567', CAST(34.77035440365152 AS Decimal(18, 14)), CAST(32.06299143574580 AS Decimal(18, 14)), N'avi@gmail.com', N'123', 1, N'??????? 12, ?? ????')
GO
INSERT [dbo].[employees] ([employeeId], [firstName], [lastName], [companyEntryDate], [phone], [locationX], [locationY], [mail], [password], [userLevel], [address]) VALUES (5, N'ששון', N'כהן', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'054-234-5678', CAST(34.87787821714012 AS Decimal(18, 14)), CAST(32.10105251032079 AS Decimal(18, 14)), N'danny@gmail.com', N'458', 1, N'???? ????? 2, ??? ?????')
GO
INSERT [dbo].[employees] ([employeeId], [firstName], [lastName], [companyEntryDate], [phone], [locationX], [locationY], [mail], [password], [userLevel], [address]) VALUES (6, N'ישראל', N'לוי', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'054-345-6789', CAST(34.83116264597733 AS Decimal(18, 14)), CAST(32.08622495423357 AS Decimal(18, 14)), N'michal@gmail.com', N'754', 1, N'רבי עקיבא 90, בני ברק')
GO
INSERT [dbo].[employees] ([employeeId], [firstName], [lastName], [companyEntryDate], [phone], [locationX], [locationY], [mail], [password], [userLevel], [address]) VALUES (7, N'דני', N'חימוב', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'054-456-7890', CAST(34.86503477480995 AS Decimal(18, 14)), CAST(32.13238642392510 AS Decimal(18, 14)), N'roei@gmail.com', N'444', 1, N'')
GO
INSERT [dbo].[employees] ([employeeId], [firstName], [lastName], [companyEntryDate], [phone], [locationX], [locationY], [mail], [password], [userLevel], [address]) VALUES (8, N'אפרים', N'גונסון', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'054-567-8901', CAST(34.89914039753966 AS Decimal(18, 14)), CAST(32.08780545541514 AS Decimal(18, 14)), N'sara@gmail.com', N'544', 1, N'?????? ??????? 26, ??? ????')
GO
INSERT [dbo].[employees] ([employeeId], [firstName], [lastName], [companyEntryDate], [phone], [locationX], [locationY], [mail], [password], [userLevel], [address]) VALUES (9, N'שאול', N'כהן', NULL, N'', CAST(32.06844830000000 AS Decimal(18, 14)), CAST(34.91240860000000 AS Decimal(18, 14)), N'1@gmail.com', N'1111', 1, N'קהילות יעקב, פתח תקוה')
GO
INSERT [dbo].[employees] ([employeeId], [firstName], [lastName], [companyEntryDate], [phone], [locationX], [locationY], [mail], [password], [userLevel], [address]) VALUES (10, N'חיים', N'רבינוביץ', NULL, N'', CAST(31.97544800000000 AS Decimal(18, 14)), CAST(34.80734540000000 AS Decimal(18, 14)), N'2@gmail.com', N'2222', 1, N'המכבים 13, ראשון לציון')
GO
INSERT [dbo].[employees] ([employeeId], [firstName], [lastName], [companyEntryDate], [phone], [locationX], [locationY], [mail], [password], [userLevel], [address]) VALUES (11, N'ששון', N'רבין', NULL, N'', CAST(32.08690460000000 AS Decimal(18, 14)), CAST(34.87817750000000 AS Decimal(18, 14)), N'3@gmail.com', N'3333', 1, N'טרומפלדור 4, פתח תקוה')
GO
INSERT [dbo].[employees] ([employeeId], [firstName], [lastName], [companyEntryDate], [phone], [locationX], [locationY], [mail], [password], [userLevel], [address]) VALUES (12, N'יצחק', N'אהרונוביץ', NULL, N'', CAST(32.06392430000000 AS Decimal(18, 14)), CAST(34.81929580000000 AS Decimal(18, 14)), N'22@gmail.com', N'22', 1, N'יוסף צבי 61, רמת גן')
GO
INSERT [dbo].[employees] ([employeeId], [firstName], [lastName], [companyEntryDate], [phone], [locationX], [locationY], [mail], [password], [userLevel], [address]) VALUES (13, N'דסי', N'דינר', NULL, N'0556740638', CAST(31.81951660000000 AS Decimal(18, 14)), CAST(35.20000110000000 AS Decimal(18, 14)), N'123@gmail.com', N'123', 1, N'צפרירים, ירושלים')
GO
INSERT [dbo].[employees] ([employeeId], [firstName], [lastName], [companyEntryDate], [phone], [locationX], [locationY], [mail], [password], [userLevel], [address]) VALUES (14, N'מיכל', N'דינר', NULL, N'0556785959', NULL, NULL, N'm0556785959@gmail.com', N'055', 2, N'רוזובסקי 8, פתח תקוה')
GO
SET IDENTITY_INSERT [dbo].[employees] OFF
GO
SET IDENTITY_INSERT [dbo].[packages] ON 
GO
INSERT [dbo].[packages] ([packageId], [sourceLocationX], [sourceLocationY], [destinationLocationX], [destinationLocationY], [clientId], [addressDestination], [addressSource], [state], [collectingPointId]) VALUES (3, CAST(34.91430026132447 AS Decimal(18, 14)), CAST(32.06896383332132 AS Decimal(18, 14)), CAST(34.88070650365035 AS Decimal(18, 14)), CAST(32.09245091941310 AS Decimal(18, 14)), 1, N'רוטשילד 34, פתח תקוה', N'רוזובסקי 8, פתח תקוה', 1, NULL)
GO
INSERT [dbo].[packages] ([packageId], [sourceLocationX], [sourceLocationY], [destinationLocationX], [destinationLocationY], [clientId], [addressDestination], [addressSource], [state], [collectingPointId]) VALUES (4, CAST(34.77952737481507 AS Decimal(18, 14)), CAST(32.05878859976402 AS Decimal(18, 14)), CAST(34.76991851714089 AS Decimal(18, 14)), CAST(32.07990992416757 AS Decimal(18, 14)), 1, N'בן יהודה 70, תל אביב יפו', N'בני ברק 10, תל אביב יפו', 1, NULL)
GO
INSERT [dbo].[packages] ([packageId], [sourceLocationX], [sourceLocationY], [destinationLocationX], [destinationLocationY], [clientId], [addressDestination], [addressSource], [state], [collectingPointId]) VALUES (5, CAST(34.77258377295855 AS Decimal(18, 14)), CAST(32.06483548533580 AS Decimal(18, 14)), CAST(34.82445990179431 AS Decimal(18, 14)), CAST(32.08288635189525 AS Decimal(18, 14)), 1, N'הגלגל 25, רמת גן', N'אלנבי 99, תל אביב יפו', 1, 13)
GO
INSERT [dbo].[packages] ([packageId], [sourceLocationX], [sourceLocationY], [destinationLocationX], [destinationLocationY], [clientId], [addressDestination], [addressSource], [state], [collectingPointId]) VALUES (7, CAST(34.77035440965152 AS Decimal(18, 14)), CAST(32.06299143574080 AS Decimal(18, 14)), CAST(34.82445990170431 AS Decimal(18, 14)), CAST(32.08288635180525 AS Decimal(18, 14)), 1, N'אילת', N'אילת', 1, NULL)
GO
INSERT [dbo].[packages] ([packageId], [sourceLocationX], [sourceLocationY], [destinationLocationX], [destinationLocationY], [clientId], [addressDestination], [addressSource], [state], [collectingPointId]) VALUES (10, CAST(32.08610413456851 AS Decimal(18, 14)), CAST(34.83236273248711 AS Decimal(18, 14)), CAST(34.96553416837612 AS Decimal(18, 14)), CAST(29.54848254615666 AS Decimal(18, 14)), 1, N'רבי עקיבא 100, בני ברק', N'רחוב הים 4, אילת', 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[packages] OFF
GO
SET IDENTITY_INSERT [dbo].[partialDelivery] ON 
GO
INSERT [dbo].[partialDelivery] ([partialDeliveryId], [employeeId], [EstimatedTimeOfArrival], [collectingPointId], [indexOfDelivery], [businessDayId]) VALUES (1, 4, NULL, 13, 1, NULL)
GO
INSERT [dbo].[partialDelivery] ([partialDeliveryId], [employeeId], [EstimatedTimeOfArrival], [collectingPointId], [indexOfDelivery], [businessDayId]) VALUES (2, 5, NULL, 13, 1, NULL)
GO
INSERT [dbo].[partialDelivery] ([partialDeliveryId], [employeeId], [EstimatedTimeOfArrival], [collectingPointId], [indexOfDelivery], [businessDayId]) VALUES (3, 4, NULL, 15, 2, NULL)
GO
SET IDENTITY_INSERT [dbo].[partialDelivery] OFF
GO
SET IDENTITY_INSERT [dbo].[PartialDeliveryToPackages] ON 
GO
INSERT [dbo].[PartialDeliveryToPackages] ([PartialDeliveryToPackagesId], [packageId], [isTakenOrDownloaded], [partialDeliveryId]) VALUES (51, 3, 0, 1)
GO
INSERT [dbo].[PartialDeliveryToPackages] ([PartialDeliveryToPackagesId], [packageId], [isTakenOrDownloaded], [partialDeliveryId]) VALUES (52, 4, 1, 1)
GO
INSERT [dbo].[PartialDeliveryToPackages] ([PartialDeliveryToPackagesId], [packageId], [isTakenOrDownloaded], [partialDeliveryId]) VALUES (53, 5, 1, 1)
GO
INSERT [dbo].[PartialDeliveryToPackages] ([PartialDeliveryToPackagesId], [packageId], [isTakenOrDownloaded], [partialDeliveryId]) VALUES (54, 7, 0, 2)
GO
INSERT [dbo].[PartialDeliveryToPackages] ([PartialDeliveryToPackagesId], [packageId], [isTakenOrDownloaded], [partialDeliveryId]) VALUES (55, 3, 1, 3)
GO
SET IDENTITY_INSERT [dbo].[PartialDeliveryToPackages] OFF
GO
/****** Object:  Index [IX_orders_businessDayID]    Script Date: 11/06/2023 00:28:20 ******/
CREATE NONCLUSTERED INDEX [IX_orders_businessDayID] ON [dbo].[orders]
(
	[businessDayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_orders_packageID]    Script Date: 11/06/2023 00:28:20 ******/
CREATE NONCLUSTERED INDEX [IX_orders_packageID] ON [dbo].[orders]
(
	[packageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_packages_clientID]    Script Date: 11/06/2023 00:28:20 ******/
CREATE NONCLUSTERED INDEX [IX_packages_clientID] ON [dbo].[packages]
(
	[clientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_partialDelivery_collectingPointId]    Script Date: 11/06/2023 00:28:20 ******/
CREATE NONCLUSTERED INDEX [IX_partialDelivery_collectingPointId] ON [dbo].[partialDelivery]
(
	[collectingPointId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_partialDelivery_employeeID]    Script Date: 11/06/2023 00:28:20 ******/
CREATE NONCLUSTERED INDEX [IX_partialDelivery_employeeID] ON [dbo].[partialDelivery]
(
	[employeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[clients] ADD  DEFAULT (N'') FOR [firstName]
GO
ALTER TABLE [dbo].[clients] ADD  DEFAULT (N'') FOR [lastName]
GO
ALTER TABLE [dbo].[clients] ADD  DEFAULT (N'') FOR [phone]
GO
ALTER TABLE [dbo].[clients] ADD  DEFAULT (N'') FOR [mail]
GO
ALTER TABLE [dbo].[collectingPoints] ADD  CONSTRAINT [DF__collectin__addre__38996AB5]  DEFAULT (N'') FOR [address]
GO
ALTER TABLE [dbo].[employees] ADD  CONSTRAINT [DF__employees__first__398D8EEE]  DEFAULT (N'') FOR [firstName]
GO
ALTER TABLE [dbo].[employees] ADD  CONSTRAINT [DF__employees__lastN__3A81B327]  DEFAULT (N'') FOR [lastName]
GO
ALTER TABLE [dbo].[employees] ADD  CONSTRAINT [DF__employees__phone__3B75D760]  DEFAULT (N'') FOR [phone]
GO
ALTER TABLE [dbo].[employees] ADD  CONSTRAINT [DF__employees__mail__3C69FB99]  DEFAULT (N'') FOR [mail]
GO
ALTER TABLE [dbo].[employees] ADD  CONSTRAINT [DF__employees__passw__3D5E1FD2]  DEFAULT (N'') FOR [password]
GO
ALTER TABLE [dbo].[employees] ADD  CONSTRAINT [DF__employees__userL__3E52440B]  DEFAULT ((1)) FOR [userLevel]
GO
ALTER TABLE [dbo].[employees] ADD  CONSTRAINT [DF__employees__addre__3F466844]  DEFAULT (N'') FOR [address]
GO
ALTER TABLE [dbo].[packages] ADD  CONSTRAINT [DF__packages__addres__403A8C7D]  DEFAULT (N'') FOR [addressDestination]
GO
ALTER TABLE [dbo].[packages] ADD  CONSTRAINT [DF__packages__addres__412EB0B6]  DEFAULT (N'') FOR [addressSource]
GO
ALTER TABLE [dbo].[collectingPoints]  WITH CHECK ADD  CONSTRAINT [FK_collectingPoints_packages] FOREIGN KEY([packageId])
REFERENCES [dbo].[packages] ([packageId])
GO
ALTER TABLE [dbo].[collectingPoints] CHECK CONSTRAINT [FK_collectingPoints_packages]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_businessDays] FOREIGN KEY([businessDayId])
REFERENCES [dbo].[businessDays] ([businessDayId])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_businessDays]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_packages] FOREIGN KEY([packageId])
REFERENCES [dbo].[packages] ([packageId])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_packages]
GO
ALTER TABLE [dbo].[packages]  WITH CHECK ADD  CONSTRAINT [FK_packages_clients] FOREIGN KEY([clientId])
REFERENCES [dbo].[clients] ([clientId])
GO
ALTER TABLE [dbo].[packages] CHECK CONSTRAINT [FK_packages_clients]
GO
ALTER TABLE [dbo].[packages]  WITH CHECK ADD  CONSTRAINT [FK_packages_collectingPoints] FOREIGN KEY([collectingPointId])
REFERENCES [dbo].[collectingPoints] ([collectingPointId])
GO
ALTER TABLE [dbo].[packages] CHECK CONSTRAINT [FK_packages_collectingPoints]
GO
ALTER TABLE [dbo].[partialDelivery]  WITH CHECK ADD  CONSTRAINT [FK_partialDelivery_businessDays] FOREIGN KEY([businessDayId])
REFERENCES [dbo].[businessDays] ([businessDayId])
GO
ALTER TABLE [dbo].[partialDelivery] CHECK CONSTRAINT [FK_partialDelivery_businessDays]
GO
ALTER TABLE [dbo].[partialDelivery]  WITH CHECK ADD  CONSTRAINT [FK_partialDelivery_collectingPoints] FOREIGN KEY([collectingPointId])
REFERENCES [dbo].[collectingPoints] ([collectingPointId])
GO
ALTER TABLE [dbo].[partialDelivery] CHECK CONSTRAINT [FK_partialDelivery_collectingPoints]
GO
ALTER TABLE [dbo].[partialDelivery]  WITH CHECK ADD  CONSTRAINT [FK_partialDelivery_employees] FOREIGN KEY([employeeId])
REFERENCES [dbo].[employees] ([employeeId])
GO
ALTER TABLE [dbo].[partialDelivery] CHECK CONSTRAINT [FK_partialDelivery_employees]
GO
ALTER TABLE [dbo].[PartialDeliveryToPackages]  WITH CHECK ADD  CONSTRAINT [FK_PartialDeliveryToPackages_packages] FOREIGN KEY([packageId])
REFERENCES [dbo].[packages] ([packageId])
GO
ALTER TABLE [dbo].[PartialDeliveryToPackages] CHECK CONSTRAINT [FK_PartialDeliveryToPackages_packages]
GO
ALTER TABLE [dbo].[PartialDeliveryToPackages]  WITH CHECK ADD  CONSTRAINT [FK_PartialDeliveryToPackages_partialDelivery] FOREIGN KEY([partialDeliveryId])
REFERENCES [dbo].[partialDelivery] ([partialDeliveryId])
GO
ALTER TABLE [dbo].[PartialDeliveryToPackages] CHECK CONSTRAINT [FK_PartialDeliveryToPackages_partialDelivery]
GO
USE [master]
GO
ALTER DATABASE [PackageProject4] SET  READ_WRITE 
GO
