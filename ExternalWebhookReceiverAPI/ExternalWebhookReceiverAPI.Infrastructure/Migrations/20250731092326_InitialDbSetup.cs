using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExternalWebhookReceiverAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var basePath = Path.Combine(AppContext.BaseDirectory, "Scripts/Release");

            var release = File.ReadAllText(Path.Combine(basePath, "001_CreateTableIntegrationSchema.ExternalWebhookReceiver.sql"));

            migrationBuilder.Sql(release);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var basePath = Path.Combine(AppContext.BaseDirectory, "Scripts/Rollback");

            var rollback = File.ReadAllText(Path.Combine(basePath, "001_Rollback_CreateTableIntegrationSchema.ExternalWebhookReceiver.sql"));

            migrationBuilder.Sql(rollback);
        }
    }
}
