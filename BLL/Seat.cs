using System;
using System.Linq;
using System.Collections.Generic;

namespace TrainSystem
{
    public class Seat
    {
        public List<Date> bookedDates = new List<Date>();

        public Seat()
        {
            
        }

        public bool IsBooked(Date date)
        {
            if (bookedDates.Contains(date)) return true;
            return false;
        }

        public bool Book(Date date)
        {
            if (IsBooked(date)) return false;

            bookedDates.Add(date);
            return true;
        }
    }
}
