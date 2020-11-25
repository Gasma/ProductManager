using FluentValidation.Results;
using gasmaToolsProducts.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace gasmaToolsProducts.Data
{
    public class GasmaToolsContext : DbContext
    {
        public GasmaToolsContext(DbContextOptions<GasmaToolsContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Ignore<ValidationResult>();

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreationTime") != null && entry.Entity.GetType().GetProperty("StartDate") == null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreationTime").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreationTime").IsModified = false;
                }
            }
            try
            {
                var success = await base.SaveChangesAsync() > 0;

                if (!success) throw new Exception("Problem saving changes");
                
                return success;
            }
            catch (Exception e)
            {
                var test = e.Message;

            }
            return false;
        }
    }
}
