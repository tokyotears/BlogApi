using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.DataConfigs;

public class BlogPostConfig : IEntityTypeConfiguration<BlogPost>
{
    public void Configure(EntityTypeBuilder<BlogPost> entity)
    {
        entity.HasIndex(p => p.Id);
        entity.Property(p => p.Title).IsRequired();
        entity.Property(p => p.Content).IsRequired();
        entity.Property(p => p.Category).HasConversion<string>().IsRequired();
        entity.Property(p => p.Tags).IsRequired();
    }
}