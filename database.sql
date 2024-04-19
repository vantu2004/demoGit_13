CREATE DATABASE WIPR
GO

USE WIPR
GO

CREATE TABLE [dbo].[TAIKHOAN] (
    [Id]           VARCHAR (50) NOT NULL,
    [UserType]     VARCHAR (50) NOT NULL,
    [UserName]     VARCHAR (32) NOT NULL,
    [UserPassword] VARCHAR (32) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([UserName] ASC)
);
GO

-- Nhà tuyển dụng
CREATE TABLE [dbo].[NHATUYENDUNG] (
    [Id]            VARCHAR (50)   NOT NULL,
    [UserType]      VARCHAR (50)   NOT NULL,
    [Fname]         NVARCHAR (62)  NOT NULL,
    [Email]         NVARCHAR (62)  NOT NULL,
    [PhoneNTD]      NVARCHAR (12)  NOT NULL,
    [JobPos]        NVARCHAR (62)  NOT NULL,
    [Company]       NVARCHAR (62)  NOT NULL,
    [JobLocation]   VARCHAR (100)  NOT NULL,
    [SocialNetwork] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[TAIKHOAN] ([Id])
);
GO

--Tin tuyển dụng
CREATE TABLE [dbo].[JobPostings] (
    [IdCompany]      VARCHAR (50)    NOT NULL,
    [IdJobPostings]  VARCHAR (50)    NOT NULL,
    [IconCompany]    VARCHAR (100)   NULL,
    [Job]            NVARCHAR (30)   NULL,
    [JobName]        NVARCHAR (62)   NULL,
    [Salary]         DECIMAL (10, 2) NULL,
    [Experience]     NVARCHAR (100)  NULL,
    [WorkFormat]     NVARCHAR (100)  NULL,
    [DatePosted]     VARCHAR (50)    NULL,
    [Deadline]       VARCHAR (50)    NULL,
    [JobDescription] NTEXT           NULL,
    [Requirements]   NTEXT           NULL,
    [Benefit]        NTEXT           NULL,
    [Activity]       NTEXT           NULL,
    [Award]          NTEXT           NULL,
    [License]        NTEXT           NULL,
    PRIMARY KEY CLUSTERED ([IdCompany] ASC, [IdJobPostings] ASC),
    FOREIGN KEY ([IdCompany]) REFERENCES [dbo].[NHATUYENDUNG] ([Id])
);
GO

-- Ứng viên
CREATE TABLE [dbo].[UNGVIEN] (
    [Id]        VARCHAR (50)   NOT NULL,
    [UserType]  VARCHAR (50)   NOT NULL,
    [Fname]     NVARCHAR (100) NOT NULL,
    [Phone]     VARCHAR (12)   NOT NULL,
    [BirthDate] VARCHAR (50)   NOT NULL,
    [Link]      VARCHAR (100)  NOT NULL,
    [Email]     NVARCHAR (62)  NOT NULL,
    [Address_C] NVARCHAR (100) NOT NULL,
    [Gender]    NVARCHAR (10)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[TAIKHOAN] ([Id])
);
GO

--Bảng các CV
CREATE TABLE [dbo].[CVs] (
    [Id]          VARCHAR (50)  NOT NULL,
    [Avatar]      VARCHAR (100) NULL,
    [JobPos]      NVARCHAR (62) NULL,
    [CareerGoal]  TEXT          NULL,
    [Education]   TEXT          NULL,
    [Experience]  TEXT          NULL,
    [Activity]    TEXT          NULL,
    [Award]       TEXT          NULL,
    [Certificate] TEXT          NULL,
    [UploadDate]  VARCHAR (50)  NULL,
    CONSTRAINT [PK_CVs] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[UNGVIEN] ([Id])
);
GO

--Đơn ứng tuyển
CREATE TABLE [dbo].[Applications] (
    [IdCompany]     VARCHAR (50) NOT NULL,
    [IdJobPostings] VARCHAR (50) NOT NULL,
    [IdCandidate]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdCompany] ASC, [IdJobPostings] ASC, [IdCandidate] ASC),
    FOREIGN KEY ([IdCompany], [IdJobPostings]) REFERENCES [dbo].[JobPostings] ([IdCompany], [IdJobPostings]),
    FOREIGN KEY ([IdCandidate]) REFERENCES [dbo].[UNGVIEN] ([Id])
);
GO

CREATE TABLE [dbo].[DinhDang_rtbx_NTD] (
    [IdCompany]     VARCHAR (50)    NOT NULL,
    [IdJobPostings] VARCHAR (50)    NOT NULL,
    [RtbxStyle]     VARCHAR (100)   DEFAULT ('NULL') NOT NULL,
    [Color]         VARCHAR (100)   DEFAULT ('NULL') NULL,
    [Font]          VARCHAR (100)   DEFAULT ('NULL') NULL,
    [FontStyle]     VARCHAR (100)   DEFAULT ('NULL') NULL,
    [Size]          DECIMAL (10, 2) DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([IdCompany] ASC, [IdJobPostings] ASC, [RtbxStyle] ASC),
    FOREIGN KEY ([IdCompany], [IdJobPostings]) REFERENCES [dbo].[JobPostings] ([IdCompany], [IdJobPostings])
);
GO

CREATE TABLE [dbo].[DinhDang_rtbx_UV] (
    [Id]        VARCHAR (50)    NOT NULL,
    [RtbxStyle] VARCHAR (100)   DEFAULT ('NULL') NOT NULL,
    [Color]     VARCHAR (100)   DEFAULT ('NULL') NULL,
    [Font]      VARCHAR (100)   DEFAULT ('NULL') NULL,
    [FontStyle] VARCHAR (100)   DEFAULT ('NULL') NULL,
    [Size]      DECIMAL (10, 2) DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC, [RtbxStyle] ASC),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[CVs] ([Id])
);
GO

CREATE TABLE [dbo].[Letter] (
    [IdCompany]     VARCHAR (50)  NOT NULL,
    [IdJobPostings] VARCHAR (50)  NOT NULL,
    [IdCandidate]   VARCHAR (50)  NOT NULL,
    [Sender]        VARCHAR (100) NOT NULL,
    [Receiver]      VARCHAR (100) NOT NULL,
    [Title]         VARCHAR (200) NOT NULL,
    [Content]       TEXT          NOT NULL,
    [DateSent]      VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdCompany] ASC, [IdJobPostings] ASC, [IdCandidate] ASC),
    FOREIGN KEY ([IdCompany], [IdJobPostings], [IdCandidate]) REFERENCES [dbo].[Applications] ([IdCompany], [IdJobPostings], [IdCandidate])
);
GO


