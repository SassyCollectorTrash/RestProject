using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public class LoadService : ILoadService
    { 
        public async Task<Stream> TryLoadImage(string url)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            return await client.GetStreamAsync(url);
        }
    }
}
