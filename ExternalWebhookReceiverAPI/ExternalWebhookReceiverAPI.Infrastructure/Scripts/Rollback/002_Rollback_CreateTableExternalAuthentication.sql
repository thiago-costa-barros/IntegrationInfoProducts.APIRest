--Rollback/002_Rolback_CreateTableExternalAuthentication

USE tc_portfolio;
GO

IF OBJECT_ID('IntegrationSchema.ExternalAuthentication', 'U') IS NOT NULL
    DROP TABLE IntegrationSchema.ExternalAuthentication;
