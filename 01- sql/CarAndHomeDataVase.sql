USE [master]
GO
/****** Object:  Database [CarAndHome]    Script Date: 14/03/2019 16:34:23 ******/
CREATE DATABASE [CarAndHome]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarAndHome', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CarAndHome.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarAndHome_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CarAndHome_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CarAndHome] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarAndHome].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarAndHome] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarAndHome] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarAndHome] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarAndHome] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarAndHome] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarAndHome] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarAndHome] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarAndHome] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarAndHome] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarAndHome] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarAndHome] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarAndHome] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarAndHome] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarAndHome] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarAndHome] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarAndHome] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarAndHome] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarAndHome] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarAndHome] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarAndHome] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarAndHome] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarAndHome] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarAndHome] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarAndHome] SET  MULTI_USER 
GO
ALTER DATABASE [CarAndHome] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarAndHome] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarAndHome] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarAndHome] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarAndHome] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarAndHome] SET QUERY_STORE = OFF
GO
USE [CarAndHome]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 14/03/2019 16:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[User ID] [int] IDENTITY(1,1) NOT NULL,
	[Full Name] [nvarchar](30) NOT NULL,
	[User Name] [nvarchar](30) NOT NULL,
	[ID Number] [nchar](9) NOT NULL,
	[Birth Date] [datetime] NULL,
	[Gender] [nchar](15) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[User ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AllClients]    Script Date: 14/03/2019 16:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[AllClients] AS
SELECT *
FROM Users
WHERE [Description] = 'Client'

GO
/****** Object:  View [dbo].[AllEmployees]    Script Date: 14/03/2019 16:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[AllEmployees] AS
SELECT *
FROM Users
WHERE [Description] = 'Employee'

GO
/****** Object:  View [dbo].[AllUsers]    Script Date: 14/03/2019 16:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[AllUsers] AS
SELECT *
FROM Users

GO
/****** Object:  Table [dbo].[Cars Types]    Script Date: 14/03/2019 16:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars Types](
	[Type ID] [int] IDENTITY(1,1) NOT NULL,
	[Manufacture] [nchar](20) NOT NULL,
	[Model] [nchar](20) NOT NULL,
	[Daily Cost] [money] NOT NULL,
	[Daily Delay Cost] [money] NOT NULL,
	[Year] [int] NOT NULL,
	[Transmission] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Cars Types] PRIMARY KEY CLUSTERED 
(
	[Type ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AllCarTypes]    Script Date: 14/03/2019 16:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AllCarTypes] 
AS
SELECT Manufacture, Model, [Daily Cost], [Daily Delay Cost], [Year], Transmission 
FROM [Cars Types]

GO
/****** Object:  View [dbo].[AllManualCars]    Script Date: 14/03/2019 16:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AllManualCars] 
AS
SELECT Manufacture, Model, [Daily Cost], [Daily Delay Cost], [Year], Transmission 
FROM [Cars Types]
WHERE 
Transmission = 'Manual'

GO
/****** Object:  View [dbo].[AllAutoCars]    Script Date: 14/03/2019 16:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AllAutoCars] 
AS
SELECT Manufacture, Model, [Daily Cost], [Daily Delay Cost], [Year], Transmission 
FROM [Cars Types]
WHERE 
Transmission = 'Auto'

GO
/****** Object:  Table [dbo].[Rented Cars]    Script Date: 14/03/2019 16:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rented Cars](
	[Rent ID] [int] IDENTITY(1,1) NOT NULL,
	[Car ID] [int] NOT NULL,
	[License Plate] [nchar](7) NOT NULL,
	[Start] [date] NOT NULL,
	[Return] [date] NOT NULL,
	[Actual Return] [date] NULL,
	[User ID] [int] NULL,
 CONSTRAINT [PK_Rented Cars] PRIMARY KEY CLUSTERED 
(
	[Rent ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AllCarRented]    Script Date: 14/03/2019 16:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AllCarRented] 
AS
SELECT * FROM [Rented Cars]

GO
/****** Object:  View [dbo].[NotReturnedCars]    Script Date: 14/03/2019 16:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[NotReturnedCars] 
AS
SELECT * FROM [Rented Cars]
WHERE [Actual Return] is null

GO
/****** Object:  Table [dbo].[Branches]    Script Date: 14/03/2019 16:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[Branch ID] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Longitude] [decimal](18, 8) NOT NULL,
	[Latitude] [decimal](18, 8) NOT NULL,
	[Name] [nvarchar](20) NULL,
 CONSTRAINT [PK_Branches] PRIMARY KEY CLUSTERED 
(
	[Branch ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars List]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars List](
	[Car ID] [int] IDENTITY(1,1) NOT NULL,
	[Type ID] [int] NOT NULL,
	[License Plate] [nchar](7) NOT NULL,
	[Mileage] [decimal](18, 3) NOT NULL,
	[Status] [nchar](20) NOT NULL,
	[Available] [nchar](10) NULL,
	[Branch ID] [int] NULL,
 CONSTRAINT [PK_Cars List] PRIMARY KEY CLUSTERED 
(
	[Car ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Branches] ON 

INSERT [dbo].[Branches] ([Branch ID], [Address], [Longitude], [Latitude], [Name]) VALUES (1, N'General Pierre Koenig St 40, Jerusalem, 9346948', CAST(35.21455540 AS Decimal(18, 8)), CAST(31.75544720 AS Decimal(18, 8)), N'Talpiyot')
INSERT [dbo].[Branches] ([Branch ID], [Address], [Longitude], [Latitude], [Name]) VALUES (2, N'HaHarash St 20, Tel Aviv-Yafo, 6761310', CAST(32.05870600 AS Decimal(18, 8)), CAST(34.78416600 AS Decimal(18, 8)), N'Tel aviv')
INSERT [dbo].[Branches] ([Branch ID], [Address], [Longitude], [Latitude], [Name]) VALUES (3, N'Khoma u-Migdal St 29, Tel Aviv-Yafo', CAST(32.06410700 AS Decimal(18, 8)), CAST(34.78661000 AS Decimal(18, 8)), N'Center')
SET IDENTITY_INSERT [dbo].[Branches] OFF
SET IDENTITY_INSERT [dbo].[Cars List] ON 

INSERT [dbo].[Cars List] ([Car ID], [Type ID], [License Plate], [Mileage], [Status], [Available], [Branch ID]) VALUES (1, 3, N'5677765', CAST(1129.450 AS Decimal(18, 3)), N'Ready               ', N'Yes       ', 3)
INSERT [dbo].[Cars List] ([Car ID], [Type ID], [License Plate], [Mileage], [Status], [Available], [Branch ID]) VALUES (2, 4, N'9911188', CAST(112232.980 AS Decimal(18, 3)), N'Ready               ', N'Yes       ', 2)
INSERT [dbo].[Cars List] ([Car ID], [Type ID], [License Plate], [Mileage], [Status], [Available], [Branch ID]) VALUES (4, 5, N'8176543', CAST(99999.990 AS Decimal(18, 3)), N'Ready               ', N'Yes       ', 1)
INSERT [dbo].[Cars List] ([Car ID], [Type ID], [License Plate], [Mileage], [Status], [Available], [Branch ID]) VALUES (5, 2, N'5463788', CAST(356876.980 AS Decimal(18, 3)), N'Ready               ', N'Yes       ', 2)
INSERT [dbo].[Cars List] ([Car ID], [Type ID], [License Plate], [Mileage], [Status], [Available], [Branch ID]) VALUES (6, 1, N'7789387', CAST(1876536.760 AS Decimal(18, 3)), N'Ready               ', N'No        ', 1)
INSERT [dbo].[Cars List] ([Car ID], [Type ID], [License Plate], [Mileage], [Status], [Available], [Branch ID]) VALUES (7, 1009, N'1029384', CAST(100.000 AS Decimal(18, 3)), N'Ready               ', N'Yes       ', 1)
INSERT [dbo].[Cars List] ([Car ID], [Type ID], [License Plate], [Mileage], [Status], [Available], [Branch ID]) VALUES (8, 6, N'6574839', CAST(354.870 AS Decimal(18, 3)), N'Ready               ', N'Yes       ', 3)
SET IDENTITY_INSERT [dbo].[Cars List] OFF
SET IDENTITY_INSERT [dbo].[Cars Types] ON 

INSERT [dbo].[Cars Types] ([Type ID], [Manufacture], [Model], [Daily Cost], [Daily Delay Cost], [Year], [Transmission]) VALUES (1, N'BMW                 ', N'M240i               ', 150.0000, 300.0000, 2012, N'Manual    ')
INSERT [dbo].[Cars Types] ([Type ID], [Manufacture], [Model], [Daily Cost], [Daily Delay Cost], [Year], [Transmission]) VALUES (2, N'Mercedes            ', N'E43                 ', 250.0000, 500.0000, 2014, N'Manual    ')
INSERT [dbo].[Cars Types] ([Type ID], [Manufacture], [Model], [Daily Cost], [Daily Delay Cost], [Year], [Transmission]) VALUES (3, N'Mazda               ', N'CX5                 ', 100.0000, 300.0000, 2019, N'Auto      ')
INSERT [dbo].[Cars Types] ([Type ID], [Manufacture], [Model], [Daily Cost], [Daily Delay Cost], [Year], [Transmission]) VALUES (4, N'Land Rover          ', N'DEFENDER            ', 400.0000, 800.0000, 2017, N'Manual    ')
INSERT [dbo].[Cars Types] ([Type ID], [Manufacture], [Model], [Daily Cost], [Daily Delay Cost], [Year], [Transmission]) VALUES (5, N'SKODA               ', N'SUPERB              ', 130.0000, 260.0000, 2018, N'Auto      ')
INSERT [dbo].[Cars Types] ([Type ID], [Manufacture], [Model], [Daily Cost], [Daily Delay Cost], [Year], [Transmission]) VALUES (6, N'Mazda               ', N'MX5                 ', 600.0000, 300.0000, 2019, N'Manual    ')
INSERT [dbo].[Cars Types] ([Type ID], [Manufacture], [Model], [Daily Cost], [Daily Delay Cost], [Year], [Transmission]) VALUES (1009, N'BMW                 ', N'Z4                  ', 900.0000, 550.0000, 2019, N'Manual    ')
SET IDENTITY_INSERT [dbo].[Cars Types] OFF
SET IDENTITY_INSERT [dbo].[Rented Cars] ON 

INSERT [dbo].[Rented Cars] ([Rent ID], [Car ID], [License Plate], [Start], [Return], [Actual Return], [User ID]) VALUES (1, 1, N'5677765', CAST(N'2017-01-01' AS Date), CAST(N'2017-01-10' AS Date), CAST(N'2017-01-10' AS Date), 1)
INSERT [dbo].[Rented Cars] ([Rent ID], [Car ID], [License Plate], [Start], [Return], [Actual Return], [User ID]) VALUES (2, 2, N'9911188', CAST(N'2018-02-15' AS Date), CAST(N'2018-02-28' AS Date), CAST(N'2018-02-28' AS Date), 2)
INSERT [dbo].[Rented Cars] ([Rent ID], [Car ID], [License Plate], [Start], [Return], [Actual Return], [User ID]) VALUES (4, 4, N'8176543', CAST(N'2018-10-11' AS Date), CAST(N'2018-10-20' AS Date), CAST(N'2018-10-20' AS Date), 3)
INSERT [dbo].[Rented Cars] ([Rent ID], [Car ID], [License Plate], [Start], [Return], [Actual Return], [User ID]) VALUES (5, 5, N'5463788', CAST(N'2019-01-01' AS Date), CAST(N'2019-01-11' AS Date), CAST(N'2019-01-11' AS Date), 4)
INSERT [dbo].[Rented Cars] ([Rent ID], [Car ID], [License Plate], [Start], [Return], [Actual Return], [User ID]) VALUES (6, 6, N'7789387', CAST(N'2018-12-20' AS Date), CAST(N'2018-12-28' AS Date), CAST(N'2018-12-29' AS Date), 8)
INSERT [dbo].[Rented Cars] ([Rent ID], [Car ID], [License Plate], [Start], [Return], [Actual Return], [User ID]) VALUES (7, 2, N'9911188', CAST(N'2018-06-16' AS Date), CAST(N'2018-06-22' AS Date), CAST(N'2018-06-25' AS Date), 6)
INSERT [dbo].[Rented Cars] ([Rent ID], [Car ID], [License Plate], [Start], [Return], [Actual Return], [User ID]) VALUES (10, 1, N'5677765', CAST(N'2019-01-25' AS Date), CAST(N'2019-01-30' AS Date), NULL, 1)
INSERT [dbo].[Rented Cars] ([Rent ID], [Car ID], [License Plate], [Start], [Return], [Actual Return], [User ID]) VALUES (11, 2, N'9911188', CAST(N'2019-01-26' AS Date), CAST(N'2019-02-03' AS Date), NULL, 2)
INSERT [dbo].[Rented Cars] ([Rent ID], [Car ID], [License Plate], [Start], [Return], [Actual Return], [User ID]) VALUES (12, 4, N'8176543', CAST(N'2019-01-27' AS Date), CAST(N'2019-02-10' AS Date), NULL, 3)
INSERT [dbo].[Rented Cars] ([Rent ID], [Car ID], [License Plate], [Start], [Return], [Actual Return], [User ID]) VALUES (13, 6, N'7789387', CAST(N'2019-01-25' AS Date), CAST(N'2019-02-08' AS Date), CAST(N'2019-03-13' AS Date), 8)
INSERT [dbo].[Rented Cars] ([Rent ID], [Car ID], [License Plate], [Start], [Return], [Actual Return], [User ID]) VALUES (14, 8, N'6574839', CAST(N'2019-01-29' AS Date), CAST(N'2019-02-11' AS Date), CAST(N'2019-02-11' AS Date), 2)
INSERT [dbo].[Rented Cars] ([Rent ID], [Car ID], [License Plate], [Start], [Return], [Actual Return], [User ID]) VALUES (15, 5, N'5463788', CAST(N'2019-03-11' AS Date), CAST(N'2019-03-20' AS Date), NULL, 3)
SET IDENTITY_INSERT [dbo].[Rented Cars] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([User ID], [Full Name], [User Name], [ID Number], [Birth Date], [Gender], [Email], [Password], [Description]) VALUES (1, N'Amnon Shaashua', N'AutoCar', N'999674138', CAST(N'1973-10-10T00:00:00.000' AS DateTime), N'Male           ', N'Nosea@Levad.com', N'IuseTaxi2000', N'Manager')
INSERT [dbo].[Users] ([User ID], [Full Name], [User Name], [ID Number], [Birth Date], [Gender], [Email], [Password], [Description]) VALUES (2, N'Jeff Bezos', N'Divorcy19', N'999781149', CAST(N'1954-11-28T00:00:00.000' AS DateTime), N'Male           ', N'rich@yahoo.com', N'LookLikeShrimp2019', N'Employee')
INSERT [dbo].[Users] ([User ID], [Full Name], [User Name], [ID Number], [Birth Date], [Gender], [Email], [Password], [Description]) VALUES (3, N'Robert John Downey Jr', N'recover2006', N'999800451', CAST(N'1963-06-13T00:00:00.000' AS DateTime), N'Male           ', N'nodrugs@gmail.com', N'LookLikeShrimp2019', N'Employee')
INSERT [dbo].[Users] ([User ID], [Full Name], [User Name], [ID Number], [Birth Date], [Gender], [Email], [Password], [Description]) VALUES (4, N'Ram Zmoram', N'puppyME666', N'999750375', CAST(N'1989-12-04T00:00:00.000' AS DateTime), N'Male           ', N'gordon@gmail.com', N'Imrymadhim837', N'Client')
INSERT [dbo].[Users] ([User ID], [Full Name], [User Name], [ID Number], [Birth Date], [Gender], [Email], [Password], [Description]) VALUES (5, N'Shifra Tslofchad', N'suffragistWithAnger', N'999145162', CAST(N'1933-06-24T00:00:00.000' AS DateTime), N'Female         ', N'war@gmail.com', N'untilDeath3849', N'Client')
INSERT [dbo].[Users] ([User ID], [Full Name], [User Name], [ID Number], [Birth Date], [Gender], [Email], [Password], [Description]) VALUES (6, N'Sara Netanyahu', N'maba', N'999762636', CAST(N'1954-10-13T00:00:00.000' AS DateTime), N'Female         ', N'pink@gmail.com', N'MarieAntoinette6969', N'Client')
INSERT [dbo].[Users] ([User ID], [Full Name], [User Name], [ID Number], [Birth Date], [Gender], [Email], [Password], [Description]) VALUES (8, N'Beni Ganz', N'HoregAravim56', N'999674138', CAST(N'1967-05-06T00:00:00.000' AS DateTime), N'Male           ', N'animadhiom@veyafe.com', N'BeniTYeledRa666', N'Employee')
INSERT [dbo].[Users] ([User ID], [Full Name], [User Name], [ID Number], [Birth Date], [Gender], [Email], [Password], [Description]) VALUES (1009, N'Oshrat Kotler', N'KibushMashchit2019', N'999353816', CAST(N'1965-07-25T00:00:00.000' AS DateTime), N'Male           ', N'idf@notgood.co.il', N'Zona666', N'Client')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Cars List]  WITH CHECK ADD  CONSTRAINT [FK_[Cars Types]]_] FOREIGN KEY([Car ID])
REFERENCES [dbo].[Cars List] ([Car ID])
GO
ALTER TABLE [dbo].[Cars List] CHECK CONSTRAINT [FK_[Cars Types]]_]
GO
ALTER TABLE [dbo].[Cars List]  WITH CHECK ADD  CONSTRAINT [FK_Cars List_Branches] FOREIGN KEY([Branch ID])
REFERENCES [dbo].[Branches] ([Branch ID])
GO
ALTER TABLE [dbo].[Cars List] CHECK CONSTRAINT [FK_Cars List_Branches]
GO
ALTER TABLE [dbo].[Cars List]  WITH CHECK ADD  CONSTRAINT [FK_Cars List_Cars Types] FOREIGN KEY([Type ID])
REFERENCES [dbo].[Cars Types] ([Type ID])
GO
ALTER TABLE [dbo].[Cars List] CHECK CONSTRAINT [FK_Cars List_Cars Types]
GO
ALTER TABLE [dbo].[Rented Cars]  WITH CHECK ADD FOREIGN KEY([Car ID])
REFERENCES [dbo].[Cars List] ([Car ID])
GO
ALTER TABLE [dbo].[Rented Cars]  WITH CHECK ADD FOREIGN KEY([User ID])
REFERENCES [dbo].[Users] ([User ID])
GO
/****** Object:  StoredProcedure [dbo].[AddBranch]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddBranch] @address nvarchar(50), @longtitude decimal (18, 8), @altitude decimal (18, 8), @name nvarchar(20)
AS
INSERT INTO Branches
VALUES (
@address,
@longtitude,
@altitude,
@name
)

GO
/****** Object:  StoredProcedure [dbo].[AddCarRent]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCarRent] (
@carid int, 
@licenseplate nchar(7), 
@rentstart date,
@rentreturn date,
@actualreturn date,
@userid int
)
AS

INSERT INTO [Rented Cars]
VALUES
(
@carid,
@licenseplate,
@rentstart,
@rentreturn,
@actualreturn,
@userid
)
GO
/****** Object:  StoredProcedure [dbo].[AddCarToCarList]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddCarToCarList] @typeid int, @licenseplate nchar(7), @mileage decimal(18, 3), @status nchar(20), @available nchar(10), @address nvarchar(50)
AS 
INSERT INTO [Cars List]
VALUES (
@typeid, 
@licenseplate,
@mileage,
@status,
@available,
@address

)


GO
/****** Object:  StoredProcedure [dbo].[AddCarType]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddCarType] @manufacture nchar(20),@model nchar (20), @dailycost money, @dailydelaycost money,@Year int, @transmission nchar(10)

AS
INSERT INTO [Cars Types]
VALUES (
@manufacture,
@model,
@dailycost,
@dailydelaycost,
@Year,
@transmission
)

GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser] (
@fullname nvarchar(30), 
@username nvarchar(30), 
@id nchar(9), 
@birthdate datetime,
@gender nchar(15),
@email nvarchar(30),
@password nvarchar(30),
@descriotion nvarchar(30)
)

AS

INSERT INTO Users
VALUES (@fullname, @username, @id, @birthdate, @gender, @email, @password, @descriotion);

GO
/****** Object:  StoredProcedure [dbo].[AllCarDetails]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AllCarDetails] @carid int
AS
SELECT
*
FROM 
[Cars Types] as T
JOIN [Cars List] as L
on t.[Type ID] = L.[Type ID]
join [Branches] as B
on L.[Branch ID] = B.[Branch ID]
WHERE L.[Car ID] = @carid

GO
/****** Object:  StoredProcedure [dbo].[CheckAvailabiltyById]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CheckAvailabiltyById] @carid int
AS
SELECT * 
FROM
[Rented Cars] as R
join
[Cars List] as L
on L.[Car ID] = R.[Car ID]
Where R.[Car ID] = @carid

GO
/****** Object:  StoredProcedure [dbo].[DeleteCarFromCarsList]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCarFromCarsList] @carid int
AS
DELETE FROM [Cars List]
WHERE
[Car ID] = @carid

GO
/****** Object:  StoredProcedure [dbo].[DeleteClient]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteClient]
@userid int 
AS
DELETE from Users 
WHERE [User ID] = @userid and [Description] = 'Client'

GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployee]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteEmployee]
@userid int 
AS
DELETE from Users 
WHERE [User ID] = @userid and [Description] = 'Employee'

GO
/****** Object:  StoredProcedure [dbo].[DeleteRentedCar]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteRentedCar] @carid int
AS
DELETE FROM [Rented Cars]
WHERE 
[Car ID] = @carid

GO
/****** Object:  StoredProcedure [dbo].[DeleteType]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteType] @id int
AS
DELETE FROM [Cars Types]
WHERE 
[Type ID] = @id

GO
/****** Object:  StoredProcedure [dbo].[GetClientById]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetClientById] @userid int
AS
select * from Users 
WHERE 
[User ID] = @userid AND [Description] = 'Client';
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeById]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetEmployeeById] @userid int
AS
select * from Users 
WHERE 
[User ID] = @userid AND [Description] = 'Employee';
GO
/****** Object:  StoredProcedure [dbo].[UpdateActualRerturnDateCar]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateActualRerturnDateCar] @carid int, @actualreturndate date 
AS
UPDATE [Rented Cars]
SET 
[Actual Return] = @actualreturndate
WHERE 
[Car ID] = @carid

GO
/****** Object:  StoredProcedure [dbo].[UpdateCarsList]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCarsList] @carid int, @typeid int, @licenseplate nchar(7), @mileage decimal(18,3), @status nchar(20), @available nchar(10), @branchid int
AS
UPDATE [Cars List] 
set
[Type ID] = @typeid,
[License Plate] = @licenseplate,
Mileage = @mileage,
[Status] = @status,
Available = @available,
[Branch ID] = @branchid

WHERE

[Car ID] = @carid

GO
/****** Object:  StoredProcedure [dbo].[UpdateCarType]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateCarType] @id int, @manufacture nchar(20), @model nchar(20), @dailycost money, @dailydelaycost money, @year int, @tranmission nchar(10)
AS 
UPDATE [Cars Types]
SET
Manufacture = @manufacture,
Model = @model,
[Daily Cost] = @dailycost,
[Daily Delay Cost] = @dailydelaycost,
[Year] = @year,
Transmission = @tranmission

WHERE 
[Type ID] = @id

GO
/****** Object:  StoredProcedure [dbo].[UpdateClientDetails]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateClientDetails] 
@userid int, 
@fullname nvarchar(30),
@username nvarchar(30),
@idnumber nchar(9),
@birthdate datetime,
@gender nchar(15),
@email nvarchar(30),
@password nvarchar(30), 
@description nvarchar(30)
AS
Update Users 
SET 
[Full Name] = @fullname,
[User Name] = @username,
[ID Number] = @idnumber,
[Birth Date] = @birthdate,
Gender = @gender,
Email = @email,
[Password] = @password,
[Description] = @description

WHERE [User ID] = @userid and [Description] = 'Client'

GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployeeDetails]    Script Date: 14/03/2019 16:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateEmployeeDetails]
@userid int, 
@fullname nvarchar(30),
@username nvarchar(30),
@idnumber nchar(9),
@birthdate datetime,
@gender nchar(15),
@email nvarchar(30),
@password nvarchar(30), 
@description nvarchar(30)
AS
Update Users 
SET 
[Full Name] = @fullname,
[User Name] = @username,
[ID Number] = @idnumber,
[Birth Date] = @birthdate,
Gender = @gender,
Email = @email,
[Password] = @password,
[Description] = @description

WHERE [User ID] = @userid and [Description] = 'Employee'

GO
USE [master]
GO
ALTER DATABASE [CarAndHome] SET  READ_WRITE 
GO
