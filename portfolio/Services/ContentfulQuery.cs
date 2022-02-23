using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Newtonsoft.Json;
using portfolio.Models;

namespace portfolio.Services
{
    public class ContentfulQuery : IContentfulQuery
    {
        private readonly HttpClient _httpClient;
        public ContentfulQuery(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
        //Retrieve posts
        public async Task<IEnumerable<BlogPost>> GetPostBySlug(string slug)
        {
            var response = await _httpClient.GetAsync($"api/ContentfulService/GetPostBySlug?slug={slug}");
            var content = await response.Content.ReadAsStringAsync();
            var blogpost = JsonConvert.DeserializeObject<IEnumerable<BlogPost>>(content);
            return blogpost;

        }

        public async Task<IEnumerable<BlogPost>> GetPosts()
        {
            var response = await _httpClient.GetAsync($"api/ContentfulService/GetPosts");
            var content = await response.Content.ReadAsStringAsync();
            var blogposts = JsonConvert.DeserializeObject<IEnumerable<BlogPost>>(content);
            return blogposts;
        }

        

        public async Task<IEnumerable<Records>> GetEntries()
        {
            var response = await _httpClient.GetAsync($"api/ContentfulService/GetEntries");
            var content = await response.Content.ReadAsStringAsync();
            var records = JsonConvert.DeserializeObject<IEnumerable<Records>>(content);
            return records;
        }

       

        public async Task<IEnumerable<Records>> GetEntryBySlug(string slug)
        {
            var response = await _httpClient.GetAsync($"api/ContentfulService/GetEntryBySlug?slug={slug}");
            var content = await response.Content.ReadAsStringAsync();
            var records = JsonConvert.DeserializeObject<IEnumerable<Records>>(content);
            return records;
        }
        //Retrieve assets
        public async Task<IEnumerable<Asset>> GetAssetByTitle(string title)
        {
            var response = await _httpClient.GetAsync($"api/ContentfulService/GetAssetByTitle?title={title}");
            var content = await response.Content.ReadAsStringAsync();
            var records = JsonConvert.DeserializeObject<IEnumerable<Asset>>(content);
            return records;
        }



    }
}
