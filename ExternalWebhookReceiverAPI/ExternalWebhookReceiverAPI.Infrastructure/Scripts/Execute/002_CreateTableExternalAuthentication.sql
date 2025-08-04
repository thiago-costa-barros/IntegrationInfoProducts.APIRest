--Release/002_CreateTableExternalAuthentication

USE tc_portfolio
GO

CREATE TABLE IntegrationSchema.ExternalAuthentication (
    ExternalAuthenticationId INT PRIMARY KEY IDENTITY(1,1),
    AuthType INT NOT NULL,
    AuthKey NVARCHAR(512) NOT NULL,
    CompanyId INT NOT NULL,
    CreationDate DATETIME2 DEFAULT GETUTCDATE(),
    UpdateDate DATETIME2 DEFAULT GETUTCDATE(),
    CreationUserId INT NOT NULL,
    UpdateUserId INT NOT NULL,
    DeletionDate DATETIME2 NULL,
    
    CONSTRAINT UQ_ExternalAuthentication_AuthType_AuthKey UNIQUE (AuthType, AuthKey),

    FOREIGN KEY (CompanyId) REFERENCES CoreSchema.Company(CompanyId)
);
GO

-- Índice para leitura rápida via AuthType + AuthKey (mesmo que já seja único, ajuda performance)
CREATE NONCLUSTERED INDEX IX_ExternalAuthentication_AuthType_AuthKey
ON IntegrationSchema.ExternalAuthentication (AuthType, AuthKey, DeletionDate)
INCLUDE (CompanyId, ExternalAuthenticationId);
GO
