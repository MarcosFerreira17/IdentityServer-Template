using IdentityServer.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer.Infrastructure.DataContext.Maps;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.PasswordHash).IsRequired();
        builder.Property(p => p.PasswordSalt).IsRequired();
        builder.Property(p => p.Username).IsRequired();
        builder.Property(p => p.Email);
        builder.Property(p => p.FirstName);
        builder.Property(p => p.LastName);
        builder.HasOne(p => p.Role);
    }
}