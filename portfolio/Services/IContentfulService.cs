using portfolio.Models;

namespace portfolio.Services
{
    public interface IContentfulService
    {

        public Task<IEnumerable<Thumbnails>> GetAssets();

    }
}
