using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem
{
    public class Train
    {
        public string Id { get; private set; }
        public string Direction { get; private set; }
        public int WagonsCount { get { return Wagons.Count; } }
        public int AvailibleSeats { get; set; }

        public TrainsManager TrainsManager { get; set; }

        public List<Wagon> Wagons = new List<Wagon>();

        public Train(TrainsManager trainManager, string id, string direction)
        {
            TrainsManager = trainManager;
            Id = id;
            Direction = direction;
        }

        public List<Seat> GetAvailibleSeats(Date date)
        {
            List<Seat> availibleSeats = new List<Seat>();
            foreach(var wagon in Wagons)
            {
                availibleSeats.AddRange(wagon.GetAvailibleSeats(date));
            }
            AvailibleSeats = availibleSeats.Count;
            return availibleSeats;
        }

        public void AddWagon(int id)
        {
            var wagon = new Wagon(this, id);
            Wagons.Add(wagon);
        }

        public void DeleteWagon(Wagon wagon)
        {
            if (wagon.Seats.Any(s => s.bookedDates.Count > 0)) return;
            Wagons.Remove(wagon);
        }

    }
}
