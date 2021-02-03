using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherImport
{
    class Day
    {
        private int Dy { get; set; }
        private int MxT { get; set; }
        private int MnT { get; set; }
        private int Avt { get; set; }
        private int HDDay { get; set; }
        private double AvDP { get; set; }
        private string OneHrP { get; set; } //unused datapoint; treated as a string for the moment
        private double TPcpn { get; set; }
        private string WxType { get; set; }
        private int PDir { get; set; }
        private double AvSp { get; set; }
        private int Dir { get; set; }
        private int MxS { get; set; }
        private double SkyC { get; set; }
        private int MxR { get; set; }
        private int MnR { get; set; }
        private double AvSLP { get; set; }
        private bool MonthMxt { get; set; } //assumption
        private bool MonthMnt { get; set; } //assumption
        private bool MonthMxS { get; set; } //assumption

        public Day()
        {
            Console.WriteLine("Day Added");
        }

    }
}
