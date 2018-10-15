IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Companies] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(150) NOT NULL,
    [EstablishmentYear] int NOT NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Employees] (
    [Id] bigint NOT NULL IDENTITY,
    [FirstName] nvarchar(150) NOT NULL,
    [LastName] nvarchar(150) NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [JobTitle] int NOT NULL,
    [CompanyId] bigint NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Employees_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Employees_CompanyId] ON [Employees] ([CompanyId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181015224236_Init', N'2.1.4-rtm-31024');

GO

