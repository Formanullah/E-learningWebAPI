using ELearningWebApp.API.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElearningWebApp.API.Data
{
    public interface IPictureManager
    {
        Task<List<Subjects>> Create(List<IFormFile> images, string folderName);
        Task<Subjects> Create(IFormFile image, string folderName);
        void Save(IFormFile Image, string folderName, out string path, out string fileName);
        Task<bool> Delete(SubjectForClass picture);
        Task<bool> DeleteFromDatabase(List<SubjectForClass> picture);
        bool DeleteFromRoot(List<SubjectForClass> picture);
        bool DeleteFromRoot(SubjectForClass picture);
        Task<Subjects> Update(SubjectForClass picture, IFormFile newPic, string folderName);

    }
}
