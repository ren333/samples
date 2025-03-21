﻿using CSharpFeaturesDemo.ViewModels;
using System.Windows;

namespace CSharpFeaturesDemo.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void MsgBtnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Message!");
        }
    }
}
