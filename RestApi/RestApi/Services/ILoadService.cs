using System.IO;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public interface ILoadService
    {
        Task<Stream> TryLoadImage(string url);
    }
}