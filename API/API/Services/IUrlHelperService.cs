using API.Models;

namespace API.Services
{
    public interface IUrlHelperService
    {
        (string? Prev, string? Next) GenerarUrlsPaginacion(Info info, string baseUrl, int pagina);

    }
}
