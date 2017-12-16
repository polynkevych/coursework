using DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace TrainSystem
{
    public class Train
    {
        public string Id { get; private set; }
        public string Direction { get; private set; }
        public int WagonsCount { get { return Wagons.Count; } }
        public int AvailibleSeats { get; private set; }

        public TrainsManager TrainsManager { get; private set; }

        public List<Wagon> Wagons { get; private set; }

        public Train(TrainsManager trainManager, string id, string direction)
        {
            TrainsManager = trainManager;
            Id = id;
            Direction = direction;
        }

        public Train(TrainsManager trainManager, TrainData trainData)
        {
            TrainsManager = trainManager;
            Id = trainData.Id;
            Direction = trainData.Direction;
            Wagons = new List<Wagon>();
            foreach (var wagonData in trainData.Wagons)
            {
                var wagon = new Wagon(this, wagonData);
                Wagons.Add(wagon);
            }
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
            TrainsManager.SaveTrains();
        }

        public void DeleteWagon(Wagon wagon)
        {
            if (wagon.Seats.Any(s => s.IsBookedAnyDate())) return;
            Wagons.Remove(wagon);
            TrainsManager.SaveTrains();
        }

        public TrainData CreateData()
        {
            var wagonsData = new List<WagonData>();
            foreach (var wagon in Wagons)
            {
                var data = wagon.CreateData();
                wagonsData.Add(data);
            }
            return new TrainData(Id, Direction, wagonsData);
        }
    }
}
