using portfolio.Services.IServices;
using portfolio_models.Models;
using System.Net.Http.Json;

namespace portfolio.Services
{
    public class GraphQLQuery : IGraphQLQuery
    {
        private readonly HttpClient _httpClient;

        public GraphQLQuery(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Repository> GetRepositories()
        {
            return await _httpClient.GetFromJsonAsync<Repository>($"api/GraphQLService/GetRepositories");
        }
    }
}
