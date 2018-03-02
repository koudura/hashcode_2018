using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_driving_cars
{
    public class Ride
    {
        int id;

        public int[] Start { get; private set; }
        public int[] End { get; private set; }

        public int Early { get; private set; }
        public int Late { get; private set; }

        public int ID { get; }
        public int Distance { get; private set; }

        public Ride(string detail, int i)
        {
            ID = i;
            setPositions(detail);
        }

        private void setPositions(string detail)
        {
            var d = detail.Split();
            Start = new int[] { d[0].ToInt(), d[1].ToInt() };
            End = new int[] { d[2].ToInt(), d[3].ToInt() };
            Early = d[4].ToInt();
            Late = d[5].ToInt();
            Distance = Math.Abs(End[0] - Start[0]) + Math.Abs(End[1] - Start[1]);
        }
    }
}
