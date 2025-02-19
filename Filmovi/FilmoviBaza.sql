USE [master]
GO
/****** Object:  Database [Filmovi]    Script Date: 08-Dec-24 17:40:02 ******/
CREATE DATABASE [Filmovi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Filmovi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.DANILOVSERVER\MSSQL\DATA\Filmovi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Filmovi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.DANILOVSERVER\MSSQL\DATA\Filmovi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Filmovi] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Filmovi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Filmovi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Filmovi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Filmovi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Filmovi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Filmovi] SET ARITHABORT OFF 
GO
ALTER DATABASE [Filmovi] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Filmovi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Filmovi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Filmovi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Filmovi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Filmovi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Filmovi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Filmovi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Filmovi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Filmovi] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Filmovi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Filmovi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Filmovi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Filmovi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Filmovi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Filmovi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Filmovi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Filmovi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Filmovi] SET  MULTI_USER 
GO
ALTER DATABASE [Filmovi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Filmovi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Filmovi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Filmovi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Filmovi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Filmovi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Filmovi] SET QUERY_STORE = OFF
GO
USE [Filmovi]
GO
/****** Object:  FullTextCatalog [FullTextCatalog]    Script Date: 08-Dec-24 17:40:02 ******/
CREATE FULLTEXT CATALOG [FullTextCatalog] AS DEFAULT
GO
/****** Object:  Table [dbo].[Film]    Script Date: 08-Dec-24 17:40:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Film](
	[FilmID] [int] NOT NULL,
	[Naziv] [nvarchar](100) NOT NULL,
	[Zanr] [nvarchar](100) NOT NULL,
	[GodinaIzdanja] [int] NOT NULL,
	[VrijemeTrajanja] [float] NOT NULL,
	[Ocjena] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FilmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 08-Dec-24 17:40:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[KorisnikID] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nchar](100) NOT NULL,
	[Password] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Korisnik] PRIMARY KEY CLUSTERED 
(
	[KorisnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Film] ([FilmID], [Naziv], [Zanr], [GodinaIzdanja], [VrijemeTrajanja], [Ocjena]) VALUES (1, N'Sin City', N'Thriller,Crime', 2005, 124, 8)
INSERT [dbo].[Film] ([FilmID], [Naziv], [Zanr], [GodinaIzdanja], [VrijemeTrajanja], [Ocjena]) VALUES (2, N'Gladiator', N'Action,Adventure,Drama', 2005, 135, 8.2)
INSERT [dbo].[Film] ([FilmID], [Naziv], [Zanr], [GodinaIzdanja], [VrijemeTrajanja], [Ocjena]) VALUES (3, N'Lord of the rings', N'Action,Adventure', 2000, 180, 8.9)
INSERT [dbo].[Film] ([FilmID], [Naziv], [Zanr], [GodinaIzdanja], [VrijemeTrajanja], [Ocjena]) VALUES (4, N'Die hard', N'Action,Thriller,Crime', 1988, 110, 6.9)
INSERT [dbo].[Film] ([FilmID], [Naziv], [Zanr], [GodinaIzdanja], [VrijemeTrajanja], [Ocjena]) VALUES (5, N'Taxi driver', N'Thriller,Crime', 1977, 115, 7.8)
INSERT [dbo].[Film] ([FilmID], [Naziv], [Zanr], [GodinaIzdanja], [VrijemeTrajanja], [Ocjena]) VALUES (6, N'Insomnia', N'Mystery', 1999, 121, 8.1)
INSERT [dbo].[Film] ([FilmID], [Naziv], [Zanr], [GodinaIzdanja], [VrijemeTrajanja], [Ocjena]) VALUES (7, N'Kill Bill', N'Action,Thriller,Crime', 2004, 92, 7.7)
INSERT [dbo].[Film] ([FilmID], [Naziv], [Zanr], [GodinaIzdanja], [VrijemeTrajanja], [Ocjena]) VALUES (8, N'Star wars', N'Adventure, Sci-Fi', 1981, 176, 6.5)
INSERT [dbo].[Film] ([FilmID], [Naziv], [Zanr], [GodinaIzdanja], [VrijemeTrajanja], [Ocjena]) VALUES (9, N'X-men', N'Action,Sci-Fi,Superhero', 2000, 119, 8)
INSERT [dbo].[Film] ([FilmID], [Naziv], [Zanr], [GodinaIzdanja], [VrijemeTrajanja], [Ocjena]) VALUES (10, N'Forest Gump', N'Drama,Romance', 1994, 124, 8.9)
INSERT [dbo].[Film] ([FilmID], [Naziv], [Zanr], [GodinaIzdanja], [VrijemeTrajanja], [Ocjena]) VALUES (11, N'Sin City 2', N'Crime', 2010, 122, 7.4)
INSERT [dbo].[Film] ([FilmID], [Naziv], [Zanr], [GodinaIzdanja], [VrijemeTrajanja], [Ocjena]) VALUES (12, N'Avengers', N'Crime Drama', 2012, 121, 7.2)
GO
USE [master]
GO
ALTER DATABASE [Filmovi] SET  READ_WRITE 
GO
