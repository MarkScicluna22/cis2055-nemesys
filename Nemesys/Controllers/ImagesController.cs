using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nemesys.Repositories;

namespace Nemesys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            //call repos
            var imageURL = await imageRepository.UploadAsync(file);

            return new JsonResult(new {link = imageURL});
        }
      
    }
}
