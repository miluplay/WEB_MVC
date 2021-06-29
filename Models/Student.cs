using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
        }

        public string ClassId { get; set; }
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDay { get; set; }

        public virtual Class Class { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
