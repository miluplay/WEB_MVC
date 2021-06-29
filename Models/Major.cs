using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Major
    {
        public Major()
        {
            Classes = new HashSet<Class>();
            TeachingPlans = new HashSet<TeachingPlan>();
        }

        public int MajorId { get; set; }
        public string MajorName { get; set; }
        public string CollageName { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<TeachingPlan> TeachingPlans { get; set; }
    }
}
