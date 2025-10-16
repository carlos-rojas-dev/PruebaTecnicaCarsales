using API.Models;

namespace API.Services
{
    public interface IApiService
    {
        Task<EpisodeResponse?> GetAsync<T>(string endpoint);
    }
}
