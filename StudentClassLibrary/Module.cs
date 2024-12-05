using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassLibrary
{
    public class Module
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Lecturer { get; set; }
        //many to many relationship with students
        //public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        public virtual ICollection<StudentModule> StudentModules { get; set; } = new List<StudentModule>();
    }
}
