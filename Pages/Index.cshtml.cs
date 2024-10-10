using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AquecimentoGlobalApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RssService _rssService = new RssService();

        public List<Article> Noticias { get; set; }

        public async Task OnGetAsync()
        {
            Noticias = await _rssService.ObterNoticiasRssAsync("https://www.theguardian.com/uk/environment/rss"); // URL do RSS
        }
    }
}
