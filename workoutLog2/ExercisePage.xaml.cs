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
            if (DataContext == null)
            {
                string selectedIndex = "";
               // int index1 =  NavigationContext.QueryString.TryGetValue("index", out index1)
                string index1string;
                int index1 = 0;
                if (NavigationContext.QueryString.TryGetValue("index", out index1string))
                {
                    index1 = int.Parse(index1string);
                    App.index1 = index1;
                }
                if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
                {

                    int index2 = int.Parse(selectedIndex);
                    App.index2 = index2; 
                    DataContext = App.ViewModel.Items[index1].Exercises[index2];
                }
                else
                {
                    DataContext = App.ViewModel.Items[App.ViewModel.Items.Count].Exercises[1];
                }
            }
        }

        private void Increase_Reps(object sender, EventArgs e)
        {

            App.ViewModel.Items[App.index1].Exercises[App.index2].Reps++;

        }
        private void Decrease_Reps(object sender, EventArgs e)
        {
            App.ViewModel.Items[App.index1].Exercises[App.index2].Reps--;

        }

        private void Increase_Sets(object sender, EventArgs e)
        {
            Debug.WriteLine("I was called");

            App.ViewModel.Items[App.index1].Exercises[App.index2].Sets++;

        }
        private void Decrease_Sets(object sender, EventArgs e)
        {
            App.ViewModel.Items[App.index1].Exercises[App.index2].Sets--;

        }
        private void Update_Name(object sender, EventArgs e)
        {
            App.ViewModel.Items[App.index1].Exercises[App.index2].Name = inputBox2.Text;

        }
        private void Update_Weight(object sender, EventArgs e)
        {
            if (inputBox3.Text != "")
            {
                App.ViewModel.Items[App.index1].Exercises[App.index2].Weight = int.Parse(inputBox3.Text);
            }
        }
       
       

        

        

      
    }
}