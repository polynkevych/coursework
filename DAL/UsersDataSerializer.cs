using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DataAccess
{
    public class UsersDataSerializer
    {
        public void SerializeXML(List<UserData> usersData)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<UserData>));
            File.Delete("usersData.xml");
            using (FileStream fs = new FileStream("usersData.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, usersData);
            }
        }

        public List<UserData> DeserializeXML()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<UserData>));

            if (!File.Exists("usersData.xml")) return new List<UserData>();
            using (FileStream fs = new FileStream("usersData.xml", FileMode.OpenOrCreate))
            {
                var deserilizedUsersData = (List<UserData>)formatter.Deserialize(fs);
                return deserilizedUsersData;
            }
        }
    }
}
