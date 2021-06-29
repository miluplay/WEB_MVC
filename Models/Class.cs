using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Class
    {
        public Class()
        {
            Curricula = new HashSet<Curriculum>();
            Students = new HashSet<Student>();
        }

        public string ClassId { get; set; }
        public int MajorId { get; set; }
        public string HeadTeacher { get; set; }
        public int StartYear { get; set; }

        public virtual Major Major { get; set; }
        public virtual ICollection<Curriculum> Curricula { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
