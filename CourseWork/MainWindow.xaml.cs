﻿using System;
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
        }

        private void userLoginButton_Click(object sender, RoutedEventArgs e)
        {
            var user = new User(false);
            var wagonView = new TrainsSearchView(user);
            wagonView.Show();
            Close();
        }

        private void adminLoginButton_Click(object sender, RoutedEventArgs e)
        {
            var user = new User(true);
            var wagonView = new TrainsSearchView(user);
            wagonView.Show();
            Close();
        }
    }
}
