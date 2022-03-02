using Contentful.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using portfolio_api.Controllers;
using portfolio_models.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
namespace portfolio_api_tests
{
    public class ContentfulTests
    {
        private readonly IConfiguration _configuration;

        public ContentfulTests(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public ContentfulClient CreateClient()
        {
            string DeliveryApiKey = _configuration.GetSection("ContentfulOptions").GetSection("DeliveryApiKey").Value;
            string PreviewApiKey = _configuration.GetSection("ContentfulOptions").GetSection("PreviewApiKey").Value;
            string SpaceId = _configuration.GetSection("ContentfulOptions").GetSection("SpaceId").Value;

            var httpClient = new HttpClient();
            var client = new ContentfulClient(httpClient, DeliveryApiKey, PreviewApiKey, SpaceId);
            return client;
        }

        [Fact]
        public async Task GetEntries()
        {
            string DeliveryApiKey = "MVf50WV535Du8tJfiGlSiTVqeg8IWO_mbUhEVJi_IQY";
            string PreviewApiKey = "LVN1riGSUvQizSP3kU3UtQ5_pigMB0oVohOfXYt5snI";
            string SpaceId = "791va4hmiioe";

            var httpClient = new HttpClient();
            var client = new ContentfulClient(httpClient, DeliveryApiKey, PreviewApiKey, SpaceId);

            ContentfulService _contentfulService = new ContentfulService(client);

            var response =  _contentfulService.GetPostThumbnails();

            Assert.Equal("Hello", response.ToString());
        }
    }
}