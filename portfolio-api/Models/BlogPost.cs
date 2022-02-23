using Contentful.Core.Models;

namespace portfolio_api.Models
{
    public class BlogPost
    {
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
        public string PostDate { get; set; }
        public string PostSlug { get; set; }
        public Asset BlogThumbnail { get; set; }

        public List<Asset> ImageGallery { get; set; }

    }
}
