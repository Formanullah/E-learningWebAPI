﻿using System;
using System.Collections.Generic;

namespace ELearningWebApp.API.Models
{
    public partial class Videos
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public bool Isfree { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string ClassName { get; set; }
        public int SyllabusId { get; set; }
        public int SubjectForSyllabusId { get; set; }
        public string SubjectName { get; set; }
        public int ChapterId { get; set; }
        public string ChapterName { get; set; }
        public string TopicName { get; set; }
        public int TopicId { get; set; }

        public virtual Chapters Chapter { get; set; }
        public virtual SubjectForSyllabus SubjectForSyllabus { get; set; }
        public virtual Syllabus Syllabus { get; set; }
        public virtual Topics Topic { get; set; }
    }
}
