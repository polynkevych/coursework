using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem
{
    public class UserManager
    {
        public UserManager(TrainsManager trainsManager)
        {
            _trainsManager = trainsManager;
        }

        public void SaveUsers()
        {
            var serializer = new UsersDataSerializer();
            var usersData = new List<UserData>();
            foreach (var user in _users)
            {
                var data = user.CreateData();
                usersData.Add(data);
            }
            serializer.SerializeXML(usersData);
        }

        public void LoadUsers()
        {
            var serizalizer = new UsersDataSerializer();
            var usersData = serizalizer.DeserializeXML();
            foreach (var userData in usersData)
                _users.Add(new User(this, _trainsManager, userData));
        }

        public User Login(string login, string password)
        {
            return _users.FirstOrDefault(u => u.Login == login && u.Password == password);
        }

        private TrainsManager _trainsManager;
        private List<User> _users = new List<User>();
    }
}
