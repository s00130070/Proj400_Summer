USE [master]
GO
/****** Object:  Database [Proj400Summer]    Script Date: 01/09/2016 21:53:31 ******/
CREATE DATABASE [Proj400Summer]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Proj400Summer', FILENAME = N'C:\Users\John\Proj400Summer.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Proj400Summer_log', FILENAME = N'C:\Users\John\Proj400Summer_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Proj400Summer] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Proj400Summer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Proj400Summer] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Proj400Summer] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Proj400Summer] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Proj400Summer] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Proj400Summer] SET ARITHABORT OFF 
GO
ALTER DATABASE [Proj400Summer] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Proj400Summer] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Proj400Summer] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Proj400Summer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Proj400Summer] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Proj400Summer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Proj400Summer] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Proj400Summer] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Proj400Summer] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Proj400Summer] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Proj400Summer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Proj400Summer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Proj400Summer] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Proj400Summer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Proj400Summer] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Proj400Summer] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Proj400Summer] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Proj400Summer] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Proj400Summer] SET  MULTI_USER 
GO
ALTER DATABASE [Proj400Summer] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Proj400Summer] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Proj400Summer] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Proj400Summer] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Proj400Summer]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 01/09/2016 21:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 01/09/2016 21:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 01/09/2016 21:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 01/09/2016 21:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 01/09/2016 21:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[order_Info]    Script Date: 01/09/2016 21:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[order_Info](
	[order_ID] [int] NOT NULL,
	[username] [nvarchar](50) NULL,
	[contact_Number] [nchar](10) NULL,
	[order_Date] [datetime] NULL,
	[user_ID] [int] NULL,
	[order_Quantity] [int] NULL,
	[order_Status] [char](10) NULL,
	[product_ID] [int] NULL,
	[shipping_ShipName] [nvarchar](50) NULL,
	[shipping_Line1] [nvarchar](50) NULL,
	[shipping_Line2] [nvarchar](50) NULL,
	[shipping_Line3] [nvarchar](50) NULL,
	[shipping_City] [nvarchar](50) NULL,
	[shipping_State] [nvarchar](50) NULL,
	[shipping_Country] [nvarchar](50) NULL,
	[shipping_Postcode] [nvarchar](10) NULL,
	[shiping_Wrapped] [bit] NULL,
 CONSTRAINT [PK_order_Info] PRIMARY KEY CLUSTERED 
(
	[order_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[product_Info]    Script Date: 01/09/2016 21:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[product_Info](
	[product_ID] [int] IDENTITY(1,1) NOT NULL,
	[product_Name] [nvarchar](100) NOT NULL,
	[product_Category] [nvarchar](10) NOT NULL,
	[product_Type] [nvarchar](10) NULL,
	[product_Brand] [nvarchar](10) NULL,
	[product_Color] [nvarchar](10) NULL,
	[product_Desc] [nvarchar](500) NOT NULL,
	[product_Price] [decimal](16, 2) NOT NULL,
	[product_ImageData] [varbinary](max) NULL,
	[product_ImageMimeType] [varchar](50) NULL,
 CONSTRAINT [PK_product_Info] PRIMARY KEY CLUSTERED 
(
	[product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductInfoes]    Script Date: 01/09/2016 21:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductInfoes](
	[product_ID] [int] IDENTITY(1,1) NOT NULL,
	[product_Name] [nvarchar](max) NULL,
	[product_Category] [nvarchar](max) NULL,
	[product_Type] [nvarchar](max) NULL,
	[product_Brand] [nvarchar](max) NULL,
	[product_Color] [nvarchar](max) NULL,
	[product_Desc] [nvarchar](max) NULL,
	[product_Price] [decimal](18, 2) NOT NULL,
	[product_Quantity] [int] NOT NULL,
	[Image_Data] [varbinary](max) NULL,
	[Image_Mime_Type] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.ProductInfoes] PRIMARY KEY CLUSTERED 
(
	[product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[user_Details]    Script Date: 01/09/2016 21:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user_Details](
	[user_ID] [int] NOT NULL,
	[user_Email] [nvarchar](256) NULL,
	[user_EmailConfirmed] [bit] NULL,
	[user_Password] [nvarchar](60) NULL,
	[user_SecurityStamp] [nvarchar](max) NULL,
	[user_PhoneNumber] [varchar](50) NULL,
	[user_PhoneNumberConfirmed] [bit] NULL,
	[TwoFactorEnabled] [bit] NULL,
	[AccessFailedCount] [int] NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[username] [nvarchar](256) NULL,
	[user_AddressPostCode] [nvarchar](10) NULL,
	[user_FirstName] [nvarchar](50) NULL,
	[user_LastName] [nvarchar](50) NULL,
	[user_DOB] [date] NULL,
	[user_RegDate] [date] NULL,
	[user_AccActive] [bit] NULL,
	[active_Hash] [nchar](10) NULL,
	[recover_Hash] [nchar](10) NULL,
	[user_AddressLine1] [nvarchar](50) NULL,
	[user_AddressLine2] [nvarchar](50) NULL,
	[user_AddressLine3] [nvarchar](50) NULL,
	[user_AddressCity] [nvarchar](50) NULL,
	[user_AddressState] [nvarchar](50) NULL,
	[user_AddressCountry] [nvarchar](50) NULL,
 CONSTRAINT [PK_user_Details] PRIMARY KEY CLUSTERED 
(
	[user_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 01/09/2016 21:53:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 01/09/2016 21:53:31 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 01/09/2016 21:53:31 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 01/09/2016 21:53:31 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 01/09/2016 21:53:31 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 01/09/2016 21:53:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[order_Info]  WITH CHECK ADD  CONSTRAINT [FK_order_Info_product_Info] FOREIGN KEY([product_ID])
REFERENCES [dbo].[product_Info] ([product_ID])
GO
ALTER TABLE [dbo].[order_Info] CHECK CONSTRAINT [FK_order_Info_product_Info]
GO
ALTER TABLE [dbo].[order_Info]  WITH CHECK ADD  CONSTRAINT [FK_order_Info_user_Details] FOREIGN KEY([user_ID])
REFERENCES [dbo].[user_Details] ([user_ID])
GO
ALTER TABLE [dbo].[order_Info] CHECK CONSTRAINT [FK_order_Info_user_Details]
GO
USE [master]
GO
ALTER DATABASE [Proj400Summer] SET  READ_WRITE 
GO
