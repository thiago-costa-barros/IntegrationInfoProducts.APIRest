--001_Release/001_CreateTableIntegrationSchema.ExternalWebhookReceiver

-- ==========================================
-- Tabela ExternalAuthentication
-- ==========================================
CREATE TABLE "IntegrationSchema"."ExternalAuthentication" (
    "ExternalAuthenticationId" SERIAL PRIMARY KEY,
    "AuthType" INT NOT NULL,
    "AuthKey" VARCHAR(512) NOT NULL,
    "CompanyId" INT NOT NULL,
    "CreationDate" TIMESTAMPTZ DEFAULT now(),
    "UpdateDate" TIMESTAMPTZ DEFAULT now(),
    "CreationUserId" INT NOT NULL,
    "UpdateUserId" INT NOT NULL,
    "DeletionDate" TIMESTAMPTZ DEFAULT NULL,
    CONSTRAINT "UQ_ExternalAuthentication_AuthType_AuthKey"
        UNIQUE ("AuthType", "AuthKey"),
    CONSTRAINT fk_externalauth_company FOREIGN KEY ("CompanyId")
        REFERENCES "CoreSchema"."Company"("CompanyId")
);
