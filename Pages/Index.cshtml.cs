using ConsumoApiWeb.Services;
using ConsumoApiWeb.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumoApiWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PessoaService _pessoaService;

        public IndexModel(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public List<Dados> Pessoas { get; set; } = new List<Dados>();

        public async Task OnGetAsync()
        {
            try
            {
                var jsonContent = await _pessoaService.GetPessoasJsonAsync();
                Pessoas = JsonSerializer.Deserialize<List<Dados>>(jsonContent) ?? new List<Dados>();
            }
            catch
            {
                Pessoas = new List<Dados>();
            }
        }
    }
}