namespace ProductsShop
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductShopContext : DbContext
    {
        // Your context has been configured to use a 'ProductShopContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ProductsShop.ProductShopContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ProductShopContext' 
        // connection string in the application configuration file.
        public ProductShopContext()
            : base("name=ProductShopContext")
        {
        }

         public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.Friends)
                .WithMany()
                .Map(configuration =>
                {
                    configuration.MapLeftKey("UserId");
                    configuration.MapRightKey("FriendId");
                    configuration.ToTable("UserFriends");
                    configuration.ToTable("UserFriends");
                });
            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}