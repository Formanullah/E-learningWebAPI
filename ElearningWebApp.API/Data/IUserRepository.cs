using System.Collections.Generic;
using System.Threading.Tasks;
using ELearningWebApp.API.Models;

namespace ElearningWebApp.API.Data
{
    public interface IUserRepository
    {
         Task<ICollection<Class>> GetAllClasses();
         Task<ICollection<Subjects>> GetAllSubjects();

         Task<ICollection<SubjectForClass>> GetAllSubjectsFromClass(int classId);
         Task<SubjectForClass> GetSubjectFromClass(int Id);
         
         Task<ICollection<Chapters>> GetChaptersBySubjectId(int subjectForClassId);
         Task<Chapters> GetChapter(int chapterId);
         Task<ICollection<Topics>> GetAllTopicByChapterId(int chapterId);
         Task<Topics> GetTopicsById(int topicId);
         Task<ICollection<Videos>> GetVideoBySubjectId(int subjectId);
         Task<ICollection<Topics>> GetTopicsByChapterId(int chapterId);

        
        Task<bool> IsExistClass(int id);
         Task<bool> IsExistSubject(int subjectId);
         Task<bool> IsExistSubjectName(string subjectName);
         Task<bool> IsExistSubjectInClass(int classId, int subjectId);
         Task<bool> IsExistSubjectInClass(int id);
         Task<bool> IsExistSubjectNameInClass(int id, string subjectName);
         Task<bool> IsExistChapter(int chapterId);
         Task<bool> IsExistTopic(int topicId);
    }
}