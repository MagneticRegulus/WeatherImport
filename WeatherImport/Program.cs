using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherImport
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            string filename = @"data\\weather.txt";
            controller.ReadFile(filename);
            controller.DisplayMinimumDiff();
            Console.WriteLine("\nAdditional example of stored data - Display the days in month with HDDay values: ");
            controller.DisplayAllHDDays();
            Console.Read();

        }
    }
}
