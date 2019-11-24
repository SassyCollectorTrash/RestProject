using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApi.Extension;
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
        public FileContentResult[] Post(ImagesUrlsInput images)
        {
            var result = new List<FileContentResult>();

            foreach (var imageUrl in images.Urls)
            {
                if (string.IsNullOrEmpty(imageUrl)) continue;

                var imageStream = GetImage(imageUrl);

                if(imageStream == null) continue;

                result.Add(new FileContentResult(_imageService.CreatePreview_100x100(imageStream), "image/png"));
            }

            return result.ToArray();;
        }

        private Stream GetImage(string imageSource)
        {
            return imageSource.IsUrl() ? _loadService.TryLoadImage(imageSource).Result : new MemoryStream(Convert.FromBase64String(imageSource));
        }
    }
}
