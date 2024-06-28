using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ShoesApp.Interfaces;
using System.IO;

namespace ShoesApp.Services
{
    public class ImgService : IImgService
    {
        private readonly IWebHostEnvironment _env;

        public ImgService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string SaveImage(IFormFile? image, string imageName, string imageType)
        {
            if (image == null || image.Length == 0)
            {
                return string.Empty;
            }

            string uploads = Path.Combine(_env.WebRootPath, "images");
            string fileName = $"{imageName}_{imageType}.jpg";
            string filePath = Path.Combine(uploads, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            return $"/images/{fileName}";
        }

        public string GetImageUrl(string imageName, string imageType)
        {
            string uploads = Path.Combine(_env.WebRootPath, "images");
            string fileName = $"{imageName}_{imageType}.jpg";
            string filePath = Path.Combine(uploads, fileName);

            if (File.Exists(filePath))
            {
                return $"/images/{fileName}";
            }

            return "/images/default.jpg"; // Path to default image
        }

    }
}
