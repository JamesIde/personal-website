using Contentful.Core.Models;

namespace portfolio_api.Models
{
    public class ContentThumbnail
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public SystemProperties Sys { get; set; }

        public Asset FeaturedAsset { get; set; }
        public string Description { get; set; }
    }
}
