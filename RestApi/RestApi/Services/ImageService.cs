using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace RestApi.Services
{
    public class ImageService : IImageService
    {
        public byte[] CreatePreview_100x100(Stream image)
        {
            using var img = Image.Load(image);

            var different = 0;

            var heightMore = img.Height > img.Width;
            
            if(img.Height != img.Width) 
                different = heightMore ? img.Height - img.Width : img.Width - img.Height;
            
            img.Mutate(x => 
                x.Crop(new Rectangle(heightMore ? 0 - different / 2 : 0 , heightMore ? 0 : 0 - different * 2,
                    heightMore ? img.Width + different : img.Width, heightMore ? img.Height : img.Height + different)).Resize(100, 100));

            MemoryStream memoryStream = new MemoryStream();
            img.SaveAsPng(memoryStream);

            return memoryStream.ToArray();
        }
    }
}