using Contentful.Core.Models;

namespace portfolio.Models
{
    public class Records
    {
        public string Slug { get; set; }
        public SystemProperties Sys { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Asset FeaturedImage { get; set; }
        public string Date { get; set; }

        public string PrefaceHeader { get; set; }
        public string PrefaceDescription { get; set; }

        public string DayOneHeader { get; set; }
        public string DayOneDescription { get; set; }
        public List<Asset> ImageBlock1 { get; set; }

        public string DayTwoHeader { get; set; }
        public string DayTwoDescription { get; set; }
        public List<Asset> ImageBlock2 { get; set; }

        public string DayThreeHeader { get; set; }
        public string DayThreeDescription { get; set; }
        public List<Asset> ImageBlock3 { get; set; }
        public string Map { get; set; }

        public string GearDescription { get; set; }
        public string TravelHeader { get; set; }
        public string TravelDescription { get; set; }
        public string AboutHeader { get; set; }
        public string AboutDescription { get; set; }

    }

}