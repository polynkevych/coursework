using System;
using System.Linq;
using System.Collections.Generic;

namespace TrainSystem
{
    public class Seat
    {
        public List<Date> bookedDates = new List<Date>();

        public Seat(int Id)
        {
            _id = Id;
        }

        public bool IsBooked(Date date)
        {
            if (bookedDates.Contains(date)) return true;
            return false;
        }

        public bool Book(User user, Date date)
        {
            if (IsBooked(date)) return false;

            user.BookedSeats.Add(this, date);
            bookedDates.Add(date);
            return true;
        }

        public override string ToString()
        {
            return _id.ToString();
        }

        private int _id;
    }
}
