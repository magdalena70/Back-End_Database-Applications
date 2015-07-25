namespace StudentSystem.Data
{
    using StudentSystem.Data.Migrations;
    using StudentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentSystemContex : DbContext
    {
        public StudentSystemContex()
            : base("StudentSystemContex")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<StudentSystemContex, 
                    Configuration>());
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
    }
}