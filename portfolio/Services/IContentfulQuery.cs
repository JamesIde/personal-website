using Contentful.Core.Models;
using portfolio.Models;

namespace portfolio.Services
{
    public interface IContentfulQuery
    {

        public Task<IEnumerable<Records>> GetEntries();
        public Task<IEnumerable<Records>> GetEntryBySlug(string slug);

        public Task<IEnumerable<Asset>> GetAssetByTitle(string title);

        public Task<IEnumerable<BlogPost>> GetPosts();
        public Task<IEnumerable<BlogPost>> GetPostBySlug(string slug);

    }
}
