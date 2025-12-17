using NZwalks.API.Data;
using NZwalks.API.Model.Domain;

namespace NZwalks.API.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly NZwalksDBContextcs dBContextcs;

        public LocalImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor , NZwalksDBContextcs dBContextcs)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dBContextcs = dBContextcs;
        }

        public async Task<Image> Upload(Image image)
        {
            var directoryPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var localFilePath = Path.Combine(directoryPath, $"{image.FileName}{image.FileExtension}");

            // Upload Image to local folder
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);


            // try to make url like this 
            // https://localhost:1234/Images/image.jpg
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";


            image.FilePath = urlFilePath;


            // Add this image to ImageTable
            await dBContextcs.Images.AddAsync(image);
            await dBContextcs.SaveChangesAsync();

            return image;
        }
    }
}
