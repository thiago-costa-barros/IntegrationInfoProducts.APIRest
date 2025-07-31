--001_Rollback_CreateTableIntegrationSchema.ExternalWebhookReceiver

USE tc_portfolio;
GO

IF OBJECT_ID('IntegrationSchema.ExternalWebhookReceiver', 'U') IS NOT NULL
    DROP TABLE IntegrationSchema.ExternalWebhookReceiver;
