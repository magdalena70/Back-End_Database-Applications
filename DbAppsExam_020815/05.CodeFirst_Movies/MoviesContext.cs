namespace _05.CodeFirst_Movies
{
    using _05.CodeFirst_Movies.Migrations;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class MoviesContext : DbContext
    {
        public MoviesContext()
            : base("MoviesContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<MoviesContext,
                    Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder); //Required
        }

         public virtual DbSet<User> Users { get; set; }
         public virtual DbSet<Country> Countries { get; set; }
         public virtual DbSet<Movie> Movies { get; set; }
         public virtual DbSet<Rating> Ratings { get; set; }
    }
}