﻿using System;
using System.Collections.Generic;

namespace ELearningWebApp.API.Models
{
    public partial class Chapters
    {
        public Chapters()
        {
            Topics = new HashSet<Topics>();
            Videos = new HashSet<Videos>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SubjectName { get; set; }
        public int SubjectForSyllabusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual SubjectForSyllabus SubjectForSyllabus { get; set; }
        public virtual ICollection<Topics> Topics { get; set; }
        public virtual ICollection<Videos> Videos { get; set; }
    }
}
