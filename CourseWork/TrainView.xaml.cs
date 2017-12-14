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
using System.Windows.Shapes;
using TrainSystem;

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for TrainView.xaml
    /// </summary>
    public partial class TrainView : Window
    {
        public TrainView(User user, Train train, DateTime? selectedDate)
        {
            InitializeComponent();

            _user = user;
            if (!_user.IsAdmin)
            {
                addWagonButton.Visibility = Visibility.Hidden;
                deleteButton.Visibility = Visibility.Hidden;
            }

            _train = train;
            datePicker.SelectedDateChanged += OnSelectedDateChanged;
            datePicker.SelectedDate = selectedDate;
        }

        private User _user;
        private Train _train;
        private Date _selectedDate;

        private void UpdateTable()
        {
            dataGrid.Items.Clear();
            foreach (var wagon in _train.Wagons)
            {
                wagon.GetAvailibleSeats(_selectedDate);
                dataGrid.Items.Add(wagon);
            }
        }

        private void OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePicker.SelectedDate == null) return;
            DateTime dateTime = (DateTime)datePicker.SelectedDate;

            _selectedDate = new Date(dateTime);
            UpdateTable();
        }

        private void OnOtherWindowClosed(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void addWagonButton_Click(object sender, RoutedEventArgs e)
        {
            int newWagonId = 1;
            var lastWagon = _train.Wagons.OrderBy(w => w.WagonId).LastOrDefault();
            if (lastWagon != null)
                newWagonId = lastWagon.WagonId + 1;

            _train.AddWagon(newWagonId);
            UpdateTable();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem == null) return;
            var wagon = dataGrid.SelectedItem as Wagon;
            if (wagon == null) return;
            var wagonView = new WagonView(_user, wagon, datePicker.SelectedDate);
            wagonView.Closed += OnOtherWindowClosed;
            wagonView.Show();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            _train.TrainsManager.DeleteTrain(_train);
            Close();
        }
    }
}
