IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Modules] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [URL] nvarchar(max) NULL,
    [Icon] nvarchar(max) NULL,
    [Sequence] int NOT NULL,
    [CreatedUser] int NOT NULL,
    [CreatedDate] datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    [UpdatedUser] int NOT NULL,
    [UpdatedData] datetime2 NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Modules] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Profiles] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [IsDefault] bit NOT NULL,
    [CreatedUser] int NOT NULL,
    [CreatedDate] datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    [UpdatedUser] int NOT NULL,
    [UpdatedData] datetime2 NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Profiles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ModuleProfiles] (
    [ModuleId] int NOT NULL,
    [ProfileId] int NOT NULL,
    CONSTRAINT [PK_ModuleProfiles] PRIMARY KEY ([ModuleId], [ProfileId]),
    CONSTRAINT [FK_ModuleProfiles_Modules_ModuleId] FOREIGN KEY ([ModuleId]) REFERENCES [Modules] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ModuleProfiles_Profiles_ProfileId] FOREIGN KEY ([ProfileId]) REFERENCES [Profiles] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [Code] nvarchar(max) NULL,
    [IsAuthorised] bit NOT NULL,
    [ProfileId] int NOT NULL,
    [CreatedUser] int NOT NULL,
    [CreatedDate] datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    [UpdatedUser] int NOT NULL,
    [UpdatedData] datetime2 NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Users_Profiles_ProfileId] FOREIGN KEY ([ProfileId]) REFERENCES [Profiles] ([Id]) ON DELETE NO ACTION
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedUser', N'Icon', N'IsActive', N'Name', N'Sequence', N'URL', N'UpdatedData', N'UpdatedUser') AND [object_id] = OBJECT_ID(N'[Modules]'))
    SET IDENTITY_INSERT [Modules] ON;
INSERT INTO [Modules] ([Id], [CreatedUser], [Icon], [IsActive], [Name], [Sequence], [URL], [UpdatedData], [UpdatedUser])
VALUES (1, 0, N'dashboard.png', CAST(1 AS bit), N'Dashboard', 1, N'dashboard', NULL, 0),
(2, 0, N'users.png', CAST(1 AS bit), N'Users', 2, N'users', NULL, 0),
(3, 0, N'accounts.png', CAST(1 AS bit), N'Account', 3, N'accounts', NULL, 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedUser', N'Icon', N'IsActive', N'Name', N'Sequence', N'URL', N'UpdatedData', N'UpdatedUser') AND [object_id] = OBJECT_ID(N'[Modules]'))
    SET IDENTITY_INSERT [Modules] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedUser', N'IsActive', N'IsDefault', N'Name', N'UpdatedData', N'UpdatedUser') AND [object_id] = OBJECT_ID(N'[Profiles]'))
    SET IDENTITY_INSERT [Profiles] ON;
INSERT INTO [Profiles] ([Id], [CreatedUser], [IsActive], [IsDefault], [Name], [UpdatedData], [UpdatedUser])
VALUES (1, 0, CAST(1 AS bit), CAST(0 AS bit), N'Admin', NULL, 0),
(2, 0, CAST(1 AS bit), CAST(1 AS bit), N'User', NULL, 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedUser', N'IsActive', N'IsDefault', N'Name', N'UpdatedData', N'UpdatedUser') AND [object_id] = OBJECT_ID(N'[Profiles]'))
    SET IDENTITY_INSERT [Profiles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ModuleId', N'ProfileId') AND [object_id] = OBJECT_ID(N'[ModuleProfiles]'))
    SET IDENTITY_INSERT [ModuleProfiles] ON;
INSERT INTO [ModuleProfiles] ([ModuleId], [ProfileId])
VALUES (1, 1),
(1, 2),
(2, 1),
(3, 1),
(3, 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ModuleId', N'ProfileId') AND [object_id] = OBJECT_ID(N'[ModuleProfiles]'))
    SET IDENTITY_INSERT [ModuleProfiles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Code', N'CreatedDate', N'CreatedUser', N'Email', N'IsActive', N'IsAuthorised', N'Name', N'Password', N'ProfileId', N'UpdatedData', N'UpdatedUser') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [Code], [CreatedDate], [CreatedUser], [Email], [IsActive], [IsAuthorised], [Name], [Password], [ProfileId], [UpdatedData], [UpdatedUser])
VALUES (1, NULL, '2022-09-29T22:52:27.642', 1, N'admin@template.com', CAST(1 AS bit), CAST(1 AS bit), N'Admin', N'8D66A53A381493BEC08DA23CEF5A43767F20A42C', 1, NULL, 0),
(2, NULL, '2022-09-29T22:52:27.642', 1, N'user@template.com', CAST(1 AS bit), CAST(1 AS bit), N'User', N'8D66A53A381493BEC08DA23CEF5A43767F20A42C', 2, NULL, 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Code', N'CreatedDate', N'CreatedUser', N'Email', N'IsActive', N'IsAuthorised', N'Name', N'Password', N'ProfileId', N'UpdatedData', N'UpdatedUser') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

CREATE INDEX [IX_ModuleProfiles_ProfileId] ON [ModuleProfiles] ([ProfileId]);
GO

CREATE INDEX [IX_Users_ProfileId] ON [Users] ([ProfileId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220930015227_Initial', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [ModuleProfiles];
GO

ALTER TABLE [Usr].[ModuleProfile] DROP CONSTRAINT [PK_ModuleProfile];
GO

DELETE FROM [Usr].[ModuleProfile]
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

DELETE FROM [Usr].[ModuleProfile]
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

DELETE FROM [Usr].[ModuleProfile]
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usr].[ModuleProfile]') AND [c].[name] = N'Id');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Usr].[ModuleProfile] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Usr].[ModuleProfile] DROP COLUMN [Id];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usr].[ModuleProfile]') AND [c].[name] = N'CreatedDate');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Usr].[ModuleProfile] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Usr].[ModuleProfile] DROP COLUMN [CreatedDate];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usr].[ModuleProfile]') AND [c].[name] = N'CreatedUser');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Usr].[ModuleProfile] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Usr].[ModuleProfile] DROP COLUMN [CreatedUser];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usr].[ModuleProfile]') AND [c].[name] = N'Icon');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Usr].[ModuleProfile] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Usr].[ModuleProfile] DROP COLUMN [Icon];
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usr].[ModuleProfile]') AND [c].[name] = N'IsActive');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Usr].[ModuleProfile] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Usr].[ModuleProfile] DROP COLUMN [IsActive];
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usr].[ModuleProfile]') AND [c].[name] = N'Name');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Usr].[ModuleProfile] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Usr].[ModuleProfile] DROP COLUMN [Name];
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usr].[ModuleProfile]') AND [c].[name] = N'URL');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Usr].[ModuleProfile] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Usr].[ModuleProfile] DROP COLUMN [URL];
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usr].[ModuleProfile]') AND [c].[name] = N'UpdatedData');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Usr].[ModuleProfile] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Usr].[ModuleProfile] DROP COLUMN [UpdatedData];
GO

EXEC sp_rename N'[Usr].[ModuleProfile].[UpdatedUser]', N'ProfileId', N'COLUMN';
GO

EXEC sp_rename N'[Usr].[ModuleProfile].[Sequence]', N'ModuleId', N'COLUMN';
GO

ALTER TABLE [Usr].[ModuleProfile] ADD CONSTRAINT [PK_ModuleProfile] PRIMARY KEY ([ModuleId], [ProfileId]);
GO

CREATE TABLE [Usr].[Module] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [URL] nvarchar(max) NULL,
    [Icon] nvarchar(max) NULL,
    [Sequence] int NOT NULL,
    [CreatedUser] int NOT NULL,
    [CreatedDate] datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    [UpdatedUser] int NOT NULL,
    [UpdatedData] datetime2 NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Module] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedUser', N'Icon', N'IsActive', N'Name', N'Sequence', N'URL', N'UpdatedData', N'UpdatedUser') AND [object_id] = OBJECT_ID(N'[Usr].[Module]'))
    SET IDENTITY_INSERT [Usr].[Module] ON;
INSERT INTO [Usr].[Module] ([Id], [CreatedUser], [Icon], [IsActive], [Name], [Sequence], [URL], [UpdatedData], [UpdatedUser])
VALUES (1, 0, N'dashboard.png', CAST(1 AS bit), N'Dashboard', 1, N'dashboard', NULL, 0),
(2, 0, N'users.png', CAST(1 AS bit), N'Users', 2, N'users', NULL, 0),
(3, 0, N'accounts.png', CAST(1 AS bit), N'Account', 3, N'accounts', NULL, 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedUser', N'Icon', N'IsActive', N'Name', N'Sequence', N'URL', N'UpdatedData', N'UpdatedUser') AND [object_id] = OBJECT_ID(N'[Usr].[Module]'))
    SET IDENTITY_INSERT [Usr].[Module] OFF;
GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-07T21:08:33.686'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-07T21:08:33.686'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ModuleId', N'ProfileId') AND [object_id] = OBJECT_ID(N'[Usr].[ModuleProfile]'))
    SET IDENTITY_INSERT [Usr].[ModuleProfile] ON;
INSERT INTO [Usr].[ModuleProfile] ([ModuleId], [ProfileId])
VALUES (1, 1),
(1, 2),
(2, 1),
(3, 1),
(3, 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ModuleId', N'ProfileId') AND [object_id] = OBJECT_ID(N'[Usr].[ModuleProfile]'))
    SET IDENTITY_INSERT [Usr].[ModuleProfile] OFF;
GO

CREATE INDEX [IX_ModuleProfile_ProfileId] ON [Usr].[ModuleProfile] ([ProfileId]);
GO

ALTER TABLE [Usr].[ModuleProfile] ADD CONSTRAINT [FK_ModuleProfile_Module_ModuleId] FOREIGN KEY ([ModuleId]) REFERENCES [Usr].[Module] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [Usr].[ModuleProfile] ADD CONSTRAINT [FK_ModuleProfile_Profile_ProfileId] FOREIGN KEY ([ProfileId]) REFERENCES [Usr].[Profile] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221208000834_MudancaSchema5', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF SCHEMA_ID(N'Loc') IS NULL EXEC(N'CREATE SCHEMA [Loc];');
GO

CREATE TABLE [Loc].[Country] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Name_PT] nvarchar(max) NULL,
    [Initials] nvarchar(max) NULL,
    [BACEN] int NOT NULL,
    [CreatedUser] int NOT NULL,
    [CreatedDate] datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    [UpdatedUser] int NOT NULL,
    [UpdatedData] datetime2 NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Country] PRIMARY KEY ([Id])
);
GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-07T21:27:52.412'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-07T21:27:52.412'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221208002752_Country2', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Loc].[Country]') AND [c].[name] = N'BACEN');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Loc].[Country] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Loc].[Country] DROP COLUMN [BACEN];
GO

CREATE TABLE [Loc].[State] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Initials] nvarchar(max) NULL,
    [CountryId] int NOT NULL,
    [CreatedUser] int NOT NULL,
    [CreatedDate] datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    [UpdatedUser] int NOT NULL,
    [UpdatedData] datetime2 NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_State] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_State_Country_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Loc].[Country] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Loc].[City] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [CountryId] int NOT NULL,
    [StateId] int NOT NULL,
    [CreatedUser] int NOT NULL,
    [CreatedDate] datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    [UpdatedUser] int NOT NULL,
    [UpdatedData] datetime2 NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_City] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_City_Country_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Loc].[Country] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_City_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [Loc].[State] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Loc].[Address] (
    [Id] int NOT NULL IDENTITY,
    [Street] nvarchar(max) NULL,
    [Number] nvarchar(max) NULL,
    [District] nvarchar(max) NULL,
    [Complement] nvarchar(max) NULL,
    [PostalCode] nvarchar(max) NULL,
    [CountryId] int NOT NULL,
    [StateId] int NOT NULL,
    [CityId] int NOT NULL,
    [CreatedUser] int NOT NULL,
    [CreatedDate] datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    [UpdatedUser] int NOT NULL,
    [UpdatedData] datetime2 NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Address] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Address_City_CityId] FOREIGN KEY ([CityId]) REFERENCES [Loc].[City] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Address_Country_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Loc].[Country] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Address_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [Loc].[State] ([Id]) ON DELETE NO ACTION
);
GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-07T23:55:50.305'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-07T23:55:50.305'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_Address_CityId] ON [Loc].[Address] ([CityId]);
GO

CREATE INDEX [IX_Address_CountryId] ON [Loc].[Address] ([CountryId]);
GO

CREATE INDEX [IX_Address_StateId] ON [Loc].[Address] ([StateId]);
GO

CREATE INDEX [IX_City_CountryId] ON [Loc].[City] ([CountryId]);
GO

CREATE INDEX [IX_City_StateId] ON [Loc].[City] ([StateId]);
GO

CREATE INDEX [IX_State_CountryId] ON [Loc].[State] ([CountryId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221208025550_Relation', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF SCHEMA_ID(N'Person') IS NULL EXEC(N'CREATE SCHEMA [Person];');
GO

IF SCHEMA_ID(N'Sales') IS NULL EXEC(N'CREATE SCHEMA [Sales];');
GO

IF SCHEMA_ID(N'Production') IS NULL EXEC(N'CREATE SCHEMA [Production];');
GO

ALTER SCHEMA [Person] TRANSFER [Loc].[Address];
GO

CREATE TABLE [Person].[Company] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [BusinessName] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [AddressId] int NOT NULL,
    [CreatedUser] int NOT NULL,
    [CreatedDate] datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    [UpdatedUser] int NOT NULL,
    [UpdatedData] datetime2 NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Company] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Company_Address_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Person].[Address] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Production].[ProductCategory] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [CreatedUser] int NOT NULL,
    [CreatedDate] datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    [UpdatedUser] int NOT NULL,
    [UpdatedData] datetime2 NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_ProductCategory] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Person].[Contact] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Nickname] nvarchar(max) NULL,
    [Code] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [AddressId] int NOT NULL,
    [CompanyId] int NULL,
    [CreatedUser] int NOT NULL,
    [CreatedDate] datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    [UpdatedUser] int NOT NULL,
    [UpdatedData] datetime2 NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Contact] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contact_Address_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Person].[Address] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Contact_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Person].[Company] ([Id])
);
GO

CREATE TABLE [Sales].[Opportunity] (
    [Id] int NOT NULL IDENTITY,
    [CompanyId] int NOT NULL,
    [ContactId] int NOT NULL,
    [CreatedUser] int NOT NULL,
    [CreatedDate] datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    [UpdatedUser] int NOT NULL,
    [UpdatedData] datetime2 NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Opportunity] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Opportunity_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Person].[Company] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Opportunity_Contact_ContactId] FOREIGN KEY ([ContactId]) REFERENCES [Person].[Contact] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Sales].[ProductCategory] (
    [Id] int NOT NULL IDENTITY,
    [OpportunityId] int NOT NULL,
    [CreatedUser] int NOT NULL,
    [CreatedDate] datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    [UpdatedUser] int NOT NULL,
    [UpdatedData] datetime2 NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_ProductCategory] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductCategory_Opportunity_OpportunityId] FOREIGN KEY ([OpportunityId]) REFERENCES [Sales].[Opportunity] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Production].[Product] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [Price] float NOT NULL,
    [Quantity] int NOT NULL,
    [ProductCategoryId] int NOT NULL,
    [OrderId] int NULL,
    [CreatedUser] int NOT NULL,
    [CreatedDate] datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    [UpdatedUser] int NOT NULL,
    [UpdatedData] datetime2 NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Product_ProductCategory_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Sales].[ProductCategory] ([Id]),
    CONSTRAINT [FK_Product_ProductCategory_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [Production].[ProductCategory] ([Id]) ON DELETE NO ACTION
);
GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-08T00:16:14.610'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-08T00:16:14.610'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_Company_AddressId] ON [Person].[Company] ([AddressId]);
GO

CREATE INDEX [IX_Contact_AddressId] ON [Person].[Contact] ([AddressId]);
GO

CREATE INDEX [IX_Contact_CompanyId] ON [Person].[Contact] ([CompanyId]);
GO

CREATE INDEX [IX_Opportunity_CompanyId] ON [Sales].[Opportunity] ([CompanyId]);
GO

CREATE INDEX [IX_Opportunity_ContactId] ON [Sales].[Opportunity] ([ContactId]);
GO

CREATE INDEX [IX_Product_OrderId] ON [Production].[Product] ([OrderId]);
GO

CREATE INDEX [IX_Product_ProductCategoryId] ON [Production].[Product] ([ProductCategoryId]);
GO

CREATE INDEX [IX_ProductCategory_OpportunityId] ON [Sales].[ProductCategory] ([OpportunityId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221208031616_Relations2', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Production].[Product] DROP CONSTRAINT [FK_Product_ProductCategory_OrderId];
GO

ALTER TABLE [Sales].[ProductCategory] DROP CONSTRAINT [FK_ProductCategory_Opportunity_OpportunityId];
GO

ALTER TABLE [Sales].[ProductCategory] DROP CONSTRAINT [PK_ProductCategory];
GO

EXEC sp_rename N'[Sales].[ProductCategory]', N'Order';
GO

EXEC sp_rename N'[Sales].[Order].[IX_ProductCategory_OpportunityId]', N'IX_Order_OpportunityId', N'INDEX';
GO

ALTER TABLE [Sales].[Order] ADD CONSTRAINT [PK_Order] PRIMARY KEY ([Id]);
GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-08T00:18:31.668'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-08T00:18:31.668'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

ALTER TABLE [Sales].[Order] ADD CONSTRAINT [FK_Order_Opportunity_OpportunityId] FOREIGN KEY ([OpportunityId]) REFERENCES [Sales].[Opportunity] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [Production].[Product] ADD CONSTRAINT [FK_Product_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Sales].[Order] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221208031834_Relations3', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [User].[User] SET [CreatedDate] = '2022-12-09T00:20:15.758'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [User].[User] SET [CreatedDate] = '2022-12-09T00:20:15.758'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221209032018_InventorySalesTables', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [User].[User] SET [CreatedDate] = '2022-12-09T00:20:37.972'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [User].[User] SET [CreatedDate] = '2022-12-09T00:20:37.972'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221209032040_InventorySalesTables2', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF SCHEMA_ID(N'Usr') IS NULL EXEC(N'CREATE SCHEMA [Usr];');
GO

ALTER SCHEMA [Usr] TRANSFER [User].[User];
GO

ALTER SCHEMA [Usr] TRANSFER [User].[Profile];
GO

ALTER SCHEMA [Usr] TRANSFER [User].[ModuleProfile];
GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-09T00:22:38.891'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-09T00:22:38.891'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221209032242_InventorySalesTables3', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER SCHEMA [Usr] TRANSFER [User].[Module];
GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-09T00:23:41.642'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-09T00:23:41.642'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221209032344_InventorySalesTables5', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-09T00:24:48.259'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-09T00:24:48.259'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221209032451_InventorySalesTables6', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-09T00:26:43.839'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-09T00:26:43.839'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221209032647_UpdateDatabaseTables', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-09T00:27:42.864'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-09T00:27:42.864'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221209032745_UpdateDatabaseTables2', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-09T00:28:10.918'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-09T00:28:10.918'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221209032814_UpdateDatabaseTables4', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-09T00:30:06.550'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usr].[User] SET [CreatedDate] = '2022-12-09T00:30:06.550'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221209033009_UpdateDatabaseTables7', N'6.0.9');
GO

COMMIT;
GO

