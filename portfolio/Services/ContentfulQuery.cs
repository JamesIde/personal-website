using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Newtonsoft.Json;
using portfolio.Models;
using System.Net.Http.Json;

namespace portfolio.Services
{
    public class ContentfulQuery : IContentfulQuery
    {
        private readonly HttpClient _httpClient;
        public ContentfulQuery(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }


        public async Task<IEnumerable<ContentThumbnail>> GetContentThumbnails()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ContentThumbnail>>($"api/ContentfulService/GetContentThumbnails");

        }

        //Retrieve BlogPostThumbnails
        public async Task<IEnumerable<BlogPostThumbnail>> GetPostThumbnails()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BlogPostThumbnail>>($"api/ContentfulService/GetPostThumbnails");
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
            return await _httpClient.GetFromJsonAsync<IEnumerable<BlogPost>>($"api/ContentfulService/GetPosts");
        }



        public async Task<IEnumerable<Records>> GetEntries()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Records>>($"api/ContentfulService/GetEntries");

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
            return await _httpClient.GetFromJsonAsync<IEnumerable<Asset>>($"api/ContentfulService/GetAssetByTitle?title={title}");
        }
    }
}
