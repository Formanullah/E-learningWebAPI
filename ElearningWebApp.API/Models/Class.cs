using System;
using System.Collections.Generic;

namespace ELearningWebApp.API.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Students>();
            SubjectForClass = new HashSet<SubjectForClass>();
            Videos = new HashSet<Videos>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Students> Students { get; set; }
        public virtual ICollection<SubjectForClass> SubjectForClass { get; set; }
        public virtual ICollection<Videos> Videos { get; set; }
    }
}
