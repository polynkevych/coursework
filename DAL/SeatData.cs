using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataAccess
{
    public class SeatData : ISerializable
    {
        public int Id { get; set; }
        public string UniqueIdentifier { get; set; }
        public List<DateTime> BookedDates { get; set; }

        public SeatData() { }

        public SeatData(int id, string uniqueId, List<DateTime> bookedDates)
        {
            Id = id;
            UniqueIdentifier = uniqueId;
            BookedDates = new List<DateTime>();
            BookedDates.AddRange(bookedDates);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("UniqueIdentifier", UniqueIdentifier);
            info.AddValue("BookedDates", BookedDates);
        }

        protected SeatData(SerializationInfo info, StreamingContext context)
        {
            Id = info.GetInt32("Id");
            UniqueIdentifier = info.GetString("UniqueIdentifier");
            BookedDates = (List<DateTime>)info.GetValue("BookedDates", typeof(List<DateTime>));
        }
    }
}
