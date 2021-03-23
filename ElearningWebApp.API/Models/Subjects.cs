using System;
using System.Collections.Generic;

namespace ELearningWebApp.API.Models
{
    public partial class Subjects
    {
        public Subjects()
        {
            SubjectForClass = new HashSet<SubjectForClass>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string VirtualPath { get; set; }

        public virtual ICollection<SubjectForClass> SubjectForClass { get; set; }
    }
}
