using System.IO;

namespace RestApi.Services
{
    public interface IImageService
    {
        byte[] CreatePreview_100x100(Stream imageStream);
    }
}