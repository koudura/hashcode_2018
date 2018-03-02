using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_driving_cars
{
    class Vehicle
    {
        private int x;
        private int y;
        private List<int> rideMe = new List<int>();
        private int points;


        public Vehicle()
        {
            x = 0;
            y = 0;
            points = 0;
        }

        public Vehicle(int a, int b)
        {
            x = a;
            y = b;
        }

        public int getPoints()
        {
            return points;
        }

        public void move(Ride r)
        {
            this.x = r.End[0];
            this.y = r.End[1];
            points += getCost(r);
            rideMe.Add(r.ID);
        }

        public List<int> allRides()
        {
            return rideMe;
        }

        public int distanceToStart(Ride r)
        {
            int a = r.Start[0];
            int b = r.Start[1];
            return Math.Abs(a - x) + Math.Abs(b - y);
        }

        public int getCost(Ride r)
        {
            if (points >= r.Early)
            {
                return distanceToStart(r) + r.Distance;
            }
            else
            {
                int m = r.Early - points;
                if (r.Distance >= m)
                {
                    return distanceToStart(r) + r.Distance;
                }
                else
                {
                    return m + r.Distance;
                }
            }
        }


    }
}
