using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainSystem
{
    public class Wagon
    {
        public int Id { get; set; }
        public int AvailibleSeats { get; set; }
        public int AvailiblePercent { get { return (int)Math.Round((float)AvailibleSeats / (float)Seats.Count * 100); } }

        public Train Train { get; set; }

        public List<Seat> Seats = new List<Seat>();

        public Wagon(Train train, int wagonId)
        {
            Train = train;
            Id = wagonId;

            for (int i = 1; i <= 27; i++)
            {
                var seat = new Seat(this, i);
                Seats.Add(seat);
            }
        }

        public Wagon(Train train, WagonData wagonData)
        {
            Train = train;
            Id = wagonData.Id;

            foreach (var seatData in wagonData.Seats)
            {
                var seat = new Seat(this, seatData);
                Seats.Add(seat);
            }
        }

        public List<Seat> GetAvailibleSeats(Date date)
        {
            var availibleSeats = Seats.Where(s => !s.IsBooked(date)).ToList();
            AvailibleSeats = availibleSeats.Count;
            return availibleSeats;
        }

        public List<Seat> GetBookedSeats(Date date)
        {
            return Seats.Where(s => s.IsBooked(date)).ToList();
        }

        public WagonData CreateData()
        {
            var seatsData = new List<SeatData>();
            foreach (var seat in Seats)
            {
                var data = seat.CreateData();
                seatsData.Add(data);
            }
            return new WagonData(Id, seatsData);
        }
    }
}
