using System;

namespace APIGroup1Android
{
    public class WeatherForecast
    {
        //TestMing
        public DateTime Date { get; set; }
        //testing Ming
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
