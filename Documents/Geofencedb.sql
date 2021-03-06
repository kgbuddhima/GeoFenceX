USE [master]
GO
/****** Object:  Database [GeoFence]    Script Date: 8/24/2017 4:21:26 PM ******/
CREATE DATABASE [GeoFence]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GeoFence', FILENAME = N'F:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS2016\MSSQL\DATA\GeoFence.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GeoFence_log', FILENAME = N'F:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS2016\MSSQL\DATA\GeoFence_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GeoFence] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GeoFence].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GeoFence] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GeoFence] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GeoFence] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GeoFence] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GeoFence] SET ARITHABORT OFF 
GO
ALTER DATABASE [GeoFence] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GeoFence] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GeoFence] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GeoFence] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GeoFence] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GeoFence] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GeoFence] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GeoFence] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GeoFence] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GeoFence] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GeoFence] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GeoFence] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GeoFence] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GeoFence] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GeoFence] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GeoFence] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GeoFence] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GeoFence] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GeoFence] SET  MULTI_USER 
GO
ALTER DATABASE [GeoFence] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GeoFence] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GeoFence] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GeoFence] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GeoFence] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GeoFence] SET QUERY_STORE = OFF
GO
USE [GeoFence]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [GeoFence]
GO
/****** Object:  User [DESKTOP-LBHS619\Buddhima]    Script Date: 8/24/2017 4:21:26 PM ******/
CREATE USER [DESKTOP-LBHS619\Buddhima] FOR LOGIN [DESKTOP-LBHS619\Buddhima] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[AttendanceData]    Script Date: 8/24/2017 4:21:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttendanceData](
	[RecordId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TransitionName] [varchar](7) NULL,
	[Name] [varchar](50) NULL,
	[TransitionTime] [datetime] NULL,
 CONSTRAINT [PK_AttendanceData] PRIMARY KEY CLUSTERED 
(
	[RecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 8/24/2017 4:21:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[Name] [varchar](20) NOT NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[Radius] [int] NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AttendanceData] ON 

INSERT [dbo].[AttendanceData] ([RecordId], [UserId], [TransitionName], [Name], [TransitionTime]) VALUES (1, 1, N'Entered', N'KesHome2', CAST(N'2017-08-24T09:30:22.697' AS DateTime))
INSERT [dbo].[AttendanceData] ([RecordId], [UserId], [TransitionName], [Name], [TransitionTime]) VALUES (2, 1, N'Exited', N'KesHome2', CAST(N'2017-08-24T09:40:22.697' AS DateTime))
SET IDENTITY_INSERT [dbo].[AttendanceData] OFF
INSERT [dbo].[Region] ([Name], [Latitude], [Longitude], [Radius]) VALUES (N'Depot', 6.792188, 79.948215, 10)
INSERT [dbo].[Region] ([Name], [Latitude], [Longitude], [Radius]) VALUES (N'KesHome1', 6.7919888496398926, 79.949104309082031, 10)
/****** Object:  StoredProcedure [dbo].[GetAttendanceData]    Script Date: 8/24/2017 4:21:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetAttendanceData]
(
@UserId INT
)
AS
SELECT [RecordId]
      ,[UserId]
      ,[TransitionName]
      ,[Name]
      ,[TransitionTime]
  FROM [dbo].[AttendanceData]
WHERE UserId=@UserId


GO
/****** Object:  StoredProcedure [dbo].[GetGeoRegions]    Script Date: 8/24/2017 4:21:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetGeoRegions]
as
SELECT * FROM Region
ORDER BY [Name] ASC
GO
/****** Object:  StoredProcedure [dbo].[UpdateAttendanceData]    Script Date: 8/24/2017 4:21:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAttendanceData]
(
@UserId INT,
@TransitionName VARCHAR(7),
@Name VARCHAR(20),
@TransitionTime DATETIME
)
AS
INSERT INTO [dbo].[AttendanceData]
           ([UserId]
           ,[TransitionName]
           ,[Name]
           ,[TransitionTime])
     VALUES
           (@UserId
           ,@TransitionName
           ,@Name
           ,@TransitionTime)
GO
/****** Object:  StoredProcedure [dbo].[UpdateGeoLocation]    Script Date: 8/24/2017 4:21:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateGeoLocation]
(
@Name VARCHAR(20),
@Latitude FLOAT,
@Longitude FLOAT,
@Radius INT
)
AS
DECLARE @NameExists VARCHAR(20)

SELECT  @NameExists=[Name] FROM [dbo].[Region] WHERE [Name]=@Name

IF @NameExists IS NULL OR @NameExists=''
	BEGIN
		INSERT INTO [dbo].[Region]
				   ([Name]
				   ,[Latitude]
				   ,[Longitude]
				   ,[Radius])
			 VALUES
				   (@Name
				   ,@Latitude
				   ,@Longitude
				   ,@Radius)
	END
ELSE
	BEGIN
		UPDATE [dbo].[Region] SET [Latitude]=@Latitude, [Longitude]=@Longitude,[Radius]=@Radius
		WHERE [Name]=@Name
	END

GO
USE [master]
GO
ALTER DATABASE [GeoFence] SET  READ_WRITE 
GO
