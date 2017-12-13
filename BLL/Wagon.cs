using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainSystem
{
    public class Wagon
    {
        public List<Seat> Seats = new List<Seat>();

        public Wagon()
        {
            for (int i = 0; i < 27; i++)
            {
                var seat = new Seat(i);
                Seats.Add(seat);
            }
        }

        public List<Seat> GetAvailibleSeats(Date date)
        {
            return Seats.Where(s => !s.IsBooked(date)).ToList();
        }

        public List<Seat> GetBookedSeats(Date date)
        {
            return Seats.Where(s => s.IsBooked(date)).ToList();
        }
    }
}
