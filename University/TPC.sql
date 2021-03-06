USE [master]
GO

/****** Object:  Database [TpcUniversityDb]    Script Date: 19.11.2016 г. 11:54:47 ******/
CREATE DATABASE [TpcUniversityDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TpcUniversityDb', FILENAME = N'C:\Users\ug_th\TpcUniversityDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TpcUniversityDb_log', FILENAME = N'C:\Users\ug_th\TpcUniversityDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [TpcUniversityDb] SET COMPATIBILITY_LEVEL = 130
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TpcUniversityDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [TpcUniversityDb] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET ARITHABORT OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [TpcUniversityDb] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [TpcUniversityDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [TpcUniversityDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET  ENABLE_BROKER 
GO

ALTER DATABASE [TpcUniversityDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [TpcUniversityDb] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [TpcUniversityDb] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [TpcUniversityDb] SET  MULTI_USER 
GO

ALTER DATABASE [TpcUniversityDb] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [TpcUniversityDb] SET DB_CHAINING OFF 
GO

ALTER DATABASE [TpcUniversityDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [TpcUniversityDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [TpcUniversityDb] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [TpcUniversityDb] SET QUERY_STORE = OFF
GO

USE [TpcUniversityDb]
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [TpcUniversityDb] SET  READ_WRITE 
GO

