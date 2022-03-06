using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Newtonsoft.Json;
using portfolio_models.Models;
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

        //Retrieve posts
        public async Task<IEnumerable<BlogPost>> GetPostBySlug(string slug)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BlogPost>>($"api/ContentfulService/GetPostBySlug?slug={slug}");
        }

        public async Task<IEnumerable<Records>> GetEntryBySlug(string slug)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Records>>($"api/ContentfulService/GetEntryBySlug?slug={slug}");
        }

        //Retrieve assets
        public async Task<IEnumerable<Asset>> GetAssetByTitle(string title)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Asset>>($"api/ContentfulService/GetAssetByTitle?title={title}");
        }
    }
}
