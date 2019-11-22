using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Services;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ILoadService _loadService;
        private readonly IImageService _imageService;

        public ImageController()
        {
            _loadService = new LoadService();
            _imageService = new ImageService();
        }

        [HttpPost]
        public FileResult Post(ImagesUrlsInput images)
        {
            foreach (var imageUrl in images.Urls)
            {
                if (string.IsNullOrEmpty(imageUrl)) continue;

                var imageStream = _loadService.TryLoadImage(imageUrl).Result;

                var imageSt = _imageService.CreatePreview_100x100(imageStream);



                return new FileContentResult(imageSt, "image/png");
            }

            return null;
        }
    }
}
