--Release/002_CreateTableExternalAuthentication

-- ==========================================
-- Tabela ExternalWebhookReceiver
-- ==========================================
CREATE TABLE "IntegrationSchema"."ExternalWebhookReceiver" (
    "ExternalWebhookReceiverId" SERIAL PRIMARY KEY,
    "SourceType" INT NOT NULL,
    "Status" INT NOT NULL,
    "CompanyId" INT NOT NULL,
    "BusinessUnitId" INT NOT NULL,
    "ExternalIdentifier" VARCHAR(256) NOT NULL,
    "Payload" JSONB NOT NULL, -- alterado de VARCHAR(MAX) para JSONB
    "CreationDate" TIMESTAMPTZ DEFAULT now(),
    "UpdateDate" TIMESTAMPTZ DEFAULT now(),
    "CreationUserId" INT NOT NULL,
    "UpdateUserId" INT NOT NULL,
    "DeletionDate" TIMESTAMPTZ DEFAULT NULL,
    CONSTRAINT "UQ_ExternalWebhookReceiver_ExternalIdentifier"
        UNIQUE ("ExternalIdentifier"),
    CONSTRAINT fk_webhookreceiver_company FOREIGN KEY ("CompanyId")
        REFERENCES "CoreSchema"."Company"("CompanyId"),
    CONSTRAINT fk_externalauth_businessunit FOREIGN KEY ("BusinessUnitId")
        REFERENCES "CoreSchema"."BusinessUnit" ("BusinessUnitId")
);