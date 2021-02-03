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
        private double AvMxT { get; set; } //average?
        private double AvMnT { get; set; } //average?
        private double AvAvT { get; set; } //average?
        private int TotHDDay { get; set; } //total?
        private double AvDP { get; set; } //average?
        private double MnTPcpn { get; set; } //unclear if total or average
        private double AvAvSp { get; set; } //average?
        private double AvSkyC { get; set; } //average?

        private Day MxTDay { get; set; }
        private Day MnTDay { get; set; }
        private Day MxSDay { get; set; }

        public Month()
        {
            Days = new List<Day>();
            Console.WriteLine("Month Added");
        }
    }
}
