using API.Models;

namespace API.External
{
    public interface IExternalApi
    {
        Task<EpisodeResponse> ObtenerEpisodiosExternosAsync(string endpoint);
        Task<Episode?> GetEpisodeAsync(int id);
        Task<Character?> GetCharacterByUrlAsync(string url);
    }
}
