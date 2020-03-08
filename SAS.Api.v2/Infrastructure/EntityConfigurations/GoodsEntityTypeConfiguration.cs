using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAS.Api.v2.Models;

namespace SAS.Api.v2.Infrastructure.EntityConfigurations
{
    public class GoodsEntityTypeConfiguration : IEntityTypeConfiguration<Goods>
    {
        public void Configure(EntityTypeBuilder<Goods> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("goods");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Category).HasMaxLength(10);
            builder.Property(p => p.GoodsName).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Cost).IsRequired();
        }
    }
}
