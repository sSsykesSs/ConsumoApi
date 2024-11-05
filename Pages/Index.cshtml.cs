using ConsumoApiWeb.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public string JsonContent { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            try
            {
                JsonContent = await _pessoaService.GetPessoasJsonAsync();
            }
            catch
            {
                JsonContent = "Erro ao acessar a API ou API não encontrada.";
            }
        }
    }
}


