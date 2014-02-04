
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/04/2014 10:16:59
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

IF OBJECT_ID(N'[dbo].[FK_CallerUserConnection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConnectionSet] DROP CONSTRAINT [FK_CallerUserConnection];
GO
IF OBJECT_ID(N'[dbo].[FK_ConnectionGame]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlaySet] DROP CONSTRAINT [FK_ConnectionGame];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayMoveUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayMoveSet] DROP CONSTRAINT [FK_PlayMoveUser];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayMovePlay]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayMoveSet] DROP CONSTRAINT [FK_PlayMovePlay];
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
IF OBJECT_ID(N'[dbo].[ConnectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConnectionSet];
GO
IF OBJECT_ID(N'[dbo].[PlayMoveSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlayMoveSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Waiting] bit  NOT NULL
);
GO

-- Creating table 'PlaySet'
CREATE TABLE [dbo].[PlaySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ConnectionId] int  NOT NULL
);
GO

-- Creating table 'ConnectionSet'
CREATE TABLE [dbo].[ConnectionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CallerUserId] int  NOT NULL,
    [CalledUserId] int  NULL,
    [CurrentPlayId] int  NULL
);
GO

-- Creating table 'PlayMoveSet'
CREATE TABLE [dbo].[PlayMoveSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Position] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL,
    [Play_Id] int  NOT NULL
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

-- Creating primary key on [Id] in table 'ConnectionSet'
ALTER TABLE [dbo].[ConnectionSet]
ADD CONSTRAINT [PK_ConnectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlayMoveSet'
ALTER TABLE [dbo].[PlayMoveSet]
ADD CONSTRAINT [PK_PlayMoveSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CallerUserId] in table 'ConnectionSet'
ALTER TABLE [dbo].[ConnectionSet]
ADD CONSTRAINT [FK_CallerUserConnection]
    FOREIGN KEY ([CallerUserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CallerUserConnection'
CREATE INDEX [IX_FK_CallerUserConnection]
ON [dbo].[ConnectionSet]
    ([CallerUserId]);
GO

-- Creating foreign key on [ConnectionId] in table 'PlaySet'
ALTER TABLE [dbo].[PlaySet]
ADD CONSTRAINT [FK_ConnectionGame]
    FOREIGN KEY ([ConnectionId])
    REFERENCES [dbo].[ConnectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ConnectionGame'
CREATE INDEX [IX_FK_ConnectionGame]
ON [dbo].[PlaySet]
    ([ConnectionId]);
GO

-- Creating foreign key on [UserId] in table 'PlayMoveSet'
ALTER TABLE [dbo].[PlayMoveSet]
ADD CONSTRAINT [FK_PlayMoveUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayMoveUser'
CREATE INDEX [IX_FK_PlayMoveUser]
ON [dbo].[PlayMoveSet]
    ([UserId]);
GO

-- Creating foreign key on [Play_Id] in table 'PlayMoveSet'
ALTER TABLE [dbo].[PlayMoveSet]
ADD CONSTRAINT [FK_PlayMovePlay]
    FOREIGN KEY ([Play_Id])
    REFERENCES [dbo].[PlaySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayMovePlay'
CREATE INDEX [IX_FK_PlayMovePlay]
ON [dbo].[PlayMoveSet]
    ([Play_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------