using Contentful.Core.Models;

namespace portfolio.Models
{
    public class Thumbnails
    {
        public string Slug { get; set; }

        public SystemProperties Sys { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Asset Image { get; set; }


    }

}