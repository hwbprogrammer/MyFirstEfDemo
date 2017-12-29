using MyFirst.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirst.Data.DomainMaps
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");
            HasKey(c => c.ID);
            this.Property(p => p.ID)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(36);
            Property(p => p.Name).IsRequired().IsFixedLength().HasMaxLength(56);
            Property(p => p.Price).HasColumnName("Price");
            Property(p => p.Quantity).HasColumnName("Quantity");
        }
    }
}
