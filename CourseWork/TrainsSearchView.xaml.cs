﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TrainSystem;

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for TrainsSearchView.xaml
    /// </summary>
    public partial class TrainsSearchView : Window
    {
        public TrainsSearchView(TrainsManager trainsManager, User user)
        {
            InitializeComponent();

            _user = user;
            if (!_user.IsAdmin)
                addNewTrainButton.Visibility = Visibility.Hidden;

            _trainsManager = trainsManager;

            datePicker.SelectedDateChanged += OnSelectedDateChanged;
            datePicker.SelectedDate = DateTime.Today;

            UpdateTable();
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

        private void UpdateFilteredTrains()
        {
            _filteredTrains = _trainsManager.FilterTrains(keywordBox.Text, _selectedDate);
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

        private void profileButton_Click(object sender, RoutedEventArgs e)
        {
            var profileWindow = new ProfileWindow(_user);
            profileWindow.Closed += OnOtherWindowClosed;
            profileWindow.Show();
        }
    }
}
