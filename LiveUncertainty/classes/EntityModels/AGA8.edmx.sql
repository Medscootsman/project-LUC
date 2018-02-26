
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/26/2018 17:19:53
-- Generated from EDMX file: C:\Users\User\Source\Repos\project-LUC\LiveUncertainty\classes\EntityModels\AGA8.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Uncertainty];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Table4]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Table4];
GO
IF OBJECT_ID(N'[dbo].[Table5]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Table5];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Table5'
CREATE TABLE [dbo].[Table5] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Gasid] nvarchar(max)  NOT NULL,
    [Mr] nvarchar(max)  NOT NULL,
    [Ea] nvarchar(max)  NOT NULL,
    [Ka] nvarchar(max)  NOT NULL,
    [Qa] nvarchar(max)  NOT NULL,
    [S] nvarchar(max)  NULL,
    [Ga] nvarchar(max)  NOT NULL,
    [Fa] nvarchar(max)  NOT NULL,
    [W] nvarchar(max)  NULL
);
GO

-- Creating table 'Table4'
CREATE TABLE [dbo].[Table4] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [a] nvarchar(max)  NOT NULL,
    [b] nvarchar(max)  NOT NULL,
    [c] nvarchar(max)  NOT NULL,
    [k] nvarchar(max)  NOT NULL,
    [u] nvarchar(max)  NOT NULL,
    [g] nvarchar(max)  NOT NULL,
    [q] nvarchar(max)  NOT NULL,
    [f] nvarchar(max)  NOT NULL,
    [s] nvarchar(max)  NOT NULL,
    [w] nvarchar(max)  NOT NULL,
    [Gasid] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Table5'
ALTER TABLE [dbo].[Table5]
ADD CONSTRAINT [PK_Table5]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Table4'
ALTER TABLE [dbo].[Table4]
ADD CONSTRAINT [PK_Table4]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------