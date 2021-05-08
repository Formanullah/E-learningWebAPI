using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELearningWebApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ElearningWebApp.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ElearningWebAppdbContext _context;
        public UserRepository(ElearningWebAppdbContext context)
        {
            _context = context;

        }


        public async Task<ICollection<Class>> GetAllClasses()
        {
            var classes = await _context.Class.ToListAsync();
            return classes;
        }

        public async Task<ICollection<Subjects>> GetAllSubjects()
        {
            var subjects = await _context.Subjects.ToListAsync();
            return subjects;
        }

        public async Task<ICollection<Chapters>> GetChaptersBySubjectId(int subjectForClassId)
        {
            var chapters = await _context.Chapters
            .Where(c =>c.SubjectForClassId == subjectForClassId).AsNoTracking().ToListAsync();
            
            return chapters;
        }


        public async Task<ICollection<Topics>> GetAllTopicByChapterId(int chapterId)
        {
            var topics = await _context.Topics.Where(t => t.ChapterId == chapterId).ToListAsync();
            return topics;
        }

        public async Task<Topics> GetTopicsById(int topicId)
        {
            var topic = await _context.Topics.FindAsync(topicId);
            return topic;
        }

        public async Task<ICollection<Videos>> GetVideoBySubjectId(int subjectId)
        {
            var videos = await _context.Videos.Where(v => v.SubjectForClass.SubjectId == subjectId & v.Isfree == true).ToListAsync();
            return videos;
        }

        public async Task<ICollection<Topics>> GetTopicsByChapterId(int chapterId)
        {
            var topics = await _context.Topics
            .Include(v => v.Videos).Where(c => c.ChapterId == chapterId).AsNoTracking().ToListAsync();
            
            return topics;
        }


        public async Task<bool> IsExistSubjectName(string name)
        {
            if (await _context.Subjects.AnyAsync(x => x.Name == name))
                return true;

            return false;
        }

        public async Task<bool> IsExistSubjectNameInClass(int id, string name)
        {
            if (await _context.SubjectForClass.AnyAsync(x => x.SubjectName == name && x.ClassId == id))
                return true;

            return false;
        }

        public async Task<bool> IsExistSubject(int subjectId)
        {
            if (await _context.Subjects.AnyAsync(x => x.Id == subjectId))
                return true;

            return false;
        }

        public async Task<bool> IsExistSubjectInClass(int classId, int subjectId)
        {
            if (await _context.SubjectForClass.AnyAsync(x => x.SubjectId == subjectId && x.ClassId == classId))
                return true;

            return false;
        }

        public async Task<Subjects> GetSubjectById(int subjectId)
        {
            var subject = await _context.Subjects.FindAsync(subjectId);
            return subject;
        }

        public async Task<ICollection<SubjectForClass>> GetAllSubjectsFromClass(int classId)
        {
            var subjectsFromClass = await _context.SubjectForClass.Where(s => s.ClassId == classId).ToListAsync();
            return subjectsFromClass;
        }

        public async Task<SubjectForClass> GetSubjectFromClass(int Id)
        {
            var subjectFromClass = await _context.SubjectForClass.FirstOrDefaultAsync(s => s.Id == Id);
            return subjectFromClass;
        }

        public async Task<bool> IsExistClass(int id)
        {
            if (await _context.Class.AnyAsync(x => x.Id == id))
                return true;

            return false;
        }

        public async Task<bool> IsExistSubjectInClass(int id)
        {
            if (await _context.SubjectForClass.AnyAsync(x => x.Id == id))
                return true;

            return false;
        }

        public async Task<bool> IsExistChapter(int chapterId)
        {
            if (await _context.Chapters.AnyAsync(x => x.Id == chapterId))
                return true;

            return false;
        }

        public async Task<Chapters> GetChapter(int chapterId)
        {
            var chapter = await _context.Chapters.FirstOrDefaultAsync(c => c.Id == chapterId);
            return chapter;
        }

        public async Task<Class> GetClassById(int id)
        {
            var classFromClass = await _context.Class.FindAsync(id);
            return classFromClass;
        }

        public async Task<bool> IsExistTopic(int topicId)
        {
            if (await _context.Topics.AnyAsync(t => t.Id == topicId))
            {
                return true;
            }

            return false;
        }


    }
}