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
        public HashSet<Month> Months { get; set; }
        public Month CurrMonth { get; set; }

        public Controller()
        {
            Months = new HashSet<Month>();
                      

        }

        public void ReadFile(string filename)
        {
            try
            {
                List<string> data = new List<string>();
                string[] lines = System.IO.File.ReadAllLines(filename);
                foreach (string curr in lines)
                {
                    if (curr.StartsWith(" ") && !curr.StartsWith("\t")) //check if line starts with space && is not blank
                    {
                        string[] cols = curr.Trim().Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                        if (cols[0] == "MMU") //add month
                        {
                            CurrMonth = new Month(cols[1], Int32.Parse(cols[2]));
                            Months.Add(CurrMonth);
                        } else if (cols[0] == "mo" && cols.Length == 9 && CurrMonth != null) //add month attributes
                        {
                            CurrMonth.SetFields(cols);
                            //debug: Console.WriteLine("Added all columns");
                        } else if (cols[0] != "Dy") //created new day
                        {
                            CurrMonth.Days.Add(new Day(curr));
                        }
                    }
                }
                foreach (Month m in Months)
                {
                    Console.WriteLine("Weather data for " + m.Title + " " + m.Year + " loaded with " + m.Days.Count + " days");
                }

            } catch (System.Exception e)
            {
                Console.WriteLine(e);

            } finally
            {
                Console.WriteLine("File Load Complete");
            }

            
            
        }

        public void DisplayMinimumDiff()
        {
            Day minimum = CurrMonth.FindMinTempDiff();
            Console.WriteLine(CurrMonth.Title + " " + minimum.Dy.Value + " had the minimum difference in temperature:\n"
                + "Max Temp: " + minimum.MxT.Value + "\n"
                + "Min Temp: " + minimum.MnT.Value + "\n"
                + "Difference: " + minimum.TempDiff().Value);

        }

        public void DisplayAllHDDays()
        {
            foreach (Day d in CurrMonth.Days)
            {
                if (d.HDDay.HasValue && d.Dy.HasValue)
                {
                    Console.WriteLine(CurrMonth.Title + " " + d.Dy.Value + " - HDDay: " + d.HDDay.Value);
                }
            }
        }

        //A Futute state would include an option to search and load information about other months
    }
}
