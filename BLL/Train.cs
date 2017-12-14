using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem
{
    public class Train
    {
        public int Id { get; private set; }
        public string Direction { get; private set; }
        public int WagonsCount { get { return Wagons.Count; } }

        public List<Wagon> Wagons = new List<Wagon>();

        public Train(int id, string direction)
        {
            Id = id;
            Direction = direction;
        }

        public void AddWagon()
        {
            Wagons.Add(new Wagon());
        }

        public void AddWagon(Wagon wagon)
        {
            Wagons.Add(wagon);
        }

        public void DeleteWagon(Wagon wagon)
        {
            Wagons.Remove(wagon);
        }

    }
}
