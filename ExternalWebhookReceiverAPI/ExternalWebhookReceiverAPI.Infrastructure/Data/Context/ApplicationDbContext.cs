using CommonSolution.Entities.CoreSchema;
using CommonSolution.Entities.IntegrationSchema;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Company> Company { get; set; }
    public DbSet<ExternalWebhookReceiver> ExternalWebhookReceiver { get; set; }
    public DbSet<ExternalAuthentication> ExternalAuthentication { get; set; }
    public DbSet<BusinessUnit> BusinessUnit { get; set; }   
}