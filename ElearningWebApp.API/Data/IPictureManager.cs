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
        Task<bool> Delete(Subjects picture);
        Task<bool> DeleteFromDatabase(List<Subjects> picture);
        bool DeleteFromRoot(List<Subjects> picture);
        bool DeleteFromRoot(Subjects picture);
        Task<Subjects> Update(Subjects picture, IFormFile newPic, string folderName);

    }
}
