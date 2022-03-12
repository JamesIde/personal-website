using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using portfolio_models.Models;

namespace portfolio_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphQLService : ControllerBase
    {
        IConfiguration _configuration;
        public GraphQLService(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        private GraphQLHttpClient CreateClient()
        {
            var graphQLClient = new GraphQLHttpClient("https://api.github.com/graphql", new NewtonsoftJsonSerializer());
            graphQLClient.HttpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {_configuration.GetSection("GithubOAuthToken").Value}");
            return graphQLClient;
        }

        [HttpGet]
        [Route("GetRepositories")]
        public async Task<IActionResult> GetGithubRepositories()
        {
            var request = new GraphQLHttpRequest
            {
                Query = @"query($username: String!){
  user(login: $username) {
        pinnedItems(first: 6, types: REPOSITORY) {
      nodes {
        ... on Repository {
          name
          description
          url
          primaryLanguage {
          name
          }
          createdAt
            }
          }
        }
      }
}
",

                Variables = new
                {
                    username = _configuration.GetSection("GithubUserName").Value
                }
            };
            var graphQlResponse = await CreateClient().SendQueryAsync<Repository>(request);
            var repo = new Repository
            {
                User = graphQlResponse.Data.User

            };

            return Ok(repo);
        }
    }
}
