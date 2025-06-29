using CleanArch.StarterKit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.StarterKit.Persistance.Configurations;
public sealed class ExampleConfiguration : IEntityTypeConfiguration<Example>
{
    public void Configure(EntityTypeBuilder<Example> builder)
    {
        builder.ToTable("Examples");
        builder.HasKey(e => e.Id);
        builder.HasIndex(p => p.Value1);
    }
}
