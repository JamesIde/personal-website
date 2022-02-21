using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Search;
using portfolio.Models;

namespace portfolio.Services
{
    public class ContentfulService : IContentfulService
    {
        private readonly IContentfulClient _contentfulClient;
        public ContentfulService(IContentfulClient contentfulClient)
        {
            _contentfulClient = contentfulClient;
        }



        public async Task<IEnumerable<Records>> GetEntries()
        {
            var entryString = QueryBuilder<Records>.New.ContentTypeIs("thumbnail");
            var records = await _contentfulClient.GetEntries<Records>(entryString);
            return records;
        }
        public async Task<IEnumerable<Records>> GetRecordBySlug(string slug)
        {
            var entryString = QueryBuilder<Records>.New.ContentTypeIs("thumbnail").FieldEquals("fields.slug", slug);
            var record = await _contentfulClient.GetEntries<Records>(entryString);
            return record;
        }

        public async Task<IEnumerable<Asset>> GetAssetByTitle(string title)
        {
            var titleFilter = QueryBuilder<Asset>.New.FieldEquals("fields.title", title);
            var assets = await _contentfulClient.GetAssets(titleFilter);
            return assets;
        }

        public async Task<IEnumerable<BlogPost>> GetPosts()
        {
            var entryString = QueryBuilder<BlogPost>.New.ContentTypeIs("blogPost");
            var posts = await _contentfulClient.GetEntries<BlogPost>(entryString);
            return posts;
        }
        public async Task<List<BlogPost>> GetPostBySlug(string slug)
        {
            var entryString = QueryBuilder<BlogPost>.New.ContentTypeIs("blogPost").FullTextSearch(slug);
            var post = await _contentfulClient.GetEntries<BlogPost>(entryString);
            return post.ToList();
        }
    }
}
