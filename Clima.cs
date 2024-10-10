namespace AquecimentoGlobalApp
{
    public class Clima
    {
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double humidity { get; set; }
    }

    public class Weather
    {
        public string description { get; set; }
    }
}
