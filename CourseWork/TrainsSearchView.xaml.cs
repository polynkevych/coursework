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
    /// Interaction logic for TrainsSearchView.xaml
    /// </summary>
    public partial class TrainsSearchView : Window
    {
        public TrainsSearchView(User user)
        {
            InitializeComponent();

            _user = user;
            if (!_user.IsAdmin)
                addNewTrainButton.Visibility = Visibility.Hidden;

            _trainsManager = new TrainsManager();
            _trainsManager.AddTrain("0", "Huevo-Kukuevo");
            _trainsManager.AddTrain("1", "Moskva-Petushki").AddWagon(1);

            _filteredTrains = _trainsManager.Trains;
            datePicker.SelectedDateChanged += OnSelectedDateChanged;
            datePicker.SelectedDate = DateTime.Today;

            UpdateTable();
        }

        public void UpdateFilteredTrains()
        {
            _filteredTrains = _trainsManager.FilterTrains(keywordBox.Text, _selectedDate);
        }

        private User _user;
        private TrainsManager _trainsManager;
        private List<Train> _filteredTrains;
        private Date _selectedDate;

        private void UpdateTable()
        {
            UpdateFilteredTrains();

            dataGrid.Items.Clear();
            foreach (var train in _filteredTrains)
            {
                dataGrid.Items.Add(train);
            }
        }

        private void OnOtherWindowClosed(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePicker.SelectedDate == null) return;
            DateTime dateTime = (DateTime)datePicker.SelectedDate;

            _selectedDate = new Date(dateTime);
            UpdateTable();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem == null) return;
            var train = dataGrid.SelectedItem as Train;
            if (train == null) return;
            var trainView = new TrainView(_user, train, datePicker.SelectedDate);
            trainView.Closed += OnOtherWindowClosed;
            trainView.Show();
        }

        private void keywordBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTable();
        }

        private void addNewTrainButton_Click(object sender, RoutedEventArgs e)
        {
            var addTrain = new AddTrain(_trainsManager);
            addTrain.Closed += OnOtherWindowClosed;
            addTrain.Show();
        }
    }
}
