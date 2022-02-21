using Contentful.Core.Models;
using portfolio.Models;

namespace portfolio.Services
{
    public interface IContentfulService
    {

        public Task<IEnumerable<Records>> GetEntries();
        public Task<IEnumerable<Records>> GetRecordBySlug(string slug);

        public Task<IEnumerable<Asset>> GetAssetByTitle(string title);

        public Task<IEnumerable<BlogPost>> GetPosts();  

    }
}
