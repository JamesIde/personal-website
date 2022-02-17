using Contentful.Core.Models;

namespace portfolio.Models
{
    public class Thumbnails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Asset Image { get; set; }


    }

}