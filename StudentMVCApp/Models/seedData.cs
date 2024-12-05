using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentClassLibrary;

namespace StudentMVCApp.Models
{
    public class seedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StudentDb(
       serviceProvider.GetRequiredService<DbContextOptions<StudentDb>>()))
            {
                if (context.Students.Any())
                {
                    return; // DB has been seeded
                }

                // Seed data
                var student1 = new Student { Name = "Alice Johnson", Age = 20, Email = "alice@example.com" };
                var student2 = new Student { Name = "Bob Smith", Age = 21, Email = "bob@example.com" };
                var module1 = new Module { Name = "Mathematics", Department = "Science", Lecturer = "Dr. Smith" };
                var module2 = new Module { Name = "History", Department = "Arts", Lecturer = "Prof. Johnson" };

                context.Students.AddRange(student1, student2);
                context.Modules.AddRange(module1, module2);
                context.SaveChanges();

                // Establish relationships through the StudentModule junction table
                var studentModule1 = new StudentModule
                {
                    StudentId = student1.Id,
                    ModuleId = module1.Id,
                    FK_Student = student1,
                    FK_Module = module1
                };

                var studentModule2 = new StudentModule
                {
                    StudentId = student2.Id,
                    ModuleId = module2.Id,
                    FK_Student = student2,
                    FK_Module = module2
                };

                var studentModule3 = new StudentModule
                {
                    StudentId = student1.Id,
                    ModuleId = module2.Id,
                    FK_Student = student1,
                    FK_Module = module2
                };

                // Add the relationships to the database
                context.StudentModules.AddRange(studentModule1, studentModule2, studentModule3);
                context.SaveChanges();
            }
        }

    }
}

