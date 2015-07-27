namespace NewsDB.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using NewsDB.Models;
    using NewsDB.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsDB.Data.NewsDBContext>
    {
        public Configuration()
        {
            //this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "NewsDB.Data.NewsDBContext";
        }

        protected override void Seed(NewsDB.Data.NewsDBContext context)
        {
                /*context.NewsItems.AddOrUpdate(
                  n => n.Content,
                  new NewsItem { Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                  new NewsItem { Content = "Sed luctus auctor mi vel ullamcorper." },
                  new NewsItem { Content = "Sed luctus auctor mi vel ullamcorper. Nam scelerisque eget lorem vitae aliquet" },
                  new NewsItem { Content = "Nam scelerisque eget lorem vitae aliquet" },
                  new NewsItem { Content = "Proin mollis felis non leo dignissim, sit amet dignissim felis pretium." },
                  new NewsItem { Content = "Donec nec fringilla erat. Donec quis odio at purus pulvinar semper et vitae quam" }
                );

                context.SaveChanges();*/
            
        }
    }
}
