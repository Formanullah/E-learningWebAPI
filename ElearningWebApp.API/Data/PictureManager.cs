using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Migrations.Design;

using MogobariWebAPI.BL.Interface;
using MogobariWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MogobariWebAPI.BL
{
    public class PictureManager : IPictureManager
    {
        private Mogobari_dbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PictureManager(IWebHostEnvironment hostingEnvironment, Mogobari_dbContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }


        /// <summary>
        // Multi Picture save
        /// </summary>
        /// <param name="images"></param>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public async Task<List<Picture>> Create(List<IFormFile> images, string folderName)
        {
            List<Picture> pictures = new List<Picture>();

            foreach (var image in images)
            {

                Picture picture = new Picture();
                string path, fileName;

                Save(image, folderName, out path, out fileName);
                picture.FileName = fileName;

                if (path != "")
                {
                    picture.VirtualPath = path;
                    _context.Picture.Add(picture);

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {

                        return null;
                    }
                }

                pictures.Add(picture);
            }


            return pictures;
        }

        /// <summary>
        // Single Picture Save
        /// </summary>
        /// <param name="images"></param>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public async Task<Picture> Create(IFormFile image, string folderName)
        {
            Picture picture = new Picture();
            string path, fileName;

            Save(image, folderName, out path, out fileName);
            picture.FileName = fileName;

            if (path != "")
            {
                picture.VirtualPath = path;
                _context.Picture.Add(picture);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    return null;
                }
            }
            return picture;
        }


        public async Task<Picture> Update(Picture picture, IFormFile newPic, string folderName)
        {
            bool res = await Delete(picture);

            string path, fileName;
            Save(newPic, folderName, out path, out fileName);
            if (fileName != "" && path != "")
            {
                picture.FileName = fileName;
                picture.VirtualPath = path;

                _context.Entry(picture).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    return null;
                }

                return picture;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Picture picture)
        {
            string root = _hostingEnvironment.WebRootPath;
            string virtualPath = picture.VirtualPath;
            string fullPath = root + virtualPath;

            string path = Path.Combine(root, virtualPath);


            _context.Picture.Remove(picture);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return false;
            }


            // Check if file exists with its full path    
            if (File.Exists(fullPath))
            {
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        // If file found, delete it    
                        File.Delete(fullPath);
                    }

                    catch (IOException ex)
                    {
                        Thread.Sleep(1000);
                        if (i == 2)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }



        public async Task<bool> DeleteFromDatabase(List<Picture> pictures)
        {
            foreach (var picture in pictures)
            {
                _context.Picture.Remove(picture);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return false;
            }

            return true;

        }
        public bool DeleteFromRoot(List<Picture> picture)
        {
            string root = _hostingEnvironment.WebRootPath;

            // Check if file exists with its full path  
            foreach (var pic in picture)
            {
                if (File.Exists(root + pic.VirtualPath))
                {
                    try
                    {
                        // If file found, delete it    
                        File.Delete(root + pic.VirtualPath);

                    }
                    catch (IOException ex)
                    {
                        return false;
                    }
                }
            }

            return true;

        }
        public bool DeleteFromRoot(Picture picture)
        {
            string root = _hostingEnvironment.WebRootPath;

            // Check if file exists with its full path  
            if (File.Exists(root + picture.VirtualPath))
            {
                try
                {
                    // If file found, delete it    
                    File.Delete(root + picture.VirtualPath);

                }
                catch (IOException ex)
                {
                    return false;
                }
            }

            return true;

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





        //public IFormFile Retrive(byte[] imageBinary)
        //       {
        //           if (imageBinary != null)
        //           {
        //               MemoryStream ms = new MemoryStream(imageBinary);
        //               IFormFile xx = new FormFile(ms, 0, imageBinary.Length, "imageName", "fileName");
        //               return xx;
        //           }
        //           return null;
        //       }
    }

}
