using IdentityServer.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer.Infrastructure.DataContext.Maps;
public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.City).IsRequired();
        builder.Property(p => p.Street).IsRequired();
        builder.Property(p => p.ZipCode).IsRequired();
        builder.HasOne(p => p.User).WithMany(p => p.Addresses).HasForeignKey(p => p.UserId);
    }
}