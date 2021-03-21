using System;
using System.Collections.Generic;

namespace ELearningWebApp.API.Models
{
    public partial class Class
    {
        public Class()
        {
            Syllabus = new HashSet<Syllabus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Syllabus> Syllabus { get; set; }
    }
}
