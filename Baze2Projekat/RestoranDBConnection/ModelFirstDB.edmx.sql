
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/27/2021 21:33:44
-- Generated from EDMX file: C:\Users\slobo\Desktop\Baze 2\Projekat\New folder\Baze2Projekat\RestoranDBConnection\ModelFirstDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Baze2DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RestoranProizvod_Restoran]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RestoranProizvod] DROP CONSTRAINT [FK_RestoranProizvod_Restoran];
GO
IF OBJECT_ID(N'[dbo].[FK_RestoranProizvod_Proizvod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RestoranProizvod] DROP CONSTRAINT [FK_RestoranProizvod_Proizvod];
GO
IF OBJECT_ID(N'[dbo].[FK_RestoranSto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stolovi] DROP CONSTRAINT [FK_RestoranSto];
GO
IF OBJECT_ID(N'[dbo].[FK_RestoranZaposleni_Restoran]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RestoranZaposleni] DROP CONSTRAINT [FK_RestoranZaposleni_Restoran];
GO
IF OBJECT_ID(N'[dbo].[FK_RestoranZaposleni_Zaposleni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RestoranZaposleni] DROP CONSTRAINT [FK_RestoranZaposleni_Zaposleni];
GO
IF OBJECT_ID(N'[dbo].[FK_StoMusterija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Musterije] DROP CONSTRAINT [FK_StoMusterija];
GO
IF OBJECT_ID(N'[dbo].[FK_ProizvodSprema]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Spremas] DROP CONSTRAINT [FK_ProizvodSprema];
GO
IF OBJECT_ID(N'[dbo].[FK_KuvarSprema]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Spremas] DROP CONSTRAINT [FK_KuvarSprema];
GO
IF OBJECT_ID(N'[dbo].[FK_RestoranGrad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Restorani] DROP CONSTRAINT [FK_RestoranGrad];
GO
IF OBJECT_ID(N'[dbo].[FK_MusterijaSprema]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Spremas] DROP CONSTRAINT [FK_MusterijaSprema];
GO
IF OBJECT_ID(N'[dbo].[FK_Kuvar_inherits_Zaposleni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zaposleni_Kuvar] DROP CONSTRAINT [FK_Kuvar_inherits_Zaposleni];
GO
IF OBJECT_ID(N'[dbo].[FK_Konobar_inherits_Zaposleni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zaposleni_Konobar] DROP CONSTRAINT [FK_Konobar_inherits_Zaposleni];
GO
IF OBJECT_ID(N'[dbo].[FK_Recepcionar_inherits_Zaposleni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zaposleni_Recepcionar] DROP CONSTRAINT [FK_Recepcionar_inherits_Zaposleni];
GO
IF OBJECT_ID(N'[dbo].[FK_Corba_inherits_Proizvod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proizvodi_Corba] DROP CONSTRAINT [FK_Corba_inherits_Proizvod];
GO
IF OBJECT_ID(N'[dbo].[FK_GlavnoJelo_inherits_Proizvod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proizvodi_GlavnoJelo] DROP CONSTRAINT [FK_GlavnoJelo_inherits_Proizvod];
GO
IF OBJECT_ID(N'[dbo].[FK_Salata_inherits_Proizvod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proizvodi_Salata] DROP CONSTRAINT [FK_Salata_inherits_Proizvod];
GO
IF OBJECT_ID(N'[dbo].[FK_Dezert_inherits_Proizvod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proizvodi_Dezert] DROP CONSTRAINT [FK_Dezert_inherits_Proizvod];
GO
IF OBJECT_ID(N'[dbo].[FK_ZaDvoje_inherits_Sto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stolovi_ZaDvoje] DROP CONSTRAINT [FK_ZaDvoje_inherits_Sto];
GO
IF OBJECT_ID(N'[dbo].[FK_ZaCetvoro_inherits_Sto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stolovi_ZaCetvoro] DROP CONSTRAINT [FK_ZaCetvoro_inherits_Sto];
GO
IF OBJECT_ID(N'[dbo].[FK_ZaSestoro_inherits_Sto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stolovi_ZaSestoro] DROP CONSTRAINT [FK_ZaSestoro_inherits_Sto];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Restorani]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Restorani];
GO
IF OBJECT_ID(N'[dbo].[Gradovi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gradovi];
GO
IF OBJECT_ID(N'[dbo].[Proizvodi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proizvodi];
GO
IF OBJECT_ID(N'[dbo].[Stolovi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stolovi];
GO
IF OBJECT_ID(N'[dbo].[Zaposleni]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposleni];
GO
IF OBJECT_ID(N'[dbo].[Musterije]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Musterije];
GO
IF OBJECT_ID(N'[dbo].[Spremas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Spremas];
GO
IF OBJECT_ID(N'[dbo].[Zaposleni_Kuvar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposleni_Kuvar];
GO
IF OBJECT_ID(N'[dbo].[Zaposleni_Konobar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposleni_Konobar];
GO
IF OBJECT_ID(N'[dbo].[Zaposleni_Recepcionar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposleni_Recepcionar];
GO
IF OBJECT_ID(N'[dbo].[Proizvodi_Corba]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proizvodi_Corba];
GO
IF OBJECT_ID(N'[dbo].[Proizvodi_GlavnoJelo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proizvodi_GlavnoJelo];
GO
IF OBJECT_ID(N'[dbo].[Proizvodi_Salata]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proizvodi_Salata];
GO
IF OBJECT_ID(N'[dbo].[Proizvodi_Dezert]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proizvodi_Dezert];
GO
IF OBJECT_ID(N'[dbo].[Stolovi_ZaDvoje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stolovi_ZaDvoje];
GO
IF OBJECT_ID(N'[dbo].[Stolovi_ZaCetvoro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stolovi_ZaCetvoro];
GO
IF OBJECT_ID(N'[dbo].[Stolovi_ZaSestoro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stolovi_ZaSestoro];
GO
IF OBJECT_ID(N'[dbo].[RestoranProizvod]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RestoranProizvod];
GO
IF OBJECT_ID(N'[dbo].[RestoranZaposleni]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RestoranZaposleni];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Restorani'
CREATE TABLE [dbo].[Restorani] (
    [IDRestorana] int  NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [GradPostanskiBroj] int  NOT NULL
);
GO

-- Creating table 'Gradovi'
CREATE TABLE [dbo].[Gradovi] (
    [PostanskiBroj] int  NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Proizvodi'
CREATE TABLE [dbo].[Proizvodi] (
    [Naziv] nvarchar(50)  NOT NULL,
    [Tip] nvarchar(max)  NOT NULL,
    [Cena] int  NOT NULL
);
GO

-- Creating table 'Stolovi'
CREATE TABLE [dbo].[Stolovi] (
    [BrojStola] int IDENTITY(1,1) NOT NULL,
    [BrojMesta] int  NOT NULL,
    [Tip] nvarchar(max)  NOT NULL,
    [RestoranIDRestorana] int  NOT NULL
);
GO

-- Creating table 'Zaposleni'
CREATE TABLE [dbo].[Zaposleni] (
    [JMBG] int  NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [Tip] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Musterije'
CREATE TABLE [dbo].[Musterije] (
    [RedniBroj] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [StoBrojStola] int  NULL,
    [StoRestoranIDRestorana] int  NULL
);
GO

-- Creating table 'Spremas'
CREATE TABLE [dbo].[Spremas] (
    [ProizvodNaziv] nvarchar(50)  NOT NULL,
    [KuvarJMBG] int  NOT NULL,
    [MusterijaRedniBroj] int  NOT NULL
);
GO

-- Creating table 'Zaposleni_Kuvar'
CREATE TABLE [dbo].[Zaposleni_Kuvar] (
    [JMBG] int  NOT NULL
);
GO

-- Creating table 'Zaposleni_Konobar'
CREATE TABLE [dbo].[Zaposleni_Konobar] (
    [JMBG] int  NOT NULL
);
GO

-- Creating table 'Zaposleni_Recepcionar'
CREATE TABLE [dbo].[Zaposleni_Recepcionar] (
    [JMBG] int  NOT NULL
);
GO

-- Creating table 'Proizvodi_Corba'
CREATE TABLE [dbo].[Proizvodi_Corba] (
    [Naziv] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Proizvodi_GlavnoJelo'
CREATE TABLE [dbo].[Proizvodi_GlavnoJelo] (
    [Naziv] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Proizvodi_Salata'
CREATE TABLE [dbo].[Proizvodi_Salata] (
    [Naziv] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Proizvodi_Dezert'
CREATE TABLE [dbo].[Proizvodi_Dezert] (
    [Naziv] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Stolovi_ZaDvoje'
CREATE TABLE [dbo].[Stolovi_ZaDvoje] (
    [BrojStola] int  NOT NULL,
    [RestoranIDRestorana] int  NOT NULL
);
GO

-- Creating table 'Stolovi_ZaCetvoro'
CREATE TABLE [dbo].[Stolovi_ZaCetvoro] (
    [BrojStola] int  NOT NULL,
    [RestoranIDRestorana] int  NOT NULL
);
GO

-- Creating table 'Stolovi_ZaSestoro'
CREATE TABLE [dbo].[Stolovi_ZaSestoro] (
    [BrojStola] int  NOT NULL,
    [RestoranIDRestorana] int  NOT NULL
);
GO

-- Creating table 'RestoranProizvod'
CREATE TABLE [dbo].[RestoranProizvod] (
    [RestoranProizvod_Proizvod_IDRestorana] int  NOT NULL,
    [RestoranProizvod_Restoran_Naziv] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'RestoranZaposleni'
CREATE TABLE [dbo].[RestoranZaposleni] (
    [RestoranZaposleni_Zaposleni_IDRestorana] int  NOT NULL,
    [RestoranZaposleni_Restoran_JMBG] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDRestorana] in table 'Restorani'
ALTER TABLE [dbo].[Restorani]
ADD CONSTRAINT [PK_Restorani]
    PRIMARY KEY CLUSTERED ([IDRestorana] ASC);
GO

-- Creating primary key on [PostanskiBroj] in table 'Gradovi'
ALTER TABLE [dbo].[Gradovi]
ADD CONSTRAINT [PK_Gradovi]
    PRIMARY KEY CLUSTERED ([PostanskiBroj] ASC);
GO

-- Creating primary key on [Naziv] in table 'Proizvodi'
ALTER TABLE [dbo].[Proizvodi]
ADD CONSTRAINT [PK_Proizvodi]
    PRIMARY KEY CLUSTERED ([Naziv] ASC);
GO

-- Creating primary key on [BrojStola], [RestoranIDRestorana] in table 'Stolovi'
ALTER TABLE [dbo].[Stolovi]
ADD CONSTRAINT [PK_Stolovi]
    PRIMARY KEY CLUSTERED ([BrojStola], [RestoranIDRestorana] ASC);
GO

-- Creating primary key on [JMBG] in table 'Zaposleni'
ALTER TABLE [dbo].[Zaposleni]
ADD CONSTRAINT [PK_Zaposleni]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [RedniBroj] in table 'Musterije'
ALTER TABLE [dbo].[Musterije]
ADD CONSTRAINT [PK_Musterije]
    PRIMARY KEY CLUSTERED ([RedniBroj] ASC);
GO

-- Creating primary key on [ProizvodNaziv], [KuvarJMBG] in table 'Spremas'
ALTER TABLE [dbo].[Spremas]
ADD CONSTRAINT [PK_Spremas]
    PRIMARY KEY CLUSTERED ([ProizvodNaziv], [KuvarJMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Zaposleni_Kuvar'
ALTER TABLE [dbo].[Zaposleni_Kuvar]
ADD CONSTRAINT [PK_Zaposleni_Kuvar]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Zaposleni_Konobar'
ALTER TABLE [dbo].[Zaposleni_Konobar]
ADD CONSTRAINT [PK_Zaposleni_Konobar]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Zaposleni_Recepcionar'
ALTER TABLE [dbo].[Zaposleni_Recepcionar]
ADD CONSTRAINT [PK_Zaposleni_Recepcionar]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [Naziv] in table 'Proizvodi_Corba'
ALTER TABLE [dbo].[Proizvodi_Corba]
ADD CONSTRAINT [PK_Proizvodi_Corba]
    PRIMARY KEY CLUSTERED ([Naziv] ASC);
GO

-- Creating primary key on [Naziv] in table 'Proizvodi_GlavnoJelo'
ALTER TABLE [dbo].[Proizvodi_GlavnoJelo]
ADD CONSTRAINT [PK_Proizvodi_GlavnoJelo]
    PRIMARY KEY CLUSTERED ([Naziv] ASC);
GO

-- Creating primary key on [Naziv] in table 'Proizvodi_Salata'
ALTER TABLE [dbo].[Proizvodi_Salata]
ADD CONSTRAINT [PK_Proizvodi_Salata]
    PRIMARY KEY CLUSTERED ([Naziv] ASC);
GO

-- Creating primary key on [Naziv] in table 'Proizvodi_Dezert'
ALTER TABLE [dbo].[Proizvodi_Dezert]
ADD CONSTRAINT [PK_Proizvodi_Dezert]
    PRIMARY KEY CLUSTERED ([Naziv] ASC);
GO

-- Creating primary key on [BrojStola], [RestoranIDRestorana] in table 'Stolovi_ZaDvoje'
ALTER TABLE [dbo].[Stolovi_ZaDvoje]
ADD CONSTRAINT [PK_Stolovi_ZaDvoje]
    PRIMARY KEY CLUSTERED ([BrojStola], [RestoranIDRestorana] ASC);
GO

-- Creating primary key on [BrojStola], [RestoranIDRestorana] in table 'Stolovi_ZaCetvoro'
ALTER TABLE [dbo].[Stolovi_ZaCetvoro]
ADD CONSTRAINT [PK_Stolovi_ZaCetvoro]
    PRIMARY KEY CLUSTERED ([BrojStola], [RestoranIDRestorana] ASC);
GO

-- Creating primary key on [BrojStola], [RestoranIDRestorana] in table 'Stolovi_ZaSestoro'
ALTER TABLE [dbo].[Stolovi_ZaSestoro]
ADD CONSTRAINT [PK_Stolovi_ZaSestoro]
    PRIMARY KEY CLUSTERED ([BrojStola], [RestoranIDRestorana] ASC);
GO

-- Creating primary key on [RestoranProizvod_Proizvod_IDRestorana], [RestoranProizvod_Restoran_Naziv] in table 'RestoranProizvod'
ALTER TABLE [dbo].[RestoranProizvod]
ADD CONSTRAINT [PK_RestoranProizvod]
    PRIMARY KEY CLUSTERED ([RestoranProizvod_Proizvod_IDRestorana], [RestoranProizvod_Restoran_Naziv] ASC);
GO

-- Creating primary key on [RestoranZaposleni_Zaposleni_IDRestorana], [RestoranZaposleni_Restoran_JMBG] in table 'RestoranZaposleni'
ALTER TABLE [dbo].[RestoranZaposleni]
ADD CONSTRAINT [PK_RestoranZaposleni]
    PRIMARY KEY CLUSTERED ([RestoranZaposleni_Zaposleni_IDRestorana], [RestoranZaposleni_Restoran_JMBG] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RestoranProizvod_Proizvod_IDRestorana] in table 'RestoranProizvod'
ALTER TABLE [dbo].[RestoranProizvod]
ADD CONSTRAINT [FK_RestoranProizvod_Restoran]
    FOREIGN KEY ([RestoranProizvod_Proizvod_IDRestorana])
    REFERENCES [dbo].[Restorani]
        ([IDRestorana])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RestoranProizvod_Restoran_Naziv] in table 'RestoranProizvod'
ALTER TABLE [dbo].[RestoranProizvod]
ADD CONSTRAINT [FK_RestoranProizvod_Proizvod]
    FOREIGN KEY ([RestoranProizvod_Restoran_Naziv])
    REFERENCES [dbo].[Proizvodi]
        ([Naziv])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RestoranProizvod_Proizvod'
CREATE INDEX [IX_FK_RestoranProizvod_Proizvod]
ON [dbo].[RestoranProizvod]
    ([RestoranProizvod_Restoran_Naziv]);
GO

-- Creating foreign key on [RestoranIDRestorana] in table 'Stolovi'
ALTER TABLE [dbo].[Stolovi]
ADD CONSTRAINT [FK_RestoranSto]
    FOREIGN KEY ([RestoranIDRestorana])
    REFERENCES [dbo].[Restorani]
        ([IDRestorana])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RestoranSto'
CREATE INDEX [IX_FK_RestoranSto]
ON [dbo].[Stolovi]
    ([RestoranIDRestorana]);
GO

-- Creating foreign key on [RestoranZaposleni_Zaposleni_IDRestorana] in table 'RestoranZaposleni'
ALTER TABLE [dbo].[RestoranZaposleni]
ADD CONSTRAINT [FK_RestoranZaposleni_Restoran]
    FOREIGN KEY ([RestoranZaposleni_Zaposleni_IDRestorana])
    REFERENCES [dbo].[Restorani]
        ([IDRestorana])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RestoranZaposleni_Restoran_JMBG] in table 'RestoranZaposleni'
ALTER TABLE [dbo].[RestoranZaposleni]
ADD CONSTRAINT [FK_RestoranZaposleni_Zaposleni]
    FOREIGN KEY ([RestoranZaposleni_Restoran_JMBG])
    REFERENCES [dbo].[Zaposleni]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RestoranZaposleni_Zaposleni'
CREATE INDEX [IX_FK_RestoranZaposleni_Zaposleni]
ON [dbo].[RestoranZaposleni]
    ([RestoranZaposleni_Restoran_JMBG]);
GO

-- Creating foreign key on [StoBrojStola], [StoRestoranIDRestorana] in table 'Musterije'
ALTER TABLE [dbo].[Musterije]
ADD CONSTRAINT [FK_StoMusterija]
    FOREIGN KEY ([StoBrojStola], [StoRestoranIDRestorana])
    REFERENCES [dbo].[Stolovi]
        ([BrojStola], [RestoranIDRestorana])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StoMusterija'
CREATE INDEX [IX_FK_StoMusterija]
ON [dbo].[Musterije]
    ([StoBrojStola], [StoRestoranIDRestorana]);
GO

-- Creating foreign key on [ProizvodNaziv] in table 'Spremas'
ALTER TABLE [dbo].[Spremas]
ADD CONSTRAINT [FK_ProizvodSprema]
    FOREIGN KEY ([ProizvodNaziv])
    REFERENCES [dbo].[Proizvodi]
        ([Naziv])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [KuvarJMBG] in table 'Spremas'
ALTER TABLE [dbo].[Spremas]
ADD CONSTRAINT [FK_KuvarSprema]
    FOREIGN KEY ([KuvarJMBG])
    REFERENCES [dbo].[Zaposleni_Kuvar]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KuvarSprema'
CREATE INDEX [IX_FK_KuvarSprema]
ON [dbo].[Spremas]
    ([KuvarJMBG]);
GO

-- Creating foreign key on [GradPostanskiBroj] in table 'Restorani'
ALTER TABLE [dbo].[Restorani]
ADD CONSTRAINT [FK_RestoranGrad]
    FOREIGN KEY ([GradPostanskiBroj])
    REFERENCES [dbo].[Gradovi]
        ([PostanskiBroj])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RestoranGrad'
CREATE INDEX [IX_FK_RestoranGrad]
ON [dbo].[Restorani]
    ([GradPostanskiBroj]);
GO

-- Creating foreign key on [MusterijaRedniBroj] in table 'Spremas'
ALTER TABLE [dbo].[Spremas]
ADD CONSTRAINT [FK_MusterijaSprema]
    FOREIGN KEY ([MusterijaRedniBroj])
    REFERENCES [dbo].[Musterije]
        ([RedniBroj])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MusterijaSprema'
CREATE INDEX [IX_FK_MusterijaSprema]
ON [dbo].[Spremas]
    ([MusterijaRedniBroj]);
GO

-- Creating foreign key on [JMBG] in table 'Zaposleni_Kuvar'
ALTER TABLE [dbo].[Zaposleni_Kuvar]
ADD CONSTRAINT [FK_Kuvar_inherits_Zaposleni]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Zaposleni]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Zaposleni_Konobar'
ALTER TABLE [dbo].[Zaposleni_Konobar]
ADD CONSTRAINT [FK_Konobar_inherits_Zaposleni]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Zaposleni]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Zaposleni_Recepcionar'
ALTER TABLE [dbo].[Zaposleni_Recepcionar]
ADD CONSTRAINT [FK_Recepcionar_inherits_Zaposleni]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Zaposleni]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Naziv] in table 'Proizvodi_Corba'
ALTER TABLE [dbo].[Proizvodi_Corba]
ADD CONSTRAINT [FK_Corba_inherits_Proizvod]
    FOREIGN KEY ([Naziv])
    REFERENCES [dbo].[Proizvodi]
        ([Naziv])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Naziv] in table 'Proizvodi_GlavnoJelo'
ALTER TABLE [dbo].[Proizvodi_GlavnoJelo]
ADD CONSTRAINT [FK_GlavnoJelo_inherits_Proizvod]
    FOREIGN KEY ([Naziv])
    REFERENCES [dbo].[Proizvodi]
        ([Naziv])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Naziv] in table 'Proizvodi_Salata'
ALTER TABLE [dbo].[Proizvodi_Salata]
ADD CONSTRAINT [FK_Salata_inherits_Proizvod]
    FOREIGN KEY ([Naziv])
    REFERENCES [dbo].[Proizvodi]
        ([Naziv])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Naziv] in table 'Proizvodi_Dezert'
ALTER TABLE [dbo].[Proizvodi_Dezert]
ADD CONSTRAINT [FK_Dezert_inherits_Proizvod]
    FOREIGN KEY ([Naziv])
    REFERENCES [dbo].[Proizvodi]
        ([Naziv])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [BrojStola], [RestoranIDRestorana] in table 'Stolovi_ZaDvoje'
ALTER TABLE [dbo].[Stolovi_ZaDvoje]
ADD CONSTRAINT [FK_ZaDvoje_inherits_Sto]
    FOREIGN KEY ([BrojStola], [RestoranIDRestorana])
    REFERENCES [dbo].[Stolovi]
        ([BrojStola], [RestoranIDRestorana])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [BrojStola], [RestoranIDRestorana] in table 'Stolovi_ZaCetvoro'
ALTER TABLE [dbo].[Stolovi_ZaCetvoro]
ADD CONSTRAINT [FK_ZaCetvoro_inherits_Sto]
    FOREIGN KEY ([BrojStola], [RestoranIDRestorana])
    REFERENCES [dbo].[Stolovi]
        ([BrojStola], [RestoranIDRestorana])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [BrojStola], [RestoranIDRestorana] in table 'Stolovi_ZaSestoro'
ALTER TABLE [dbo].[Stolovi_ZaSestoro]
ADD CONSTRAINT [FK_ZaSestoro_inherits_Sto]
    FOREIGN KEY ([BrojStola], [RestoranIDRestorana])
    REFERENCES [dbo].[Stolovi]
        ([BrojStola], [RestoranIDRestorana])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------