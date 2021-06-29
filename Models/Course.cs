using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Course
    {
        public Course()
        {
            Curricula = new HashSet<Curriculum>();
            Grades = new HashSet<Grade>();
            TeachingPlans = new HashSet<TeachingPlan>();
        }

        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public int Credit { get; set; }
        public string CourseType { get; set; }

        public virtual ICollection<Curriculum> Curricula { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<TeachingPlan> TeachingPlans { get; set; }
    }
}
