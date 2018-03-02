using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_driving_cars
{
    class Program
    {
        static string in_example = "../../2018/a_example.in";
        static string in_easy = "../../2018/b_should_be_easy.in";
        static string in_medium = "../../2018/c_no_hurry.in";
        static string in_hard = "../../2018/d_metropolis.in";
        static string in_extreme = "../../2018/e_high_bonus.in";


        static void Main(string[] args)
        {
            var scn = Scan.ReadData(in_extreme);
            var v_list = new List<Vehicle>(scn.vehicles);
            var r = scn.Rides;
            var r_list = new List<Ride>(r);


            for (int i = 0; i < scn.vehicles; i++)
            {
                if (r_list.Count == 0)
                {
                    break;
                }
                v_list.Add(new Vehicle());
                Ride chride = null;
                int cost = int.MaxValue;
                foreach (Ride cur in r_list)
                {
                    int precost = v_list[i].getCost(cur);
                    if ((precost < cost) && (precost + v_list[i].getPoints() < cur.Late))
                    {
                        cost = precost;
                        chride = cur;
                    }
                }
                if (chride != null)
                {
                    v_list[i].move(chride);
                    r_list.Remove(chride);
                    i--;
                }
            }
            Scan.Write(v_list, scn.vehicles);
        }
    }
}
