using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AquecimentoGlobalApp.Pages
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Threading.Tasks;

    public class ClimaModel : PageModel
    {
        private readonly ClimaService _climaService = new ClimaService();

        [BindProperty]
        public string Cidade { get; set; }

        public Clima Clima { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(Cidade))
            {
                Clima = await _climaService.ObterDadosClimaticosAsync(Cidade);
            }

            return Page();
        }
    }

}
