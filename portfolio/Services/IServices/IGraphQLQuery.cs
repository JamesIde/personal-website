using portfolio_models.Models;

namespace portfolio.Services.IServices
{
    public interface IGraphQLQuery
    {
        public Task<Repository> GetRepositories();
    }
}
