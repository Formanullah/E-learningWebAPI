using System;
using System.Collections.Generic;

namespace ELearningWebApp.API.Models
{
    public partial class Syllabus
    {
        public Syllabus()
        {
            SubjectForSyllabus = new HashSet<SubjectForSyllabus>();
            Videos = new HashSet<Videos>();
        }

        public int Id { get; set; }
        public string ClassName { get; set; }
        public int ClassId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Class Class { get; set; }
        public virtual ICollection<SubjectForSyllabus> SubjectForSyllabus { get; set; }
        public virtual ICollection<Videos> Videos { get; set; }
    }
}
