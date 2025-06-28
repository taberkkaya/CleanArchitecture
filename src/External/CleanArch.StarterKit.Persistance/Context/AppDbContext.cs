using CleanArch.StarterKit.Domain.Abstractions;
using CleanArch.StarterKit.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.StarterKit.Persistance.Context;
public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Example> Examples { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries().Where(e => e.Entity is IAuditable);

        foreach (var entry in entries)
        {
            var entity = (IAuditable)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = Guid.Empty;
            }

            if (entry.State == EntityState.Modified)
            {
                entity.UpdatedAt = DateTime.Now;
                entity.UpdatedBy = Guid.Empty;
            }

            if(entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entity.IsDeleted = true;
                entity.DeletedAt = DateTime.Now;
                entity.DeletedBy = Guid.Empty;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
