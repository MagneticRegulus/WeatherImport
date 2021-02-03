using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherImport
{
    class Controller
    {
        public List<Month> Months { get; set; }
        public Day Day { get; set; }
        public Month Month { get; set; }

        public Controller()
        {
            Console.WriteLine("Controller Added");
            Day = new Day();
            Month = new Month();
            Month.Days.Add(Day);
            Console.WriteLine("Day added to month");
            Console.Read();

        }

    }
}
