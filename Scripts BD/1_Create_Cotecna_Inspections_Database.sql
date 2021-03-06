CREATE DATABASE [Cotecna_Inspections] ON  PRIMARY 
( NAME = N'Cotecna_Inspections', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Cotecna_Inspections.mdf' , SIZE = 3072KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Cotecna_Inspections_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Cotecna_Inspections_log.ldf' , SIZE = 1024KB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Cotecna_Inspections] SET COMPATIBILITY_LEVEL = 100
GO
ALTER DATABASE [Cotecna_Inspections] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cotecna_Inspections] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cotecna_Inspections] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cotecna_Inspections] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cotecna_Inspections] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cotecna_Inspections] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cotecna_Inspections] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Cotecna_Inspections] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cotecna_Inspections] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cotecna_Inspections] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cotecna_Inspections] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cotecna_Inspections] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cotecna_Inspections] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cotecna_Inspections] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cotecna_Inspections] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cotecna_Inspections] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cotecna_Inspections] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cotecna_Inspections] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cotecna_Inspections] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cotecna_Inspections] SET  READ_WRITE 
GO
ALTER DATABASE [Cotecna_Inspections] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Cotecna_Inspections] SET  MULTI_USER 
GO
ALTER DATABASE [Cotecna_Inspections] SET PAGE_VERIFY CHECKSUM  
GO
USE [Cotecna_Inspections]
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [Cotecna_Inspections] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO
