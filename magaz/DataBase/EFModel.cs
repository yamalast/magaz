using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace magaz.DataBase
{
    public partial class EFModel : DbContext
    {
        private static EFModel Instains;
        public static EFModel init()
        {
            if (Instains == null)
            {
                Instains = new EFModel();
            }
            return Instains;
        }
        public EFModel()
            : base("name=EFModel")
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(e => e.OrderPoint)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Orders)
                .Map(m => m.ToTable("Products_has_Order").MapRightKey("Products_ProductArticul"));

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductArticul)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductCategory)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.Role_RoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserFN)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserLN)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserMN)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserLogin)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserPassword)
                .IsUnicode(false);
        }
    }
}
