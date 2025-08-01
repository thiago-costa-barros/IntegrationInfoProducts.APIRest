using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExternalWebhookReceiverAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExternalAuthenticationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var basePath = Path.Combine(AppContext.BaseDirectory, "Scripts/Execute");

            var release = File.ReadAllText(Path.Combine(basePath, "002_CreateTableExternalAuthentication.sql"));

            migrationBuilder.Sql(release);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var basePath = Path.Combine(AppContext.BaseDirectory, "Scripts/Rollback");

            var rollback = File.ReadAllText(Path.Combine(basePath, "001_Rollback_CreateTableExternalAuthentication.sql"));

            migrationBuilder.Sql(rollback);
        }
    }
}
