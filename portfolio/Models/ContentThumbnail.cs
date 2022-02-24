using Contentful.Core.Models;

namespace portfolio.Models
{
    public class BlogPostThumbnail
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public Asset FeaturedAsset { get; set; }
        public string Description { get; set; }
    }
}
