using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ELearningWebApp.API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ElearningWebApp.API.Data
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ElearningWebAppdbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public CourseRepository(ElearningWebAppdbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;

        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public SubjectForClass AddImage(IFormFile image, string folderName)
        {
            var subject = new SubjectForClass();
            string path, fileName;

            Save(image, folderName, out path, out fileName);
            subject.FileName = fileName;
            subject.VirtualPath = path;

            if (path == "" & fileName == "")
            {
                return null;
            }

            return subject;
        }

        public void Save(IFormFile Image, string folderName, out string path, out string fileName)
        {
            fileName = "";
            path = "";

            if (Image.Length > 0)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "imgs\\" + folderName);

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                Image.CopyTo(new FileStream(filePath, FileMode.Create));

                fileName = uniqueFileName;
                path = "\\imgs\\" + folderName + "\\" + uniqueFileName;

            }

        }


        public bool DeleteFromRoot(string virtualPath)
        {
            string root = _hostingEnvironment.WebRootPath;

            // Check if file exists with its full path  
            if (File.Exists(root + virtualPath))
            {
                try
                {
                    // If file found, delete it    
                    File.Delete(root + virtualPath);

                }
                catch (IOException)
                {
                    return false;
                }
            }

            return true;

        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);

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
            var chapters = await _context.Chapters.Where(c => c.SubjectForClassId == subjectForClassId).ToListAsync();
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

        public Task<Videos> GetVideoByChapterId(int chapterId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Videos> GetVideoByTopicId(int topicId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> IsExistSubjectName(string name)
        {
            if (await _context.Subjects.AnyAsync(x => x.Name == name))
                return true;

            return false;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> IsExistSubjectNameInClass(int id, string name)
        {
            if (await _context.SubjectForClass.AnyAsync(x => x.SubjectName == name && x.ClassId ==id))
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
            if (await _context.SubjectForClass.AnyAsync(x => x.SubjectId == subjectId && x.ClassId ==classId))
                return true;

            return false;
        }

        public  async Task<Subjects> GetSubjectById(int subjectId)
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

        public async Task<Videos> GetVideo(int id)
        {
            if (await _context.Topics.AnyAsync(v => v.Id == id))
            {
                return await _context.Videos.FirstOrDefaultAsync(v => v.Id == id);
            }

            return null;
        }

    }
}