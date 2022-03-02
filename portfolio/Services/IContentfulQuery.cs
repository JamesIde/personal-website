using Contentful.Core.Models;
using portfolio_models.Models;

namespace portfolio.Services
{
    public interface IContentfulQuery
    {
        // Records
        public Task<IEnumerable<ContentThumbnail>> GetContentThumbnails();

        public Task<IEnumerable<Records>> GetEntryBySlug(string slug);

        //Assets
        public Task<IEnumerable<Asset>> GetAssetByTitle(string title);

        // Blog posts
        public Task<IEnumerable<BlogPostThumbnail>> GetPostThumbnails();

        public Task<IEnumerable<BlogPost>> GetPostBySlug(string slug);

    }
}
