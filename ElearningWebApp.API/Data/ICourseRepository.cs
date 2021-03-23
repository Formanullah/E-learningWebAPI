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
         Task<ICollection<Class>> GetAllClasses();
         Task<Class> GetClassById(int id);
         Task<ICollection<Subjects>> GetAllSubjects();
         Task<Subjects> GetSubjectById(int subjectId);

         Task<ICollection<SubjectForClass>> GetAllSubjectsFromClass(int classId);
         Task<SubjectForClass> GetSubjectFromClass(int Id);
         
         Task<ICollection<Chapters>> GetChaptersBySubjectId(int subjectForClassId);
         Task<Chapters> GetChapter(int chapterId);
         Task<Topics> GetTopicByChapterId(int ChapterId);
         Task<Videos> GetVideoByChapterId(int chapterId);

         Task<Videos> GetVideoByTopicId(int topicId);
        
        Task<bool> IsExistClass(int id);
         Task<bool> IsExistSubject(int subjectId);
         Task<bool> IsExistSubjectName(string subjectName);
         Task<bool> IsExistSubjectInClass(int classId, int subjectId);
         Task<bool> IsExistSubjectInClass(int id);
         Task<bool> IsExistSubjectNameInClass(int id, string subjectName);
         Task<bool> IsExistChapter(int chapterId);

        SubjectForClass AddImage(IFormFile image, string folderName);


    }
}