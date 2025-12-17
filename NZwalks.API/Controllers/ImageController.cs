using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NZwalks.API.Model.Domain;
using NZwalks.API.Model.DTO;
using NZwalks.API.Repositories;

namespace NZwalks.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
           this.imageRepository = imageRepository;
        }

        public IImageRepository ImageRepository { get; }


        // POST: /api/Image/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {
                // convert Dto to Domain model 

                var imageDomailModel = new Image
                {
                    File = request.File,
                    FileDescription = request.FileDescription,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileName = request.FileName,
                    FileSizeInBytes = request.File.Length
                };



                //User repository to upload image
                await imageRepository.Upload(imageDomailModel);
                return Ok(imageDomailModel);


            }

          return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtension = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtension.Contains(Path.GetExtension(request.File.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if (request.File.Length > 10 * 1024 * 1024) // 10MB
            {
                ModelState.AddModelError("file", "File size more than 10MB, please upload a smaller file");
            }
        }
    }


}
