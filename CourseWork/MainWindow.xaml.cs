using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrainSystem;

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            _trainsManager = new TrainsManager();
            _trainsManager.LoadTrains();
            _userManager = new UserManager(_trainsManager);
            _userManager.LoadUsers();
        }

        private TrainsManager _trainsManager;
        private UserManager _userManager;

        private void userLoginButton_Click(object sender, RoutedEventArgs e)
        {
            //var user1 = new User("user", "user", false);
            //var user2 = new User("user", "user", false);
            //var users = new List<User>();
            //users.Add(user1);
            //users.Add(user2);
            //var serializer = new UsersDataSerializer();
            //var usersData = new List<UserData>();
            //foreach (var user in users)
            //{
            //    var data = user.CreateData();
            //    usersData.Add(data);
            //}
            //serializer.SerializeXML(usersData);

            var login = loginBox.Text;
            var password = passwordBox.Password;

            var user = _userManager.Login(login, password);
            if (user == null)
            {
                MessageBox.Show("Wrong login or password!");
                return;
            }

            var wagonView = new TrainsSearchView(_trainsManager, user);
            wagonView.Show();
            Close();
        }
    }
}
