using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace RestApi.Services
{
    public class ImageService : IImageService
    {
        public byte[] CreatePreview_100x100(Stream imageStream)
        {
            using var image = Image.Load(imageStream);

            var different = 0;

            var heightMore = image.Height > image.Width;
            
            if(image.Height != image.Width) 
                different = heightMore ? image.Height - image.Width : image.Width - image.Height;

            image.Mutate(x => x
                .Resize(new ResizeOptions
                {
                    Size = new Size(heightMore ? image.Width + different : image.Width, heightMore ? image.Height : image.Height + different),
                    Mode = ResizeMode.Pad,
                    
                }).Resize(100, 100)
            );

            var memoryStream = new MemoryStream();
            image.SaveAsPng(memoryStream);

            return memoryStream.ToArray();
        }
    }
}