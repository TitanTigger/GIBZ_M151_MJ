USE [master]
GO
/****** Object:  Database [M151_DB_MJ]    Script Date: 14/06/2021 21:37:31 ******/
CREATE DATABASE [M151_DB_MJ]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'M151_DB_MJ', FILENAME = N'D:\Software\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\M151_DB_MJ_Primary.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'M151_DB_MJ_log', FILENAME = N'D:\Software\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\M151_DB_MJ_Primary.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [M151_DB_MJ] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [M151_DB_MJ].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [M151_DB_MJ] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET ARITHABORT OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [M151_DB_MJ] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [M151_DB_MJ] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [M151_DB_MJ] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET  DISABLE_BROKER 
GO
ALTER DATABASE [M151_DB_MJ] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [M151_DB_MJ] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [M151_DB_MJ] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [M151_DB_MJ] SET  MULTI_USER 
GO
ALTER DATABASE [M151_DB_MJ] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [M151_DB_MJ] SET DB_CHAINING OFF 
GO
ALTER DATABASE [M151_DB_MJ] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [M151_DB_MJ] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [M151_DB_MJ] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [M151_DB_MJ] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [M151_DB_MJ] SET QUERY_STORE = OFF
GO
USE [M151_DB_MJ]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14/06/2021 21:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 14/06/2021 21:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 14/06/2021 21:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 14/06/2021 21:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 14/06/2021 21:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 14/06/2021 21:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 14/06/2021 21:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 14/06/2021 21:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comment]    Script Date: 14/06/2021 21:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [nvarchar](450) NULL,
	[taskId] [int] NULL,
	[comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_comment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[list]    Script Date: 14/06/2021 21:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[list](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_list] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[priority]    Script Date: 14/06/2021 21:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[priority](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[emphasis] [int] NULL,
 CONSTRAINT [PK_priority] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 14/06/2021 21:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[share]    Script Date: 14/06/2021 21:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[share](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [nvarchar](450) NULL,
	[listId] [int] NULL,
	[roleId] [int] NULL,
 CONSTRAINT [PK_share] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[status]    Script Date: 14/06/2021 21:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[task]    Script Date: 14/06/2021 21:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[task](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [nvarchar](450) NULL,
	[listId] [int] NULL,
	[statusId] [int] NULL,
	[priorityId] [int] NULL,
	[title] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_task] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'089e7411-9e07-402b-a489-fc74f528df2e', N'test@gmail.com', N'TEST@GMAIL.COM', N'test@gmail.com', N'TEST@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEMC1Kt0O2MunHHMX0vbIhduQNiCcpImN/139nXFYnG049U5Rp4ZuRXTNo1+fOFZgMw==', N'YOCV46DLHPFDC47XQOCMBAGH2RQXFTTJ', N'12ce0d1f-a88e-4a87-bf3f-dd4e24858fbf', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2d509df3-d4ac-4b9e-8d88-6f605f853a57', N'dsaasdsdafsfa@gmail.com', N'DSAASDSDAFSFA@GMAIL.COM', N'dsaasdsdafsfa@gmail.com', N'DSAASDSDAFSFA@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAECc+TFf5RQdeGhFBRTmA9GNM8cjg3ZEdFF1HbkrT1P9NTyb3Gt/2SMxEtDIF+k7oUQ==', N'XRV4AQX47YBBMWMHHDTTQJJ7D3HSVYFV', N'9e982f06-10ba-44d4-96c9-ee17caaf3e6c', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'86438f28-7203-4510-a538-3fb2e950cc69', N'max.braaten03@gmail.com', N'MAX.BRAATEN03@GMAIL.COM', N'max.braaten03@gmail.com', N'MAX.BRAATEN03@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAECKSpHCWbx1nPg/i9L2UK76JQMdB+wmEjSta9EqEmQKIvm88uA9TPRhoJw2Q25i4Rg==', N'2IWQOBQSOVY6G7D4IXPPZFNL5C2QT43S', N'856775ed-bb87-43fa-a999-836167956bda', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a75ed816-8b64-4310-b92a-20bf92505dab', N'6origin9@gmail.com', N'6ORIGIN9@GMAIL.COM', N'6origin9@gmail.com', N'6ORIGIN9@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAENMP60DzSg34yYWRo9NJfWcJflTR1jMnuAcOgYmPDl0j1aAMOw2nWiOrrnmqYiYB2g==', N'4X4L7DBQCBTRUETLUKNFJZDPER6DJQQS', N'ed94e0dd-12e6-4891-86bb-99b293a9ff5a', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd33d8906-c490-4e94-8bc2-259f88e46f59', N'testemail@gmail.com', N'TESTEMAIL@GMAIL.COM', N'testemail@gmail.com', N'TESTEMAIL@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEOWhszGHpAqUiHuTQU2hJiXLF6NaHzIjUhbOHHRZPHZPm226MVlXVhjzVifPSjashA==', N'VIDRINMZFXLAX74XHJGYOVF5P56Y426W', N'49392ae8-a340-4765-be49-152136716d11', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd61ee38b-6603-4c78-b7f3-4ac0ad0b826d', N'max.braaten04@gmail.com', N'MAX.BRAATEN04@GMAIL.COM', N'max.braaten04@gmail.com', N'MAX.BRAATEN04@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEIRIhdqbvk27cFUlc++Yo1ARPjUKb3Ool0wTJ1wH0tkCg7u4FYX4CtcGDOUY1fcz1A==', N'DGIP7NZ5CYSON25S4AF45SYYH72JTKUZ', N'd435ea04-a9d8-499d-8722-272d42532a35', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ffe710b1-732d-421e-b58e-362152b1a917', N'jlipp@online.gibz.ch', N'JLIPP@ONLINE.GIBZ.CH', N'jlipp@online.gibz.ch', N'JLIPP@ONLINE.GIBZ.CH', 1, N'AQAAAAEAACcQAAAAECYuQLY79Ec6CvPBuqz15b9BuZfWNmoCuunVXY/18qayWoowpYWmlHQM0H2ppTz90Q==', N'HBEXOPFSUNDGKO4DAK4G6J3LXBTKTCCT', N'197eeb0e-fbec-424c-97aa-9534ca114616', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[list] ON 

INSERT [dbo].[list] ([id], [name]) VALUES (2, N'Joshua Lipp')
INSERT [dbo].[list] ([id], [name]) VALUES (3, N'Joshua Lipp')
INSERT [dbo].[list] ([id], [name]) VALUES (11, N'M151')
SET IDENTITY_INSERT [dbo].[list] OFF
GO
SET IDENTITY_INSERT [dbo].[share] ON 

INSERT [dbo].[share] ([id], [userId], [listId], [roleId]) VALUES (15, N'089e7411-9e07-402b-a489-fc74f528df2e', 11, NULL)
INSERT [dbo].[share] ([id], [userId], [listId], [roleId]) VALUES (16, N'ffe710b1-732d-421e-b58e-362152b1a917', 11, NULL)
SET IDENTITY_INSERT [dbo].[share] OFF
GO
SET IDENTITY_INSERT [dbo].[status] ON 

INSERT [dbo].[status] ([id], [name]) VALUES (1, N'ToDo')
INSERT [dbo].[status] ([id], [name]) VALUES (2, N'Doing')
INSERT [dbo].[status] ([id], [name]) VALUES (3, N'Done')
SET IDENTITY_INSERT [dbo].[status] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 14/06/2021 21:37:31 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 14/06/2021 21:37:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 14/06/2021 21:37:31 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 14/06/2021 21:37:31 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 14/06/2021 21:37:31 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 14/06/2021 21:37:31 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 14/06/2021 21:37:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[comment]  WITH CHECK ADD  CONSTRAINT [FK_comment_AspNetUsers] FOREIGN KEY([userId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [FK_comment_AspNetUsers]
GO
ALTER TABLE [dbo].[comment]  WITH CHECK ADD  CONSTRAINT [FK_comment_task] FOREIGN KEY([taskId])
REFERENCES [dbo].[task] ([id])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [FK_comment_task]
GO
ALTER TABLE [dbo].[share]  WITH CHECK ADD  CONSTRAINT [FK_share_AspNetUsers] FOREIGN KEY([userId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[share] CHECK CONSTRAINT [FK_share_AspNetUsers]
GO
ALTER TABLE [dbo].[share]  WITH CHECK ADD  CONSTRAINT [FK_share_list] FOREIGN KEY([listId])
REFERENCES [dbo].[list] ([id])
GO
ALTER TABLE [dbo].[share] CHECK CONSTRAINT [FK_share_list]
GO
ALTER TABLE [dbo].[share]  WITH CHECK ADD  CONSTRAINT [FK_share_role] FOREIGN KEY([roleId])
REFERENCES [dbo].[role] ([id])
GO
ALTER TABLE [dbo].[share] CHECK CONSTRAINT [FK_share_role]
GO
ALTER TABLE [dbo].[task]  WITH CHECK ADD  CONSTRAINT [FK_task_AspNetUsers] FOREIGN KEY([userId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[task] CHECK CONSTRAINT [FK_task_AspNetUsers]
GO
ALTER TABLE [dbo].[task]  WITH CHECK ADD  CONSTRAINT [FK_task_list] FOREIGN KEY([listId])
REFERENCES [dbo].[list] ([id])
GO
ALTER TABLE [dbo].[task] CHECK CONSTRAINT [FK_task_list]
GO
ALTER TABLE [dbo].[task]  WITH CHECK ADD  CONSTRAINT [FK_task_priority] FOREIGN KEY([priorityId])
REFERENCES [dbo].[priority] ([id])
GO
ALTER TABLE [dbo].[task] CHECK CONSTRAINT [FK_task_priority]
GO
ALTER TABLE [dbo].[task]  WITH CHECK ADD  CONSTRAINT [FK_task_status] FOREIGN KEY([statusId])
REFERENCES [dbo].[status] ([id])
GO
ALTER TABLE [dbo].[task] CHECK CONSTRAINT [FK_task_status]
GO
USE [master]
GO
ALTER DATABASE [M151_DB_MJ] SET  READ_WRITE 
GO
