using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherImport
{
    class Day
    {
        public int? Dy { get; set; }
        public int? MxT { get; set; }
        public int? MnT { get; set; }
        public int? Avt { get; set; }
        public int? HDDay { get; set; }
        public double? AvDP { get; set; }
        public string OneHrP { get; set; } //unused datapoint; treated as a string for the moment
        public double? TPcpn { get; set; }
        public string WxType { get; set; }
        public int? PDir { get; set; } //change to strings?
        public double? AvSp { get; set; }
        public int? Dir { get; set; } //change to strings?
        public int? MxS { get; set; }
        public double? SkyC { get; set; }
        public int? MxR { get; set; }
        public int? MnR { get; set; }
        public double? AvSLP { get; set; }
        public bool MonthMxt { get; set; } //assumption
        public bool MonthMnt { get; set; } //assumption
        public bool MonthMxS { get; set; } //assumption

        public Day(string fileimport)
        {
            SetAllFields(fileimport);
        }

        private void SetAllFields(string fi)
        {
            try
            {
                Dy = ParseIntSubString(fi, 0, 5);
                ImportMxT(fi);
                ImportMnT(fi);
                Avt = ParseIntSubString(fi, 17, 6);
                HDDay = ParseIntSubString(fi, 23, 7);
                AvDP = ParseDoubleSubString(fi, 30, 5);
                OneHrP = fi.Substring(35, 5).Trim();
                TPcpn = ParseDoubleSubString(fi, 40, 6);
                WxType = fi.Substring(46, 7).Trim();
                PDir = ParseIntSubString(fi, 53, 5);
                AvSp = ParseDoubleSubString(fi, 58, 5);
                Dir = ParseIntSubString(fi, 63, 4);
                ImportMxS(fi);
                SkyC = ParseDoubleSubString(fi, 71, 5);
                MxR = ParseIntSubString(fi, 76, 4);
                MnR = ParseIntSubString(fi, 80, 3);
                AvSLP = ParseDoubleSubString(fi, 83, 6);
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private bool Starred(string datapoint)
        {
            return datapoint.Contains("*");
        }

        private int? ParseIntSubString(string data, int first, int length)
        {
            string str = data.Substring(first, length).Trim();
            return ParseInt(str);
        }

        private double? ParseDoubleSubString(string data, int first, int length)
        {
            string str = data.Substring(first, length).Trim();
            return ParseDouble(str);
        }

        private void ImportMxT(string str)
        {
            string datapoint = str.Substring(5, 6).Trim();
            if (Starred(datapoint))
            {
                MonthMxt = true;
                datapoint = datapoint.Remove(datapoint.LastIndexOf('*'));
            }
            MxT = ParseInt(datapoint);
        }

        private void ImportMnT(string str)
        {
            string datapoint = str.Substring(11, 6).Trim();
            if (Starred(datapoint))
            {
                MonthMnt = true;
                datapoint = datapoint.Remove(datapoint.LastIndexOf('*'));
            }
            MnT = ParseInt(datapoint);
        }

        private void ImportMxS(string str)
        {
            string datapoint = str.Substring(67, 4).Trim();
            if (Starred(datapoint))
            {
                MonthMxS = true;
                datapoint = datapoint.Remove(datapoint.LastIndexOf('*'));
            }
            MxS = ParseInt(datapoint);
        }

        private bool EmptyData(string str)
        {
            return str.Equals("");
        }

        private int? ParseInt(string str)
        {
            if (EmptyData(str))
            {
                return null;
            }
            else
            {
                return Int32.Parse(str);
            }
        }

        private double? ParseDouble(string str)
        {
            if (EmptyData(str))
            {
                return null;
            }
            else
            {
                return Double.Parse(str);
            }
        }
    }
}
