USE [master]
GO
CREATE DATABASE [CarRental2]
GO
ALTER DATABASE [CarRental2] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarRental2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarRental2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarRental2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarRental2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarRental2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarRental2] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarRental2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarRental2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarRental2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarRental2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarRental2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarRental2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarRental2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarRental2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarRental2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarRental2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarRental2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarRental2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarRental2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarRental2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarRental2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarRental2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarRental2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarRental2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarRental2] SET  MULTI_USER 
GO
ALTER DATABASE [CarRental2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarRental2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarRental2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarRental2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarRental2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarRental2] SET QUERY_STORE = OFF
GO
USE [CarRental2]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Car](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LicensePlate] [nvarchar](50) NULL,
	[CategoryId] [int] NULL,
	[LocationId] [int] NULL,
	[Brand] [nvarchar](128) NULL,
	[Model] [nvarchar](128) NULL,
	[ProductionYear] [int] NULL,
	[KmClock] [int] NULL,
	[Fuel] [nvarchar](128) NULL,
	[Color] [nvarchar](128) NULL,
	[Seats] [int] NULL,
	[Gearbox] [nvarchar](128) NULL,
	[Horsepower] [int] NULL,
	[Image] [nvarchar](max) NULL,
	[Remark] [nvarchar](max) NULL,
 CONSTRAINT [Car_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CarCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](128) NULL,
	[CategoryDescription] [nvarchar](max) NULL,
	[RentalPrice] [decimal](18, 2) NULL,
 CONSTRAINT [CarCategory_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCardNumber] [nvarchar](50) NULL,
	[FirstName] [nvarchar](128) NULL,
	[SurName] [nvarchar](128) NULL,
	[Birthdate] [date] NULL,
	[ZipCode] [nvarchar](50) NULL,
	[City] [nvarchar](128) NULL,
	[AdressLine1] [nvarchar](128) NULL,
	[AdressLine2] [nvarchar](128) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[LicenseNumber] [nvarchar](50) NULL,
	[LicenseIssueDate] [date] NULL,
	[UserName] [nvarchar](50) NULL,
	[PasswordHash] [nvarchar](128) NULL,
	[Salt] [nvarchar](128) NULL,
	[EmailAdress] [nvarchar](128) NULL,
 CONSTRAINT [Client_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](128) NULL,
	[SurName] [nvarchar](128) NULL,
	[UserName] [nvarchar](128) NULL,
	[PasswordHash] [nvarchar](128) NULL,
	[Salt] [nvarchar](128) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[EmailAdress] [nvarchar](128) NULL,
	[AdminStatus] [bit] NULL,
 CONSTRAINT [Employee_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [nvarchar](128) NULL,
	[ZipCode] [nvarchar](50) NULL,
	[City] [nvarchar](30) NULL,
	[AdressLine1] [nvarchar](128) NULL,
	[AdressLine2] [nvarchar](128) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
 CONSTRAINT [Location_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Rental](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[ReservationId] [int] NULL,
	[RentalCreate] [timestamp] NULL,
	[KmsDriven] [int] NULL,
	[Cost] [decimal](18, 2) NULL,
	[Discount] [decimal](5, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[Advance] [decimal](18, 2) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [Rental_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reservation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NULL,
	[CarId] [int] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[PickUpLocationId] [int] NULL,
	[DropOffLocationId] [int] NULL,
 CONSTRAINT [Reservation_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [Car]  WITH CHECK ADD  CONSTRAINT [Car_CarCategory] FOREIGN KEY([CategoryId])
REFERENCES [CarCategory] ([Id])
GO
ALTER TABLE [Car] CHECK CONSTRAINT [Car_CarCategory]
GO
ALTER TABLE [Car]  WITH CHECK ADD  CONSTRAINT [Car_Location] FOREIGN KEY([LocationId])
REFERENCES [Location] ([Id])
GO
ALTER TABLE [Car] CHECK CONSTRAINT [Car_Location]
GO
ALTER TABLE [Rental]  WITH CHECK ADD  CONSTRAINT [Rental_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [Employee] ([Id])
GO
ALTER TABLE [Rental] CHECK CONSTRAINT [Rental_Employee]
GO
ALTER TABLE [Rental]  WITH CHECK ADD  CONSTRAINT [Rental_Reservation] FOREIGN KEY([ReservationId])
REFERENCES [Reservation] ([Id])
GO
ALTER TABLE [Rental] CHECK CONSTRAINT [Rental_Reservation]
GO
ALTER TABLE [Reservation]  WITH CHECK ADD  CONSTRAINT [Reservation_Car] FOREIGN KEY([CarId])
REFERENCES [Car] ([Id])
GO
ALTER TABLE [Reservation] CHECK CONSTRAINT [Reservation_Car]
GO
ALTER TABLE [Reservation]  WITH CHECK ADD  CONSTRAINT [Reservation_Client] FOREIGN KEY([ClientId])
REFERENCES [Client] ([Id])
GO
ALTER TABLE [Reservation] CHECK CONSTRAINT [Reservation_Client]
GO
ALTER TABLE [Reservation]  WITH CHECK ADD  CONSTRAINT [Reservation_LocationD] FOREIGN KEY([DropOffLocationId])
REFERENCES [Location] ([Id])
GO
ALTER TABLE [Reservation] CHECK CONSTRAINT [Reservation_LocationD]
GO
ALTER TABLE [Reservation]  WITH CHECK ADD  CONSTRAINT [Reservation_LocationP] FOREIGN KEY([PickUpLocationId])
REFERENCES [Location] ([Id])
GO
ALTER TABLE [Reservation] CHECK CONSTRAINT [Reservation_LocationP]
GO
USE [master]
GO
ALTER DATABASE [CarRental2] SET  READ_WRITE 
GO
