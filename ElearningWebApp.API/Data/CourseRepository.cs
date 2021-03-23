using System;
using System.Collections.Generic;
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

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);

        }

        public Task<Class> GetAllClasses()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<Subjects>> GetAllSubjects()
        {
            var subjects = await _context.Subjects.ToListAsync();
            return subjects;
        }

        public Task<Chapters> GetChapterBySubjectId(int subjectId)
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
    }
}