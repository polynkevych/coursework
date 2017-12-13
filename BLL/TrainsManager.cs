using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem
{
    public class TrainsManager
    {
        public List<Train> Trains = new List<Train>();

        public void AddTrain(Train train)
        {
            Trains.Add(train);
        }

        public List<Train> GetTrainsByDirection(string keyword)
        {
            var trains = Trains.Where(t => t.Direction.Contains(keyword));
            return trains.ToList();
        }

        public List<Train> GetUnbookedTrains(Date date)
        {
            var trains = Trains.Where(t => t.Wagons.Any(w => w.Seats.Any(s => !s.IsBooked(date))));
            return trains.ToList();
        }
    }
}
