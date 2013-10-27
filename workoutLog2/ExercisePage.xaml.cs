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
    public partial class ExercisePage : PhoneApplicationPage
    {
        // Constructor
        public ExercisePage()
        {
            InitializeComponent();


            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Debug.WriteLine("Settings data context to: " + App.index1 + " " + App.index2);
            //DataContext = App.ViewModel.Items[App.index1].Exercises[App.index2];
            if (DataContext == null)
            {
                string selectedIndex = "";
                // int index1 =  NavigationContext.QueryString.TryGetValue("index", out index1)
                string index1string;
                int exindex = 0;
                if (NavigationContext.QueryString.TryGetValue("index", out index1string))
                {
                    exindex = int.Parse(index1string);
                    App.index2 = exindex;
                }
                if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
                {
                    int workoutindex = int.Parse(selectedIndex);
                    App.index1 = workoutindex;
                    DataContext = App.ViewModel.Items[workoutindex].Exercises[exindex];
                }
                else
                {
                    DataContext = App.ViewModel.Items[App.ViewModel.Items.Count].Exercises[1];
                }
            }
        }

        private void Increase_Reps(object sender, EventArgs e)
        {
            App.ViewModel.Items[App.index1].Exercises[App.index2].Reps = int.Parse(this.repsInputBox.Text);

            App.ViewModel.Items[App.index1].Exercises[App.index2].Reps++;

        }
        private void Decrease_Reps(object sender, EventArgs e)
        {
            App.ViewModel.Items[App.index1].Exercises[App.index2].Reps = int.Parse(this.repsInputBox.Text);

            App.ViewModel.Items[App.index1].Exercises[App.index2].Reps--;

        }

        private void Increase_Sets(object sender, EventArgs e)
        {
            //Debug.WriteLine("I was called");
            App.ViewModel.Items[App.index1].Exercises[App.index2].Sets = int.Parse(this.setsInputBox.Text);

            App.ViewModel.Items[App.index1].Exercises[App.index2].Sets++;

        }
        private void Decrease_Sets(object sender, EventArgs e)
        {
            App.ViewModel.Items[App.index1].Exercises[App.index2].Sets = int.Parse(this.setsInputBox.Text);

            App.ViewModel.Items[App.index1].Exercises[App.index2].Sets--;

        }
        private void Update_Name(object sender, EventArgs e)
        {
            App.ViewModel.Items[App.index1].Exercises[App.index2].Name = exerciseInputBox.Text;

        }
        private void Update_Weight(object sender, EventArgs e)
        {
            if (weightInputBox.Text != "")
            {
                App.ViewModel.Items[App.index1].Exercises[App.index2].Weight = int.Parse(weightInputBox.Text);
            }
        }

        private void Confirm_Activity(object sender, EventArgs e)
        {
            App.ViewModel.Items[App.index1].Exercises[App.index2].Reps = int.Parse(this.repsInputBox.Text);
            App.ViewModel.Items[App.index1].Exercises[App.index2].Sets = int.Parse(this.setsInputBox.Text);
            NavigationService.GoBack();
        }

        private void Delete_Activity(object sender, EventArgs e)
        {
            //DataContext = App.ViewModel.Items[App.index1];
            App.ViewModel.Items[App.index1].Exercises.Remove(App.ViewModel.Items[App.index1].Exercises[App.index2]);
            GC.Collect();
            for (int i = App.index2; i < App.ViewModel.Items[App.index1].Exercises.Count; i++)
            {
                App.ViewModel.Items[App.index1].Exercises[i].ID = (Convert.ToInt32(App.ViewModel.Items[App.index1].Exercises[i].ID) - 1).ToString();
            }
            //NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + App.index1, UriKind.Relative));
        }

        private void rename_keydown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key.ToString() == "Enter")
            {
                this.Focus();
            }
        }

        








    }
}