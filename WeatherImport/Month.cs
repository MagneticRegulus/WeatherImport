using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherImport
{
    class Month
    {
        public HashSet<Day> Days { get; set; }
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
            Days = new HashSet<Day>();
        }

        public Day FindMinTempDiff()
        {
            Day min = new Day(null);
            foreach (Day d in Days)
            {
                if (min.Dy == null && d.TempDiff() != null)
                {
                    min = d;
                } else if (d.TempDiff() != null && d.TempDiff() < min.TempDiff())
                {
                    min = d;
                }
            }
            return min;
        }

        public void SetFields(string[] cols)
        {
            AvMxT = Double.Parse(cols[1]);
            AvMnT = Double.Parse(cols[2]);
            AvAvT = Double.Parse(cols[3]);
            TotHDDay = Int32.Parse(cols[4]);
            AvAvDP = Double.Parse(cols[5]);
            MnTPcpn = Double.Parse(cols[6]);
            AvAvSp = Double.Parse(cols[7]);
            AvSkyC = Double.Parse(cols[8]);
        }
    }
}
