using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyFirst.Data.Domain;
using MyFirst.Data.DomainMaps;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyFirst.Data
{
    public class EFDbContext : DbContext
    {

        //static EFDbContext()
        //{
        //    //Database.SetInitializer<EFDbContext>(null);
        //}
        public EFDbContext() : base("EFDefaultConnection")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sys_Menu> Sys_Menus { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new Sys_MenuMap());
            //移除表名为复数
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

        }
    }
}
