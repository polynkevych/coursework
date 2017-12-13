using System;
using System.Collections.Generic;

namespace TrainSystem
{
    public class Wagon
    {
        public List<Seat> Seats = new List<Seat>();

        public Wagon()
        {
            for (int i = 0; i < 27; i++)
            {
                var seat = new Seat();
                Seats.Add(seat);
            }
        }
    }
}
