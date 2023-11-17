using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PakCore
{
    public class PakCore
    {
        static readonly HttpClient client = new HttpClient();
        public string BaseUrl { get; }
        public PakCore(string BaseUrl)
        {
            this.BaseUrl = BaseUrl;
        }


        public async Task<JObject> FetchPackages()
        {
            using HttpResponseMessage response = await client.GetAsync(this.BaseUrl);
            response.EnsureSuccessStatusCode();
            JObject? obj = (JObject)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
            return obj;
        }
    }
}