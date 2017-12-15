using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DataAccess
{
    public class TrainsDataSerializer
    {
        public void SerializeXML(List<TrainData> trainsData)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<TrainData>));
            File.Delete("trainsData.xml");
            using (FileStream fs = new FileStream("trainsData.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, trainsData);
            }
        }

        public List<TrainData> DeserializeXML()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<TrainData>));

            if (!File.Exists("trainsData.xml")) return new List<TrainData>();
            using (FileStream fs = new FileStream("trainsData.xml", FileMode.OpenOrCreate))
            {
                var deserilizedTrainsData = (List<TrainData>)formatter.Deserialize(fs);
                return deserilizedTrainsData;
            }
        }
    }
}
