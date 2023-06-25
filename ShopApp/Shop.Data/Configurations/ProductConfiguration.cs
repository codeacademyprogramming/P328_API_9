using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired(true);
            builder.Property(x => x.SalePrice).HasColumnType("money");
            builder.Property(x => x.DiscountPercent).HasColumnType("money");
            builder.Property(x => x.CostPrice).HasColumnType("money");
            builder.Property(x => x.ImageName).HasMaxLength(100);
        }
    }
}
