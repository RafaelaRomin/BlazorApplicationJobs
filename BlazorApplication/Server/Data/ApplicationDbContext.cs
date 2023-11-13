using BlazorApplication.Server.Entities;
using BlazorApplication.Server.Models;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace BlazorApplication.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>(e =>
            {
                e.HasMany(u => u.JobApplications)
               .WithOne()
               .HasForeignKey(ja => ja.UserId);
            });

            builder.Entity<Job>(e =>
            {
                e.HasKey(j => j.Id);
                e.HasMany(j => j.JobApplications)
                .WithOne(ja => ja.Job)
                .HasForeignKey(j => j.JobId);
            });

            builder.Entity<JobApplication>(e =>
            {
                e.HasKey(e => e.Id);
            });

               base.OnModelCreating(builder);
        }

    }
}