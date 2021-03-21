using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MogobariWebAPI.BL.Interface
{
    public interface IPictureManager
    {
        Task<List<Picture>> Create(List<IFormFile> images, string folderName);
        Task<Picture> Create(IFormFile image, string folderName);
        void Save(IFormFile Image, string folderName, out string path, out string fileName);
        Task<bool> Delete(Picture picture);
        Task<bool> DeleteFromDatabase(List<Picture> picture);
        bool DeleteFromRoot(List<Picture> picture);
        bool DeleteFromRoot(Picture picture);
        Task<Picture> Update(Picture picture, IFormFile newPic, string folderName);

    }
}
