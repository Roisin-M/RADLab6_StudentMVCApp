namespace StudentClassLibrary
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        //a many to many relationship with modules
        // public virtual ICollection<Module> Modules { get; set; } = new List<Module>();
        public virtual ICollection<StudentModule> StudentModules { get; set; } = new List<StudentModule>();

    }
}
