using System;
using System.Collections.Generic;
using System.IO;
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
            string filename = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\\data\\weather.txt");
            ReadFile(filename);
            Console.Read();

        }

        public void ReadFile(string filename)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(filename);
                foreach (string s in lines)
                {
                    Console.WriteLine(s);
                }

            } catch (System.Exception e)
            {
                Console.WriteLine(e);

            } finally
            {
                Console.WriteLine("Done");
            }

            
            
        }

    }
}
