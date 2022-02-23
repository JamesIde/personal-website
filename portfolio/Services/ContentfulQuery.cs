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

        public Task<IEnumerable<Asset>> GetAssetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Records>> GetEntries()
        {
            throw new NotImplementedException();
        }

        public Task<List<BlogPost>> GetPostBySlug(string slug)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlogPost>> GetPosts()
        {
            var response = await _httpClient.GetAsync($"api/ContentfulService/GetPosts");
            var content = await response.Content.ReadAsStringAsync();
            var blogposts = JsonConvert.DeserializeObject<IEnumerable<BlogPost>>(content);
            return blogposts;
        }

        public Task<IEnumerable<Records>> GetRecordBySlug(string slug)
        {
            throw new NotImplementedException();
        }



        //public async Task<IEnumerable<Records>> GetEntries()
        //{
        //    var entryString = QueryBuilder<Records>.New.ContentTypeIs("thumbnail");
        //    var records = await _contentfulClient.GetEntries<Records>(entryString);
        //    return records;
        //}
        //public async Task<IEnumerable<Records>> GetRecordBySlug(string slug)
        //{
        //    var entryString = QueryBuilder<Records>.New.ContentTypeIs("thumbnail").FieldEquals("fields.slug", slug);
        //    var record = await _contentfulClient.GetEntries<Records>(entryString);
        //    return record;
        //}

        //public async Task<IEnumerable<Asset>> GetAssetByTitle(string title)
        //{
        //    var titleFilter = QueryBuilder<Asset>.New.FieldEquals("fields.title", title);
        //    var assets = await _contentfulClient.GetAssets(titleFilter);
        //    return assets;
        //}

        //public async Task<IEnumerable<BlogPost>> GetPosts()
        //{
        //    var entryString = QueryBuilder<BlogPost>.New.ContentTypeIs("blogPost");
        //    var posts = await _contentfulClient.GetEntries<BlogPost>(entryString);
        //    return posts;
        //}
        //public async Task<List<BlogPost>> GetPostBySlug(string slug)
        //{
        //    var entryString = QueryBuilder<BlogPost>.New.ContentTypeIs("blogPost").FullTextSearch(slug);
        //    var post = await _contentfulClient.GetEntries<BlogPost>(entryString);
        //    return post.ToList();
        //}
    }
}
