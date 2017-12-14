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
        public TrainsSearchView()
        {
            InitializeComponent();

            _trainsManager = new TrainsManager();
            var train1 = new Train(0, "Huevo-Kukuevo");
            _trainsManager.AddTrain(train1);
            train1.AddWagon(new Wagon());
            var train2 = new Train(1, "Moskva-Petushki");
            _trainsManager.AddTrain(train2);
            train2.AddWagon(new Wagon());

            _filteredTrains = _trainsManager.Trains;

            UpdateTable();
        }

        private TrainsManager _trainsManager;
        private List<Train> _filteredTrains;

        private void UpdateFilteredTrains()
        {
            if (datePicker == null) return;
            if (datePicker.SelectedDate == null) return;
            var date = (DateTime)datePicker.SelectedDate;
            _filteredTrains = _trainsManager.FilterTrains(keywordBox.Text, new Date(date));

            UpdateTable();
        }

        private void UpdateTable()
        {
            dataGrid.Items.Clear();
            foreach (var train in _filteredTrains)
            {
                dataGrid.Items.Add(train);
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void keywordBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateFilteredTrains();
        }
    }
}
