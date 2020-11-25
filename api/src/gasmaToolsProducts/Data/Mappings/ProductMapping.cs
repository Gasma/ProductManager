using gasmaToolsProducts.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gasmaToolsProducts.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(c => c.Price)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.UrlPhoto)
               .HasColumnType("varchar(255)");

            builder.Property(c => c.PhotoPublicId)
                .HasColumnType("varchar(255)");

            builder.Property(c => c.CreationTime)
                .IsRequired()
                .HasColumnType("timestamp")
                .ValueGeneratedOnAddOrUpdate();

            builder.ToTable("Products");
        }
    }
}
