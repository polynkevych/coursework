using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserData : ISerializable
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public List<BookedSeatDataPair> BookedSeats { get; set; }

        public UserData() { }

        public UserData(string login, string password, bool isAdmin, List<BookedSeatDataPair> bookedSeats)
        {
            Login = login;
            Password = password;
            IsAdmin = isAdmin;
            BookedSeats = new List<BookedSeatDataPair>();
            BookedSeats.AddRange(bookedSeats);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Login", Login);
            info.AddValue("Password", Password);
            info.AddValue("IsAdmin", IsAdmin);
            info.AddValue("BookedSeats", BookedSeats);
        }

        protected UserData(SerializationInfo info, StreamingContext context)
        {
            Login = info.GetString("Login");
            Password = info.GetString("Password");
            IsAdmin = info.GetBoolean("IsAdmin");
            BookedSeats = (List<BookedSeatDataPair>)info.GetValue("BookedSeats", typeof(List<BookedSeatDataPair>));
        }
    }

    public struct BookedSeatDataPair
    {
        public SeatData Seat;
        public DateTime Date;

        public BookedSeatDataPair(SeatData seat, DateTime date)
        {
            Seat = seat;
            Date = date;
        }
    }

}
