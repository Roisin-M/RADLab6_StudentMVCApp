using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassLibrary
{
    public class StudentAndModulesDb:DbContext
    {
        public StudentAndModulesDb() { }
        public StudentAndModulesDb(DbContextOptions<StudentAndModulesDb>options)
        : base(options){ }

        //Dbset properties
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Module> Modules => Set<Module>();
        public DbSet<StudentModule> StudentModules => Set<StudentModule>();

        //Override OnConfiguring to specify the database location
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite(@"Data Source=C:\Users\Roisi\OneDrive - Atlantic TU\5sem\richAppDev\week7\Lab6\StudentClassLibrary\students.db");
            }
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite($"Data Source=C:\\Users\\Roisi\\OneDrive - Atlantic TU\\5sem\\richAppDev\\week7\\Lab6\\StudentClassLibrary\\students.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define composite primary key for the StudentModule table
            modelBuilder.Entity<StudentModule>()
                .HasKey(sm => new { sm.StudentId, sm.ModuleId });

            // Configure relationships
            modelBuilder.Entity<StudentModule>()
                .HasOne(sm => sm.FK_Student)
                .WithMany(s => s.StudentModules)
                .HasForeignKey(sm => sm.StudentId);

            modelBuilder.Entity<StudentModule>()
                .HasOne(sm => sm.FK_Module)
                .WithMany(m => m.StudentModules)
                .HasForeignKey(sm => sm.ModuleId);
        }
    }
}
