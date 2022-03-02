using Contentful.Core.Models;

namespace portfolio_models.Models
{
    public class ContentThumbnail
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public Asset FeaturedAsset { get; set; }
        public string Description { get; set; }
        public ContentfulMetadata Metadata { get; set; }    
    }
}
