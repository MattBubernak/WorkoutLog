using System;
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


namespace WorkoutLog2
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        // Constructor
        public DetailsPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                string selectedIndex = "";
                if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
                {
                    App.index1 = int.Parse(selectedIndex);
                    Debug.WriteLine(App.index1);
                    DataContext = App.ViewModel.Items[App.index1];
                }
                else
                {
                    DataContext = App.ViewModel.Items[App.ViewModel.Items.Count];
                }
            }
        }

        private void Rename_Workout(object sender, TextChangedEventArgs e)
        {
                DataContext = App.ViewModel.Items[App.index1];
                App.ViewModel.Items[App.index1].Title = this.inputBox.Text;
        }

        private void Add_Workout(object sender, EventArgs e)
        {
                DataContext = App.ViewModel.Items[App.index1];
                App.ViewModel.Items[App.index1].Exercises.Add(new Exercise() { ID = (App.ViewModel.Items[App.index1].Exercises.Count).ToString() });
        }

        private void Delete_Workout(object sender, EventArgs e)
        {
                DataContext = App.ViewModel.Items[App.index1];
                App.ViewModel.Items.Remove(App.ViewModel.Items[App.index1]);
                GC.Collect();
                Debug.WriteLine((App.ViewModel.Items.Count - 1).ToString());
                for (int i = App.index1; i < App.ViewModel.Items.Count; i++)
                {
                    App.ViewModel.Items[i].ID = (Convert.ToInt32(App.ViewModel.Items[i].ID) - 1).ToString();
                }
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));  
        }

        private void ExerciseLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedIndex = "";
            int da = 0;
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                  da = int.Parse(selectedIndex);
            }
            // If selected item is null (no selection) do nothing
            if (ExerciseLongListSelector.SelectedItem == null)
                return;
            Debug.WriteLine("Sending over this Exercise ID:" + (ExerciseLongListSelector.SelectedItem as Exercise).ID);

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/ExercisePage.xaml?selectedItem=" + (ExerciseLongListSelector.SelectedItem as Exercise).ID + "&index=" + da, UriKind.Relative));

            // Reset selected item to null (no selection)
            ExerciseLongListSelector.SelectedItem = null;
        }

        private void remove_focus_name(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key.ToString() == "Enter")
            {
                this.Focus();
            }
        }

        

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
       // {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
         //   ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
         //   ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Images/add.png", UriKind.Relative));
         //   appBarButton.Text = AppResources.AppBarButtonText;
         //   ApplicationBar.Buttons.Add(appBarButton);

            // Create a new menu item with the localized string from AppResources.
          //  ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
          //  ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}