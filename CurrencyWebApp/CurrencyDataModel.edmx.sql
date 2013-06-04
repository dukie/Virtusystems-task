
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/17/2012 07:18:53
-- Generated from EDMX file: C:\Users\Pingwin\Documents\Visual Studio 2012\Projects\CurrencyWebApp\CurrencyWebApp\CurrencyDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [exchangerates];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CurrencyRefCurrencyRate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CurrencyRateSet] DROP CONSTRAINT [FK_CurrencyRefCurrencyRate];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CurrencyRefSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CurrencyRefSet];
GO
IF OBJECT_ID(N'[dbo].[CurrencyRateSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CurrencyRateSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CurrencyRefSet'
CREATE TABLE [dbo].[CurrencyRefSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [nominal] decimal(15,2)  NOT NULL,
    [numcode] int  NOT NULL,
    [charcode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CurrencyRateSet'
CREATE TABLE [dbo].[CurrencyRateSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [rate] decimal(15,4)  NOT NULL,
    [date] datetime  NOT NULL,
    [CurrencyRef_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CurrencyRefSet'
ALTER TABLE [dbo].[CurrencyRefSet]
ADD CONSTRAINT [PK_CurrencyRefSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CurrencyRateSet'
ALTER TABLE [dbo].[CurrencyRateSet]
ADD CONSTRAINT [PK_CurrencyRateSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CurrencyRef_Id] in table 'CurrencyRateSet'
ALTER TABLE [dbo].[CurrencyRateSet]
ADD CONSTRAINT [FK_CurrencyRefCurrencyRate]
    FOREIGN KEY ([CurrencyRef_Id])
    REFERENCES [dbo].[CurrencyRefSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CurrencyRefCurrencyRate'
CREATE INDEX [IX_FK_CurrencyRefCurrencyRate]
ON [dbo].[CurrencyRateSet]
    ([CurrencyRef_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------