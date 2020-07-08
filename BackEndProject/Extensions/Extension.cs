using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Extensions
{
    public static class Extension
    {
        public static bool isImage(this IFormFile file) 
        {
            return file.ContentType.Contains("image/");
        }
        public static bool MaxLenght(this IFormFile file, int storage)
        {
            return file.Length / 1024 >= storage;
        }

        public async static Task<string> SaveImg(this IFormFile file, string root, string folder)
        {
            string path = Path.Combine(root, folder);
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string resultPath = Path.Combine(path, fileName);
            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }
    }
}
