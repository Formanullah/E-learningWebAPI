using System;
using System.Collections.Generic;

namespace ELearningWebApp.API.Models
{
    public partial class SubjectForClass
    {
        public SubjectForClass()
        {
            Chapters = new HashSet<Chapters>();
            Topics = new HashSet<Topics>();
            Videos = new HashSet<Videos>();
        }

        public int Id { get; set; }
        public string SubjectName { get; set; }
        public int SubjectId { get; set; }
        public int ClassId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string FileName { get; set; }
        public string VirtualPath { get; set; }
        public string ClassName { get; set; }

        public virtual Class Class { get; set; }
        public virtual Subjects Subject { get; set; }
        public virtual ICollection<Chapters> Chapters { get; set; }
        public virtual ICollection<Topics> Topics { get; set; }
        public virtual ICollection<Videos> Videos { get; set; }
    }
}
