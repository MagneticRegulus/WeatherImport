using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherImport
{
    class Month
    {
        public List<Day> Days { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double AvMxT { get; set; } //average?
        public double AvMnT { get; set; } //average?
        public double AvAvT { get; set; } //average?
        public int TotHDDay { get; set; } //total?
        public double AvAvDP { get; set; } //average?
        public double MnTPcpn { get; set; } //unclear if total or average
        public double AvAvSp { get; set; } //average?
        public double AvSkyC { get; set; } //average?

        public Day MxTDay { get; set; }
        public Day MnTDay { get; set; }
        public Day MxSDay { get; set; }

        public Month(string title, int year)
        {
            Title = title;
            Year = year;
            Days = new List<Day>();
            Console.WriteLine("Month Added");
        }
    }
}
