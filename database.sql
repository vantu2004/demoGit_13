USE [master]
GO
/****** Object:  Database [DeTai_02]    Script Date: 13/05/2024 10:06:33 SA ******/
CREATE DATABASE [DeTai_02]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DeTai_02', FILENAME = N'C:\Users\tulev\DeTai_02.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DeTai_02_log', FILENAME = N'C:\Users\tulev\DeTai_02_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DeTai_02] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DeTai_02].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DeTai_02] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DeTai_02] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DeTai_02] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DeTai_02] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DeTai_02] SET ARITHABORT OFF 
GO
ALTER DATABASE [DeTai_02] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DeTai_02] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DeTai_02] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DeTai_02] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DeTai_02] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DeTai_02] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DeTai_02] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DeTai_02] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DeTai_02] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DeTai_02] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DeTai_02] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DeTai_02] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DeTai_02] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DeTai_02] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DeTai_02] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DeTai_02] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DeTai_02] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DeTai_02] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DeTai_02] SET  MULTI_USER 
GO
ALTER DATABASE [DeTai_02] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DeTai_02] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DeTai_02] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DeTai_02] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DeTai_02] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DeTai_02] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DeTai_02] SET QUERY_STORE = OFF
GO
USE [DeTai_02]
GO
/****** Object:  Table [dbo].[Applications]    Script Date: 13/05/2024 10:06:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applications](
	[IdCompany] [varchar](50) NOT NULL,
	[IdJobPostings] [varchar](50) NOT NULL,
	[IdCandidate] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompany] ASC,
	[IdJobPostings] ASC,
	[IdCandidate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CVs]    Script Date: 13/05/2024 10:06:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CVs](
	[Id] [varchar](50) NOT NULL,
	[Avatar] [varchar](500) NULL,
	[JobPos] [nvarchar](62) NULL,
	[CareerGoal] [text] NULL,
	[Education] [text] NULL,
	[Experience] [text] NULL,
	[Activity] [text] NULL,
	[Award] [text] NULL,
	[Certificate] [text] NULL,
	[UploadDate] [varchar](50) NULL,
 CONSTRAINT [PK_CVs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DinhDang_rtbx_NTD]    Script Date: 13/05/2024 10:06:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DinhDang_rtbx_NTD](
	[IdCompany] [varchar](50) NOT NULL,
	[IdJobPostings] [varchar](50) NOT NULL,
	[RtbxStyle] [varchar](100) NOT NULL,
	[Color] [varchar](100) NULL,
	[Font] [varchar](100) NULL,
	[FontStyle] [varchar](100) NULL,
	[Size] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompany] ASC,
	[IdJobPostings] ASC,
	[RtbxStyle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DinhDang_rtbx_UV]    Script Date: 13/05/2024 10:06:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DinhDang_rtbx_UV](
	[Id] [varchar](50) NOT NULL,
	[RtbxStyle] [varchar](100) NOT NULL,
	[Color] [varchar](100) NULL,
	[Font] [varchar](100) NULL,
	[FontStyle] [varchar](100) NULL,
	[Size] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[RtbxStyle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobPostings]    Script Date: 13/05/2024 10:06:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobPostings](
	[IdCompany] [varchar](50) NOT NULL,
	[IdJobPostings] [varchar](50) NOT NULL,
	[IconCompany] [varchar](500) NULL,
	[Job] [nvarchar](30) NULL,
	[JobName] [nvarchar](62) NULL,
	[Salary] [decimal](10, 2) NULL,
	[Experience] [nvarchar](100) NULL,
	[WorkFormat] [nvarchar](100) NULL,
	[DatePosted] [varchar](50) NULL,
	[Deadline] [varchar](50) NULL,
	[JobDescription] [ntext] NULL,
	[Requirements] [ntext] NULL,
	[Benefit] [ntext] NULL,
	[Activity] [ntext] NULL,
	[Award] [ntext] NULL,
	[License] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompany] ASC,
	[IdJobPostings] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Letter]    Script Date: 13/05/2024 10:06:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Letter](
	[IdCompany] [varchar](50) NOT NULL,
	[IdJobPostings] [varchar](50) NOT NULL,
	[IdCandidate] [varchar](50) NOT NULL,
	[Sender] [varchar](100) NOT NULL,
	[Receiver] [varchar](100) NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[Content] [text] NOT NULL,
	[DateSent] [varchar](100) NOT NULL,
	[InterviewDate] [varchar](100) NOT NULL,
	[InterViewTime] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompany] ASC,
	[IdJobPostings] ASC,
	[IdCandidate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LichPhongVan]    Script Date: 13/05/2024 10:06:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichPhongVan](
	[IdCompany] [varchar](50) NOT NULL,
	[IdJobPostings] [varchar](50) NOT NULL,
	[IdCandidate] [varchar](50) NOT NULL,
	[LinkAvatar] [varchar](200) NULL,
	[UpdateDate] [varchar](100) NULL,
	[InterviewDate] [varchar](100) NULL,
	[InterviewTime] [varchar](100) NULL,
	[JobName] [varchar](100) NULL,
	[CandidateName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompany] ASC,
	[IdJobPostings] ASC,
	[IdCandidate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LuuCV]    Script Date: 13/05/2024 10:06:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LuuCV](
	[IdCompany] [varchar](50) NOT NULL,
	[IdJobPostings] [varchar](50) NOT NULL,
	[IdCandidate] [varchar](50) NOT NULL,
	[Follow] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompany] ASC,
	[IdJobPostings] ASC,
	[IdCandidate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LuuTin]    Script Date: 13/05/2024 10:06:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LuuTin](
	[IdCompany] [varchar](50) NOT NULL,
	[IdJobPostings] [varchar](50) NOT NULL,
	[IdCandidate] [varchar](50) NOT NULL,
	[Follow] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompany] ASC,
	[IdJobPostings] ASC,
	[IdCandidate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHATUYENDUNG]    Script Date: 13/05/2024 10:06:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHATUYENDUNG](
	[Id] [varchar](50) NOT NULL,
	[UserType] [varchar](50) NOT NULL,
	[Fname] [nvarchar](62) NOT NULL,
	[Email] [nvarchar](62) NOT NULL,
	[PhoneNTD] [nvarchar](12) NOT NULL,
	[JobPos] [nvarchar](62) NOT NULL,
	[Company] [nvarchar](62) NOT NULL,
	[JobLocation] [varchar](100) NOT NULL,
	[SocialNetwork] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 13/05/2024 10:06:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[Id] [varchar](50) NOT NULL,
	[UserType] [varchar](50) NOT NULL,
	[UserName] [varchar](32) NOT NULL,
	[UserPassword] [varchar](32) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TinNhan]    Script Date: 13/05/2024 10:06:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinNhan](
	[IdCandidate] [varchar](50) NOT NULL,
	[DatePosted_up] [varchar](50) NOT NULL,
	[DateSent] [varchar](50) NOT NULL,
	[Avatar] [varchar](200) NULL,
	[Name] [varchar](500) NULL,
	[Content] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[DateSent] ASC,
	[DatePosted_up] ASC,
	[IdCandidate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TinXinViec]    Script Date: 13/05/2024 10:06:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinXinViec](
	[Id] [varchar](50) NOT NULL,
	[DatePosted] [varchar](50) NOT NULL,
	[Avatar] [varchar](200) NULL,
	[Name] [varchar](500) NULL,
	[Content] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[DatePosted] ASC,
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UNGVIEN]    Script Date: 13/05/2024 10:06:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UNGVIEN](
	[Id] [varchar](50) NOT NULL,
	[UserType] [varchar](50) NOT NULL,
	[Fname] [nvarchar](100) NOT NULL,
	[Phone] [varchar](12) NOT NULL,
	[BirthDate] [varchar](50) NOT NULL,
	[Link] [varchar](100) NOT NULL,
	[Email] [nvarchar](62) NOT NULL,
	[Address_C] [nvarchar](100) NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'0ce8682c-2145-4ae0-acd1-3ae717affd3e', N'1b21d928-f685-40b3-bd9a-1c34a932166b')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'0ce8682c-2145-4ae0-acd1-3ae717affd3e', N'442fd9cd-d1d8-482e-a53b-e51aa03bc6db')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'0ce8682c-2145-4ae0-acd1-3ae717affd3e', N'ca63e213-96fc-4499-a8db-985e65be9753')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'274ec4eb-4c9d-4be9-bb86-1da84162115c', N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'274ec4eb-4c9d-4be9-bb86-1da84162115c', N'1b21d928-f685-40b3-bd9a-1c34a932166b')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'274ec4eb-4c9d-4be9-bb86-1da84162115c', N'ca63e213-96fc-4499-a8db-985e65be9753')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'9508768a-317b-4391-93ec-6f2ebb0dddae', N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'9508768a-317b-4391-93ec-6f2ebb0dddae', N'1b21d928-f685-40b3-bd9a-1c34a932166b')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'9508768a-317b-4391-93ec-6f2ebb0dddae', N'442fd9cd-d1d8-482e-a53b-e51aa03bc6db')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'9508768a-317b-4391-93ec-6f2ebb0dddae', N'ca63e213-96fc-4499-a8db-985e65be9753')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'c589ae0f-a373-4e71-ac23-358ec1495458', N'ca63e213-96fc-4499-a8db-985e65be9753')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'1762e7e1-5b1e-479f-a9e5-c3b762e78891', N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'1762e7e1-5b1e-479f-a9e5-c3b762e78891', N'442fd9cd-d1d8-482e-a53b-e51aa03bc6db')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'1762e7e1-5b1e-479f-a9e5-c3b762e78891', N'ca63e213-96fc-4499-a8db-985e65be9753')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'8c71ba3a-d6f7-497c-ad6e-1ff58c9d1cb4', N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'8c71ba3a-d6f7-497c-ad6e-1ff58c9d1cb4', N'1b21d928-f685-40b3-bd9a-1c34a932166b')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'8c71ba3a-d6f7-497c-ad6e-1ff58c9d1cb4', N'442fd9cd-d1d8-482e-a53b-e51aa03bc6db')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'8c71ba3a-d6f7-497c-ad6e-1ff58c9d1cb4', N'ca63e213-96fc-4499-a8db-985e65be9753')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'9c61a560-7e10-4056-9d98-06d12904f576', N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'ad462998-2353-45b2-a822-05ce005beeea', N'1b21d928-f685-40b3-bd9a-1c34a932166b')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'ad462998-2353-45b2-a822-05ce005beeea', N'ca63e213-96fc-4499-a8db-985e65be9753')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'eb4c38ce-5171-4a9b-ae81-b2c3eb879c78', N'1b21d928-f685-40b3-bd9a-1c34a932166b')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'dfd1de16-df05-4c7a-963f-c7278b0be15f', N'dd540c79-3140-4201-a566-4e4033986868', N'1b21d928-f685-40b3-bd9a-1c34a932166b')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'dfd1de16-df05-4c7a-963f-c7278b0be15f', N'dd540c79-3140-4201-a566-4e4033986868', N'ca63e213-96fc-4499-a8db-985e65be9753')
INSERT [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate]) VALUES (N'dfd1de16-df05-4c7a-963f-c7278b0be15f', N'e8c692b6-faec-43d5-85f8-2b2ee3650ffa', N'ca63e213-96fc-4499-a8db-985e65be9753')
GO
INSERT [dbo].[CVs] ([Id], [Avatar], [JobPos], [CareerGoal], [Education], [Experience], [Activity], [Award], [Certificate], [UploadDate]) VALUES (N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154334.png', N'Employee', N'Seeking a challenging role in [field/industry] where I can utilize my skills and knowledge to contribute effectively to the growth and success of the organization.
', N'- [University]
- [Job Title], [Company Name], [Dates]
Responsibilities included [brief description of duties]
- [Job Title], [Company Name], [Dates]
Achievements in [mention any notable accomplishments]
', N'[Job Title], [Company Name], [Dates]
- Achievements:
   + Implemented [strategy/tool] resulting in [quantifiable result].
   + Received recognition for [specific accomplishment].

[Job Title], [Company Name], [Dates]
- Responsibilities:
   + Developed [specific skill] to streamline [process/task].
   + Collaborated with team to achieve [specific goal].
', N'Volunteer, [Organization/Event], [Dates]
- Responsibilities:
  + Organized [event/task] leading to [impact/outcome].
  + Member, [Club/Association], [Dates]
- Activities:
  + Participated in [activity/event] contributing to [group goal].
', N'- [Name of Award], [Year], [Awarding Organization]
Recognized for [specific achievement or contribution].
- [Name of Award], [Year], [Awarding Organization]
Received for [specific accomplishment or project].
', N'- [Certification Name], [Issuing Organization], [Year]
Demonstrates proficiency in [specific skill or area].
- [Certification Name], [Issuing Organization], [Year]
Validates expertise in [specific domain or tool].
', N'09/05/2024')
INSERT [dbo].[CVs] ([Id], [Avatar], [JobPos], [CareerGoal], [Education], [Experience], [Activity], [Award], [Certificate], [UploadDate]) VALUES (N'1b21d928-f685-40b3-bd9a-1c34a932166b', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154328.png', N'Employee', N'Seeking a challenging role in [field/industry] where I can utilize my skills and knowledge to contribute effectively to the growth and success of the organization.
', N'- [University]
- [Job Title], [Company Name], [Dates]
Responsibilities included [brief description of duties]
- [Job Title], [Company Name], [Dates]
Achievements in [mention any notable accomplishments]
', N'[Job Title], [Company Name], [Dates]
- Responsibilities:
   + Developed [specific skill] to streamline [process/task].
   + Collaborated with team to achieve [specific goal].

[Job Title], [Company Name], [Dates]
- Achievements:
   + Implemented [strategy/tool] resulting in [quantifiable result].
   + Received recognition for [specific accomplishment].
', N'Volunteer, [Organization/Event], [Dates]
- Responsibilities:
  + Organized [event/task] leading to [impact/outcome].
  + Member, [Club/Association], [Dates]
- Activities:
  + Participated in [activity/event] contributing to [group goal].
', N'- [Name of Award], [Year], [Awarding Organization]
Recognized for [specific achievement or contribution].
- [Name of Award], [Year], [Awarding Organization]
Received for [specific accomplishment or project].
', N'- [Certification Name], [Issuing Organization], [Year]
Demonstrates proficiency in [specific skill or area].
- [Certification Name], [Issuing Organization], [Year]
Validates expertise in [specific domain or tool].
', N'09/05/2024')
INSERT [dbo].[CVs] ([Id], [Avatar], [JobPos], [CareerGoal], [Education], [Experience], [Activity], [Award], [Certificate], [UploadDate]) VALUES (N'442fd9cd-d1d8-482e-a53b-e51aa03bc6db', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154321.png', N'Employee', N'Seeking a challenging role in [field/industry] where I can utilize my skills and knowledge to contribute effectively to the growth and success of the organization.
', N'- [University]
- [Job Title], [Company Name], [Dates]
Responsibilities included [brief description of duties]
- [Job Title], [Company Name], [Dates]
Achievements in [mention any notable accomplishments]
', N'[Job Title], [Company Name], [Dates]
- Achievements:
   + Implemented [strategy/tool] resulting in [quantifiable result].
   + Received recognition for [specific accomplishment].

[Job Title], [Company Name], [Dates]
- Responsibilities:
   + Developed [specific skill] to streamline [process/task].
   + Collaborated with team to achieve [specific goal].
', N'Volunteer, [Organization/Event], [Dates]
- Responsibilities:
  + Organized [event/task] leading to [impact/outcome].
  + Member, [Club/Association], [Dates]
- Activities:
  + Participated in [activity/event] contributing to [group goal].
', N'- [Name of Award], [Year], [Awarding Organization]
Recognized for [specific achievement or contribution].
- [Name of Award], [Year], [Awarding Organization]
Received for [specific accomplishment or project].
', N'- [Certification Name], [Issuing Organization], [Year]
Demonstrates proficiency in [specific skill or area].
- [Certification Name], [Issuing Organization], [Year]
Validates expertise in [specific domain or tool].
', N'09/05/2024')
INSERT [dbo].[CVs] ([Id], [Avatar], [JobPos], [CareerGoal], [Education], [Experience], [Activity], [Award], [Certificate], [UploadDate]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'Employee', N'Seeking a challenging role in [field/industry] where I can utilize my skills and knowledge to contribute effectively to the growth and success of the organization.
', N'- [University]
- [Job Title], [Company Name], [Dates]
Responsibilities included [brief description of duties]
- [Job Title], [Company Name], [Dates]
Achievements in [mention any notable accomplishments]
', N'[Job Title], [Company Name], [Dates]
- Responsibilities:
   + Developed [specific skill] to streamline [process/task].
   + Collaborated with team to achieve [specific goal].

[Job Title], [Company Name], [Dates]
- Achievements:
   + Implemented [strategy/tool] resulting in [quantifiable result].
   + Received recognition for [specific accomplishment].

[Job Title], [Company Name], [Dates]
- Achievements:
   + Implemented [strategy/tool] resulting in [quantifiable result].
   + Received recognition for [specific accomplishment].
', N'Volunteer, [Organization/Event], [Dates]
- Responsibilities:
  + Organized [event/task] leading to [impact/outcome].
  + Member, [Club/Association], [Dates]
- Activities:
  + Participated in [activity/event] contributing to [group goal].
', N'- [Name of Award], [Year], [Awarding Organization]
Recognized for [specific achievement or contribution].
- [Name of Award], [Year], [Awarding Organization]
Received for [specific accomplishment or project].
', N'- [Certification Name], [Issuing Organization], [Year]
Demonstrates proficiency in [specific skill or area].
- [Certification Name], [Issuing Organization], [Year]
Validates expertise in [specific domain or tool].
', N'10/05/2024')
GO
INSERT [dbo].[DinhDang_rtbx_NTD] ([IdCompany], [IdJobPostings], [RtbxStyle], [Color], [Font], [FontStyle], [Size]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'ad462998-2353-45b2-a822-05ce005beeea', N'rtbx_moTaCongViec', N'Black', N'Segoe UI', N'Italic', CAST(12.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[DinhDang_rtbx_UV] ([Id], [RtbxStyle], [Color], [Font], [FontStyle], [Size]) VALUES (N'442fd9cd-d1d8-482e-a53b-e51aa03bc6db', N'rtbx_mucTieuNgheNghiep', N'Black', N'Segoe UI', N'Bold', CAST(12.00 AS Decimal(10, 2)))
INSERT [dbo].[DinhDang_rtbx_UV] ([Id], [RtbxStyle], [Color], [Font], [FontStyle], [Size]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'rtbx_chungChi', N'Black', N'Segoe UI', N'Regular', CAST(12.00 AS Decimal(10, 2)))
INSERT [dbo].[DinhDang_rtbx_UV] ([Id], [RtbxStyle], [Color], [Font], [FontStyle], [Size]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'rtbx_giaiThuong', N'Black', N'Segoe UI', N'Italic', CAST(12.00 AS Decimal(10, 2)))
INSERT [dbo].[DinhDang_rtbx_UV] ([Id], [RtbxStyle], [Color], [Font], [FontStyle], [Size]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'rtbx_hocVan', N'Black', N'Segoe UI', N'Italic', CAST(12.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[JobPostings] ([IdCompany], [IdJobPostings], [IconCompany], [Job], [JobName], [Salary], [Experience], [WorkFormat], [DatePosted], [Deadline], [JobDescription], [Requirements], [Benefit], [Activity], [Award], [License]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'0ce8682c-2145-4ae0-acd1-3ae717affd3e', N'C:\Users\tulev\OneDrive\Pictures\logo\853a8699e57f3f9810354cd2d4a93ac1.jpg', N'Information Technology (IT)', N'DATA ENGINEER', CAST(21000000.00 AS Decimal(10, 2)), N'2y - 3y', N'Direct', N'09/05/2024', N'07/05/2024', N'Be part of our innovative team! 
- We are hiring passionate individuals for diverse roles, from marketing to software development. 
- Contribute your unique skills to dynamic projects and drive our companys growth.
', N'- Seeking motivated candidates with a can-do attitude. 
- While experience is valued, we prioritize enthusiasm and a willingness to learn. 
- Strong communication and teamwork skills are essential for success in our collaborative environment.
', N'- Enjoy competitive salaries, comprehensive benefits, and opportunities for advancement. 
- We foster a supportive culture that promotes work-life balance and professional development. 
- Your contributions are recognized and rewarded.
', N'-Engage in exciting projects and participate in team-building activities. 
- Take advantage of skill-enhancement workshops and networking events to grow professionally. 
- Join a vibrant community of like-minded individuals committed to excellence.
', N'Unlock recognition and rewards for your hard work. Standout performers have the opportunity to receive bonuses, promotions, and other incentives. Join us and strive for excellence with the promise of meaningful recognition.
', N'C:\Users\tulev\OneDrive\Pictures\logo\GIAY-PHEP-DKKD_001.jpg')
INSERT [dbo].[JobPostings] ([IdCompany], [IdJobPostings], [IconCompany], [Job], [JobName], [Salary], [Experience], [WorkFormat], [DatePosted], [Deadline], [JobDescription], [Requirements], [Benefit], [Activity], [Award], [License]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'274ec4eb-4c9d-4be9-bb86-1da84162115c', N'C:\Users\tulev\OneDrive\Pictures\logo\0de93b31d1fe2861d3e2b56a74aefa46.jpg', N'Medicine', N'DOCTOR', CAST(30000000.00 AS Decimal(10, 2)), N'> 3y', N'Direct', N'09/05/2024', N'20/05/2024', N'Be part of our innovative team! 
- We are hiring passionate individuals for diverse roles, from marketing to software development. 
- Contribute your unique skills to dynamic projects and drive our companys growth.
', N'- Seeking motivated candidates with a can-do attitude. 
- While experience is valued, we prioritize enthusiasm and a willingness to learn. 
- Strong communication and teamwork skills are essential for success in our collaborative environment.
', N'- Enjoy competitive salaries, comprehensive benefits, and opportunities for advancement. 
- We foster a supportive culture that promotes work-life balance and professional development. 
- Your contributions are recognized and rewarded.
', N'-Engage in exciting projects and participate in team-building activities. 
- Take advantage of skill-enhancement workshops and networking events to grow professionally. 
- Join a vibrant community of like-minded individuals committed to excellence.
', N'Unlock recognition and rewards for your hard work. Standout performers have the opportunity to receive bonuses, promotions, and other incentives. Join us and strive for excellence with the promise of meaningful recognition.
', N'C:\Users\tulev\OneDrive\Pictures\logo\GIAY-PHEP-DKKD_001.jpg')
INSERT [dbo].[JobPostings] ([IdCompany], [IdJobPostings], [IconCompany], [Job], [JobName], [Salary], [Experience], [WorkFormat], [DatePosted], [Deadline], [JobDescription], [Requirements], [Benefit], [Activity], [Award], [License]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'9508768a-317b-4391-93ec-6f2ebb0dddae', N'C:\Users\tulev\OneDrive\Pictures\logo\f5c5b242fd4176e60968df0003ceb38e.jpg', N'Information Technology (IT)', N'BA', CAST(11000000.00 AS Decimal(10, 2)), N'1y - 2y', N'Remote', N'09/05/2024', N'14/05/2024', N'Be part of our innovative team! 
- We are hiring passionate individuals for diverse roles, from marketing to software development. 
- Contribute your unique skills to dynamic projects and drive our companys growth.
', N'- Seeking motivated candidates with a can-do attitude. 
- While experience is valued, we prioritize enthusiasm and a willingness to learn. 
- Strong communication and teamwork skills are essential for success in our collaborative environment.
', N'- Enjoy competitive salaries, comprehensive benefits, and opportunities for advancement. 
- We foster a supportive culture that promotes work-life balance and professional development. 
- Your contributions are recognized and rewarded.
', N'-Engage in exciting projects and participate in team-building activities. 
- Take advantage of skill-enhancement workshops and networking events to grow professionally. 
- Join a vibrant community of like-minded individuals committed to excellence.
', N'Unlock recognition and rewards for your hard work. Standout performers have the opportunity to receive bonuses, promotions, and other incentives. Join us and strive for excellence with the promise of meaningful recognition.
', N'C:\Users\tulev\OneDrive\Pictures\logo\GIAY-PHEP-DKKD_001.jpg')
INSERT [dbo].[JobPostings] ([IdCompany], [IdJobPostings], [IconCompany], [Job], [JobName], [Salary], [Experience], [WorkFormat], [DatePosted], [Deadline], [JobDescription], [Requirements], [Benefit], [Activity], [Award], [License]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'c589ae0f-a373-4e71-ac23-358ec1495458', N'C:\Users\tulev\OneDrive\Pictures\logo\803a6a23e1fc1663cd64132dba8bda43.jpg', N'Information Technology (IT)', N'FULL STACK', CAST(21000000.00 AS Decimal(10, 2)), N'2y - 3y', N'Remote', N'09/05/2024', N'18/05/2024', N'Be part of our innovative team! 
- We are hiring passionate individuals for diverse roles, from marketing to software development. 
- Contribute your unique skills to dynamic projects and drive our companys growth.
', N'- Seeking motivated candidates with a can-do attitude. 
- While experience is valued, we prioritize enthusiasm and a willingness to learn. 
- Strong communication and teamwork skills are essential for success in our collaborative environment.
', N'- Enjoy competitive salaries, comprehensive benefits, and opportunities for advancement. 
- We foster a supportive culture that promotes work-life balance and professional development. 
- Your contributions are recognized and rewarded.
', N'-Engage in exciting projects and participate in team-building activities. 
- Take advantage of skill-enhancement workshops and networking events to grow professionally. 
- Join a vibrant community of like-minded individuals committed to excellence.
', N'Unlock recognition and rewards for your hard work. Standout performers have the opportunity to receive bonuses, promotions, and other incentives. Join us and strive for excellence with the promise of meaningful recognition.
', N'C:\Users\tulev\OneDrive\Pictures\logo\GIAY-PHEP-DKKD_001.jpg')
INSERT [dbo].[JobPostings] ([IdCompany], [IdJobPostings], [IconCompany], [Job], [JobName], [Salary], [Experience], [WorkFormat], [DatePosted], [Deadline], [JobDescription], [Requirements], [Benefit], [Activity], [Award], [License]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'1762e7e1-5b1e-479f-a9e5-c3b762e78891', N'C:\Users\tulev\OneDrive\Pictures\logo\8a61f0a05dc671c8ffedd767de656170.jpg', N'Information Technology (IT)', N'BACK END', CAST(12000000.00 AS Decimal(10, 2)), N'2y - 3y', N'Remote', N'09/05/2024', N'01/05/2024', N'Be part of our innovative team! 
- We are hiring passionate individuals for diverse roles, from marketing to software development. 
- Contribute your unique skills to dynamic projects and drive our companys growth.
', N'- Seeking motivated candidates with a can-do attitude. 
- While experience is valued, we prioritize enthusiasm and a willingness to learn. 
- Strong communication and teamwork skills are essential for success in our collaborative environment.
', N'- Enjoy competitive salaries, comprehensive benefits, and opportunities for advancement. 
- We foster a supportive culture that promotes work-life balance and professional development. 
- Your contributions are recognized and rewarded.
', N'-Engage in exciting projects and participate in team-building activities. 
- Take advantage of skill-enhancement workshops and networking events to grow professionally. 
- Join a vibrant community of like-minded individuals committed to excellence.
', N'Unlock recognition and rewards for your hard work. Standout performers have the opportunity to receive bonuses, promotions, and other incentives. Join us and strive for excellence with the promise of meaningful recognition.
', N'C:\Users\tulev\OneDrive\Pictures\logo\GIAY-PHEP-DKKD_001.jpg')
INSERT [dbo].[JobPostings] ([IdCompany], [IdJobPostings], [IconCompany], [Job], [JobName], [Salary], [Experience], [WorkFormat], [DatePosted], [Deadline], [JobDescription], [Requirements], [Benefit], [Activity], [Award], [License]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'8c71ba3a-d6f7-497c-ad6e-1ff58c9d1cb4', N'C:\Users\tulev\OneDrive\Pictures\logo\b4a9c107c272dc09885157183d2bfd14.jpg', N'Information Technology (IT)', N'TESTER', CAST(23000000.00 AS Decimal(10, 2)), N'> 3y', N'Direct', N'09/05/2024', N'17/05/2024', N'Be part of our innovative team! 
- We are hiring passionate individuals for diverse roles, from marketing to software development. 
- Contribute your unique skills to dynamic projects and drive our companys growth.
', N'- Seeking motivated candidates with a can-do attitude. 
- While experience is valued, we prioritize enthusiasm and a willingness to learn. 
- Strong communication and teamwork skills are essential for success in our collaborative environment.
', N'- Enjoy competitive salaries, comprehensive benefits, and opportunities for advancement. 
- We foster a supportive culture that promotes work-life balance and professional development. 
- Your contributions are recognized and rewarded.
', N'-Engage in exciting projects and participate in team-building activities. 
- Take advantage of skill-enhancement workshops and networking events to grow professionally. 
- Join a vibrant community of like-minded individuals committed to excellence.
', N'Unlock recognition and rewards for your hard work. Standout performers have the opportunity to receive bonuses, promotions, and other incentives. Join us and strive for excellence with the promise of meaningful recognition.
', N'C:\Users\tulev\OneDrive\Pictures\logo\GIAY-PHEP-DKKD_001.jpg')
INSERT [dbo].[JobPostings] ([IdCompany], [IdJobPostings], [IconCompany], [Job], [JobName], [Salary], [Experience], [WorkFormat], [DatePosted], [Deadline], [JobDescription], [Requirements], [Benefit], [Activity], [Award], [License]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'9c61a560-7e10-4056-9d98-06d12904f576', N'C:\Users\tulev\OneDrive\Pictures\logo\0de93b31d1fe2861d3e2b56a74aefa46.jpg', N'Marketing', N'SALE', CAST(9000000.00 AS Decimal(10, 2)), N'2y - 3y', N'Remote', N'09/05/2024', N'11/05/2024', N'Be part of our innovative team! 
- We are hiring passionate individuals for diverse roles, from marketing to software development. 
- Contribute your unique skills to dynamic projects and drive our companys growth.
', N'- Seeking motivated candidates with a can-do attitude. 
- While experience is valued, we prioritize enthusiasm and a willingness to learn. 
- Strong communication and teamwork skills are essential for success in our collaborative environment.
', N'- Enjoy competitive salaries, comprehensive benefits, and opportunities for advancement. 
- We foster a supportive culture that promotes work-life balance and professional development. 
- Your contributions are recognized and rewarded.
', N'-Engage in exciting projects and participate in team-building activities. 
- Take advantage of skill-enhancement workshops and networking events to grow professionally. 
- Join a vibrant community of like-minded individuals committed to excellence.
', N'Unlock recognition and rewards for your hard work. Standout performers have the opportunity to receive bonuses, promotions, and other incentives. Join us and strive for excellence with the promise of meaningful recognition.
', N'C:\Users\tulev\OneDrive\Pictures\logo\GIAY-PHEP-DKKD_001.jpg')
INSERT [dbo].[JobPostings] ([IdCompany], [IdJobPostings], [IconCompany], [Job], [JobName], [Salary], [Experience], [WorkFormat], [DatePosted], [Deadline], [JobDescription], [Requirements], [Benefit], [Activity], [Award], [License]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'ad462998-2353-45b2-a822-05ce005beeea', N'C:\Users\tulev\OneDrive\Pictures\logo\e82795ac5b77fece088b53a65f1f9736.jpg', N'Engineering', N'ARCHITECTURE', CAST(20000000.00 AS Decimal(10, 2)), N'2y - 3y', N'Direct', N'09/05/2024', N'16/05/2024', N'Be part of our innovative team! 
- We are hiring passionate individuals for diverse roles, from marketing to software development. 
- Contribute your unique skills to dynamic projects and drive our companys growth.
', N'- Seeking motivated candidates with a can-do attitude. 
- While experience is valued, we prioritize enthusiasm and a willingness to learn. 
- Strong communication and teamwork skills are essential for success in our collaborative environment.
', N'- Enjoy competitive salaries, comprehensive benefits, and opportunities for advancement. 
- We foster a supportive culture that promotes work-life balance and professional development. 
- Your contributions are recognized and rewarded.
', N'-Engage in exciting projects and participate in team-building activities. 
- Take advantage of skill-enhancement workshops and networking events to grow professionally. 
- Join a vibrant community of like-minded individuals committed to excellence.
', N'Unlock recognition and rewards for your hard work. Standout performers have the opportunity to receive bonuses, promotions, and other incentives. Join us and strive for excellence with the promise of meaningful recognition.
', N'C:\Users\tulev\OneDrive\Pictures\logo\GIAY-PHEP-DKKD_001.jpg')
INSERT [dbo].[JobPostings] ([IdCompany], [IdJobPostings], [IconCompany], [Job], [JobName], [Salary], [Experience], [WorkFormat], [DatePosted], [Deadline], [JobDescription], [Requirements], [Benefit], [Activity], [Award], [License]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'c3dcbc0d-e810-4dc9-bdc0-a0f978032351', N'C:\Users\tulev\OneDrive\Pictures\logo\8a61f0a05dc671c8ffedd767de656170.jpg', N'Law', N'JUDGE', CAST(22000000.00 AS Decimal(10, 2)), N'> 3y', N'Direct', N'09/05/2024', N'26/05/2024', N'Be part of our innovative team! 
- We are hiring passionate individuals for diverse roles, from marketing to software development. 
- Contribute your unique skills to dynamic projects and drive our companys growth.
', N'- Seeking motivated candidates with a can-do attitude. 
- While experience is valued, we prioritize enthusiasm and a willingness to learn. 
- Strong communication and teamwork skills are essential for success in our collaborative environment.
', N'- Enjoy competitive salaries, comprehensive benefits, and opportunities for advancement. 
- We foster a supportive culture that promotes work-life balance and professional development. 
- Your contributions are recognized and rewarded.
', N'-Engage in exciting projects and participate in team-building activities. 
- Take advantage of skill-enhancement workshops and networking events to grow professionally. 
- Join a vibrant community of like-minded individuals committed to excellence.
', N'Unlock recognition and rewards for your hard work. Standout performers have the opportunity to receive bonuses, promotions, and other incentives. Join us and strive for excellence with the promise of meaningful recognition.
', N'C:\Users\tulev\OneDrive\Pictures\logo\GIAY-PHEP-DKKD_001.jpg')
INSERT [dbo].[JobPostings] ([IdCompany], [IdJobPostings], [IconCompany], [Job], [JobName], [Salary], [Experience], [WorkFormat], [DatePosted], [Deadline], [JobDescription], [Requirements], [Benefit], [Activity], [Award], [License]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'eb4c38ce-5171-4a9b-ae81-b2c3eb879c78', N'C:\Users\tulev\OneDrive\Pictures\logo\49cce7df9c93ec4d44167e62ffbb9cca.jpg', N'Information Technology (IT)', N'FULL STACK', CAST(12000000.00 AS Decimal(10, 2)), N'1y - 2y', N'Direct', N'09/05/2024', N'10/05/2024', N'Be part of our innovative team! 
- We are hiring passionate individuals for diverse roles, from marketing to software development. 
- Contribute your unique skills to dynamic projects and drive our companys growth.
', N'- Seeking motivated candidates with a can-do attitude. 
- While experience is valued, we prioritize enthusiasm and a willingness to learn. 
- Strong communication and teamwork skills are essential for success in our collaborative environment.
', N'- Enjoy competitive salaries, comprehensive benefits, and opportunities for advancement. 
- We foster a supportive culture that promotes work-life balance and professional development. 
- Your contributions are recognized and rewarded.
', N'-Engage in exciting projects and participate in team-building activities. 
- Take advantage of skill-enhancement workshops and networking events to grow professionally. 
- Join a vibrant community of like-minded individuals committed to excellence.
', N'Unlock recognition and rewards for your hard work. Standout performers have the opportunity to receive bonuses, promotions, and other incentives. Join us and strive for excellence with the promise of meaningful recognition.
', N'C:\Users\tulev\OneDrive\Pictures\logo\GIAY-PHEP-DKKD_001.jpg')
INSERT [dbo].[JobPostings] ([IdCompany], [IdJobPostings], [IconCompany], [Job], [JobName], [Salary], [Experience], [WorkFormat], [DatePosted], [Deadline], [JobDescription], [Requirements], [Benefit], [Activity], [Award], [License]) VALUES (N'dfd1de16-df05-4c7a-963f-c7278b0be15f', N'4dd7ca38-319f-4ce9-ae09-9d67963b41de', N'C:\Users\tulev\OneDrive\Pictures\logo\0de93b31d1fe2861d3e2b56a74aefa46.jpg', N'Information Technology (IT)', N'FRONT END', CAST(14000000.00 AS Decimal(10, 2)), N'2y - 3y', N'Remote', N'09/05/2024', N'08/05/2024', N'Be part of our innovative team! 
- We are hiring passionate individuals for diverse roles, from marketing to software development. 
- Contribute your unique skills to dynamic projects and drive our companys growth.
', N'- Seeking motivated candidates with a can-do attitude. 
- While experience is valued, we prioritize enthusiasm and a willingness to learn. 
- Strong communication and teamwork skills are essential for success in our collaborative environment.
', N'- Enjoy competitive salaries, comprehensive benefits, and opportunities for advancement. 
- We foster a supportive culture that promotes work-life balance and professional development. 
- Your contributions are recognized and rewarded.
', N'-Engage in exciting projects and participate in team-building activities. 
- Take advantage of skill-enhancement workshops and networking events to grow professionally. 
- Join a vibrant community of like-minded individuals committed to excellence.
', N'Unlock recognition and rewards for your hard work. Standout performers have the opportunity to receive bonuses, promotions, and other incentives. Join us and strive for excellence with the promise of meaningful recognition.
', N'C:\Users\tulev\OneDrive\Pictures\logo\GIAY-PHEP-DKKD_001.jpg')
INSERT [dbo].[JobPostings] ([IdCompany], [IdJobPostings], [IconCompany], [Job], [JobName], [Salary], [Experience], [WorkFormat], [DatePosted], [Deadline], [JobDescription], [Requirements], [Benefit], [Activity], [Award], [License]) VALUES (N'dfd1de16-df05-4c7a-963f-c7278b0be15f', N'4f90e4a6-768a-4cf3-911c-d906ffa22e78', N'C:\Users\tulev\OneDrive\Pictures\logo\e82795ac5b77fece088b53a65f1f9736.jpg', N'Information Technology (IT)', N'MANAGER PROJECT', CAST(34000000.00 AS Decimal(10, 2)), N'> 3y', N'Direct', N'09/05/2024', N'15/05/2024', N'Be part of our innovative team! 
- We are hiring passionate individuals for diverse roles, from marketing to software development. 
- Contribute your unique skills to dynamic projects and drive our companys growth.
', N'- Seeking motivated candidates with a can-do attitude. 
- While experience is valued, we prioritize enthusiasm and a willingness to learn. 
- Strong communication and teamwork skills are essential for success in our collaborative environment.
', N'- Enjoy competitive salaries, comprehensive benefits, and opportunities for advancement. 
- We foster a supportive culture that promotes work-life balance and professional development. 
- Your contributions are recognized and rewarded.
', N'-Engage in exciting projects and participate in team-building activities. 
- Take advantage of skill-enhancement workshops and networking events to grow professionally. 
- Join a vibrant community of like-minded individuals committed to excellence.
', N'Unlock recognition and rewards for your hard work. Standout performers have the opportunity to receive bonuses, promotions, and other incentives. Join us and strive for excellence with the promise of meaningful recognition.
', N'C:\Users\tulev\OneDrive\Pictures\logo\GIAY-PHEP-DKKD_001.jpg')
INSERT [dbo].[JobPostings] ([IdCompany], [IdJobPostings], [IconCompany], [Job], [JobName], [Salary], [Experience], [WorkFormat], [DatePosted], [Deadline], [JobDescription], [Requirements], [Benefit], [Activity], [Award], [License]) VALUES (N'dfd1de16-df05-4c7a-963f-c7278b0be15f', N'dd540c79-3140-4201-a566-4e4033986868', N'C:\Users\tulev\OneDrive\Pictures\logo\5a9b43bff2cdf0ff202f89891d46506c.jpg', N'Finance', N'SALE', CAST(9000000.00 AS Decimal(10, 2)), N'1y - 2y', N'Direct', N'29/04/2024', N'30/04/2024', N'Be part of our innovative team! 
- We are hiring passionate individuals for diverse roles, from marketing to software development. 
- Contribute your unique skills to dynamic projects and drive our companys growth.
', N'- Seeking motivated candidates with a can-do attitude. 
- While experience is valued, we prioritize enthusiasm and a willingness to learn. 
- Strong communication and teamwork skills are essential for success in our collaborative environment.
', N'- Enjoy competitive salaries, comprehensive benefits, and opportunities for advancement. 
- We foster a supportive culture that promotes work-life balance and professional development. 
- Your contributions are recognized and rewarded.
', N'-Engage in exciting projects and participate in team-building activities. 
- Take advantage of skill-enhancement workshops and networking events to grow professionally. 
- Join a vibrant community of like-minded individuals committed to excellence.
', N'Unlock recognition and rewards for your hard work. Standout performers have the opportunity to receive bonuses, promotions, and other incentives. Join us and strive for excellence with the promise of meaningful recognition.
', N'C:\Users\tulev\OneDrive\Pictures\logo\GIAY-PHEP-DKKD_001.jpg')
INSERT [dbo].[JobPostings] ([IdCompany], [IdJobPostings], [IconCompany], [Job], [JobName], [Salary], [Experience], [WorkFormat], [DatePosted], [Deadline], [JobDescription], [Requirements], [Benefit], [Activity], [Award], [License]) VALUES (N'dfd1de16-df05-4c7a-963f-c7278b0be15f', N'e8c692b6-faec-43d5-85f8-2b2ee3650ffa', N'C:\Users\tulev\OneDrive\Pictures\logo\0de93b31d1fe2861d3e2b56a74aefa46.jpg', N'Marketing', N'MANAGER', CAST(14000000.00 AS Decimal(10, 2)), N'2y - 3y', N'Direct', N'09/05/2024', N'18/05/2024', N'Be part of our innovative team! 
- We are hiring passionate individuals for diverse roles, from marketing to software development. 
- Contribute your unique skills to dynamic projects and drive our companys growth.
', N'- Seeking motivated candidates with a can-do attitude. 
- While experience is valued, we prioritize enthusiasm and a willingness to learn. 
- Strong communication and teamwork skills are essential for success in our collaborative environment.
', N'- Enjoy competitive salaries, comprehensive benefits, and opportunities for advancement. 
- We foster a supportive culture that promotes work-life balance and professional development. 
- Your contributions are recognized and rewarded.
', N'-Engage in exciting projects and participate in team-building activities. 
- Take advantage of skill-enhancement workshops and networking events to grow professionally. 
- Join a vibrant community of like-minded individuals committed to excellence.
', N'Unlock recognition and rewards for your hard work. Standout performers have the opportunity to receive bonuses, promotions, and other incentives. Join us and strive for excellence with the promise of meaningful recognition.
', N'C:\Users\tulev\OneDrive\Pictures\logo\GIAY-PHEP-DKKD_001.jpg')
GO
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'274ec4eb-4c9d-4be9-bb86-1da84162115c', N'1b21d928-f685-40b3-bd9a-1c34a932166b', N'vanduc123@gmail.com', N'tu123@gmail.com', N'sdv', N'sdv', N'11/05/2024 2:11:00 SA', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'9508768a-317b-4391-93ec-6f2ebb0dddae', N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b', N'vanduc123@gmail.com', N'doan123@gmail.com', N'xcb', N'cxv', N'10/05/2024 3:38:35 CH', N'19/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'9508768a-317b-4391-93ec-6f2ebb0dddae', N'1b21d928-f685-40b3-bd9a-1c34a932166b', N'vanduc123@gmail.com', N'tu123@gmail.com', N'sd', N'sdv', N'10/05/2024 4:04:23 CH', N'06/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'9508768a-317b-4391-93ec-6f2ebb0dddae', N'442fd9cd-d1d8-482e-a53b-e51aa03bc6db', N'vanduc123@gmail.com', N'vantu123@gmail.com', N'sdv', N'dfb', N'10/05/2024 3:23:11 CH', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'9508768a-317b-4391-93ec-6f2ebb0dddae', N'ca63e213-96fc-4499-a8db-985e65be9753', N'vanduc123@gmail.com', N'thanhsang123@gmail.com', N'sdfg', N'sdfg', N'10/05/2024 3:23:21 CH', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'c589ae0f-a373-4e71-ac23-358ec1495458', N'ca63e213-96fc-4499-a8db-985e65be9753', N'vanduc123@gmail.com', N'thanhsang123@gmail.com', N'sdv', N'svd', N'11/05/2024 2:23:03 SA', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'1762e7e1-5b1e-479f-a9e5-c3b762e78891', N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b', N'khanh123@gmail.com', N'doan123@gmail.com', N'Congratulations! You have Been Selected for the Position', N'Dear [Candidate Name],

I am thrilled to inform you that you have been selected for the [Position Title] at [Company Name]. Congratulations!

Your qualifications, experience, and enthusiasm for the role truly stood out among the applicants, and we believe you will make a valuable addition to our team.

We would like to discuss further details regarding your start date, salary, and any other pertinent information. Please let us know your availability for a meeting or phone call at your earliest convenience.

Once again, congratulations on your successful application. We look forward to welcoming you aboard and embarking on this exciting journey together.

Warm regards,

[Your Name]
[Your Position]
[Company Name]
', N'09/05/2024 10:16:22 CH', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'1762e7e1-5b1e-479f-a9e5-c3b762e78891', N'442fd9cd-d1d8-482e-a53b-e51aa03bc6db', N'khanh123@gmail.com', N'vantu123@gmail.com', N'Congratulations! You have Been Selected for the Position', N'Dear [Candidate Name],

I am thrilled to inform you that you have been selected for the [Position Title] at [Company Name]. Congratulations!

Your qualifications, experience, and enthusiasm for the role truly stood out among the applicants, and we believe you will make a valuable addition to our team.

We would like to discuss further details regarding your start date, salary, and any other pertinent information. Please let us know your availability for a meeting or phone call at your earliest convenience.

Once again, congratulations on your successful application. We look forward to welcoming you aboard and embarking on this exciting journey together.

Warm regards,

[Your Name]
[Your Position]
[Company Name]
', N'09/05/2024 10:16:50 CH', N'07/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'1762e7e1-5b1e-479f-a9e5-c3b762e78891', N'ca63e213-96fc-4499-a8db-985e65be9753', N'khanh123@gmail.com', N'thanhsang123@gmail.com', N'Congratulations! You have Been Selected for the Position', N'Dear [Candidate Name],

I am thrilled to inform you that you have been selected for the [Position Title] at [Company Name]. Congratulations!

Your qualifications, experience, and enthusiasm for the role truly stood out among the applicants, and we believe you will make a valuable addition to our team.

We would like to discuss further details regarding your start date, salary, and any other pertinent information. Please let us know your availability for a meeting or phone call at your earliest convenience.

Once again, congratulations on your successful application. We look forward to welcoming you aboard and embarking on this exciting journey together.

Warm regards,

[Your Name]
[Your Position]
[Company Name]
', N'09/05/2024 10:17:18 CH', N'11/05/2024 12:00:00 SA', N'01/05/2024 7:30:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'81be8f6c-9cea-48a5-add2-8062d5da0ec8', N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b', N'khanh123@gmail.com', N'doan123@gmail.com', N'Congratulations! You have Been Selected for the Position', N'Dear [Candidate Name],

I am thrilled to inform you that you have been selected for the [Position Title] at [Company Name]. Congratulations!

Your qualifications, experience, and enthusiasm for the role truly stood out among the applicants, and we believe you will make a valuable addition to our team.

We would like to discuss further details regarding your start date, salary, and any other pertinent information. Please let us know your availability for a meeting or phone call at your earliest convenience.

Once again, congratulations on your successful application. We look forward to welcoming you aboard and embarking on this exciting journey together.

Warm regards,

[Your Name]
[Your Position]
[Company Name]
', N'09/05/2024 10:17:54 CH', N'12/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'81be8f6c-9cea-48a5-add2-8062d5da0ec8', N'442fd9cd-d1d8-482e-a53b-e51aa03bc6db', N'khanh123@gmail.com', N'vantu123@gmail.com', N'ác', N'ád', N'10/05/2024 2:41:44 CH', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'81be8f6c-9cea-48a5-add2-8062d5da0ec8', N'ca63e213-96fc-4499-a8db-985e65be9753', N'khanh123@gmail.com', N'thanhsang123@gmail.com', N'Congratulations! You have Been Selected for the Position', N'Dear [Candidate Name],

I am thrilled to inform you that you have been selected for the [Position Title] at [Company Name]. Congratulations!

Your qualifications, experience, and enthusiasm for the role truly stood out among the applicants, and we believe you will make a valuable addition to our team.

We would like to discuss further details regarding your start date, salary, and any other pertinent information. Please let us know your availability for a meeting or phone call at your earliest convenience.

Once again, congratulations on your successful application. We look forward to welcoming you aboard and embarking on this exciting journey together.

Warm regards,

[Your Name]
[Your Position]
[Company Name]
', N'09/05/2024 10:18:21 CH', N'25/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'8c71ba3a-d6f7-497c-ad6e-1ff58c9d1cb4', N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b', N'khanh123@gmail.com', N'doan123@gmail.com', N'ghhh', N'sdzvv', N'10/05/2024 1:24:35 CH', N'15/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'8c71ba3a-d6f7-497c-ad6e-1ff58c9d1cb4', N'1b21d928-f685-40b3-bd9a-1c34a932166b', N'khanh123@gmail.com', N'tu123@gmail.com', N'Congratulations! You have Been Selected for the Position', N'Dear [Candidate Name],

I am thrilled to inform you that you have been selected for the [Position Title] at [Company Name]. Congratulations!

Your qualifications, experience, and enthusiasm for the role truly stood out among the applicants, and we believe you will make a valuable addition to our team.

We would like to discuss further details regarding your start date, salary, and any other pertinent information. Please let us know your availability for a meeting or phone call at your earliest convenience.

Once again, congratulations on your successful application. We look forward to welcoming you aboard and embarking on this exciting journey together.

Warm regards,

[Your Name]
[Your Position]
[Company Name]
', N'09/05/2024 10:19:05 CH', N'18/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'8c71ba3a-d6f7-497c-ad6e-1ff58c9d1cb4', N'442fd9cd-d1d8-482e-a53b-e51aa03bc6db', N'khanh123@gmail.com', N'vantu123@gmail.com', N'ádassadfsd', N'sd', N'10/05/2024 2:36:42 CH', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'8c71ba3a-d6f7-497c-ad6e-1ff58c9d1cb4', N'ca63e213-96fc-4499-a8db-985e65be9753', N'khanh123@gmail.com', N'thanhsang123@gmail.com', N'Congratulations! You have Been Selected for the Position', N'Dear [Candidate Name],

I am thrilled to inform you that you have been selected for the [Position Title] at [Company Name]. Congratulations!

Your qualifications, experience, and enthusiasm for the role truly stood out among the applicants, and we believe you will make a valuable addition to our team.

We would like to discuss further details regarding your start date, salary, and any other pertinent information. Please let us know your availability for a meeting or phone call at your earliest convenience.

Once again, congratulations on your successful application. We look forward to welcoming you aboard and embarking on this exciting journey together.

Warm regards,

[Your Name]
[Your Position]
[Company Name]', N'09/05/2024 10:19:31 CH', N'02/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'9c61a560-7e10-4056-9d98-06d12904f576', N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b', N'khanh123@gmail.com', N'doan123@gmail.com', N'Congratulations! You have Been Selected for the Position', N'Dear [Candidate Name],

I am thrilled to inform you that you have been selected for the [Position Title] at [Company Name]. Congratulations!

Your qualifications, experience, and enthusiasm for the role truly stood out among the applicants, and we believe you will make a valuable addition to our team.

We would like to discuss further details regarding your start date, salary, and any other pertinent information. Please let us know your availability for a meeting or phone call at your earliest convenience.

Once again, congratulations on your successful application. We look forward to welcoming you aboard and embarking on this exciting journey together.

Warm regards,

[Your Name]
[Your Position]
[Company Name]', N'09/05/2024 10:19:49 CH', N'10/05/2024 12:00:00 SA', N'01/05/2024 5:00:00 CH')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'ad462998-2353-45b2-a822-05ce005beeea', N'1b21d928-f685-40b3-bd9a-1c34a932166b', N'khanh123@gmail.com', N'tu123@gmail.com', N'ád', N'ádf', N'10/05/2024 3:49:47 CH', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'ad462998-2353-45b2-a822-05ce005beeea', N'ca63e213-96fc-4499-a8db-985e65be9753', N'khanh123@gmail.com', N'thanhsang123@gmail.com', N'dsf', N'sdf', N'10/05/2024 3:50:40 CH', N'25/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
INSERT [dbo].[Letter] ([IdCompany], [IdJobPostings], [IdCandidate], [Sender], [Receiver], [Title], [Content], [DateSent], [InterviewDate], [InterViewTime]) VALUES (N'dfd1de16-df05-4c7a-963f-c7278b0be15f', N'e8c692b6-faec-43d5-85f8-2b2ee3650ffa', N'ca63e213-96fc-4499-a8db-985e65be9753', N'nhat123@gmail.com', N'thanhsang123@gmail.com', N'sdv', N'sdv', N'11/05/2024 2:25:58 SA', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA')
GO
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'274ec4eb-4c9d-4be9-bb86-1da84162115c', N'1b21d928-f685-40b3-bd9a-1c34a932166b', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154328.png', N'09/05/2024', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'DOCTOR', N'levantu')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'9508768a-317b-4391-93ec-6f2ebb0dddae', N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154334.png', N'09/05/2024', N'19/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'BA', N'Le Khanh Doan')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'9508768a-317b-4391-93ec-6f2ebb0dddae', N'1b21d928-f685-40b3-bd9a-1c34a932166b', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154328.png', N'09/05/2024', N'06/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'BA', N'levantu')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'9508768a-317b-4391-93ec-6f2ebb0dddae', N'442fd9cd-d1d8-482e-a53b-e51aa03bc6db', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154321.png', N'09/05/2024', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'BA', N'vuvanduc')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'9508768a-317b-4391-93ec-6f2ebb0dddae', N'ca63e213-96fc-4499-a8db-985e65be9753', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'09/05/2024', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'BA', N'vothanhsang')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'c589ae0f-a373-4e71-ac23-358ec1495458', N'ca63e213-96fc-4499-a8db-985e65be9753', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'09/05/2024', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'FULL STACK', N'vothanhsang')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'1762e7e1-5b1e-479f-a9e5-c3b762e78891', N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154334.png', N'09/05/2024', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'BACK END', N'Le Khanh Doan')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'1762e7e1-5b1e-479f-a9e5-c3b762e78891', N'442fd9cd-d1d8-482e-a53b-e51aa03bc6db', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154321.png', N'09/05/2024', N'07/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'BACK END', N'vuvanduc')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'1762e7e1-5b1e-479f-a9e5-c3b762e78891', N'ca63e213-96fc-4499-a8db-985e65be9753', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'09/05/2024', N'11/05/2024 12:00:00 SA', N'01/05/2024 7:30:00 SA', N'BACK END', N'vothanhsang')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'81be8f6c-9cea-48a5-add2-8062d5da0ec8', N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154334.png', N'09/05/2024', N'12/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'TESTER', N'Le Khanh Doan')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'81be8f6c-9cea-48a5-add2-8062d5da0ec8', N'442fd9cd-d1d8-482e-a53b-e51aa03bc6db', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154321.png', N'09/05/2024', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'TESTER', N'vuvanduc')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'81be8f6c-9cea-48a5-add2-8062d5da0ec8', N'ca63e213-96fc-4499-a8db-985e65be9753', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'09/05/2024', N'25/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'TESTER', N'vothanhsang')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'8c71ba3a-d6f7-497c-ad6e-1ff58c9d1cb4', N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154334.png', N'09/05/2024', N'15/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'TESTER', N'Le Khanh Doan')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'8c71ba3a-d6f7-497c-ad6e-1ff58c9d1cb4', N'1b21d928-f685-40b3-bd9a-1c34a932166b', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154328.png', N'09/05/2024', N'18/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'TESTER', N'levantu')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'8c71ba3a-d6f7-497c-ad6e-1ff58c9d1cb4', N'ca63e213-96fc-4499-a8db-985e65be9753', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'09/05/2024', N'02/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'TESTER', N'vothanhsang')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'9c61a560-7e10-4056-9d98-06d12904f576', N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154334.png', N'09/05/2024', N'10/05/2024 12:00:00 SA', N'01/05/2024 5:00:00 CH', N'SALE', N'Le Khanh Doan')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'ad462998-2353-45b2-a822-05ce005beeea', N'1b21d928-f685-40b3-bd9a-1c34a932166b', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154328.png', N'09/05/2024', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'ARCHITECTURE', N'levantu')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'ad462998-2353-45b2-a822-05ce005beeea', N'ca63e213-96fc-4499-a8db-985e65be9753', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'09/05/2024', N'25/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'ARCHITECTURE', N'vothanhsang')
INSERT [dbo].[LichPhongVan] ([IdCompany], [IdJobPostings], [IdCandidate], [LinkAvatar], [UpdateDate], [InterviewDate], [InterviewTime], [JobName], [CandidateName]) VALUES (N'dfd1de16-df05-4c7a-963f-c7278b0be15f', N'e8c692b6-faec-43d5-85f8-2b2ee3650ffa', N'ca63e213-96fc-4499-a8db-985e65be9753', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'09/05/2024', N'01/05/2024 12:00:00 SA', N'01/05/2024 12:00:00 SA', N'MANAGER', N'vothanhsang')
GO
INSERT [dbo].[LuuTin] ([IdCompany], [IdJobPostings], [IdCandidate], [Follow]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'9508768a-317b-4391-93ec-6f2ebb0dddae', N'ca63e213-96fc-4499-a8db-985e65be9753', N'flw')
GO
INSERT [dbo].[NHATUYENDUNG] ([Id], [UserType], [Fname], [Email], [PhoneNTD], [JobPos], [Company], [JobLocation], [SocialNetwork]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'Employer', N'vuvanduc', N'vanduc123@gmail.com', N'0232874278', N'Department Manager', N'FPT SOFTWARE', N'Ninh Binh', N'www.fpt.com')
INSERT [dbo].[NHATUYENDUNG] ([Id], [UserType], [Fname], [Email], [PhoneNTD], [JobPos], [Company], [JobLocation], [SocialNetwork]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'Employer', N'tranvukhanh', N'khanh123@gmail.com', N'034827345', N'Team Leader', N'HALO VIET NAM', N'Binh Duong', N'www.facebook.com')
INSERT [dbo].[NHATUYENDUNG] ([Id], [UserType], [Fname], [Email], [PhoneNTD], [JobPos], [Company], [JobLocation], [SocialNetwork]) VALUES (N'dfd1de16-df05-4c7a-963f-c7278b0be15f', N'Employer', N'dangminhnhat', N'nhat123@gmail.com', N'0932488457', N'Employee', N'VUKHANH HOAPHAT', N'Binh Duong', N'www.zalo.com')
GO
INSERT [dbo].[TAIKHOAN] ([Id], [UserType], [UserName], [UserPassword]) VALUES (N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b', N'Candidate', N'f', N'f')
INSERT [dbo].[TAIKHOAN] ([Id], [UserType], [UserName], [UserPassword]) VALUES (N'1b21d928-f685-40b3-bd9a-1c34a932166b', N'Candidate', N'j', N'j')
INSERT [dbo].[TAIKHOAN] ([Id], [UserType], [UserName], [UserPassword]) VALUES (N'4417c858-7b72-4eed-a7f2-6ff08c632c31', N'Employer', N'd', N'd')
INSERT [dbo].[TAIKHOAN] ([Id], [UserType], [UserName], [UserPassword]) VALUES (N'442fd9cd-d1d8-482e-a53b-e51aa03bc6db', N'Candidate', N'c', N'c')
INSERT [dbo].[TAIKHOAN] ([Id], [UserType], [UserName], [UserPassword]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'Candidate', N'b', N'b')
INSERT [dbo].[TAIKHOAN] ([Id], [UserType], [UserName], [UserPassword]) VALUES (N'dd4d39a3-49f5-496f-b6f9-4ee5748d5658', N'Employer', N'a', N'a')
INSERT [dbo].[TAIKHOAN] ([Id], [UserType], [UserName], [UserPassword]) VALUES (N'dfd1de16-df05-4c7a-963f-c7278b0be15f', N'Employer', N'e', N'e')
GO
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:16:02 CH', N'12/05/2024 10:00:22 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\853a8699e57f3f9810354cd2d4a93ac1.jpg', N'FPT SOFTWARE', N'        private void btn_reload_lichPV_Click(object sender, EventArgs e)
        {
            NTD_DAO.sapXepLichPV(hienFullLichPV());
        }')
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:15:52 CH', N'12/05/2024 8:53:45 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\8a61f0a05dc671c8ffedd767de656170.jpg', N'HALO VIET NAM', N'hello world')
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:15:52 CH', N'12/05/2024 8:54:05 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\8a61f0a05dc671c8ffedd767de656170.jpg', N'HALO VIET NAM', N'hello everybody
')
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:15:52 CH', N'12/05/2024 8:54:32 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\8a61f0a05dc671c8ffedd767de656170.jpg', N'HALO VIET NAM', N'how are you')
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:15:43 CH', N'12/05/2024 9:01:25 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\853a8699e57f3f9810354cd2d4a93ac1.jpg', N'FPT SOFTWARE', N'im here')
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:15:43 CH', N'12/05/2024 9:01:46 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\853a8699e57f3f9810354cd2d4a93ac1.jpg', N'FPT SOFTWARE', N'im fine, thank you, and you')
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:15:43 CH', N'12/05/2024 9:05:02 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\0de93b31d1fe2861d3e2b56a74aefa46.jpg', N'VUKHANH HOAPHAT', N'hi guy
')
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:15:43 CH', N'12/05/2024 9:06:15 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\8a61f0a05dc671c8ffedd767de656170.jpg', N'HALO VIET NAM', N'hello world')
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:15:52 CH', N'12/05/2024 9:07:37 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\0de93b31d1fe2861d3e2b56a74aefa46.jpg', N'VUKHANH HOAPHAT', N'im fine')
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:15:43 CH', N'12/05/2024 9:38:56 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'vothanhsang', N'hello everybody')
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:15:43 CH', N'12/05/2024 9:41:42 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\8a61f0a05dc671c8ffedd767de656170.jpg', N'HALO VIET NAM', N'introduce yourself')
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:15:43 CH', N'12/05/2024 9:45:22 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'vothanhsang', N'yes sir')
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:15:43 CH', N'12/05/2024 9:45:38 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'vothanhsang', N'"Hi there! I''m Vo Thanh Sang, a passionate individual dedicated to continuous learning and growth. With a background in [mention relevant fields or experiences], I thrive on challenges and enjoy exploring new opportunities.')
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:15:43 CH', N'12/05/2024 9:45:55 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'vothanhsang', N'I''m skilled in [mention key skills or areas of expertise], and I''m always eager to collaborate, innovate, and make a positive impact. Let''s connect and embark on exciting journeys together!"')
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:16:02 CH', N'12/05/2024 9:57:45 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\8a61f0a05dc671c8ffedd767de656170.jpg', N'HALO VIET NAM', N'            flpl_danhSachTinNhan.Controls.Clear();
            pnl_chatBox.Controls.Clear();')
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:16:02 CH', N'12/05/2024 9:58:04 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\8a61f0a05dc671c8ffedd767de656170.jpg', N'HALO VIET NAM', N'            ThongKe.thucThi_load_BieuDoTron(chart_soCV_theoNganh, this.IdCompany);
')
INSERT [dbo].[TinNhan] ([IdCandidate], [DatePosted_up], [DateSent], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:16:02 CH', N'12/05/2024 9:58:56 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'vothanhsang', N'        private void btn_newChat_Click(object sender, EventArgs e)
        {
            flpl_chiTietTinXinViec.Controls.Clear();
            flpl_tinNhan.Controls.Clear();
            pnl_chatBox.Controls.Clear();

            NTD_DAO.load_tinXinViec(flpl_tinDaDang, flpl_chiTietTinXinViec, flpl_tinNhan, pnl_chatBox, this.IdCompany);
        }')
GO
INSERT [dbo].[TinXinViec] ([Id], [DatePosted], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:15:43 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'vothanhsang', N'Searching for a job can be both exciting and challenging. It''s a journey filled with opportunities to explore new career paths, connect with potential employers, and showcase your skills and experiences. From scouring job boards to crafting tailored resumes and cover letters, each step brings you closer to finding the perfect fit. Whether you''re a recent graduate eager to kickstart your career or a seasoned professional seeking new challenges, the job hunt is a chance to define your ambitions and pursue your passions. So, dive in with enthusiasm, stay persistent, and embrace the adventure of finding your next opportunity.')
INSERT [dbo].[TinXinViec] ([Id], [DatePosted], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:15:52 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'vothanhsang', N'hello all')
INSERT [dbo].[TinXinViec] ([Id], [DatePosted], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:16:02 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'vothanhsang', N'hello class')
INSERT [dbo].[TinXinViec] ([Id], [DatePosted], [Avatar], [Name], [Content]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'12/05/2024 3:40:34 CH', N'C:\Users\tulev\OneDrive\Pictures\logo\Screenshot 2024-05-09 154314.png', N'vothanhsang', N'Searching for a job can be both exciting and challenging. It''s a journey filled with opportunities to explore new career paths, connect with potential employers, and showcase your skills and experiences. From scouring job boards to crafting tailored resumes and cover letters, each step brings you closer to finding the perfect fit. Whether you''re a recent graduate eager to kickstart your career or a seasoned professional seeking new challenges, the job hunt is a chance to define your ambitions and pursue your passions. So, dive in with enthusiasm, stay persistent, and embrace the adventure of finding your next opportunity.')
GO
INSERT [dbo].[UNGVIEN] ([Id], [UserType], [Fname], [Phone], [BirthDate], [Link], [Email], [Address_C], [Gender]) VALUES (N'03cd0f1a-7f75-4eaf-8757-cab5e81f3e8b', N'Candidate', N'Le Khanh Doan', N'0923478273', N'15/08/2023', N'www.google.com', N'doan123@gmail.com', N'Soc Trang', N'Male')
INSERT [dbo].[UNGVIEN] ([Id], [UserType], [Fname], [Phone], [BirthDate], [Link], [Email], [Address_C], [Gender]) VALUES (N'1b21d928-f685-40b3-bd9a-1c34a932166b', N'Candidate', N'levantu', N'0923445873', N'04/03/2024', N'www.hub.com', N'tu123@gmail.com', N'Ninh Thuan', N'Male')
INSERT [dbo].[UNGVIEN] ([Id], [UserType], [Fname], [Phone], [BirthDate], [Link], [Email], [Address_C], [Gender]) VALUES (N'442fd9cd-d1d8-482e-a53b-e51aa03bc6db', N'Candidate', N'vuvanduc', N'0385068953', N'16/06/2016', N'www.github.com', N'vantu123@gmail.com', N'Dak Lak', N'Male')
INSERT [dbo].[UNGVIEN] ([Id], [UserType], [Fname], [Phone], [BirthDate], [Link], [Email], [Address_C], [Gender]) VALUES (N'ca63e213-96fc-4499-a8db-985e65be9753', N'Candidate', N'vothanhsang', N'0923847434', N'26/02/2024', N'www.youtube.com', N'thanhsang123@gmail.com', N'Binh Duong', N'Male')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__tmp_ms_x__C9F2845604694B4D]    Script Date: 13/05/2024 10:06:33 SA ******/
ALTER TABLE [dbo].[TAIKHOAN] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DinhDang_rtbx_UV] ADD  DEFAULT ('NULL') FOR [RtbxStyle]
GO
ALTER TABLE [dbo].[DinhDang_rtbx_UV] ADD  DEFAULT ('NULL') FOR [Color]
GO
ALTER TABLE [dbo].[DinhDang_rtbx_UV] ADD  DEFAULT ('NULL') FOR [Font]
GO
ALTER TABLE [dbo].[DinhDang_rtbx_UV] ADD  DEFAULT ('NULL') FOR [FontStyle]
GO
ALTER TABLE [dbo].[DinhDang_rtbx_UV] ADD  DEFAULT ((0)) FOR [Size]
GO
ALTER TABLE [dbo].[LuuCV] ADD  DEFAULT ('NULL') FOR [Follow]
GO
ALTER TABLE [dbo].[LuuTin] ADD  DEFAULT ('NULL') FOR [Follow]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD FOREIGN KEY([IdCandidate])
REFERENCES [dbo].[UNGVIEN] ([Id])
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD FOREIGN KEY([IdCompany], [IdJobPostings])
REFERENCES [dbo].[JobPostings] ([IdCompany], [IdJobPostings])
GO
ALTER TABLE [dbo].[CVs]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[UNGVIEN] ([Id])
GO
ALTER TABLE [dbo].[DinhDang_rtbx_NTD]  WITH CHECK ADD FOREIGN KEY([IdCompany], [IdJobPostings])
REFERENCES [dbo].[JobPostings] ([IdCompany], [IdJobPostings])
GO
ALTER TABLE [dbo].[DinhDang_rtbx_UV]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[CVs] ([Id])
GO
ALTER TABLE [dbo].[JobPostings]  WITH CHECK ADD FOREIGN KEY([IdCompany])
REFERENCES [dbo].[NHATUYENDUNG] ([Id])
GO
ALTER TABLE [dbo].[LuuCV]  WITH CHECK ADD FOREIGN KEY([IdCompany], [IdJobPostings])
REFERENCES [dbo].[JobPostings] ([IdCompany], [IdJobPostings])
GO
ALTER TABLE [dbo].[LuuCV]  WITH CHECK ADD FOREIGN KEY([IdCandidate])
REFERENCES [dbo].[UNGVIEN] ([Id])
GO
ALTER TABLE [dbo].[LuuTin]  WITH CHECK ADD FOREIGN KEY([IdCompany], [IdJobPostings])
REFERENCES [dbo].[JobPostings] ([IdCompany], [IdJobPostings])
GO
ALTER TABLE [dbo].[LuuTin]  WITH CHECK ADD FOREIGN KEY([IdCandidate])
REFERENCES [dbo].[UNGVIEN] ([Id])
GO
ALTER TABLE [dbo].[NHATUYENDUNG]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[TAIKHOAN] ([Id])
GO
ALTER TABLE [dbo].[TinNhan]  WITH CHECK ADD FOREIGN KEY([IdCandidate])
REFERENCES [dbo].[UNGVIEN] ([Id])
GO
ALTER TABLE [dbo].[TinXinViec]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[UNGVIEN] ([Id])
GO
ALTER TABLE [dbo].[UNGVIEN]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[TAIKHOAN] ([Id])
GO
USE [master]
GO
ALTER DATABASE [DeTai_02] SET  READ_WRITE 
GO
