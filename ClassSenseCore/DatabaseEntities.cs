using ClassSenseCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
//using System.Data.Entity;
using System.Linq;

namespace ClassSenseCore
{
    public class DatabaseEntities : Microsoft.EntityFrameworkCore.DbContext
    {
        // Your context has been configured to use a 'DatabaseEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ClassSense.DatabaseEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DatabaseEntities' 
        // connection string in the application configuration file.
        
        public DatabaseEntities(DbContextOptions<DatabaseEntities> options)
            : base(options)
        {}
         public virtual DbSet<Student> Students { get; set; }
         public virtual DbSet<Attend> Attends { get; set; }
         public virtual DbSet<Course>  Courses { get; set; }
         public virtual DbSet<Enrolled>  Enrolleds { get; set; }
         public virtual DbSet<Images>  Images { get; set; }
         public virtual DbSet<Instructor> Instructors { get; set; }
         public virtual DbSet<Reminder>  Reminders { get; set; }
         public virtual DbSet<Room>  Rooms { get; set; }
         public virtual DbSet<Section>   Sections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define your relationships here
            modelBuilder.Entity<Enrolled>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrolleds)
                .HasForeignKey(e => e.StudentID)
                .IsRequired();

            modelBuilder.Entity<Images>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Images)
                .HasForeignKey(e => e.StudentID)
                .IsRequired();

            modelBuilder.Entity<Attend>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Attends)
                .HasForeignKey(e => e.StudentID)
                .IsRequired();


            // Add other configurations as needed
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}