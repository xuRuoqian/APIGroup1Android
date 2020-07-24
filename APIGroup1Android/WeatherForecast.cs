using System;

namespace APIGroup1Android
{
    public class WeatherForecast
    {
        //Test
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }
        //55535
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
        //happy
    }
}
