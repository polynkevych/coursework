using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem
{
    public class TrainsManager
    {
        public List<Train> Trains = new List<Train>();

        public TrainsManager()
        {
            LoadTrains();
        }

        public void AddTrain(string id, string direction)
        {
            var train = new Train(this, id, direction);
            Trains.Add(train);
            SaveTrains();
        }

        public void DeleteTrain(Train train)
        {
            Trains.Remove(train);
            SaveTrains();
        }

        public void SaveTrains()
        {
            var serializer = new TrainsDataSerializer();
            var trainsData = new List<TrainData>();
            foreach (var train in Trains)
            {
                var data = train.CreateData();
                trainsData.Add(data);
            }
            serializer.SerializeXML(trainsData);
        }

        public void LoadTrains()
        {
            var serializer = new TrainsDataSerializer();
            var trains = serializer.DeserializeXML();
            Trains.Clear();
            foreach (var trainData in trains)
            {
                var train = new Train(this, trainData);
                Trains.Add(train);
            }
        }

        public List<Train> FilterTrains(string keyword, Date date)
        {
            var direction = GetTrainsByDirection(Trains, keyword);
            foreach (var train in direction)
            {
                train.GetAvailibleSeats(date);
            }
            return direction.OrderByDescending(t => t.AvailibleSeats).ToList();

        }

        public Seat FindSeatByUniqueId(string uniqueId)
        {
            foreach (var train in Trains)
            {
                foreach (var wagon in train.Wagons)
                {
                    foreach (var seat in wagon.Seats)
                    {
                        if (seat.UniqueIdentifier == uniqueId)
                            return seat;
                    }
                }
            }

            return null;
        }

        private List<Train> GetTrainsByDirection(List<Train> trains, string keyword)
        {
            var result = trains.Where(t => t.Direction.Contains(keyword));
            return result.ToList();
        }
    }
}
