using API.Models;

namespace API.External
{
    public class RickAndMortyClient : IRickAndMortyClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RickAndMortyClient> _logger;

        public RickAndMortyClient(HttpClient httpClient, ILogger<RickAndMortyClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<Episode?> GetEpisodeAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/episode/{id}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var episode = System.Text.Json.JsonSerializer.Deserialize<Episode>(
                    json,
                    new System.Text.Json.JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                return episode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener episodio con ID {Id}", id);
                return null;
            }
        }

        public async Task<Character?> GetCharacterByUrlAsync(string url)
        {
            try
            {
                // Rick & Morty API devuelve URLs completas como "https://rickandmortyapi.com/api/character/1"
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var character = System.Text.Json.JsonSerializer.Deserialize<Character>(
                    json,
                    new System.Text.Json.JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                return character;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener personaje desde {Url}", url);
                return null;
            }
        }
    }

}
