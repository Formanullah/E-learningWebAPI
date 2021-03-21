using System;
using System.IO;
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

        public Subjects AddImage(IFormFile image, string folderName)
        {
            var subject = new Subjects();
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

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);

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

        public Task<Syllabus> GetSyllabus()

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

        public async Task<bool> IsExistSubject(string name)
        {
            if (await _context.Subjects.AnyAsync(x => x.Name == name))
                return true;

            return false;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}