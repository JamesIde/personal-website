using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using portfolio_api.Models;

namespace portfolio_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentfulService : ControllerBase
    {
        private readonly ContentfulClient _contentfulClient;

        public ContentfulService(ContentfulClient contentfulClient)
        {
            _contentfulClient = contentfulClient;
        }

        // Blog posts E.g Content model of type 'blogPost'
        [HttpGet]
        [Route("GetPosts")]
        public async Task<IActionResult> GetPosts()
        {
            var entryString = QueryBuilder<BlogPost>.New.ContentTypeIs("blogPost");
            var posts = await _contentfulClient.GetEntries<BlogPost>(entryString);
            return Ok(posts);
        }

        [HttpGet]
        [Route("GetPostBySlug")]
        public async Task<IActionResult>GetPostBySlug(string slug)
        {
            var entryString = QueryBuilder<BlogPost>.New.ContentTypeIs("blogPost").FullTextSearch(slug);
            var post = await _contentfulClient.GetEntries<BlogPost>(entryString);
            return Ok(post);
        }
        //Entries E.g Content model of type 'thumbnail'
        [HttpGet]
        [Route("GetEntries")]
        public async Task<IActionResult> GetEntries()
        {
            var entryString = QueryBuilder<Records>.New.ContentTypeIs("thumbnail");
            var records = await _contentfulClient.GetEntries<Records>(entryString);
            return Ok(records);
        }
        [HttpGet]
        [Route("GetEntryBySlug")]
        public async Task<IActionResult> GetEntryBySlug(string slug)
        {
            var entryString = QueryBuilder<Records>.New.ContentTypeIs("thumbnail").FieldEquals("fields.slug", slug);
            var record = await _contentfulClient.GetEntries<Records>(entryString);
            return Ok(record);
        }

        //Assets E.g. Images
        [HttpGet]
        [Route("GetAssetByTitle")]
        public async Task<IActionResult>GetAssetByTitle(string title)
        {
            var titleFilter = QueryBuilder<Asset>.New.FieldEquals("fields.title", title);
            var assets = await _contentfulClient.GetAssets(titleFilter);
            return Ok(assets);
        }
    }
}
