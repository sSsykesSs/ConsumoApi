using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ConsumoApiWeb.Services
{
    public class PessoaService
    {
        private readonly HttpClient _httpClient;
       

        public PessoaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            
            _httpClient.BaseAddress = new Uri("https://localhost:7013");
        }

        public async Task<string> GetPessoasJsonAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Pessoas");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                return "Erro ao acessar a API.";
            }
        }
    }
}