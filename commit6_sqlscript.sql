USE [master]
GO
/****** Object:  Database [ProRecruit_Final]    Script Date: 17-Mar-18 6:37:11 PM ******/
CREATE DATABASE [ProRecruit_Final]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProRecruit_Final', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ProRecruit_Final.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProRecruit_Final_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ProRecruit_Final_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProRecruit_Final] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProRecruit_Final].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProRecruit_Final] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProRecruit_Final] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProRecruit_Final] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProRecruit_Final] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProRecruit_Final] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET RECOVERY FULL 
GO
ALTER DATABASE [ProRecruit_Final] SET  MULTI_USER 
GO
ALTER DATABASE [ProRecruit_Final] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProRecruit_Final] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProRecruit_Final] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProRecruit_Final] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ProRecruit_Final] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProRecruit_Final', N'ON'
GO
USE [ProRecruit_Final]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 17-Mar-18 6:37:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 17-Mar-18 6:37:11 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 17-Mar-18 6:37:11 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 17-Mar-18 6:37:11 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 17-Mar-18 6:37:11 PM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 17-Mar-18 6:37:11 PM ******/
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
	[Type] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Candidate]    Script Date: 17-Mar-18 6:37:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidate](
	[FirstName] [nvarchar](30) NULL,
	[LastName] [nvarchar](30) NULL,
	[Email] [nvarchar](30) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Gender] [nvarchar](30) NOT NULL,
	[MaritalStatus] [nvarchar](30) NULL,
	[Nationality] [nvarchar](30) NULL,
	[City] [nvarchar](30) NULL,
	[CNIC] [nvarchar](30) NOT NULL,
	[CurrentAddress] [nvarchar](max) NULL,
	[Contact] [nvarchar](30) NULL,
	[Industry] [nvarchar](30) NULL,
	[FunctionalArea] [nvarchar](30) NULL,
	[CurrentSalary] [nvarchar](30) NULL,
	[ExpectedSalary] [nvarchar](30) NULL,
	[CarreerLevel] [nvarchar](30) NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[Summary] [nvarchar](max) NULL,
 CONSTRAINT [PK_Candidate] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CandidateCertifications]    Script Date: 17-Mar-18 6:37:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidateCertifications](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[CertificationTitle] [nvarchar](50) NULL,
	[CertificationDescription] [nvarchar](max) NULL,
	[UserId] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CandidateExperience]    Script Date: 17-Mar-18 6:37:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidateExperience](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[OrganizationName] [nvarchar](30) NOT NULL,
	[PositionHeld] [nvarchar](50) NOT NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[Country] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[UserId] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CandidateJob]    Script Date: 17-Mar-18 6:37:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidateJob](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[JobId] [int] NULL,
	[DateApplied] [datetime] NULL,
	[UserId] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CandidateLanguages]    Script Date: 17-Mar-18 6:37:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidateLanguages](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[LanguageTitle] [nvarchar](50) NULL,
	[ProficiencyWithLanguage] [nvarchar](50) NULL,
	[UserId] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CandidateProjects]    Script Date: 17-Mar-18 6:37:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidateProjects](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[ProjectTitle] [nvarchar](50) NULL,
	[ProjectDescription] [nvarchar](max) NULL,
	[URL] [nvarchar](max) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[UserId] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CandidateQualification]    Script Date: 17-Mar-18 6:37:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidateQualification](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[QualificationId] [int] NOT NULL,
	[Institute] [nvarchar](50) NOT NULL,
	[DateCompleted] [datetime] NULL,
	[DegreeLevel] [nvarchar](50) NULL,
	[DegreeType] [nvarchar](50) NULL,
	[Degreetitle] [nvarchar](50) NULL,
	[MajorSubjects] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Institution] [nvarchar](50) NULL,
	[CompletionYear] [nvarchar](50) NULL,
	[ResultType] [nvarchar](50) NULL,
	[TotalGPA] [nvarchar](50) NULL,
	[TotalGrade] [nvarchar](50) NULL,
	[TotalPercentage] [nvarchar](50) NULL,
	[YourGPA] [nvarchar](50) NULL,
	[UserId] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CandidateSkills]    Script Date: 17-Mar-18 6:37:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidateSkills](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[SkillId] [int] NOT NULL,
	[ExperienceWithSkill] [nvarchar](50) NULL,
	[UserId] [nvarchar](128) NULL,
 CONSTRAINT [PK_CandidateSkills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Job]    Script Date: 17-Mar-18 6:37:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[DatePublished] [datetime] NULL,
	[DateApplyBy] [datetime] NULL,
	[Title] [nvarchar](50) NULL,
	[JobDescription] [nvarchar](max) NULL,
	[Location] [nvarchar](50) NULL,
	[SalaryRange] [nvarchar](30) NULL,
	[FunctionalArea] [nvarchar](50) NULL,
	[JobShift] [nvarchar](20) NULL,
	[Gender] [nvarchar](10) NULL,
	[ReqYearsOfExp] [nvarchar](30) NULL,
	[AgeRequirement] [nvarchar](20) NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JobQualification]    Script Date: 17-Mar-18 6:37:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobQualification](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[JobId] [int] NOT NULL,
	[QualificationId] [int] NULL,
	[DegreeLevel] [nvarchar](50) NULL,
	[DegreeType] [nvarchar](50) NULL,
	[DegreeTitle] [nvarchar](50) NULL,
	[MajorSubject] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[Institution] [nvarchar](50) NULL,
	[CompletionYear] [nvarchar](50) NULL,
	[ResultType] [nvarchar](50) NULL,
	[TotalGPA] [nvarchar](50) NULL,
	[TotalPercentage] [nvarchar](50) NULL,
	[TotalGrade] [nvarchar](50) NULL,
	[YourGPA] [nvarchar](50) NULL,
 CONSTRAINT [PK_JobQualification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JobSkills]    Script Date: 17-Mar-18 6:37:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobSkills](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[JobId] [int] NOT NULL,
	[SkillId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Organization]    Script Date: 17-Mar-18 6:37:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[UserId] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[Industry] [nvarchar](50) NULL,
	[ContactPerson] [nvarchar](50) NULL,
	[Phonenumber] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[NoOfEmployee] [nvarchar](50) NULL,
	[OperatingSince] [nvarchar](50) NULL,
	[StockSymbol] [nvarchar](50) NULL,
	[CompanyLogo] [nvarchar](50) NULL,
	[PostedJobs] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Qualification]    Script Date: 17-Mar-18 6:37:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qualification](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[QualificationName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Skill]    Script Date: 17-Mar-18 6:37:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[SkillName] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201711301158249_InitialCreate', N'ProRecruit_Final_MidEvaluation.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5CDB6EE4B8117D0F907F10F49404DE962F99C1C4E8DE85B76D6F8C8C2F98F62CF266B025769B1889D24A94D746B05FB60FF9A4FC428A12A59678D1A55B7DF16281855B244F158B8764B1589CFFFDFEDFF10FAF816FBDE03821219DD827A363DBC2D40D3D4297133B658BEF3ED93F7CFFE73F8DAFBCE0D5FAB9A877C6EB414B9A4CEC67C6A273C749DC671CA0641410370E9370C1466E1838C80B9DD3E3E37F3827270E06081BB02C6BFC25A58C0438FB013FA7217571C452E4DF861EF613F11D4A6619AA7587029C44C8C513FB210EBF60374E097BBA25DED50BF253C440A951DED4B62E7C8240AD19F617B685280D59567EFE35C133168774398BE003F21FDF220CF516C84FB0E8CCF9AA7AD77E1D9FF27E39AB8605949B262C0C7A029E9C09433972F3B5CC6D978604535E81C9D91BEF7566CE897DE3E1ECD397D00703C802CFA77ECC2B4FECDB52C44512DD61362A1A8E72C8EB18E07E0DE36FA32AE291D5B9DD5149ACD3D131FFEFC89AA63E4B633CA1386531F28FAC8774EE13F75FF8ED31FC86E9E4EC64BE38FBF4E123F2CE3EFE1D9F7DA8F614FA0AF56A1FE013F026C231E8861765FF6DCBA9B773E48665B34A9BDC2AC0259823B6758B5E3F63BA64CF307B4E3FD9D63579C55EF14590EB2B2530A5A0118B53F87997FA3E9AFBB82C771A65F2FF37483DFDF07110A977E8852CB3A197E4C3C489615E7DC17E569A3C93289F5EB5F17E12D5AEE330E0BFEBFCCA4B9F66611ABBBC33A1B1CA238A9798D5B51B3B2BF276A234871A9ED605EAE1539B6BAAD25B5B9577689D995088D8F56C28F4DDAEDCCE8CBB882218BC8C5ADC224D846BD9B946121410C3D06045AA93AEA4A2D0D93FF21A791520E20FB048769002CECA82C4012E7BF963089444B4B7CE0F2849608DF0FE8992E706D5E1CF01549F61378D81BA33868268EBD21E9E438AEFD260CE67C4EE640D36348FBF86D7C865617C4579AB8DF13E87EEB7306557D4BB440C7F656E01C87F3E92A03BC020EA5CB82E4E926B2033F6A621F8E205E00D6567A7BDE1F86AB56F2765EA2312E8BD14695D7D2AAAAE3C157D0DC55B3154D3792C4DAA7E0E97847653B5A86A5635AFD1AAAAA8D657550ED64D5351D3AC6856A155CFBCD6603E603642C33B8119ECE17B819B6DDEA6B5A062C619AC90F8274C710CCB98F78018C3315D8D409775631FCE42367C5CE8D6F7A64CD2CFE0B70D2D6AADD9902D02C3CF860CF6F06743A6267C7E211EF74A3A1C8D8ACA00DFA9BEFED4D53EE724CD763D1D6ADDDCB5F0DDAC01A6E9729124A14BB259A0098A8990465D7FF0E1ACF6F846DE1B3946021D03A213BEE5C117E89B2D93EA9E5E621F336C5DB879D0708A121779AA19A1435E0FC58A1D55A3D82A565257EE6F8A4C603A8E7923C40F4109CC5442993A2D08754984FC562B492D3B6E61BCEFA50CB9E41247987281AD96E8225C1F1AE10A9472A44169B3D0D8A930AE998806AFD534E66D2EEC6ADC9588C54E38D9E23B1B7829FCB7AD10B3D9623B2067B349BA28600CF3ED83A0E2ACD29500F2C1E5D0082A9D980C04152ED54E085AB7D81E085A37C9BB23687E44ED3AFED279F5D0E8593F28EF7E5B6F34D71EB859B3C7815133F73DA10D83163856E97939E785F895690E67A0A7389F25C2D59529C2C16798D543362B7F57EB873ACD2032899A0057446B011517840A9032A17A2857C4F21AB5135E440FD822EED6082BD67E09B6C20115BB7A515AA968BE4E95C9D9E9F451F6AC648342F24E87850A8E8610F2E255EF7807A398E2B2AA61BAF8C27DBCE14AC7C4603418A8C5733518A9E8CCE0562AA8D96E259D43D6C725DBC84A92FB64B052D199C1AD2438DA6E248D53D0C32DD8C844F52D7CA0C956443ACADDA62C1B3B793295F830760C5957E35B1445842E2B5958E28B35CB53B0A6DFCDFAA723053986E3269AACA452DB52120B63B4C4522988064DAF499CB04BC4D01CF138CFD40B946ADABDD5B0FC1722ABDBA73A88C53E50D4E67F97E1B3C66BFDDAC6AB7A2602F01ABA1B70F7268BA96BC8A06F6EF11439E4A35813C69F867E1A50B3B7656E9D5FE655DBE75F5484B123E9AF78538AE9149FB73E0E9D46499D21DB18B1D2B3597FD4CC1026DB177E69D5FA265FD58C5284AEAA28A670D6DE46D1E4E2AC3F72B22BD97FE05A11B633E344FE4A15407CEA8951498150C02A65DD51EB592A55CC7A4977442915A50A2915F5D0B29A705253B25AB0169EC1A2FA1ADD25A829265574B5B43BB226D9A40AAD295E035BA3B35CD61D55938F5205D61477C75E25A7C82BEA01EF69C603CE309B5A7E20DE6C5733606C67791C6653ACDCFB57812A9F7B62899B7D054C7C3F486A194F85C3502B0F8A6C462D0386794DAA5D9FD797A4C63B7F3366ED4EBCB6EC37E50498F1FA1178AB34514E887295527A7952944E8463713A6B7FACA31CD7F22AB6559811B6FCB784E160C42B8C66BFF8539F60BEC017156E11250B9CB03C0FC43E3D3E39959EF81CCE731B27493C5F73BA35BDB9A98FD90E52BAE80B8ADD6714AB09161B3C4959812AB1EB1BEAE1D789FD9FACD5791606E17F659F8FAC9BE42B25BFA450F018A7D8FA4D4D181D2645BFF92C76A00F2ABA5BF5E6DF4F79D323EB3E8619736E1D4BB65C6784EBCF2C7A699337DD409BB51F5FBCDF09557BBFA0459526C4FACF15E6840DF254A1D0F22F017AFD6B5FD5B4CF113642D43C39180A6F10139A9E14AC83657C4EE0C14F963D27E8D759FDF3827554333E2D20B43F98FCB0A0FB3254B4DCE356A33920ED6249CAECDC9A98BD5196E6BEF726257F7BA389AEE668F780DB200F7B0D66BCB314E6C176474D86F260D8FBA4F6D6D3920F2513799523B2DF04E45DE61C37DC1EFDA1528D0F20394E93ECB3FF84E25D73CD14D43DF0ACCC7E69C30746369102B6FFE4E05D93CD14E63D70B2F54A013E30AEED6BFFDC33D33A6FA17B4FE85573930C9733BA58705BC26E1E388713FE3C0412E41E65FECE529F21D694DDDA227055C52CD49C9A260B56268E2257A9D12CB65F5FC586DFD85951A759AC21A1B349B658FF1B658B3ACDB20D6992FB4835D6262AEAD2BF5BD6B1A65CA9F7945A5CEB494B267B9BCFDA78D3FE9E328907314A6DF618EE88DF4FE2F020261972EAF4481456AF7B61EFACFC0B8EB07F2764B982E0FF9E23C56E6DD72CEBDCD045586CDE924645152942738B19F2604BBD881959209741318F31670FC5B3B81DBFE99863EF86DEA72C4A1974190773BF16F0E24E4093FC2C1BBAAEF3F83EE2BF9221BA006A121E9BBFA73FA6C4F74ABDAF3531210304F72E4444978F25E391DDE55B897417D28E40C27CA553F48883C807B0E49ECED00B5E4737A0DF67BC44EEDB2A026802691F88BAD9C797042D6314240263D51E7E0287BDE0F5FBFF030D4A7B63C8540000, N'6.1.3-40302')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Type]) VALUES (N'4d2980a7-c2a4-4331-a745-4f68215f6907', N'hamzaws99@gmail.com', 0, N'AJbAWfXRNzK7wLR8ip+jv1DDvteUZLVexgsj1n4d+xzlxasm6xTVFyWbMgLQ4PkGAg==', N'cdedba6b-d958-4763-858a-b076f1fae367', NULL, 0, 0, NULL, 1, 0, N'hamzaws99@gmail.com', N'Candidate')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Type]) VALUES (N'c84c5bb7-2920-4e9b-bceb-6c6f8b5f7689', N'hamzaws9@gmail.com', 0, N'AKX5pCSHWzf89Bay0+vzj695t5aV8YAYjqOxFZljuk2EQJ/OmG0u7nj5qserizUtww==', N'88707794-0d04-4703-8388-c12c7d80d5a5', NULL, 0, 0, NULL, 1, 0, N'hamzaws9@gmail.com', N'Organization')
INSERT [dbo].[Candidate] ([FirstName], [LastName], [Email], [DateOfBirth], [Gender], [MaritalStatus], [Nationality], [City], [CNIC], [CurrentAddress], [Contact], [Industry], [FunctionalArea], [CurrentSalary], [ExpectedSalary], [CarreerLevel], [UserId], [Summary]) VALUES (N'Hamza', N'Bin Wasi', N'hamzaws99@gmail.com', CAST(N'1996-04-03 00:00:00.000' AS DateTime), N'Male', N'Unmarried', N'Pakistani', N'Karachi', N'42201-2579042-5', N'Karachi', N'03002216803', N'IT', N'IT', N'10000', N'10000', N'Fresh', N'4d2980a7-c2a4-4331-a745-4f68215f6907', NULL)
SET IDENTITY_INSERT [dbo].[CandidateCertifications] ON 

INSERT [dbo].[CandidateCertifications] ([Id], [CertificationTitle], [CertificationDescription], [UserId]) VALUES (100, N'MongoDB', N'Certified MongoDB', N'4d2980a7-c2a4-4331-a745-4f68215f6907')
SET IDENTITY_INSERT [dbo].[CandidateCertifications] OFF
SET IDENTITY_INSERT [dbo].[CandidateExperience] ON 

INSERT [dbo].[CandidateExperience] ([Id], [OrganizationName], [PositionHeld], [FromDate], [ToDate], [Country], [City], [UserId]) VALUES (100, N'Colgate Palmolive', N'Intern', CAST(N'2017-08-01 00:00:00.000' AS DateTime), CAST(N'2017-10-01 00:00:00.000' AS DateTime), N'Pakistan', N'Karachi', N'4d2980a7-c2a4-4331-a745-4f68215f6907')
SET IDENTITY_INSERT [dbo].[CandidateExperience] OFF
SET IDENTITY_INSERT [dbo].[CandidateJob] ON 

INSERT [dbo].[CandidateJob] ([Id], [JobId], [DateApplied], [UserId]) VALUES (100, 0, CAST(N'2018-03-17 13:13:38.323' AS DateTime), N'4d2980a7-c2a4-4331-a745-4f68215f6907')
SET IDENTITY_INSERT [dbo].[CandidateJob] OFF
SET IDENTITY_INSERT [dbo].[CandidateLanguages] ON 

INSERT [dbo].[CandidateLanguages] ([Id], [LanguageTitle], [ProficiencyWithLanguage], [UserId]) VALUES (100, N'English', N'Great', N'4d2980a7-c2a4-4331-a745-4f68215f6907')
INSERT [dbo].[CandidateLanguages] ([Id], [LanguageTitle], [ProficiencyWithLanguage], [UserId]) VALUES (101, N'Urdu', N'Great', N'4d2980a7-c2a4-4331-a745-4f68215f6907')
SET IDENTITY_INSERT [dbo].[CandidateLanguages] OFF
SET IDENTITY_INSERT [dbo].[CandidateQualification] ON 

INSERT [dbo].[CandidateQualification] ([Id], [QualificationId], [Institute], [DateCompleted], [DegreeLevel], [DegreeType], [Degreetitle], [MajorSubjects], [Country], [City], [Institution], [CompletionYear], [ResultType], [TotalGPA], [TotalGrade], [TotalPercentage], [YourGPA], [UserId]) VALUES (100, 1107, N'Bahria University', CAST(N'2201-10-10 00:00:00.000' AS DateTime), N'Bachelors', N'A', N'A', N'A', NULL, N'Karachi', N'A', N'A', N'A', N'A', N'A', N'A', N'A', N'4d2980a7-c2a4-4331-a745-4f68215f6907')
SET IDENTITY_INSERT [dbo].[CandidateQualification] OFF
SET IDENTITY_INSERT [dbo].[CandidateSkills] ON 

INSERT [dbo].[CandidateSkills] ([Id], [SkillId], [ExperienceWithSkill], [UserId]) VALUES (100, 103, N'2 Years', N'4d2980a7-c2a4-4331-a745-4f68215f6907')
INSERT [dbo].[CandidateSkills] ([Id], [SkillId], [ExperienceWithSkill], [UserId]) VALUES (101, 105, N'4 Years', N'4d2980a7-c2a4-4331-a745-4f68215f6907')
SET IDENTITY_INSERT [dbo].[CandidateSkills] OFF
INSERT [dbo].[Job] ([DatePublished], [DateApplyBy], [Title], [JobDescription], [Location], [SalaryRange], [FunctionalArea], [JobShift], [Gender], [ReqYearsOfExp], [AgeRequirement], [UserId], [Id]) VALUES (NULL, NULL, N'Blowjob', N'Sloppy', N'Karachi', N'500', N'HR', N'Night', N'Male', N'None', N'18+', N'c84c5bb7-2920-4e9b-bceb-6c6f8b5f7689', 0)
INSERT [dbo].[Organization] ([UserId], [Name], [Industry], [ContactPerson], [Phonenumber], [Fax], [NoOfEmployee], [OperatingSince], [StockSymbol], [CompanyLogo], [PostedJobs], [Email]) VALUES (N'c84c5bb7-2920-4e9b-bceb-6c6f8b5f7689', N'ProRecruit', N'IT', N'Hamza Bin Wasi', N'03002216803', NULL, N'50', N'2017', N'PRT', NULL, NULL, N'hamzaws9@gmail.com')
SET IDENTITY_INSERT [dbo].[Qualification] ON 

INSERT [dbo].[Qualification] ([Id], [QualificationName]) VALUES (1107, N'Bachelors of Electrical Engineering')
INSERT [dbo].[Qualification] ([Id], [QualificationName]) VALUES (1108, N'Bachelors of Software Engineering')
INSERT [dbo].[Qualification] ([Id], [QualificationName]) VALUES (1109, N'Bachelors of Computer Engineering')
INSERT [dbo].[Qualification] ([Id], [QualificationName]) VALUES (1110, N'Bachelors of Computer Science')
INSERT [dbo].[Qualification] ([Id], [QualificationName]) VALUES (1111, N'Bachelors of Business Administration')
INSERT [dbo].[Qualification] ([Id], [QualificationName]) VALUES (1112, N'Masters of Electrical Engineering')
INSERT [dbo].[Qualification] ([Id], [QualificationName]) VALUES (1113, N'Masters of Software Engineering')
INSERT [dbo].[Qualification] ([Id], [QualificationName]) VALUES (1114, N'Masters of Computer Engineering')
INSERT [dbo].[Qualification] ([Id], [QualificationName]) VALUES (1115, N'Masters of Computer Science')
INSERT [dbo].[Qualification] ([Id], [QualificationName]) VALUES (1116, N'Masters of Business Administraion')
SET IDENTITY_INSERT [dbo].[Qualification] OFF
SET IDENTITY_INSERT [dbo].[Skill] ON 

INSERT [dbo].[Skill] ([Id], [SkillName]) VALUES (102, N'iOS')
INSERT [dbo].[Skill] ([Id], [SkillName]) VALUES (103, N'.Net MVC')
INSERT [dbo].[Skill] ([Id], [SkillName]) VALUES (104, N'.Net Web Forms')
INSERT [dbo].[Skill] ([Id], [SkillName]) VALUES (105, N'C#')
INSERT [dbo].[Skill] ([Id], [SkillName]) VALUES (106, N'Swift')
INSERT [dbo].[Skill] ([Id], [SkillName]) VALUES (1102, N'Python')
INSERT [dbo].[Skill] ([Id], [SkillName]) VALUES (1103, N'Data science')
SET IDENTITY_INSERT [dbo].[Skill] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 17-Mar-18 6:37:11 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 17-Mar-18 6:37:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 17-Mar-18 6:37:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 17-Mar-18 6:37:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 17-Mar-18 6:37:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 17-Mar-18 6:37:11 PM ******/
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
ALTER TABLE [dbo].[Candidate]  WITH CHECK ADD  CONSTRAINT [FK_Candidate_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Candidate] CHECK CONSTRAINT [FK_Candidate_AspNetUsers]
GO
ALTER TABLE [dbo].[CandidateCertifications]  WITH CHECK ADD  CONSTRAINT [FK_CandidateCertifications_Candidate] FOREIGN KEY([UserId])
REFERENCES [dbo].[Candidate] ([UserId])
GO
ALTER TABLE [dbo].[CandidateCertifications] CHECK CONSTRAINT [FK_CandidateCertifications_Candidate]
GO
ALTER TABLE [dbo].[CandidateExperience]  WITH CHECK ADD  CONSTRAINT [FK_CandidateExperience_Candidate] FOREIGN KEY([UserId])
REFERENCES [dbo].[Candidate] ([UserId])
GO
ALTER TABLE [dbo].[CandidateExperience] CHECK CONSTRAINT [FK_CandidateExperience_Candidate]
GO
ALTER TABLE [dbo].[CandidateJob]  WITH CHECK ADD  CONSTRAINT [FK_CandidateJob_Candidate] FOREIGN KEY([UserId])
REFERENCES [dbo].[Candidate] ([UserId])
GO
ALTER TABLE [dbo].[CandidateJob] CHECK CONSTRAINT [FK_CandidateJob_Candidate]
GO
ALTER TABLE [dbo].[CandidateJob]  WITH CHECK ADD  CONSTRAINT [FK_CandidateJob_Job] FOREIGN KEY([JobId])
REFERENCES [dbo].[Job] ([Id])
GO
ALTER TABLE [dbo].[CandidateJob] CHECK CONSTRAINT [FK_CandidateJob_Job]
GO
ALTER TABLE [dbo].[CandidateLanguages]  WITH CHECK ADD  CONSTRAINT [FK_CandidateLanguages_Candidate] FOREIGN KEY([UserId])
REFERENCES [dbo].[Candidate] ([UserId])
GO
ALTER TABLE [dbo].[CandidateLanguages] CHECK CONSTRAINT [FK_CandidateLanguages_Candidate]
GO
ALTER TABLE [dbo].[CandidateProjects]  WITH CHECK ADD  CONSTRAINT [FK_CandidateProjects_Candidate] FOREIGN KEY([UserId])
REFERENCES [dbo].[Candidate] ([UserId])
GO
ALTER TABLE [dbo].[CandidateProjects] CHECK CONSTRAINT [FK_CandidateProjects_Candidate]
GO
ALTER TABLE [dbo].[CandidateQualification]  WITH CHECK ADD  CONSTRAINT [FK_CandidateQualification_Candidate] FOREIGN KEY([UserId])
REFERENCES [dbo].[Candidate] ([UserId])
GO
ALTER TABLE [dbo].[CandidateQualification] CHECK CONSTRAINT [FK_CandidateQualification_Candidate]
GO
ALTER TABLE [dbo].[CandidateQualification]  WITH CHECK ADD  CONSTRAINT [FK_CandidateQualification_Qualification] FOREIGN KEY([QualificationId])
REFERENCES [dbo].[Qualification] ([Id])
GO
ALTER TABLE [dbo].[CandidateQualification] CHECK CONSTRAINT [FK_CandidateQualification_Qualification]
GO
ALTER TABLE [dbo].[CandidateSkills]  WITH CHECK ADD  CONSTRAINT [CandidateSkills_SkillId_FK] FOREIGN KEY([SkillId])
REFERENCES [dbo].[Skill] ([Id])
GO
ALTER TABLE [dbo].[CandidateSkills] CHECK CONSTRAINT [CandidateSkills_SkillId_FK]
GO
ALTER TABLE [dbo].[CandidateSkills]  WITH CHECK ADD  CONSTRAINT [FK_CandidateSkills_Candidate] FOREIGN KEY([UserId])
REFERENCES [dbo].[Candidate] ([UserId])
GO
ALTER TABLE [dbo].[CandidateSkills] CHECK CONSTRAINT [FK_CandidateSkills_Candidate]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_Organization1] FOREIGN KEY([UserId])
REFERENCES [dbo].[Organization] ([UserId])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK_Job_Organization1]
GO
ALTER TABLE [dbo].[JobQualification]  WITH CHECK ADD  CONSTRAINT [FK_JobQualification_Job] FOREIGN KEY([Id])
REFERENCES [dbo].[Job] ([Id])
GO
ALTER TABLE [dbo].[JobQualification] CHECK CONSTRAINT [FK_JobQualification_Job]
GO
ALTER TABLE [dbo].[JobQualification]  WITH CHECK ADD  CONSTRAINT [FK_JobQualification_Qualification] FOREIGN KEY([QualificationId])
REFERENCES [dbo].[Qualification] ([Id])
GO
ALTER TABLE [dbo].[JobQualification] CHECK CONSTRAINT [FK_JobQualification_Qualification]
GO
ALTER TABLE [dbo].[JobSkills]  WITH CHECK ADD  CONSTRAINT [FK_JobSkills_Job] FOREIGN KEY([JobId])
REFERENCES [dbo].[Job] ([Id])
GO
ALTER TABLE [dbo].[JobSkills] CHECK CONSTRAINT [FK_JobSkills_Job]
GO
ALTER TABLE [dbo].[JobSkills]  WITH CHECK ADD  CONSTRAINT [FK_JobSkills_Skill] FOREIGN KEY([SkillId])
REFERENCES [dbo].[Skill] ([Id])
GO
ALTER TABLE [dbo].[JobSkills] CHECK CONSTRAINT [FK_JobSkills_Skill]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK_Organization_AspNetUsers]
GO
USE [master]
GO
ALTER DATABASE [ProRecruit_Final] SET  READ_WRITE 
GO
