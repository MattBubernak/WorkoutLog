﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WorkoutLog2.Resources;
using WorkoutLog2.ViewModels;
using System.Diagnostics;
using Microsoft.Phone.Tasks;
namespace WorkoutLog2
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the LongListSelector control to the sample data
            DataContext = App.ViewModel;

            //float timer = 0; 
            //Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        // Handle selection changed on LongListSelector
        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (MainLongListSelector.SelectedItem == null)
                return;
            Debug.WriteLine((MainLongListSelector.SelectedItem as ItemViewModel).ID);

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (MainLongListSelector.SelectedItem as ItemViewModel).ID, UriKind.Relative));

            // Reset selected item to null (no selection)
            MainLongListSelector.SelectedItem = null;
        }

        private void New_Workout_Button_Click_1(object sender, RoutedEventArgs e)
        {

            //Add the item
            
            App.ViewModel.Items.Add(new ItemViewModel() { ID = (App.ViewModel.Items.Count).ToString(), Title = "Untitled", DateCreated = ""+DateTime.Now });
            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (App.ViewModel.Items.Count-1).ToString(), UriKind.Relative));

        }

        private void Continue_Workout_Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (App.ViewModel.Items.Count - 1).ToString(), UriKind.Relative));
        }

        

        private void send_email(object sender, RoutedEventArgs e)
        {
            var task = new EmailComposeTask { To = "BirdBucketProductions@gmail.com" };
            task.Show();
        }

        

        private void reset_timer(object sender, RoutedEventArgs e)
        {
            //Debug.WriteLine(App.viewModel.stopwatch.ElapsedMilliseconds);
            App.viewModel.timer.Reset();
            ExerciseResult testresult = new ExerciseResult();
            Debug.WriteLine(testresult.Name);
            App.recordBook.Records.Add("test", testresult);
            Debug.WriteLine("Attempting to print a record" + App.recordBook.Records["test"].Name);
        }

        private void start_timer(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("about to start the stopwatch");

            App.viewModel.timer.Start();
            Debug.WriteLine("started the stopwatch");

        }

        private void stop_timer(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(App.viewModel.stopwatch.ElapsedMilliseconds);

           App.viewModel.timer.Stop(); 
        }

        private void ResultsLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}