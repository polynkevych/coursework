using System;
using System.Collections.Generic;
using DataAccess;

namespace TrainSystem
{
    public class Seat
    {
        public Wagon Wagon { get; private set; }
        public int Id { get; private set; }

        public string UniqueIdentifier { get { return Wagon.Train.Id.ToString() + Wagon.Id.ToString() + Id.ToString(); } }

        public Seat(Wagon wagon, int id)
        {
            Wagon = wagon;
            Id = id;
        }

        public Seat(Wagon wagon, SeatData seatData)
        {
            Wagon = wagon;
            Id = seatData.Id;
            foreach (var timeDate in seatData.BookedDates)
            {
                var date = new Date(timeDate);
                _bookedDates.Add(date);
            }
        }

        public bool IsBooked(Date date)
        {
            return _bookedDates.Contains(date);
        }

        public bool IsBookedAnyDate()
        {
            return _bookedDates.Count != 0;
        }

        public void Book(User user, Date date)
        {
            if (IsBooked(date)) return;

            user.BookedSeats.Add(new BookedSeatPair(this, date));
            user.UserManager.SaveUsers();
            _bookedDates.Add(date);
            Wagon.Train.TrainsManager.SaveTrains();
        }

        public void RevokeBooking(User user, Date date)
        {
            if (!IsBooked(date)) return;
            user.BookedSeats.Remove(new BookedSeatPair(this, date));
            user.UserManager.SaveUsers();
            _bookedDates.Remove(date);
            Wagon.Train.TrainsManager.SaveTrains();
        }

        public SeatData CreateData()
        {
            var bookedDateTime = new List<DateTime>();
            foreach (var date in _bookedDates)
            {
                var dateTime = new DateTime(date.Year, date.Month, date.Day);
                bookedDateTime.Add(dateTime);
            }
            return new SeatData(Id, UniqueIdentifier, bookedDateTime);
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        private List<Date> _bookedDates = new List<Date>();
    }

    public struct BookedSeatPair
    {
        public string TrainDirection { get { return Seat.Wagon.Train.Direction; } }
        public int SeatId { get { return Seat.Id; } }
        public int WagonId { get { return Seat.Wagon.Id; } }
        public string DateString { get { return Date.Day + "/" + Date.Month + "/" + Date.Year; } }

        public Seat Seat { get; }
        public Date Date { get; }

        public BookedSeatPair(Seat seat, Date date)
        {
            Seat = seat;
            Date = date;
        }
    }
}
