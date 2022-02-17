using Contentful.Core;
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

        public async Task<IEnumerable<Thumbnails>> GetAssets()
        {
            var thumbnails = await _contentfulClient.GetEntries<Thumbnails>();
            return thumbnails;
        }
    }
}
