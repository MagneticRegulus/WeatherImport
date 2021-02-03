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

        public Controller()
        {
            Months = new List<Month>();
            string filename = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\\data\\weather.txt");
            ReadFile(filename);
            Console.Read();

        }

        public void ReadFile(string filename)
        {
            try
            {
                Month filemonth = null;
                List<string> data = new List<string>();
                string[] lines = System.IO.File.ReadAllLines(filename);
                foreach (string curr in lines)
                {
                    if (curr.StartsWith(" ") && !curr.StartsWith("\t")) //check if line starts with space && is not blank
                    {
                        string[] cols = curr.Trim().Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                        if (cols[0] == "MMU") //add month
                        {
                            filemonth = new Month(cols[1], Int32.Parse(cols[2]));
                            Months.Add(filemonth);
                        } else if (cols[0] == "mo" && cols.Length == 9 && filemonth != null) //add month attributes
                        {
                            filemonth.AvMxT = Double.Parse(cols[1]);
                            filemonth.AvMnT = Double.Parse(cols[2]);
                            filemonth.AvAvT = Double.Parse(cols[3]);
                            filemonth.TotHDDay = Int32.Parse(cols[4]);
                            filemonth.AvAvDP = Double.Parse(cols[5]);
                            filemonth.MnTPcpn = Double.Parse(cols[6]);
                            filemonth.AvAvSp = Double.Parse(cols[7]);
                            filemonth.AvSkyC = Double.Parse(cols[8]);
                            //debug: Console.WriteLine("Added all columns");
                        } else if (cols[0] != "Dy")
                        {
                            filemonth.Days.Add(new Day(curr));
                        }
                    }
                }
                foreach (Month m in Months)
                {
                    Console.WriteLine(m.Title + " " + m.Year + " loaded with " + m.Days.Count + " days");
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
