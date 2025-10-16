using API.Models;

namespace API.External
{
    public interface IRickAndMortyClient
    {
        Task<Episode?> GetEpisodeAsync(int id);
        Task<Character?> GetCharacterByUrlAsync(string url);
    }

}
