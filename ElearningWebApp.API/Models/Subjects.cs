using System;
using System.Collections.Generic;

namespace ELearningWebApp.API.Models
{
    public partial class Subjects
    {
        public Subjects()
        {
            SubjectForSyllabus = new HashSet<SubjectForSyllabus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubjectForSyllabus> SubjectForSyllabus { get; set; }
    }
}
