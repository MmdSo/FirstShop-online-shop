using FirstShop.Data.Blogs;
using FirstShop.Data.Products;
using FirstShop.Data.Sales;
using FirstShop.Data.setting;
using FirstShop.Data.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SiteUser> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        public DbSet<ShoppingBasket> shoppingBasket { get; set; }
        public DbSet<ShoppingBasketDetail> shoppingBasketDetail { get; set; }
        public DbSet<InvoiceBody> InvoiceBody { get; set; }
        public DbSet<InvoiceHead> InvoiceHead { get; set; }


        public DbSet<Brand> Brands { get; set; }
        public DbSet<Categories> Category { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Productss> Products { get; set; }
        public DbSet<IProductComment> ProductComment { get; set; }


        public DbSet<Posts> Posts { get; set; }
        public DbSet<PostComments> PostComments { get; set; }
        public DbSet<PostType> PostType { get; set; }

        public DbSet<Contect> Contect { get; set; }
        public DbSet<SendMessage> SendMessage { get; set; }
        public DbSet<SliderPic> SliderPic { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach(var Relation in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                Relation.DeleteBehavior = DeleteBehavior.NoAction;
            }


            builder.Entity<SiteUser>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<Roles>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<Permissions>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<UserRole>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<RolePermission>().HasQueryFilter(e => !e.IsDeleted);
            

            builder.Entity<Productss>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<Brand>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<Color>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<IProductComment>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<Categories>().HasQueryFilter(e => !e.IsDeleted);
            
            
            builder.Entity<ShoppingBasket>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<InvoiceBody>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<InvoiceHead>().HasQueryFilter(e => !e.IsDeleted);
            
            
            builder.Entity<Posts>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<PostType>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<PostComments>().HasQueryFilter(e => !e.IsDeleted);


            builder.Entity<Contect>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<SendMessage>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<SliderPic>().HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
