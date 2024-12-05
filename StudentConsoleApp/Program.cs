using Microsoft.EntityFrameworkCore;
using StudentClassLibrary;
namespace StudentConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Set up the DbContext with options
            var options = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<StudentAndModulesDb>()
                .UseSqlite(@"Data Source=C:\Users\Roisi\OneDrive - Atlantic TU\5sem\richAppDev\week7\Lab6\StudentClassLibrary\students.db")
                .Options;

            using var context = new StudentAndModulesDb(options);
            ////set up SQLite Database
            //var connectionString = builder.Configuration.GetConnectionString("AdvertisementsDB")
            //    ?? "Data Source = ad.db";
            //builder.Services.AddSqlite<AdDb>(connectionString);

            //var student = new Student
            //{
            //    Id = 1,
            //    Name = "John Doe",
            //    Age = 21,
            //    Email = "johndoe@example.com"
            //};

            var student2 = new Student
            {
                Id = 2,
                Name = "Gerry Perry",
                Age = 23,
                Email = "gp@example.com"
            };

            //var module = new Module
            //{
            //    Id = 101,
            //    Name = "Computer Science",
            //    Department = "Engineering",
            //    Lecturer = "Dr. Smith"
            //};

            var module2 = new Module
            {
                Id = 102,
                Name = "Architecture basics",
                Department = "Art & Design",
                Lecturer = "Dr. murphy"
            };

            //context.Students.Add(student);
            context.Students.Add(student2);
            //context.Modules.Add(module);
            context.Modules.Add(module2);
            context.SaveChanges();

            // Query the database to find the existing module with Id = 101
            var existingModule = context.Modules.FirstOrDefault(m => m.Id == 101);

            // Create a relationship between the student and the module
            //var studentModule = new StudentModule
            //{
            //    StudentId = student.Id,
            //    ModuleId = module.Id
            //};

            var studentModule2 = new StudentModule
            {
                StudentId = student2.Id,
                ModuleId = module2.Id
            };

            var studentModule2b = new StudentModule
            {
                StudentId = student2.Id,
                //reference the already created module with id 1
                ModuleId = existingModule.Id
            };

            //context.StudentModules.Add(studentModule);
            context.StudentModules.Add(studentModule2);
            context.StudentModules.Add(studentModule2b);
            context.SaveChanges();

            // Display the data to confirm it was added
            var students = context.Students.ToList();
            foreach (var stud in students)
            {
                Console.WriteLine($"Student: {stud.Name}, Age: {stud.Age}, Email: {stud.Email}");
            }

            var modules = context.Modules.ToList();
            foreach (var mod in modules)
            {
                Console.WriteLine($"Module: {mod.Name}, Department: {mod.Department}, Lecturer: {mod.Lecturer}");
            }

            var studentModules = context.StudentModules.ToList();
            foreach (var sm in studentModules)
            {
                Console.WriteLine($"Student ID: {sm.StudentId} is enrolled in Module ID: {sm.ModuleId}");
            }
        }
    }
}


