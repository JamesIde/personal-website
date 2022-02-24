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
        //Blog posts thumbnails 
        [HttpGet]
        [Route("GetPostThumbnails")]
        public async Task<IActionResult> GetPostThumbnails()
        {
            var postThumbnails = await _contentfulClient.GetEntriesByType<BlogPostThumbnail>("blogPostThumbnail");
            return Ok(postThumbnails);
        }

        // Blog posts E.g Content model of type 'blogPost'
        [HttpGet]
        [Route("GetPosts")]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _contentfulClient.GetEntriesByType<BlogPost>("blogPost");
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

        //GetContentThumbnails (entry)
        [HttpGet]
        [Route("GetContentThumbnails")]
        public async Task<IActionResult> GetContentThumbnails()
        {
            var postThumbnails = await _contentfulClient.GetEntriesByType<ContentThumbnail>("contentThumbnail");
            return Ok(postThumbnails);
        }

        //Entries E.g Content model of type 'thumbnail'
        [HttpGet]
        [Route("GetEntries")]
        public async Task<IActionResult> GetEntries()
        {
            var records = await _contentfulClient.GetEntriesByType<Records>("thumbnail");
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
