
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/13/2014 09:28:26
-- Generated from EDMX file: D:\NEC\Development\ASP\NIDCWA\NIDCWA\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [NECCaptran_Dev];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Module]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Module];
GO
IF OBJECT_ID(N'[dbo].[ModuleDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ModuleDetail];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[RoleDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleDetail];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[ModuleRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ModuleRole];
GO
IF OBJECT_ID(N'[dbo].[RoleUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleUser];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Module'
CREATE TABLE [dbo].[Module] (
    [ID] tinyint IDENTITY(1,1) NOT NULL,
    [Parent] tinyint  NULL,
    [Action] varchar(16)  NULL,
    [Controller] varchar(32)  NULL,
    [Sequence] tinyint  NOT NULL,
    [Visibility] tinyint  NULL
);
GO

-- Creating table 'ModuleDetail'
CREATE TABLE [dbo].[ModuleDetail] (
    [ID] smallint IDENTITY(1,1) NOT NULL,
    [Module] tinyint  NOT NULL,
    [Title] varchar(32)  NOT NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [ID] tinyint  NOT NULL,
    [Active] tinyint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'RoleDetail'
CREATE TABLE [dbo].[RoleDetail] (
    [ID] smallint IDENTITY(1,1) NOT NULL,
    [Role] tinyint  NOT NULL,
    [Name] varchar(32)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Username] varchar(128)  NOT NULL,
    [Password] char(64)  NOT NULL,
    [Active] tinyint  NOT NULL
);
GO

-- Creating table 'ModuleRole'
CREATE TABLE [dbo].[ModuleRole] (
    [Module] tinyint  NOT NULL,
    [Role] tinyint  NOT NULL
);
GO

-- Creating table 'RoleUser'
CREATE TABLE [dbo].[RoleUser] (
    [Role] tinyint  NOT NULL,
    [User] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Module'
ALTER TABLE [dbo].[Module]
ADD CONSTRAINT [PK_Module]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ModuleDetail'
ALTER TABLE [dbo].[ModuleDetail]
ADD CONSTRAINT [PK_ModuleDetail]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RoleDetail'
ALTER TABLE [dbo].[RoleDetail]
ADD CONSTRAINT [PK_RoleDetail]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Module], [Role] in table 'ModuleRole'
ALTER TABLE [dbo].[ModuleRole]
ADD CONSTRAINT [PK_ModuleRole]
    PRIMARY KEY CLUSTERED ([Module], [Role] ASC);
GO

-- Creating primary key on [Role], [User] in table 'RoleUser'
ALTER TABLE [dbo].[RoleUser]
ADD CONSTRAINT [PK_RoleUser]
    PRIMARY KEY CLUSTERED ([Role], [User] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------