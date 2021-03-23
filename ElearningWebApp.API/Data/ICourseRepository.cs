using System.Collections.Generic;
using System.Threading.Tasks;
using ELearningWebApp.API.Models;
using Microsoft.AspNetCore.Http;

namespace ElearningWebApp.API.Data
{
    public interface ICourseRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<Class> GetAllClasses();
         Task<ICollection<Subjects>> GetAllSubjects();
         Task<Subjects> GetSubjectById(int subjectId);
         
         Task<Chapters> GetChapterBySubjectId(int subjectId);
         Task<Topics> GetTopicByChapterId(int ChapterId);
         Task<Videos> GetVideoByChapterId(int chapterId);

         Task<Videos> GetVideoByTopicId(int topicId);

         Task<bool> IsExistSubject(int subjectId);
         Task<bool> IsExistSubjectName(string subjectName);
         Task<bool> IsExistSubjectInClass(int classId, int subjectId);
         Task<bool> IsExistSubjectNameInClass(int id, string subjectName);

        SubjectForClass AddImage(IFormFile image, string folderName);


    }
}