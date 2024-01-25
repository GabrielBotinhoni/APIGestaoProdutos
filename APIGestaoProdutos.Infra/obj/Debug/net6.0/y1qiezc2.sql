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

CREATE TABLE [TB_PRODUTO] (
    [CODIGO] int NOT NULL IDENTITY,
    [DESCRICAO] nvarchar(max) NOT NULL,
    [ATIVO] bit NOT NULL,
    [DT_FABRICACAO] datetime2 NULL,
    [DT_VALIDADE] datetime2 NULL,
    [CODIGO_FORNECEDOR] int NULL,
    [DESCRICAO_FORNECEDOR] nvarchar(max) NULL,
    [CNPJ_FORNECEDOR] nvarchar(max) NULL,
    CONSTRAINT [PK_TB_PRODUTO] PRIMARY KEY ([CODIGO])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240125173718_CriandoEstruturaTabela', N'6.0.26');
GO

COMMIT;
GO

