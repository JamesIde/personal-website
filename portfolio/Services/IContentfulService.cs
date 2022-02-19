using Contentful.Core.Models;
using portfolio.Models;

namespace portfolio.Services
{
    public interface IContentfulService
    {

        public Task<IEnumerable<Thumbnails>> GetEntries();
        public Task<IEnumerable<Thumbnails>> GetRecordBySlug(string slug);

        public Task<IEnumerable<Asset>> GetAssetByTitle(string title);

    }
}
