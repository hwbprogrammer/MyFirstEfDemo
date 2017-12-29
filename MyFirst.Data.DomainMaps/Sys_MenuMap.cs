using MyFirst.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirst.Data.DomainMaps
{
    public class Sys_MenuMap: EntityTypeConfiguration<Sys_Menu>
    {
        public Sys_MenuMap()
        {
            ToTable("Sys_Menu");
            HasKey(p => p.ID);
            this.Property(p => p.ID)
               .IsRequired()
               .IsFixedLength()
               .HasMaxLength(36);
            this.Property(p => p.M_Name).HasColumnName("M_Name");
            this.Property(p => p.M_ParentCode).HasColumnName("M_ParentCode");
            this.Property(p => p.M_url).HasColumnName("M_url");
            this.Property(p => p.Sort).HasColumnName("Sort");
            this.Property(p => p.CreatTime).HasColumnName("CreatTime");
            this.Property(p => p.UpdateTime).HasColumnName("UpdateTime");

        }
    }
}
