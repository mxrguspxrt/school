
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/09/2014 17:06:56
-- Generated from EDMX file: C:\Users\dte\Documents\Visual Studio 2013\Projects\TripsTraps\Server\Server\DBA\Trips.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [trips];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PlayMove]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MoveSet] DROP CONSTRAINT [FK_PlayMove];
GO
IF OBJECT_ID(N'[dbo].[FK_UserMove]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MoveSet] DROP CONSTRAINT [FK_UserMove];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[PlaySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlaySet];
GO
IF OBJECT_ID(N'[dbo].[MoveSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MoveSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CurrentPlayId] int  NOT NULL,
    [Active] bit  NOT NULL
);
GO

-- Creating table 'PlaySet'
CREATE TABLE [dbo].[PlaySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [MoverUserId] int  NOT NULL
);
GO

-- Creating table 'MoveSet'
CREATE TABLE [dbo].[MoveSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Position] int  NOT NULL,
    [PlayId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlaySet'
ALTER TABLE [dbo].[PlaySet]
ADD CONSTRAINT [PK_PlaySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MoveSet'
ALTER TABLE [dbo].[MoveSet]
ADD CONSTRAINT [PK_MoveSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PlayId] in table 'MoveSet'
ALTER TABLE [dbo].[MoveSet]
ADD CONSTRAINT [FK_PlayMove]
    FOREIGN KEY ([PlayId])
    REFERENCES [dbo].[PlaySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayMove'
CREATE INDEX [IX_FK_PlayMove]
ON [dbo].[MoveSet]
    ([PlayId]);
GO

-- Creating foreign key on [UserId] in table 'MoveSet'
ALTER TABLE [dbo].[MoveSet]
ADD CONSTRAINT [FK_UserMove]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMove'
CREATE INDEX [IX_FK_UserMove]
ON [dbo].[MoveSet]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------