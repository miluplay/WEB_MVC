using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class TeachingPlan
    {
        public string Semester { get; set; }
        public int MajorId { get; set; }
        public string CourseId { get; set; }
        public string TeachingPlanId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Major Major { get; set; }
    }
}
