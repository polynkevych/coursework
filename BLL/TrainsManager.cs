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

        public List<Train> FilterTrains(string keyword, Date date)
        {
            var direction = GetTrainsByDirection(Trains, keyword);
            return GetUnbookedTrains(direction, date);

        }

        private List<Train> GetTrainsByDirection(List<Train> trains, string keyword)
        {
            var result = trains.Where(t => t.Direction.Contains(keyword));
            return result.ToList();
        }

        private List<Train> GetUnbookedTrains(List<Train> trains, Date date)
        {
            var result = trains.Where(t => t.Wagons.Any(w => w.Seats.Any(s => !s.IsBooked(date))));
            return result.ToList();
        }
    }
}
