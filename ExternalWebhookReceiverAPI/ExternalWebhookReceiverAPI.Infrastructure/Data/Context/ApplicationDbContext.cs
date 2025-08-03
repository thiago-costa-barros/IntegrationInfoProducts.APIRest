using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Company> Company { get; set; }
    public DbSet<ExternalWebhookReceiver> ExternalWebhookReceiver { get; set; }
    public DbSet<ExternalAuthentication> ExternalAuthentication { get; set; }
}