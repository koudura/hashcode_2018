using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_driving_cars
{
    internal static class Scan
    {
        static StreamReader reader;

        internal static (int rows, int columns, int vehicles, int ride_count, int bonus, int steps, Ride[] Rides) ReadData(string file)
        {
            var _in = new List<string>();
            using (reader = new StreamReader(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    _in.Add(line);
                }
            }
            var f_in = _in[0].Split();
            var det = new List<Ride>();
            for (int i = 1; i < _in.Count; i++)
            {
                det.Add(new Ride(_in[i], i - 1));
            }

            return (f_in[0].ToInt(), f_in[1].ToInt(), f_in[2].ToInt(), f_in[3].ToInt(), f_in[4].ToInt(), f_in[5].ToInt(), det.ToArray());
        }

        public static int ToInt(this string str)
        {
            return int.Parse(str);
        }

        internal static void Write(List<Vehicle> v_list, int k)
        {
            using (var writer = new StreamWriter("../../out_xtreme.txt"))
            {
                for (int i = 0; i < k; i++)
                {
                    var str = new StringBuilder();
                    if (v_list[i] != null)
                    {
                        str.Append((v_list[i].allRides().Count));

                        foreach (var num in v_list[i].allRides())
                        {
                            str.Append(" " + num);
                        }
                        writer.WriteLine(str.ToString());
                    }
                }
            }
        }

    }

}
