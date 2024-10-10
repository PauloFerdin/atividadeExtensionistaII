namespace AquecimentoGlobalApp
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class ClimaService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string apiKey = "53cf5266290e7f49af885564a18bf87d"; // Chave da OpenWeatherMap
        private readonly string baseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public async Task<Clima> ObterDadosClimaticosAsync(string cidade)
        {
            string url = $"{baseUrl}?q={cidade}&appid={apiKey}&units=metric";

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var clima = JsonConvert.DeserializeObject<Clima>(json);
                return clima;
            }

            return null;
        }
    }
}
