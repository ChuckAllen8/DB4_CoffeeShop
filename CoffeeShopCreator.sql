USE [master]
GO
/****** Object:  Database [CoffeeShop]    Script Date: 9/11/2020 1:44:12 PM ******/
CREATE DATABASE [CoffeeShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CoffeeShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.DB4_SERVER\MSSQL\DATA\CoffeeShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CoffeeShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.DB4_SERVER\MSSQL\DATA\CoffeeShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CoffeeShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CoffeeShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CoffeeShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CoffeeShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CoffeeShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CoffeeShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CoffeeShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [CoffeeShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CoffeeShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CoffeeShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CoffeeShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CoffeeShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CoffeeShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CoffeeShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CoffeeShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CoffeeShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CoffeeShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CoffeeShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CoffeeShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CoffeeShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CoffeeShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CoffeeShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CoffeeShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CoffeeShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CoffeeShop] SET RECOVERY FULL 
GO
ALTER DATABASE [CoffeeShop] SET  MULTI_USER 
GO
ALTER DATABASE [CoffeeShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CoffeeShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CoffeeShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CoffeeShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CoffeeShop] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CoffeeShop', N'ON'
GO
ALTER DATABASE [CoffeeShop] SET QUERY_STORE = OFF
GO
USE [CoffeeShop]
GO
/****** Object:  User [DB4_Coffee]    Script Date: 9/11/2020 1:44:12 PM ******/
CREATE USER [DB4_Coffee] FOR LOGIN [DB4_Coffee] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [DB4_Coffee]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [DB4_Coffee]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 9/11/2020 1:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 9/11/2020 1:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ShortDescription] [nvarchar](50) NULL,
	[LongDescription] [nvarchar](max) NULL,
	[Price] [money] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
USE [master]
GO
ALTER DATABASE [CoffeeShop] SET  READ_WRITE 
GO
