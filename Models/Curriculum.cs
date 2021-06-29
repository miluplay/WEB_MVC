using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Curriculum
    {
        public string CourseId { get; set; }
        public string ClassId { get; set; }
        public string TeacherName { get; set; }
        public string CurriculumId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Course Course { get; set; }
    }
}
