namespace AquecimentoGlobalApp
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.ServiceModel.Syndication;
    using System.Threading.Tasks;
    using System.Xml;

    public class RssService
    {
        public async Task<List<Article>> ObterNoticiasRssAsync(string rssUrl)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(rssUrl);

                if (response.IsSuccessStatusCode)
                {
                    using (var reader = XmlReader.Create(await response.Content.ReadAsStreamAsync()))
                    {
                        SyndicationFeed feed = SyndicationFeed.Load(reader);
                        var noticias = new List<Article>();

                        foreach (var item in feed.Items)
                        {
                            noticias.Add(new Article
                            {
                                title = item.Title.Text,
                                description = item.Summary.Text,
                                url = item.Links[0].Uri.ToString()
                            });
                        }

                        return noticias;
                    }
                }

                return new List<Article>();
            }
        }
    }

    public class Article1
    {
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
    }

}
