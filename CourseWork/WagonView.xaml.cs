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
    /// Interaction logic for WagonView.xaml
    /// </summary>
    public partial class WagonView : Window
    {
        public WagonView(User user, Wagon wagon, DateTime? selectedDate)
        {
            InitializeComponent();

            _user = user;
            if (!_user.IsAdmin)
                deleteButton.Visibility = Visibility.Hidden;

            _wagon = wagon;

            UpdateTickets();

            datePicker.SelectedDateChanged += OnSelectedDateChanged;
            datePicker.SelectedDate = selectedDate;
        }

        private User _user;
        private Wagon _wagon;
        private Date _selectedDate;

        private void UpdateTickets()
        {
            availableTickes.Items.Clear();
            bookedTickets.Items.Clear();

            var availibleSeats = _wagon.GetAvailibleSeats(_selectedDate);
            foreach (var seat in availibleSeats)
            {
                availableTickes.Items.Add(seat);
            }

            var bookedSeats = _wagon.GetBookedSeats(_selectedDate);
            foreach (var seat in bookedSeats)
            {
                bookedTickets.Items.Add(seat);
            }
        }

        private void OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePicker.SelectedDate == null) return;
            DateTime dateTime = (DateTime)datePicker.SelectedDate;

            _selectedDate = new Date(dateTime);
            UpdateTickets();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (availableTickes.SelectedItem == null) return;
            var seat = availableTickes.SelectedItem as Seat;
            if (seat == null) return;
            if (!seat.IsBooked(_selectedDate))
                bookButton.IsEnabled = true;
            else
                bookButton.IsEnabled = false;
        }

        private void bookButton_Click(object sender, RoutedEventArgs e)
        {
            if (availableTickes.SelectedItem == null) return;
            var seat = availableTickes.SelectedItem as Seat;
            if (seat == null) return;
            seat.Book(_user, _selectedDate);
            UpdateTickets();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            _wagon.Train.DeleteWagon(_wagon);
            Close();
        }
    }
}
