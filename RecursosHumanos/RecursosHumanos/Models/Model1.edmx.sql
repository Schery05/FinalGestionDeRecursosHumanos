
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/08/2019 16:03:06
-- Generated from EDMX file: C:\Users\yamil\Documents\GitHub\FinalGestionDeRecursosHumanos\RecursosHumanos\RecursosHumanos\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PROYECTO_FINAL_BBDD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EmpleadosSet'
CREATE TABLE [dbo].[EmpleadosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo_Empleado] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [Telefono] nvarchar(max)  NOT NULL,
    [Fecha_Ingreso] datetime  NOT NULL,
    [Salario] float  NOT NULL,
    [Estatus] bit  NOT NULL,
    [DepartamentosId] int  NOT NULL,
    [CargosId] int  NOT NULL
);
GO

-- Creating table 'DepartamentosSet'
CREATE TABLE [dbo].[DepartamentosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo_Departamento] int  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CargosSet'
CREATE TABLE [dbo].[CargosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cargo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LicenciasSet'
CREATE TABLE [dbo].[LicenciasSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Desde] datetime  NOT NULL,
    [Hasta] datetime  NOT NULL,
    [Motivo] nvarchar(max)  NOT NULL,
    [Comentario] nvarchar(max)  NOT NULL,
    [EmpleadosId] int  NOT NULL
);
GO

-- Creating table 'Cal_NominaSet'
CREATE TABLE [dbo].[Cal_NominaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ano] nvarchar(max)  NOT NULL,
    [Mes] nvarchar(max)  NOT NULL,
    [Monto_Total] int  NOT NULL,
    [EmpleadosId] int  NOT NULL
);
GO

-- Creating table 'PermisosSet'
CREATE TABLE [dbo].[PermisosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Desde] datetime  NOT NULL,
    [Hasta] datetime  NOT NULL,
    [Comentario] nvarchar(max)  NOT NULL,
    [EmpleadosId] int  NOT NULL
);
GO

-- Creating table 'VacacionesSet'
CREATE TABLE [dbo].[VacacionesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Desde] datetime  NOT NULL,
    [Hasta] datetime  NOT NULL,
    [Ano_Corres] nvarchar(max)  NOT NULL,
    [Comentario] nvarchar(max)  NOT NULL,
    [EmpleadosId] int  NOT NULL
);
GO

-- Creating table 'Salida_EmpleadosSet'
CREATE TABLE [dbo].[Salida_EmpleadosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tipo_Salida] nvarchar(max)  NOT NULL,
    [Motivo] nvarchar(max)  NOT NULL,
    [Fecha_Salida] datetime  NOT NULL,
    [EmpleadosId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'EmpleadosSet'
ALTER TABLE [dbo].[EmpleadosSet]
ADD CONSTRAINT [PK_EmpleadosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DepartamentosSet'
ALTER TABLE [dbo].[DepartamentosSet]
ADD CONSTRAINT [PK_DepartamentosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CargosSet'
ALTER TABLE [dbo].[CargosSet]
ADD CONSTRAINT [PK_CargosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LicenciasSet'
ALTER TABLE [dbo].[LicenciasSet]
ADD CONSTRAINT [PK_LicenciasSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cal_NominaSet'
ALTER TABLE [dbo].[Cal_NominaSet]
ADD CONSTRAINT [PK_Cal_NominaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PermisosSet'
ALTER TABLE [dbo].[PermisosSet]
ADD CONSTRAINT [PK_PermisosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VacacionesSet'
ALTER TABLE [dbo].[VacacionesSet]
ADD CONSTRAINT [PK_VacacionesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Salida_EmpleadosSet'
ALTER TABLE [dbo].[Salida_EmpleadosSet]
ADD CONSTRAINT [PK_Salida_EmpleadosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DepartamentosId] in table 'EmpleadosSet'
ALTER TABLE [dbo].[EmpleadosSet]
ADD CONSTRAINT [FK_DepartamentosEmpleados]
    FOREIGN KEY ([DepartamentosId])
    REFERENCES [dbo].[DepartamentosSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartamentosEmpleados'
CREATE INDEX [IX_FK_DepartamentosEmpleados]
ON [dbo].[EmpleadosSet]
    ([DepartamentosId]);
GO

-- Creating foreign key on [CargosId] in table 'EmpleadosSet'
ALTER TABLE [dbo].[EmpleadosSet]
ADD CONSTRAINT [FK_CargosEmpleados]
    FOREIGN KEY ([CargosId])
    REFERENCES [dbo].[CargosSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CargosEmpleados'
CREATE INDEX [IX_FK_CargosEmpleados]
ON [dbo].[EmpleadosSet]
    ([CargosId]);
GO

-- Creating foreign key on [EmpleadosId] in table 'LicenciasSet'
ALTER TABLE [dbo].[LicenciasSet]
ADD CONSTRAINT [FK_EmpleadosLicencias]
    FOREIGN KEY ([EmpleadosId])
    REFERENCES [dbo].[EmpleadosSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadosLicencias'
CREATE INDEX [IX_FK_EmpleadosLicencias]
ON [dbo].[LicenciasSet]
    ([EmpleadosId]);
GO

-- Creating foreign key on [EmpleadosId] in table 'Cal_NominaSet'
ALTER TABLE [dbo].[Cal_NominaSet]
ADD CONSTRAINT [FK_EmpleadosCal_Nomina]
    FOREIGN KEY ([EmpleadosId])
    REFERENCES [dbo].[EmpleadosSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadosCal_Nomina'
CREATE INDEX [IX_FK_EmpleadosCal_Nomina]
ON [dbo].[Cal_NominaSet]
    ([EmpleadosId]);
GO

-- Creating foreign key on [EmpleadosId] in table 'PermisosSet'
ALTER TABLE [dbo].[PermisosSet]
ADD CONSTRAINT [FK_EmpleadosPermisos]
    FOREIGN KEY ([EmpleadosId])
    REFERENCES [dbo].[EmpleadosSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadosPermisos'
CREATE INDEX [IX_FK_EmpleadosPermisos]
ON [dbo].[PermisosSet]
    ([EmpleadosId]);
GO

-- Creating foreign key on [EmpleadosId] in table 'VacacionesSet'
ALTER TABLE [dbo].[VacacionesSet]
ADD CONSTRAINT [FK_EmpleadosVacaciones]
    FOREIGN KEY ([EmpleadosId])
    REFERENCES [dbo].[EmpleadosSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadosVacaciones'
CREATE INDEX [IX_FK_EmpleadosVacaciones]
ON [dbo].[VacacionesSet]
    ([EmpleadosId]);
GO

-- Creating foreign key on [EmpleadosId] in table 'Salida_EmpleadosSet'
ALTER TABLE [dbo].[Salida_EmpleadosSet]
ADD CONSTRAINT [FK_EmpleadosSalida_Empleados]
    FOREIGN KEY ([EmpleadosId])
    REFERENCES [dbo].[EmpleadosSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadosSalida_Empleados'
CREATE INDEX [IX_FK_EmpleadosSalida_Empleados]
ON [dbo].[Salida_EmpleadosSet]
    ([EmpleadosId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------