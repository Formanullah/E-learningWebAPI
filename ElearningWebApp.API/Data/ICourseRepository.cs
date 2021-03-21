using System.Threading.Tasks;
using ELearningWebApp.API.Models;

namespace ElearningWebApp.API.Data
{
    public interface ICourseRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<Class> GetAllClasses();
         Task<Subjects> GetAllSubjects();
         Task<SubjectForSyllabus> GetSubjectsBySyllabusId(int syllabusId);
         
         Task<Chapters> GetChapterBySubjectId(int subjectId);
         Task<Topics> GetTopicByChapterId(int ChapterId);
         Task<Videos> GetVideoByChapterId(int chapterId);

         Task<Videos> GetVideoByTopicId(int topicId);


    }
}