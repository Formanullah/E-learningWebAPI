using System;
using System.Collections.Generic;

namespace ELearningWebApp.API.Models
{
    public partial class Class
    {
        public Class()
        {
            Chapters = new HashSet<Chapters>();
            Students = new HashSet<Students>();
            SubjectForClass = new HashSet<SubjectForClass>();
            Topics = new HashSet<Topics>();
            Videos = new HashSet<Videos>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Chapters> Chapters { get; set; }
        public virtual ICollection<Students> Students { get; set; }
        public virtual ICollection<SubjectForClass> SubjectForClass { get; set; }
        public virtual ICollection<Topics> Topics { get; set; }
        public virtual ICollection<Videos> Videos { get; set; }
    }
}
