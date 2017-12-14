using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainSystem
{
    public class Wagon
    {
        public int WagonId { get; set; }
        public int AvailibleSeats { get; set; }
        public int AvailiblePercent { get { return (int)Math.Round((float)AvailibleSeats / (float)Seats.Count * 100); } }

        public Train Train { get; set; }

        public List<Seat> Seats = new List<Seat>();

        public Wagon(Train train, int wagonId)
        {
            Train = train;
            WagonId = wagonId;

            for (int i = 1; i <= 27; i++)
            {
                var seat = new Seat(i);
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
    }
}
