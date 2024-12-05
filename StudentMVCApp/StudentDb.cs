using Microsoft.EntityFrameworkCore;
using StudentClassLibrary;

namespace StudentMVCApp
{
    public class StudentDb: DbContext
    {
        public StudentDb(DbContextOptions<StudentDb> options)
            : base(options) { }
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Module> Modules => Set<Module>();
        public DbSet<StudentModule> StudentModules => Set<StudentModule>();
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


            modelBuilder.Entity<Student>()
               .Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(50);

            modelBuilder.Entity<Module>()
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Student>()
                .Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
