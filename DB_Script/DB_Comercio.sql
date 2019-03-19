USE [master]
GO
/****** Object:  Database [DB_Comercio]    Script Date: 18/03/2019 18:00:50 ******/
CREATE DATABASE [DB_Comercio]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Comercio', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014EX\MSSQL\DATA\DB_Comercio.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DB_Comercio_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014EX\MSSQL\DATA\DB_Comercio_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DB_Comercio] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Comercio].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Comercio] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Comercio] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Comercio] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Comercio] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Comercio] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Comercio] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_Comercio] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Comercio] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Comercio] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Comercio] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Comercio] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Comercio] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Comercio] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Comercio] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Comercio] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_Comercio] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Comercio] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Comercio] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Comercio] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Comercio] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Comercio] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Comercio] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Comercio] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_Comercio] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Comercio] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Comercio] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Comercio] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Comercio] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DB_Comercio] SET DELAYED_DURABILITY = DISABLED 
GO

