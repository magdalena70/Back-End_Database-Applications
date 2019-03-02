namespace _05.CodeFirst_Movies.Migrations
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_05.CodeFirst_Movies.MoviesContext>
    {
        public Configuration()
        {
            //this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "_05.CodeFirst_Movies.MoviesContext";
        }

        protected override void Seed(_05.CodeFirst_Movies.MoviesContext context)
        {
            /*if (!context.Users.Any())
            {
                using (StreamReader r = new StreamReader("../../Data/users.json"))
                {
                    string jsonUsers = r.ReadToEnd();
                    //to do
                }


                //context.SaveChanges();
            }*/
        }
    }
}
