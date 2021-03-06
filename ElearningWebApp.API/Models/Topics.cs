using System;
using System.Collections.Generic;

namespace ELearningWebApp.API.Models
{
    public partial class Topics
    {
        public Topics()
        {
            Videos = new HashSet<Videos>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ChapterName { get; set; }
        public int ChapterId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string SubjctName { get; set; }
        public string ClassName { get; set; }
        public int SubjectIdInClass { get; set; }
        public int ClassId { get; set; }

        public virtual Chapters Chapter { get; set; }
        public virtual Class Class { get; set; }
        public virtual SubjectForClass SubjectIdInClassNavigation { get; set; }
        public virtual ICollection<Videos> Videos { get; set; }
    }
}
