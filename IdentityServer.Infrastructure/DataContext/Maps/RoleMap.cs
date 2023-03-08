using IdentityServer.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer.Infrastructure.DataContext.Maps;

public class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Name).IsRequired();
    }
}