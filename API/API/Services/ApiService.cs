using API.External;
using API.Models;
using API.Services;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.NewFolder
{
    public class ApiService: IApiService
    {

        private readonly IExternalApi _external;

        public ApiService(IExternalApi externalClient)
        {
            _external = externalClient;
        }
 
        async Task<EpisodeResponse?> IApiService.GetAsync<T>(string endpoint)
        {
            // var response = await _httpClient.GetAsync(endpoint);

            var response = await _external.ObtenerEpisodiosExternosAsync(endpoint);
                          
            return response;
        }
    }
}
