using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles"); 
            builder.HasKey(u => u.Id); 
            builder.Property(u => u.Name).HasMaxLength(100).IsRequired();
            builder.Property(u => u.Description).HasMaxLength(500);
           // builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
