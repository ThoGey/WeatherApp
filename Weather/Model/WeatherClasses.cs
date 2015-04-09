using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Model
{
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class City
    {
        public string id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Day
    {
        private int _dt;

        public int dt
        {
            get { return _dt; }
            set 
            {
                _dt = value;
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                Time = epoch.AddSeconds(value);
            }
        }

        private DateTime _time;

        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public double temp { get; set; }
        public double night { get; set; }
        public double eve { get; set; }
        public double morn { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public List<Weather> weather { get; set; }
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class RootObject
    {
        public string cod { get; set; }
        public string message { get; set; }
        public City city { get; set; }
        public int cnt { get; set; }
        public string model { get; set; }
        public List<Day> list { get; set; }
    }

}
