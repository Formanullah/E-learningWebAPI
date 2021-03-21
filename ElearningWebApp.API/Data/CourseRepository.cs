using System.Threading.Tasks;
using ELearningWebApp.API.Models;

namespace ElearningWebApp.API.Data
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ElearningWebAppdbContext _context;
        public CourseRepository(ElearningWebAppdbContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);

            _context.Syllabus.SubjectForSyllabus.add();
        }

        public Task<Class> GetAllClasses()
        {
            throw new System.NotImplementedException();
        }

        public Task<Subjects> GetAllSubjects()
        {
            throw new System.NotImplementedException();
        }

        public Task<Chapters> GetChapterBySubjectId(int subjectId)
        {
            throw new System.NotImplementedException();
        }

        public Task<SubjectForSyllabus> GetSubjectsBySyllabusId(int syllabusId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Topics> GetTopicByChapterId(int ChapterId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Videos> GetVideoByChapterId(int chapterId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Videos> GetVideoByTopicId(int topicId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}