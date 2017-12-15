using System;
using System.Linq;
using System.Collections.Generic;

namespace TrainSystem
{
    public class Seat
    {
        public Wagon Wagon { get; set; }
        public int Id { get; set; }

        public List<Date> bookedDates = new List<Date>();

        public Seat(Wagon wagon, int Id)
        {
            Wagon = wagon;
            this.Id = Id;
        }

        public bool IsBooked(Date date)
        {
            if (bookedDates.Contains(date)) return true;
            return false;
        }

        public void Book(User user, Date date)
        {
            if (IsBooked(date)) return;

            user.BookedSeats.Add(new SeatDatePair(this, date));
            bookedDates.Add(date);
        }

        public void RevokeBooking(User user, Date date)
        {
            if (!IsBooked(date)) return;
            user.BookedSeats.Remove(new SeatDatePair(this, date));
            bookedDates.Remove(date);
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }

    public struct SeatDatePair
    {
        public string TrainDirection { get { return Seat.Wagon.Train.Direction; } }
        public int SeatId { get { return Seat.Id; } }
        public int WagonId { get { return Seat.Wagon.Id; } }
        public string DateString { get { return Date.Day + "/" + Date.Month + "/" + Date.Year; } }

        public Seat Seat;
        public Date Date;

        public SeatDatePair(Seat seat, Date date)
        {
            Seat = seat;
            Date = date;
        }
    }
}
