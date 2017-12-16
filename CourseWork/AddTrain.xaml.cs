using System.Windows;
using TrainSystem;

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for AddTrain.xaml
    /// </summary>
    public partial class AddTrain : Window
    {
        public AddTrain(TrainsManager trainsManager)
        {
            InitializeComponent();

            _trainsManager = trainsManager;
        }

        private TrainsManager _trainsManager;

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addTrainButton_Click(object sender, RoutedEventArgs e)
        {
            if (idBox.Text == "" || directionBox.Text == "") return;
            _trainsManager.AddTrain(idBox.Text, directionBox.Text);
            Close();
        }
    }
}
