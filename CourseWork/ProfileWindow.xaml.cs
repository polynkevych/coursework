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
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public ProfileWindow(User user)
        {
            InitializeComponent();

            _user = user;
            UpdateTable();
        }

        private User _user;

        private void UpdateTable()
        {
            dataGrid.Items.Clear();
            foreach (var seatDatePair in _user.BookedSeats)
            {
                dataGrid.Items.Add(seatDatePair);
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cancelButton.IsEnabled = dataGrid.SelectedItem != null;
            changeButton.IsEnabled = dataGrid.SelectedItem != null;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            var seat = dataGrid.SelectedItem as SeatDatePair?;
            if (seat == null) return;
            seat.Value.Seat.RevokeBooking(_user, seat.Value.Date);
            UpdateTable();
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            var seat = dataGrid.SelectedItem as SeatDatePair?;
            if (seat == null) return;
            var seatValue = seat.Value.Seat;
            var date = seat.Value.Date;
            seat.Value.Seat.RevokeBooking(_user, seat.Value.Date);
            UpdateTable();
            var wagonView = new WagonView(_user, seatValue.Wagon, new DateTime(date.Year, date.Month, date.Day));
            wagonView.Show();
        }
    }
}
