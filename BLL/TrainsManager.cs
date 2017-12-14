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

        public Train AddTrain(string id, string direction) //Train train)
        {
            var train = new Train(this, id, direction);
            Trains.Add(train);
            return train;
        }

        public void DeleteTrain(Train train)
        {
            Trains.Remove(train);
        }

        public List<Train> FilterTrains(string keyword, Date date)
        {
            var direction = GetTrainsByDirection(Trains, keyword);
            foreach (var train in direction)
            {
                train.GetAvailibleSeats(date);
            }
            return direction.OrderByDescending(t => t.AvailibleSeats).ToList();//GetUnbookedTrains(direction, date);

        }

        private List<Train> GetTrainsByDirection(List<Train> trains, string keyword)
        {
            var result = trains.Where(t => t.Direction.Contains(keyword));
            return result.ToList();
        }

        //private List<Train> GetUnbookedTrains(List<Train> trains, Date date)
        //{
        //    var result = trains.Where(t => t.Wagons.Any(w => w.Seats.Any(s => !s.IsBooked(date))));
        //    return result.ToList();
        //}
    }
}
