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
    [IconCompany]    VARCHAR(100)           NULL,
    [Job]            NVARCHAR (30)   DEFAULT ('null') NOT NULL,
    [JobName]        NVARCHAR (62)   DEFAULT ('null') NOT NULL,
    [Salary]         DECIMAL (10, 2) DEFAULT ((0.0)) NOT NULL,
    [Experience]     NVARCHAR (100)  DEFAULT ('null') NOT NULL,
    [WorkFormat]     NVARCHAR (100)  DEFAULT ('null') NOT NULL,
    [DatePosted]     VARCHAR (50)    DEFAULT ('null') NOT NULL,
    [Deadline]       VARCHAR (50)    DEFAULT ('null') NOT NULL,
    [JobDescription] TEXT            DEFAULT ('null') NOT NULL,
    [Requirements]   TEXT            DEFAULT ('null') NOT NULL,
    [Benefit]        TEXT            DEFAULT ('null') NOT NULL,
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
    [Id]         VARCHAR (50)  NOT NULL,
    [Avatar]     IMAGE         NULL,
    [JobPos]     NVARCHAR (62) NOT NULL,
    [CareerGoal] TEXT          NOT NULL,
    [Education]  TEXT          NOT NULL,
    [Experience] TEXT          NOT NULL,
    [UploadDate] VARCHAR (50)  NOT NULL,
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


