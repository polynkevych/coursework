using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataAccess
{
    public class WagonData : ISerializable
    {
        public int Id { get; set; }

        public List<SeatData> Seats { get; set; }

        public WagonData() { }

        public WagonData(int id, List<SeatData> seats)
        {
            Id = id;
            Seats = new List<SeatData>();
            Seats.AddRange(seats);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Seats", Seats);
        }

        protected WagonData(SerializationInfo info, StreamingContext context)
        {
            Id = info.GetInt32("Id");
            Seats = (List<SeatData>)info.GetValue("Seats", typeof(List<SeatData>));
        }
    }
}
