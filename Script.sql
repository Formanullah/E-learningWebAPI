USE [master]
GO
/****** Object:  Database [ElearningWebApp.db]    Script Date: 23-Mar-21 3:20:52 PM ******/
CREATE DATABASE [ElearningWebApp.db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ElearningWebApp.db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ElearningWebApp.db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ElearningWebApp.db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ElearningWebApp.db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ElearningWebApp.db] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ElearningWebApp.db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ElearningWebApp.db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET ARITHABORT OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ElearningWebApp.db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ElearningWebApp.db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ElearningWebApp.db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ElearningWebApp.db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ElearningWebApp.db] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ElearningWebApp.db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ElearningWebApp.db] SET  MULTI_USER 
GO
ALTER DATABASE [ElearningWebApp.db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ElearningWebApp.db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ElearningWebApp.db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ElearningWebApp.db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ElearningWebApp.db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ElearningWebApp.db] SET QUERY_STORE = OFF
GO
USE [ElearningWebApp.db]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23-Mar-21 3:20:53 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 23-Mar-21 3:20:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chapters]    Script Date: 23-Mar-21 3:20:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chapters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[SubjectName] [nvarchar](max) NOT NULL,
	[SubjectForClassId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Chapters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 23-Mar-21 3:20:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 23-Mar-21 3:20:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ClassName] [nvarchar](max) NOT NULL,
	[MobileNo] [nvarchar](max) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectForClass]    Script Date: 23-Mar-21 3:20:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectForClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [nvarchar](max) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_GetSubjectForSyllabus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 23-Mar-21 3:20:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[VirtualPath] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topics]    Script Date: 23-Mar-21 3:20:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ChapterName] [nvarchar](max) NOT NULL,
	[ChapterId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Topics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Videos]    Script Date: 23-Mar-21 3:20:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Videos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[Isfree] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[ClassName] [nvarchar](max) NOT NULL,
	[SubjectForClassId] [int] NOT NULL,
	[SubjectName] [nvarchar](max) NOT NULL,
	[ChapterId] [int] NOT NULL,
	[ChapterName] [nvarchar](max) NOT NULL,
	[TopicName] [nvarchar](max) NOT NULL,
	[TopicId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
 CONSTRAINT [PK_Videos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210320095008_initialCreate1', N'3.1.5')
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([Id], [Name], [FileName], [VirtualPath]) VALUES (1, N'Bangla', N'02f444c7-d599-4f67-8deb-ad3de769b5fe_0a641b4f-33c3-4b81-8995-6faaaca606cf.3792f93a2c3075c55c1d61556ebb4986.jpeg', N'\imgs\Subject\02f444c7-d599-4f67-8deb-ad3de769b5fe_0a641b4f-33c3-4b81-8995-6faaaca606cf.3792f93a2c3075c55c1d61556ebb4986.jpeg')
INSERT [dbo].[Subjects] ([Id], [Name], [FileName], [VirtualPath]) VALUES (2, N'English', N'd383e922-0243-4099-b64c-2d380f0fe0e7_0a641b4f-33c3-4b81-8995-6faaaca606cf.3792f93a2c3075c55c1d61556ebb4986.jpeg', N'\imgs\Subject\d383e922-0243-4099-b64c-2d380f0fe0e7_0a641b4f-33c3-4b81-8995-6faaaca606cf.3792f93a2c3075c55c1d61556ebb4986.jpeg')
SET IDENTITY_INSERT [dbo].[Subjects] OFF
/****** Object:  Index [IX_Chapters_SubjectForSyllabusId]    Script Date: 23-Mar-21 3:20:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_Chapters_SubjectForSyllabusId] ON [dbo].[Chapters]
(
	[SubjectForClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GetSubjectForSyllabus_SubjectId]    Script Date: 23-Mar-21 3:20:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_GetSubjectForSyllabus_SubjectId] ON [dbo].[SubjectForClass]
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GetSubjectForSyllabus_SyllabusId]    Script Date: 23-Mar-21 3:20:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_GetSubjectForSyllabus_SyllabusId] ON [dbo].[SubjectForClass]
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Topics_ChapterId]    Script Date: 23-Mar-21 3:20:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_Topics_ChapterId] ON [dbo].[Topics]
(
	[ChapterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Videos_TopicId]    Script Date: 23-Mar-21 3:20:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_Videos_TopicId] ON [dbo].[Videos]
(
	[TopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Chapters]  WITH CHECK ADD  CONSTRAINT [FK_Chapters_SubjectForClass] FOREIGN KEY([SubjectForClassId])
REFERENCES [dbo].[SubjectForClass] ([Id])
GO
ALTER TABLE [dbo].[Chapters] CHECK CONSTRAINT [FK_Chapters_SubjectForClass]
GO
ALTER TABLE [dbo].[SubjectForClass]  WITH CHECK ADD  CONSTRAINT [FK_SubjectForClass_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([Id])
GO
ALTER TABLE [dbo].[SubjectForClass] CHECK CONSTRAINT [FK_SubjectForClass_Class]
GO
ALTER TABLE [dbo].[SubjectForClass]  WITH CHECK ADD  CONSTRAINT [FK_SubjectForSyllabus_Subjects] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([Id])
GO
ALTER TABLE [dbo].[SubjectForClass] CHECK CONSTRAINT [FK_SubjectForSyllabus_Subjects]
GO
ALTER TABLE [dbo].[Topics]  WITH CHECK ADD  CONSTRAINT [FK_Topics_Chapters] FOREIGN KEY([ChapterId])
REFERENCES [dbo].[Chapters] ([Id])
GO
ALTER TABLE [dbo].[Topics] CHECK CONSTRAINT [FK_Topics_Chapters]
GO
ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_Chapters] FOREIGN KEY([ChapterId])
REFERENCES [dbo].[Chapters] ([Id])
GO
ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_Chapters]
GO
ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([Id])
GO
ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_Class]
GO
ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_SubjectForClass] FOREIGN KEY([SubjectForClassId])
REFERENCES [dbo].[SubjectForClass] ([Id])
GO
ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_SubjectForClass]
GO
ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_Topics] FOREIGN KEY([TopicId])
REFERENCES [dbo].[Topics] ([Id])
GO
ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_Topics]
GO
USE [master]
GO
ALTER DATABASE [ElearningWebApp.db] SET  READ_WRITE 
GO
