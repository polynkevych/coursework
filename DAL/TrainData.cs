using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TrainData : ISerializable
    {
        public string Id { get; set; }
        public string Direction { get; set; }

        public List<WagonData> Wagons { get; set; }

        public TrainData() { }

        public TrainData(string id, string direction, List<WagonData> wagons)
        {
            Id = id;
            Direction = direction;
            Wagons = new List<WagonData>();
            Wagons.AddRange(wagons);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Direction", Direction);
            info.AddValue("Wagons", Wagons);
        }

        protected TrainData(SerializationInfo info, StreamingContext context)
        {
            Id = info.GetString("Id");
            Direction = info.GetString("Direction");
            Wagons = (List<WagonData>)info.GetValue("Wagons", typeof(List<WagonData>));
        }
    }
}
