--001_Release/001_CreateTableIntegrationSchema.ExternalWebhookReceiver

USE tc_portfolio;
GO

CREATE TABLE IntegrationSchema.ExternalWebhookReceiver (
    ExternalWebhookReceiverId INT PRIMARY KEY IDENTITY(1,1),
    SourceType INT NOT NULL,
    Status INT NOT NULL,
    CompanyId INT NOT NULL,
    ExternalIdentifier VARCHAR(256) UNIQUE,
    Payload VARCHAR(MAX) NOT NULL, --Payload Json mas convertido para string 
    CreationDate DATETIME2 DEFAULT GETUTCDATE(),
    UpdateDate DATETIME2 DEFAULT GETUTCDATE(),
    CreationUserId INT NOT NULL,
    UpdateUserId INT NOT NULL,
    DeletionDate DATETIME2 DEFAULT NULL,
    FOREIGN KEY (CompanyId) REFERENCES CoreSchema.Company(CompanyId)
);