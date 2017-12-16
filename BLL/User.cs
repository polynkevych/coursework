using DataAccess;
using System;
using System.Collections.Generic;

namespace TrainSystem
{
    public class User
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }

        public UserManager UserManager { get; private set; }
        public List<BookedSeatPair> BookedSeats { get; private set; }

        public User(UserManager userManager, TrainsManager trainsManager, UserData userData)
        {
            Login = userData.Login;
            Password = userData.Password;
            IsAdmin = userData.IsAdmin;
            UserManager = userManager;

            BookedSeats = new List<BookedSeatPair>();
            foreach (var bookedSeatData in userData.BookedSeats)
            {
                var seat = trainsManager.FindSeatByUniqueId(bookedSeatData.Seat.UniqueIdentifier);
                if (seat == null)
                    continue;
                var date = new Date(bookedSeatData.Date);
                BookedSeats.Add(new BookedSeatPair(seat, date));
            }
        }

        public User(string login, string password, bool isAdmin)
        {
            Login = login;
            Password = password;
            IsAdmin = isAdmin;
            BookedSeats = new List<BookedSeatPair>();
        }

        public UserData CreateData()
        {
            var bookedSeats = new List<BookedSeatDataPair>();
            foreach (var seatDatePair in BookedSeats)
            {
                var dateTime = new DateTime(seatDatePair.Date.Year, seatDatePair.Date.Month, seatDatePair.Date.Day);
                bookedSeats.Add(new BookedSeatDataPair(seatDatePair.Seat.CreateData(), dateTime));
            }
            return new UserData(Login, Password, IsAdmin, bookedSeats);
        }
    }
}
