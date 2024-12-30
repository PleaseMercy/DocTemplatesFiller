USE [master]
GO
/****** Object:  Database [LoggerDB]    Script Date: 30.12.2024 23:13:56 ******/
CREATE DATABASE [LoggerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LoggerDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LoggerDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LoggerDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LoggerDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LoggerDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LoggerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LoggerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LoggerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LoggerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LoggerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LoggerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LoggerDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LoggerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LoggerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LoggerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LoggerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LoggerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LoggerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LoggerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LoggerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LoggerDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LoggerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LoggerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LoggerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LoggerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LoggerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LoggerDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LoggerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LoggerDB] SET RECOVERY FULL 
GO
ALTER DATABASE [LoggerDB] SET  MULTI_USER 
GO
ALTER DATABASE [LoggerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LoggerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LoggerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LoggerDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LoggerDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LoggerDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'LoggerDB', N'ON'
GO
ALTER DATABASE [LoggerDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [LoggerDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LoggerDB]
GO
/****** Object:  Table [dbo].[FileInfo]    Script Date: 30.12.2024 23:13:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileInfo](
	[ID_file] [int] IDENTITY(1,1) NOT NULL,
	[ID_action] [uniqueidentifier] NOT NULL,
	[NameFile] [varchar](max) NULL,
	[DataFromFile] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_file] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAction]    Script Date: 30.12.2024 23:13:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAction](
	[ID_action] [uniqueidentifier] NOT NULL,
	[ID_user] [int] NOT NULL,
	[usrAction] [varchar](100) NOT NULL,
	[dateAction] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_action] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersInfo]    Script Date: 30.12.2024 23:13:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SystemName] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FileInfo]  WITH CHECK ADD FOREIGN KEY([ID_action])
REFERENCES [dbo].[UserAction] ([ID_action])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAction]  WITH CHECK ADD FOREIGN KEY([ID_user])
REFERENCES [dbo].[UsersInfo] ([ID])
ON DELETE CASCADE
GO
/****** Object:  StoredProcedure [dbo].[InsertData]    Script Date: 30.12.2024 23:13:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertData] 
	@user nvarchar(max),
	@data nvarchar(max),
	@ActParam int
AS
BEGIN
	DECLARE @Query nvarchar(max),
			@RowsCount int,
			@UnicID uniqueidentifier = NEWID(),
			@UserID int
	
	IF @ActParam = 1
	BEGIN
		IF NOT EXISTS(SELECT * FROM UsersInfo WHERE SystemName = @user)
		BEGIN
			SET @Query = N'INSERT INTO UsersInfo SELECT ''' + @user + ''''
			EXECUTE sp_executesql
				@Query,
				N'@RowsCount int out',
				@RowsCount = @RowsCount out;
		END
	END
	
	SET @UserID = (SELECT TOP 1 ID FROM UsersInfo WHERE SystemName = @user)

	IF @ActParam = 2
	BEGIN
		INSERT UserAction VALUES (@UnicID, @UserID, @data, GETDATE())
	END

	IF @ActParam = 3
	BEGIN
		DECLARE @FileName nvarchar(max) 
		SET @FileName = RIGHT(LEFT(@data,CHARINDEX(CHAR(35),@data)-1),LEN(LEFT(@data,CHARINDEX(CHAR(35),@data)-1))-CHARINDEX(CHAR(36),LEFT(@data,CHARINDEX(CHAR(35),@data)-1)))
		INSERT UserAction VALUES (@UnicID, @UserID, LEFT(@data,CHARINDEX(CHAR(36),@data)-1), GETDATE())
		INSERT FileInfo VALUES (@UnicID,@FileName,SUBSTRING(@data,CHARINDEX(CHAR(35),@data)+1, LEN(@data)-CHARINDEX(CHAR(35),@data)))			
	END
END
GO
USE [master]
GO
ALTER DATABASE [LoggerDB] SET  READ_WRITE 
GO
