using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassLibrary
{
    //junction table for student and module as many to many relationship exists
    public class StudentModule
    {
        public int StudentId { get; set; }
        public int ModuleId { get; set; }
        public virtual Student FK_Student { get; set; }
        public virtual Module FK_Module { get; set; }
    }
}
