namespace AquecimentoGlobalApp
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class NoticiaService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string apiKey = "719b11eb0c694fd3b1bb6299b00e9780"; // Chave API da NewsAPI
        private readonly string baseUrl = "https://newsapi.org/v2/everything?q=climate&apiKey=";

        public async Task<List<Article>> ObterNoticiasAsync()
        {
            string url = $"{baseUrl}{apiKey}&language=pt&sortBy=publishedAt";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var noticias = JsonConvert.DeserializeObject<NewsResponse>(json);
                return noticias.articles;
            }

            return new List<Article>();
        }
    }

    public class NewsResponse
    {
        public List<Article> articles { get; set; }
    }

    public class Article
    {
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
    }
}
