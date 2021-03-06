USE [master]
GO
/****** Object:  Database [ElearningWebApp.db]    Script Date: 04-Apr-21 12:50:12 AM ******/
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
/****** Object:  Table [dbo].[Admins]    Script Date: 04-Apr-21 12:50:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[CreatedDate] [date] NULL,
	[UpdateDate] [date] NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chapters]    Script Date: 04-Apr-21 12:50:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chapters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[SubjectName] [varchar](max) NOT NULL,
	[SubjectForClassId] [int] NOT NULL,
	[CreatedDate] [date] NULL,
	[UpdateDate] [date] NULL,
	[ClassName] [varchar](50) NOT NULL,
	[ClassId] [int] NOT NULL,
 CONSTRAINT [PK_Chapters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 04-Apr-21 12:50:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 04-Apr-21 12:50:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 04-Apr-21 12:50:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[ClassName] [varchar](max) NOT NULL,
	[MobileNo] [varchar](max) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[CreatedDate] [date] NULL,
	[UpdateDate] [date] NULL,
	[RoleId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectForClass]    Script Date: 04-Apr-21 12:50:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectForClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [varchar](max) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
	[CreatedDate] [date] NULL,
	[UpdateDate] [date] NULL,
	[FileName] [varchar](max) NOT NULL,
	[VirtualPath] [varchar](max) NOT NULL,
	[ClassName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GetSubjectForSyllabus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 04-Apr-21 12:50:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[CreatedDate] [date] NULL,
	[UpdateDate] [date] NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topics]    Script Date: 04-Apr-21 12:50:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[ChapterName] [varchar](max) NOT NULL,
	[ChapterId] [int] NOT NULL,
	[CreatedDate] [date] NULL,
	[UpdateDate] [date] NULL,
	[SubjctName] [varchar](50) NOT NULL,
	[ClassName] [varchar](50) NOT NULL,
	[SubjectIdInClass] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
 CONSTRAINT [PK_Topics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Videos]    Script Date: 04-Apr-21 12:50:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Videos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [varchar](max) NOT NULL,
	[Isfree] [bit] NOT NULL,
	[CreatedDate] [date] NULL,
	[UpdateDate] [date] NULL,
	[ClassName] [varchar](max) NOT NULL,
	[SubjectForClassId] [int] NOT NULL,
	[SubjectName] [varchar](max) NOT NULL,
	[ChapterId] [int] NOT NULL,
	[ChapterName] [varchar](max) NOT NULL,
	[TopicName] [varchar](max) NOT NULL,
	[TopicId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
	[PublicId] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Videos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admins] ON 

INSERT [dbo].[Admins] ([Id], [Name], [PasswordHash], [PasswordSalt], [CreatedDate], [UpdateDate], [RoleId]) VALUES (1, N'a', 0x4B65D504CCF6AE295676A7C13045D17DBA2DFF1FD48650FB0FE531F480D9B8F446B0E806CFC53E6B6A840252B59C73A56594ED07A378A46EEF8D2D65D1335726, 0x26CC485CA471E4696AC7BF5A25915DD07F4D6383D679AD47EB551A2A1585CF852878D5323E41DB70A0473BA54CB200C5375A3B31A762D2C0715BCA7FCBC1C64C718471CF8CB7F956115E5D0660FC052CC7E93D55E732E4BBF614A5FE8E6CF2CFC0B8B0121667213F41B7B33C20C4E760DD955237C3F47D14948F9B2F1BD479C3, NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[Admins] OFF
SET IDENTITY_INSERT [dbo].[Chapters] ON 

INSERT [dbo].[Chapters] ([Id], [Name], [SubjectName], [SubjectForClassId], [CreatedDate], [UpdateDate], [ClassName], [ClassId]) VALUES (1, N'Gram Bangla', N'Bangla', 1, CAST(N'2021-03-23' AS Date), CAST(N'2021-04-03' AS Date), N'One', 1)
INSERT [dbo].[Chapters] ([Id], [Name], [SubjectName], [SubjectForClassId], [CreatedDate], [UpdateDate], [ClassName], [ClassId]) VALUES (2, N'Bhuter bari', N'Bangla', 8, CAST(N'2021-04-03' AS Date), CAST(N'2021-04-03' AS Date), N'Two', 2)
INSERT [dbo].[Chapters] ([Id], [Name], [SubjectName], [SubjectForClassId], [CreatedDate], [UpdateDate], [ClassName], [ClassId]) VALUES (3, N'nodi', N'Bangla', 8, CAST(N'2021-04-03' AS Date), NULL, N'Two', 2)
SET IDENTITY_INSERT [dbo].[Chapters] OFF
SET IDENTITY_INSERT [dbo].[Class] ON 

INSERT [dbo].[Class] ([Id], [Name]) VALUES (1, N'One')
INSERT [dbo].[Class] ([Id], [Name]) VALUES (2, N'Two')
INSERT [dbo].[Class] ([Id], [Name]) VALUES (3, N'Three')
INSERT [dbo].[Class] ([Id], [Name]) VALUES (4, N'Four')
SET IDENTITY_INSERT [dbo].[Class] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [RoleName]) VALUES (1, N'Student')
INSERT [dbo].[Role] ([Id], [RoleName]) VALUES (2, N'Admin')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [Name], [ClassName], [MobileNo], [PasswordHash], [PasswordSalt], [CreatedDate], [UpdateDate], [RoleId], [ClassId]) VALUES (1, N'Elias', N'One', N'012545252544', 0xC553755E68E78DAE8AE5AD5B1CEBAB5DC324DC05C9A2DF0421DE92340FEF9DDA7932FADD2C7532EFF75DD9E0787121619DE893F812A087A4E32A8AF338C6D33D, 0xE15A22FF4F55E9B29367066553AB067E0913A4900D0057AF6A156C0C556D1B6002F91818820DECBCC566A79DC4EEAECCF37B16612F81AFFA0CBA813246F36C5A183FF71C3500E2EBF25ECCBD7DA3FF70550854FAF6E9FD86314CAE002A305D988B027EFDBD990EA9C0CBED771039BC7C77A66366AD63D98872215B72C62240E3, CAST(N'2021-03-31' AS Date), NULL, 1, 1)
SET IDENTITY_INSERT [dbo].[Students] OFF
SET IDENTITY_INSERT [dbo].[SubjectForClass] ON 

INSERT [dbo].[SubjectForClass] ([Id], [SubjectName], [SubjectId], [ClassId], [CreatedDate], [UpdateDate], [FileName], [VirtualPath], [ClassName]) VALUES (1, N'Bangla', 1, 1, CAST(N'2021-03-24' AS Date), NULL, N'a690edbf-465e-44e1-9989-8617f342941c_0a641b4f-33c3-4b81-8995-6faaaca606cf.3792f93a2c3075c55c1d61556ebb4986.jpeg', N'\imgs\Subject\a690edbf-465e-44e1-9989-8617f342941c_0a641b4f-33c3-4b81-8995-6faaaca606cf.3792f93a2c3075c55c1d61556ebb4986.jpeg', N'One')
INSERT [dbo].[SubjectForClass] ([Id], [SubjectName], [SubjectId], [ClassId], [CreatedDate], [UpdateDate], [FileName], [VirtualPath], [ClassName]) VALUES (2, N'English', 2, 1, CAST(N'2021-03-24' AS Date), NULL, N'42ea237e-1429-4c95-922e-5b076319cc6d_0a641b4f-33c3-4b81-8995-6faaaca606cf.3792f93a2c3075c55c1d61556ebb4986.jpeg', N'\imgs\Subject\42ea237e-1429-4c95-922e-5b076319cc6d_0a641b4f-33c3-4b81-8995-6faaaca606cf.3792f93a2c3075c55c1d61556ebb4986.jpeg', N'One')
INSERT [dbo].[SubjectForClass] ([Id], [SubjectName], [SubjectId], [ClassId], [CreatedDate], [UpdateDate], [FileName], [VirtualPath], [ClassName]) VALUES (3, N'English', 2, 2, CAST(N'2021-03-24' AS Date), NULL, N'bad93238-d410-4673-8a01-8541330d1d58_0a641b4f-33c3-4b81-8995-6faaaca606cf.3792f93a2c3075c55c1d61556ebb4986.jpeg', N'\imgs\Subject\bad93238-d410-4673-8a01-8541330d1d58_0a641b4f-33c3-4b81-8995-6faaaca606cf.3792f93a2c3075c55c1d61556ebb4986.jpeg', N'Two')
INSERT [dbo].[SubjectForClass] ([Id], [SubjectName], [SubjectId], [ClassId], [CreatedDate], [UpdateDate], [FileName], [VirtualPath], [ClassName]) VALUES (4, N'English', 2, 3, CAST(N'2021-03-24' AS Date), NULL, N'a176dd79-9bbf-4a5a-9aab-eba3ed4a1922_0a641b4f-33c3-4b81-8995-6faaaca606cf.3792f93a2c3075c55c1d61556ebb4986.jpeg', N'\imgs\Subject\a176dd79-9bbf-4a5a-9aab-eba3ed4a1922_0a641b4f-33c3-4b81-8995-6faaaca606cf.3792f93a2c3075c55c1d61556ebb4986.jpeg', N'Three')
INSERT [dbo].[SubjectForClass] ([Id], [SubjectName], [SubjectId], [ClassId], [CreatedDate], [UpdateDate], [FileName], [VirtualPath], [ClassName]) VALUES (7, N'Biology', 5, 4, CAST(N'2021-04-03' AS Date), NULL, N'1f4b2e64-d4d5-42a9-b64b-8ef9d7093dd4_17477705.jpg', N'\imgs\Subject\1f4b2e64-d4d5-42a9-b64b-8ef9d7093dd4_17477705.jpg', N'Four')
INSERT [dbo].[SubjectForClass] ([Id], [SubjectName], [SubjectId], [ClassId], [CreatedDate], [UpdateDate], [FileName], [VirtualPath], [ClassName]) VALUES (8, N'Bangla', 1, 2, CAST(N'2021-04-03' AS Date), NULL, N'1a23d276-172f-43d2-8e5d-a97f05a273f2_17477705.jpg', N'\imgs\Subject\1a23d276-172f-43d2-8e5d-a97f05a273f2_17477705.jpg', N'Two')
SET IDENTITY_INSERT [dbo].[SubjectForClass] OFF
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([Id], [Name], [CreatedDate], [UpdateDate]) VALUES (1, N'Bangla', NULL, NULL)
INSERT [dbo].[Subjects] ([Id], [Name], [CreatedDate], [UpdateDate]) VALUES (2, N'English', NULL, NULL)
INSERT [dbo].[Subjects] ([Id], [Name], [CreatedDate], [UpdateDate]) VALUES (5, N'Biology', CAST(N'2021-03-23' AS Date), CAST(N'2021-04-03' AS Date))
INSERT [dbo].[Subjects] ([Id], [Name], [CreatedDate], [UpdateDate]) VALUES (6, N'Math', CAST(N'2021-03-23' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Subjects] OFF
SET IDENTITY_INSERT [dbo].[Topics] ON 

INSERT [dbo].[Topics] ([Id], [Name], [ChapterName], [ChapterId], [CreatedDate], [UpdateDate], [SubjctName], [ClassName], [SubjectIdInClass], [ClassId]) VALUES (1, N'force', N'amader gram', 1, CAST(N'2021-03-24' AS Date), NULL, N'Bangla', N'One', 1, 1)
INSERT [dbo].[Topics] ([Id], [Name], [ChapterName], [ChapterId], [CreatedDate], [UpdateDate], [SubjctName], [ClassName], [SubjectIdInClass], [ClassId]) VALUES (2, N'Gravity', N'Bhuter bari', 2, CAST(N'2021-04-03' AS Date), CAST(N'2021-04-03' AS Date), N'Bangla', N'Two', 8, 2)
SET IDENTITY_INSERT [dbo].[Topics] OFF
SET IDENTITY_INSERT [dbo].[Videos] ON 

INSERT [dbo].[Videos] ([Id], [Url], [Isfree], [CreatedDate], [UpdateDate], [ClassName], [SubjectForClassId], [SubjectName], [ChapterId], [ChapterName], [TopicName], [TopicId], [ClassId], [PublicId]) VALUES (4, N'http://res.cloudinary.com/dpibyu75k/video/upload/v1617370031/rc8tsk3zpnjwl6nbkip7.mkv', 1, CAST(N'2021-04-02' AS Date), NULL, N'One', 1, N'Bangla', 1, N'amader gram', N'force', 1, 1, N'rc8tsk3zpnjwl6nbkip7')
INSERT [dbo].[Videos] ([Id], [Url], [Isfree], [CreatedDate], [UpdateDate], [ClassName], [SubjectForClassId], [SubjectName], [ChapterId], [ChapterName], [TopicName], [TopicId], [ClassId], [PublicId]) VALUES (5, N'http://res.cloudinary.com/dpibyu75k/video/upload/v1617375295/hcvbbv0jb2j3v62wgsrc.mkv', 1, CAST(N'2021-04-02' AS Date), NULL, N'One', 1, N'Bangla', 1, N'amader gram', N'force', 1, 1, N'hcvbbv0jb2j3v62wgsrc')
SET IDENTITY_INSERT [dbo].[Videos] OFF
/****** Object:  Index [IX_Chapters_SubjectForSyllabusId]    Script Date: 04-Apr-21 12:50:13 AM ******/
CREATE NONCLUSTERED INDEX [IX_Chapters_SubjectForSyllabusId] ON [dbo].[Chapters]
(
	[SubjectForClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GetSubjectForSyllabus_SubjectId]    Script Date: 04-Apr-21 12:50:13 AM ******/
CREATE NONCLUSTERED INDEX [IX_GetSubjectForSyllabus_SubjectId] ON [dbo].[SubjectForClass]
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GetSubjectForSyllabus_SyllabusId]    Script Date: 04-Apr-21 12:50:13 AM ******/
CREATE NONCLUSTERED INDEX [IX_GetSubjectForSyllabus_SyllabusId] ON [dbo].[SubjectForClass]
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Topics_ChapterId]    Script Date: 04-Apr-21 12:50:13 AM ******/
CREATE NONCLUSTERED INDEX [IX_Topics_ChapterId] ON [dbo].[Topics]
(
	[ChapterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Videos_TopicId]    Script Date: 04-Apr-21 12:50:13 AM ******/
CREATE NONCLUSTERED INDEX [IX_Videos_TopicId] ON [dbo].[Videos]
(
	[TopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Admins]  WITH CHECK ADD  CONSTRAINT [FK_Admins_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Admins] CHECK CONSTRAINT [FK_Admins_Role]
GO
ALTER TABLE [dbo].[Chapters]  WITH CHECK ADD  CONSTRAINT [FK_Chapters_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([Id])
GO
ALTER TABLE [dbo].[Chapters] CHECK CONSTRAINT [FK_Chapters_Class]
GO
ALTER TABLE [dbo].[Chapters]  WITH CHECK ADD  CONSTRAINT [FK_Chapters_SubjectForClass] FOREIGN KEY([SubjectForClassId])
REFERENCES [dbo].[SubjectForClass] ([Id])
GO
ALTER TABLE [dbo].[Chapters] CHECK CONSTRAINT [FK_Chapters_SubjectForClass]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Class]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Role]
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
ALTER TABLE [dbo].[Topics]  WITH CHECK ADD  CONSTRAINT [FK_Topics_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([Id])
GO
ALTER TABLE [dbo].[Topics] CHECK CONSTRAINT [FK_Topics_Class]
GO
ALTER TABLE [dbo].[Topics]  WITH CHECK ADD  CONSTRAINT [FK_Topics_SubjectForClass] FOREIGN KEY([SubjectIdInClass])
REFERENCES [dbo].[SubjectForClass] ([Id])
GO
ALTER TABLE [dbo].[Topics] CHECK CONSTRAINT [FK_Topics_SubjectForClass]
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
