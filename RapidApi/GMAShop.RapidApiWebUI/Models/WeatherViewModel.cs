namespace GMAShop.RapidApiWebUI.Models;

    public class WeatherViewModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Timezone { get; set; }
        public string ConditionText { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public double Visibility { get; set; }
        public int WindChill { get; set; }
        public string WindDirection { get; set; }
        public double WindSpeed { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public List<WeatherForecast> Forecasts { get; set; }
    }