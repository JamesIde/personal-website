using Contentful.Core;
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

        public async Task<IEnumerable<Thumbnails>> GetEntries()
        {
            var thumbnails = await _contentfulClient.GetEntries<Thumbnails>();
            return thumbnails;
        }
        public async Task<IEnumerable<Thumbnails>> GetRecordBySlug(string slug)
        {
            var entryString = QueryBuilder<Thumbnails>.New.ContentTypeIs("thumbnail").FieldEquals("fields.slug", slug);

            var record = await _contentfulClient.GetEntries<Thumbnails>(entryString);
            return record;
        }
    }
}
