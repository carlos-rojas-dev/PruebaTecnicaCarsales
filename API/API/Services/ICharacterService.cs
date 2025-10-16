using API.Models;

namespace API.Services
{
    public interface ICharacterService
    {
        Task<EpisodioData?> GetCharactersByEpisodeAsync(int episodeId);
    }

}
