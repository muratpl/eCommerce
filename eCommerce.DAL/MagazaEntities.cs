namespace eCommerce.DAL
{
    using eCommerce.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class eCommerceEntities : DbContext
    {
        // Your context has been configured to use a 'eCommerceEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'eCommerce.DAL.eCommerceEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'eCommerceEntities' 
        // connection string in the application configuration file.
        public eCommerceEntities()
            : base("name=eCommerceEntities")
        {
            Database.SetInitializer(new MyDb());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Category> Category { get; set; }
         public virtual DbSet<Product> Product { get; set; }
         public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

        //custom database - özel veri tabaný
    public class MyDb: CreateDatabaseIfNotExists<eCommerceEntities>
    {
        protected override void Seed(eCommerceEntities context)
        {
            context.Category.Add(new Category
            {
                 Id = 1,
                 Name ="Sport"
            });

            context.Category.Add(new Category
            {
                Id = 2,
                Name = "Technology"
            });

            context.Product.Add(new Product
            {  
                Id = 1,
                Name = "Ball (Football)",
                CategoryId = 1,
                Price = 45.99,
            });

            context.Product.Add(new Product
            {
                Id = 1,
                Name = "Ball (Basketball)",
                CategoryId = 1,
                Price = 65.99,
            });

            context.Product.Add(new Product
            {
                Id = 1,
                Name = "Iphone 13 Pro Max",
                CategoryId = 2,
                Price = 27999,
            });

            context.Product.Add(new Product
            {
                Id = 1,
                Name = "LG G7 Thinq",
                CategoryId = 2,
                Price = 4999,
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}