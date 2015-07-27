namespace NewsDB.Data
{
    using NewsDB.Data.Migrations;
    using NewsDB.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class NewsDBContext : DbContext
    {
        
        public NewsDBContext()
            : base("NewsDBContext")
        {
            Database.SetInitializer(new
                MigrateDatabaseToLatestVersion<NewsDBContext, 
                    Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<NewsItem> NewsItems { get; set; }
    }
}