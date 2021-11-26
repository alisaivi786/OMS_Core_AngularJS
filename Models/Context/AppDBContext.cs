using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Modules> Modules { get; set; }
        public DbSet<SubModules> SubModules  { get; set; }
        public DbSet<Pages> Pages  { get; set; }
        public DbSet<Roles> Roles  { get; set; }
        public DbSet<PagesRolesPolicies> PagesRolesPolicies  { get; set; }
        public DbSet<ThemeSettings> ThemeSettings { get; set; }
        public DbSet<BedSizes> BedSizes { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<DeliveryRoutes> DeliveryRoutes { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderStatuses> OrderStatuses { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<ProductSubCategories> ProductSubCategories { get; set; }
        public DbSet<ProductPhotos> ProductPhotos { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductVarients> ProductVarients { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>();
            modelBuilder.Entity<Modules>();
            modelBuilder.Entity<SubModules>();
            modelBuilder.Entity<Pages>();
            modelBuilder.Entity<Roles>();
            modelBuilder.Entity<PagesRolesPolicies>();
            modelBuilder.Entity<ThemeSettings>();
            modelBuilder.Entity<BedSizes>();
            modelBuilder.Entity<Brands>();
            modelBuilder.Entity<DeliveryRoutes>();
            modelBuilder.Entity<OrderDetails>();
            modelBuilder.Entity<Orders>();
            modelBuilder.Entity<OrderStatuses>();
            modelBuilder.Entity<ProductCategories>();
            modelBuilder.Entity<ProductSubCategories>();
            modelBuilder.Entity<ProductPhotos>();
            modelBuilder.Entity<Products>();
            modelBuilder.Entity<ProductVarients>();
         
        }
    }
}
