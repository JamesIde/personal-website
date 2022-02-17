using Contentful.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using portfolio.Models;
using System.Net.Http;

namespace portfolio_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {

        private readonly IContentfulClient _contentfulClient;
        public TestController(IContentfulClient contentfulClient)
        {
            _contentfulClient = contentfulClient;
        }
        [HttpGet]
        public async Task<IEnumerable<Thumbnails>> Index()
        {
            var thumbnails = await _contentfulClient.GetEntries<Thumbnails>();
            return thumbnails;
        }
    }
}
