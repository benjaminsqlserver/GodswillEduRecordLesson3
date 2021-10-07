USE [master]
GO
/****** Object:  Database [GodswillDB]    Script Date: 10/5/2021 10:44:19 AM ******/
CREATE DATABASE [GodswillDB]
 
GO

USE [GodswillDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/5/2021 10:44:21 AM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 10/5/2021 10:44:22 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10/5/2021 10:44:22 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10/5/2021 10:44:22 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10/5/2021 10:44:22 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10/5/2021 10:44:22 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10/5/2021 10:44:22 AM ******/
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
	[FirstName] [nvarchar](max) NULL,
	[GenderID] [int] NULL,
	[LastName] [nvarchar](max) NULL,
	[MiddleName] [nvarchar](max) NULL,
	[Picture] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 10/5/2021 10:44:22 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeviceCodes]    Script Date: 10/5/2021 10:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceCodes](
	[UserCode] [nvarchar](200) NOT NULL,
	[DeviceCode] [nvarchar](200) NOT NULL,
	[SubjectId] [nvarchar](200) NULL,
	[SessionId] [nvarchar](100) NULL,
	[ClientId] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[Expiration] [datetime2](7) NOT NULL,
	[Data] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DeviceCodes] PRIMARY KEY CLUSTERED 
(
	[UserCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genders]    Script Date: 10/5/2021 10:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genders](
	[GenderID] [int] IDENTITY(1,1) NOT NULL,
	[GenderName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED 
(
	[GenderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NextOfKins]    Script Date: 10/5/2021 10:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NextOfKins](
	[NextOfKinID] [bigint] IDENTITY(1,1) NOT NULL,
	[BiodataID] [bigint] NOT NULL,
	[NameOfNextOfKin] [nvarchar](250) NOT NULL,
	[RelationshipID] [int] NOT NULL,
	[NextOfKinPhoneNo] [nvarchar](50) NOT NULL,
	[NextOfKinEmail] [nvarchar](50) NOT NULL,
	[NextOfKinContactAddress] [ntext] NOT NULL,
 CONSTRAINT [PK_NextOfKins] PRIMARY KEY CLUSTERED 
(
	[NextOfKinID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersistedGrants]    Script Date: 10/5/2021 10:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersistedGrants](
	[Key] [nvarchar](200) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[SubjectId] [nvarchar](200) NULL,
	[SessionId] [nvarchar](100) NULL,
	[ClientId] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[Expiration] [datetime2](7) NULL,
	[ConsumedTime] [datetime2](7) NULL,
	[Data] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PersistedGrants] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Qualifications]    Script Date: 10/5/2021 10:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qualifications](
	[QualificationID] [int] IDENTITY(1,1) NOT NULL,
	[QualificationName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Qualifications] PRIMARY KEY CLUSTERED 
(
	[QualificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Relationships]    Script Date: 10/5/2021 10:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relationships](
	[RelationshipID] [int] IDENTITY(1,1) NOT NULL,
	[RelationshipName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Relationships] PRIMARY KEY CLUSTERED 
(
	[RelationshipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchoolCourses]    Script Date: 10/5/2021 10:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolCourses](
	[CourseOfStudyID] [int] IDENTITY(1,1) NOT NULL,
	[CourseOfStudyName] [nvarchar](300) NOT NULL,
	[CourseFee] [decimal](18, 2) NULL,
	[DurationInMonths] [int] NOT NULL,
 CONSTRAINT [PK_SchoolCourses] PRIMARY KEY CLUSTERED 
(
	[CourseOfStudyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 10/5/2021 10:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentBiodata]    Script Date: 10/5/2021 10:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentBiodata](
	[BiodataID] [bigint] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[OtherNames] [nvarchar](101) NULL,
	[ContactAddress] [ntext] NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[GenderID] [int] NOT NULL,
	[StateOfOriginID] [int] NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[EmailAddress] [nvarchar](50) NOT NULL,
	[FacebookID] [nvarchar](50) NULL,
	[Picture] [nvarchar](max) NULL,
 CONSTRAINT [PK_StudentBiodata] PRIMARY KEY CLUSTERED 
(
	[BiodataID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentCoursePayments]    Script Date: 10/5/2021 10:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCoursePayments](
	[PaymentID] [bigint] IDENTITY(1,1) NOT NULL,
	[BiodataID] [bigint] NOT NULL,
	[CourseOfStudyID] [int] NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[CourseFee] [decimal](18, 2) NOT NULL,
	[AmountPaid] [decimal](18, 2) NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_StudentCoursePayments] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentCourseRegistrations]    Script Date: 10/5/2021 10:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourseRegistrations](
	[CourseRegistrationID] [bigint] IDENTITY(1,1) NOT NULL,
	[BiodataID] [bigint] NOT NULL,
	[CourseOfStudyID] [int] NOT NULL,
	[StudySessionID] [int] NOT NULL,
	[IsPrivateStudent] [bit] NULL,
	[PrivateTrainingVenue] [ntext] NULL,
	[PrivateTrainingTime] [nvarchar](50) NULL,
	[Signature] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_StudentCourseRegistrations] PRIMARY KEY CLUSTERED 
(
	[CourseRegistrationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentEducationHistories]    Script Date: 10/5/2021 10:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentEducationHistories](
	[EducationRecordID] [bigint] IDENTITY(1,1) NOT NULL,
	[BiodataID] [bigint] NOT NULL,
	[NameOfInstitution] [nvarchar](350) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NULL,
	[QualificationObtainedID] [int] NOT NULL,
 CONSTRAINT [PK_StudentEducationHistories] PRIMARY KEY CLUSTERED 
(
	[EducationRecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudySessions]    Script Date: 10/5/2021 10:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudySessions](
	[StudySessionID] [int] IDENTITY(1,1) NOT NULL,
	[StudySessionName] [nvarchar](50) NOT NULL,
	[Time] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StudySessions] PRIMARY KEY CLUSTERED 
(
	[StudySessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'5.0.1')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211005171859_ExtendApplicationUser', N'5.0.1')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'15475467-922d-461f-878f-148906d121ca', N'Accountant', N'ACCOUNTANT', N'69689515-2b0a-47b0-9df8-852875314714')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'42e962d9-9a16-4fec-81c3-0e359e92c448', N'Lecturer', N'LECTURER', N'fbbe081f-4646-48c6-9513-d184a5fef9ef')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'57070843-3e96-44b0-80b6-45f853394771', N'SuperAdmin', N'SUPERADMIN', N'aa007315-0bab-4a11-8902-6ce4f27440bc')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ea19ee21-770f-439f-b42d-6e9b4925ac17', N'15475467-922d-461f-878f-148906d121ca')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'053ddd7a-becf-411a-97e0-4e4b0e825993', N'42e962d9-9a16-4fec-81c3-0e359e92c448')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a1b7b174-f27a-417c-8efe-6aba55b0244b', N'57070843-3e96-44b0-80b6-45f853394771')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [GenderID], [LastName], [MiddleName], [Picture]) VALUES (N'053ddd7a-becf-411a-97e0-4e4b0e825993', N'ogunstate@october1.com', N'OGUNSTATE@OCTOBER1.COM', N'ogunstate@october1.com', N'OGUNSTATE@OCTOBER1.COM', 0, N'AQAAAAEAACcQAAAAELK4dV2TcKUKc8/d9PqHv/MiOXiYpNMnXraRmKwZ5tSNsyoF5+qE0vgC8DDaEpN0vQ==', N'AEHKXXJ3LAQJMDT4CAJE5JU7MRIJJJ7Q', N'bcf40c0d-9e1a-491b-934a-7ad04adf9e0e', NULL, 0, 0, NULL, 1, 0, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [GenderID], [LastName], [MiddleName], [Picture]) VALUES (N'a1b7b174-f27a-417c-8efe-6aba55b0244b', N'nigeria@october1.com', N'NIGERIA@OCTOBER1.COM', N'nigeria@october1.com', N'NIGERIA@OCTOBER1.COM', 0, N'AQAAAAEAACcQAAAAEAZIfV2KgNwUoC0xdzQTvehcS+TXUcR4RI+6ddywjk95/i4ZNAx9li9jNQXlPkFzHg==', N'22HMFZSP7X7H3E6ZNBCXO25AWPL6JD73', N'ed3eea7e-afbf-486a-b46a-2e694d61dd03', NULL, 0, 0, NULL, 1, 0, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [GenderID], [LastName], [MiddleName], [Picture]) VALUES (N'ea19ee21-770f-439f-b42d-6e9b4925ac17', N'deltastate@october1.com', N'DELTASTATE@OCTOBER1.COM', N'deltastate@october1.com', N'DELTASTATE@OCTOBER1.COM', 0, N'AQAAAAEAACcQAAAAEDX5kU4i1wfHI3La6J2PIK6riDWj1wX1DhJW4h7oexVh+aHrLhpf9B6ErmMtqJdPPw==', N'PD4KAEQVZRSFJ5Z2IQCJWO6J2GJ6B6XI', N'ad19a35b-9dbd-4102-9d27-a79160735308', NULL, 0, 0, NULL, 1, 0, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Genders] ON 
GO
INSERT [dbo].[Genders] ([GenderID], [GenderName]) VALUES (2, N'Female')
GO
INSERT [dbo].[Genders] ([GenderID], [GenderName]) VALUES (1, N'Male')
GO
SET IDENTITY_INSERT [dbo].[Genders] OFF
GO
SET IDENTITY_INSERT [dbo].[Qualifications] ON 
GO
INSERT [dbo].[Qualifications] ([QualificationID], [QualificationName]) VALUES (4, N'First Degree')
GO
INSERT [dbo].[Qualifications] ([QualificationID], [QualificationName]) VALUES (3, N'HND')
GO
INSERT [dbo].[Qualifications] ([QualificationID], [QualificationName]) VALUES (5, N'ND')
GO
INSERT [dbo].[Qualifications] ([QualificationID], [QualificationName]) VALUES (2, N'Primary School Leaving Certificate')
GO
INSERT [dbo].[Qualifications] ([QualificationID], [QualificationName]) VALUES (1, N'SSCE')
GO
SET IDENTITY_INSERT [dbo].[Qualifications] OFF
GO
SET IDENTITY_INSERT [dbo].[Relationships] ON 
GO
INSERT [dbo].[Relationships] ([RelationshipID], [RelationshipName]) VALUES (2, N'Brother')
GO
INSERT [dbo].[Relationships] ([RelationshipID], [RelationshipName]) VALUES (4, N'Father')
GO
INSERT [dbo].[Relationships] ([RelationshipID], [RelationshipName]) VALUES (5, N'Friend')
GO
INSERT [dbo].[Relationships] ([RelationshipID], [RelationshipName]) VALUES (3, N'Mother')
GO
INSERT [dbo].[Relationships] ([RelationshipID], [RelationshipName]) VALUES (1, N'Wife')
GO
SET IDENTITY_INSERT [dbo].[Relationships] OFF
GO
SET IDENTITY_INSERT [dbo].[SchoolCourses] ON 
GO
INSERT [dbo].[SchoolCourses] ([CourseOfStudyID], [CourseOfStudyName], [CourseFee], [DurationInMonths]) VALUES (1, N'Introduction To App Development Using RADZEN', CAST(150000.00 AS Decimal(18, 2)), 6)
GO
INSERT [dbo].[SchoolCourses] ([CourseOfStudyID], [CourseOfStudyName], [CourseFee], [DurationInMonths]) VALUES (2, N'Introduction To C# Programming Language', CAST(80000.00 AS Decimal(18, 2)), 3)
GO
INSERT [dbo].[SchoolCourses] ([CourseOfStudyID], [CourseOfStudyName], [CourseFee], [DurationInMonths]) VALUES (3, N'Database Design And Development Using Microsoft SQL SERVER', CAST(70000.00 AS Decimal(18, 2)), 2)
GO
SET IDENTITY_INSERT [dbo].[SchoolCourses] OFF
GO
SET IDENTITY_INSERT [dbo].[States] ON 
GO
INSERT [dbo].[States] ([StateID], [StateName]) VALUES (3, N'Enugu')
GO
INSERT [dbo].[States] ([StateID], [StateName]) VALUES (2, N'Kano')
GO
INSERT [dbo].[States] ([StateID], [StateName]) VALUES (1, N'Lagos')
GO
SET IDENTITY_INSERT [dbo].[States] OFF
GO
SET IDENTITY_INSERT [dbo].[StudySessions] ON 
GO
INSERT [dbo].[StudySessions] ([StudySessionID], [StudySessionName], [Time]) VALUES (1, N'Morning', N'9 A.M.-12.00 P.M.')
GO
INSERT [dbo].[StudySessions] ([StudySessionID], [StudySessionName], [Time]) VALUES (2, N'Afternoon', N'12:30 P.M.-3.30 P.M.')
GO
INSERT [dbo].[StudySessions] ([StudySessionID], [StudySessionName], [Time]) VALUES (3, N'Evening', N'4 P.M.-7 P.M.')
GO
SET IDENTITY_INSERT [dbo].[StudySessions] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 10/5/2021 10:44:25 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 10/5/2021 10:44:25 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 10/5/2021 10:44:25 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 10/5/2021 10:44:25 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 10/5/2021 10:44:25 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 10/5/2021 10:44:25 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 10/5/2021 10:44:25 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DeviceCodes_DeviceCode]    Script Date: 10/5/2021 10:44:25 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DeviceCodes_DeviceCode] ON [dbo].[DeviceCodes]
(
	[DeviceCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DeviceCodes_Expiration]    Script Date: 10/5/2021 10:44:25 AM ******/
CREATE NONCLUSTERED INDEX [IX_DeviceCodes_Expiration] ON [dbo].[DeviceCodes]
(
	[Expiration] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Genders]    Script Date: 10/5/2021 10:44:25 AM ******/
ALTER TABLE [dbo].[Genders] ADD  CONSTRAINT [IX_Genders] UNIQUE NONCLUSTERED 
(
	[GenderName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersistedGrants_Expiration]    Script Date: 10/5/2021 10:44:25 AM ******/
CREATE NONCLUSTERED INDEX [IX_PersistedGrants_Expiration] ON [dbo].[PersistedGrants]
(
	[Expiration] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PersistedGrants_SubjectId_ClientId_Type]    Script Date: 10/5/2021 10:44:25 AM ******/
CREATE NONCLUSTERED INDEX [IX_PersistedGrants_SubjectId_ClientId_Type] ON [dbo].[PersistedGrants]
(
	[SubjectId] ASC,
	[ClientId] ASC,
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Qualifications]    Script Date: 10/5/2021 10:44:25 AM ******/
ALTER TABLE [dbo].[Qualifications] ADD  CONSTRAINT [IX_Qualifications] UNIQUE NONCLUSTERED 
(
	[QualificationName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Relationships]    Script Date: 10/5/2021 10:44:25 AM ******/
ALTER TABLE [dbo].[Relationships] ADD  CONSTRAINT [IX_Relationships] UNIQUE NONCLUSTERED 
(
	[RelationshipName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SchoolCourses]    Script Date: 10/5/2021 10:44:25 AM ******/
ALTER TABLE [dbo].[SchoolCourses] ADD  CONSTRAINT [IX_SchoolCourses] UNIQUE NONCLUSTERED 
(
	[CourseOfStudyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_States]    Script Date: 10/5/2021 10:44:25 AM ******/
ALTER TABLE [dbo].[States] ADD  CONSTRAINT [IX_States] UNIQUE NONCLUSTERED 
(
	[StateName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_StudySessions]    Script Date: 10/5/2021 10:44:25 AM ******/
ALTER TABLE [dbo].[StudySessions] ADD  CONSTRAINT [IX_StudySessions] UNIQUE NONCLUSTERED 
(
	[StudySessionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
ALTER TABLE [dbo].[NextOfKins]  WITH CHECK ADD  CONSTRAINT [FK_NextOfKins_Relationships] FOREIGN KEY([RelationshipID])
REFERENCES [dbo].[Relationships] ([RelationshipID])
GO
ALTER TABLE [dbo].[NextOfKins] CHECK CONSTRAINT [FK_NextOfKins_Relationships]
GO
ALTER TABLE [dbo].[NextOfKins]  WITH CHECK ADD  CONSTRAINT [FK_NextOfKins_StudentBiodata] FOREIGN KEY([BiodataID])
REFERENCES [dbo].[StudentBiodata] ([BiodataID])
GO
ALTER TABLE [dbo].[NextOfKins] CHECK CONSTRAINT [FK_NextOfKins_StudentBiodata]
GO
ALTER TABLE [dbo].[StudentBiodata]  WITH CHECK ADD  CONSTRAINT [FK_StudentBiodata_Genders] FOREIGN KEY([GenderID])
REFERENCES [dbo].[Genders] ([GenderID])
GO
ALTER TABLE [dbo].[StudentBiodata] CHECK CONSTRAINT [FK_StudentBiodata_Genders]
GO
ALTER TABLE [dbo].[StudentBiodata]  WITH CHECK ADD  CONSTRAINT [FK_StudentBiodata_States] FOREIGN KEY([StateOfOriginID])
REFERENCES [dbo].[States] ([StateID])
GO
ALTER TABLE [dbo].[StudentBiodata] CHECK CONSTRAINT [FK_StudentBiodata_States]
GO
ALTER TABLE [dbo].[StudentCoursePayments]  WITH CHECK ADD  CONSTRAINT [FK_StudentCoursePayments_SchoolCourses] FOREIGN KEY([CourseOfStudyID])
REFERENCES [dbo].[SchoolCourses] ([CourseOfStudyID])
GO
ALTER TABLE [dbo].[StudentCoursePayments] CHECK CONSTRAINT [FK_StudentCoursePayments_SchoolCourses]
GO
ALTER TABLE [dbo].[StudentCoursePayments]  WITH CHECK ADD  CONSTRAINT [FK_StudentCoursePayments_StudentBiodata] FOREIGN KEY([BiodataID])
REFERENCES [dbo].[StudentBiodata] ([BiodataID])
GO
ALTER TABLE [dbo].[StudentCoursePayments] CHECK CONSTRAINT [FK_StudentCoursePayments_StudentBiodata]
GO
ALTER TABLE [dbo].[StudentCourseRegistrations]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourseRegistrations_SchoolCourses] FOREIGN KEY([CourseOfStudyID])
REFERENCES [dbo].[SchoolCourses] ([CourseOfStudyID])
GO
ALTER TABLE [dbo].[StudentCourseRegistrations] CHECK CONSTRAINT [FK_StudentCourseRegistrations_SchoolCourses]
GO
ALTER TABLE [dbo].[StudentCourseRegistrations]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourseRegistrations_StudentBiodata] FOREIGN KEY([BiodataID])
REFERENCES [dbo].[StudentBiodata] ([BiodataID])
GO
ALTER TABLE [dbo].[StudentCourseRegistrations] CHECK CONSTRAINT [FK_StudentCourseRegistrations_StudentBiodata]
GO
ALTER TABLE [dbo].[StudentCourseRegistrations]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourseRegistrations_StudySessions] FOREIGN KEY([StudySessionID])
REFERENCES [dbo].[StudySessions] ([StudySessionID])
GO
ALTER TABLE [dbo].[StudentCourseRegistrations] CHECK CONSTRAINT [FK_StudentCourseRegistrations_StudySessions]
GO
ALTER TABLE [dbo].[StudentEducationHistories]  WITH CHECK ADD  CONSTRAINT [FK_StudentEducationHistories_Qualifications] FOREIGN KEY([QualificationObtainedID])
REFERENCES [dbo].[Qualifications] ([QualificationID])
GO
ALTER TABLE [dbo].[StudentEducationHistories] CHECK CONSTRAINT [FK_StudentEducationHistories_Qualifications]
GO
ALTER TABLE [dbo].[StudentEducationHistories]  WITH CHECK ADD  CONSTRAINT [FK_StudentEducationHistories_StudentBiodata] FOREIGN KEY([BiodataID])
REFERENCES [dbo].[StudentBiodata] ([BiodataID])
GO
ALTER TABLE [dbo].[StudentEducationHistories] CHECK CONSTRAINT [FK_StudentEducationHistories_StudentBiodata]
GO
USE [master]
GO
ALTER DATABASE [GodswillDB] SET  READ_WRITE 
GO
