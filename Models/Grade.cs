using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Grade
    {
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public int? Grades { get; set; }
        public int? GradesOfMakeup { get; set; }
        public int? GradesOfRepeat { get; set; }
        public string GradesId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
