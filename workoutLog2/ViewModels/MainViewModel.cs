using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WorkoutLog2.Resources;
using System.IO.IsolatedStorage;
using System.Diagnostics;
using System.Threading;


namespace WorkoutLog2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<ItemViewModel>();
            stopwatch = new Stopwatch();
            timer = new TimerViewModel();
            this._timer = new Timer(new TimerCallback((s) => this.FirePropertyChanged()),
            null, 1000, 1000);
            TestString = "nud"; 

        }

         

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        public Stopwatch stopwatch { get;  set; }
        public TimerViewModel timer { get; private set; }
        public string teststring { get; private set; }
        private Timer _timer;



        private string _sampleProperty = "Sample Runtime Property Value";

        private void FirePropertyChanged()
        {
            teststring = teststring + "g";
            NotifyPropertyChanged("TestString");
        }

        private string _teststring;

        public string TestString
        {
            get
            {
                return _teststring;
            }
            set
            {
                if (value != _teststring)
                {
                    _teststring = value;
                    NotifyPropertyChanged("TestString");
                }
            }
        }


        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

     

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            Debug.WriteLine("Loading Data!!");
            // Sample data; replace with real data
          //this.Items.Add(new ItemViewModel() { ID = "0", Title = "Arms Workout", DateCreated = "11/12/13", LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
          // this.Items.Add(new ItemViewModel() { ID = "1", Title = "Legs Workout", DateCreated = "11/12/13", LineThree = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
          //  this.Items.Add(new ItemViewModel() { ID = "2", Title = "Abs Workout", DateCreated = "11/12/13", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos" });
          //  this.Items.Add(new ItemViewModel() { ID = "3", Title = "Toes Workout", DateCreated = "11/12/13", LineThree = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur" });
          //  this.Items.Add(new ItemViewModel() { ID = "4", Title = "Bicep Workout", DateCreated = "11/12/13", LineThree = "Pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent" });
            
            
              if (IsolatedStorageSettings.ApplicationSettings.Contains("numOfWorkouts"))
            {
                int numOfWorkouts = (int)IsolatedStorageSettings.ApplicationSettings["numOfWorkouts"];
                Debug.WriteLine(numOfWorkouts);

               // int arr = (int)IsolatedStorageSettings.ApplicationSettings["arr" + 1];
                //Debug.W/riteLine(arr);
                for (int i = 0; i < numOfWorkouts; i++)
                {
                   Debug.WriteLine("Checking Workout" + i);
                   string[] arr = (string[])IsolatedStorageSettings.ApplicationSettings["workout" + i.ToString()];
                   Debug.WriteLine("just imported the first arr");
                   this.Items.Add(new ItemViewModel() { ID = i.ToString(), Title = arr[1], DateCreated = arr[0], LineThree = "" });
                   Debug.WriteLine(arr[2]);
                   for (int j = 0; j < Convert.ToInt32(arr[2]); j++)
                   {
                       string[] arr2 = (string[])IsolatedStorageSettings.ApplicationSettings["workout" + i.ToString() + "ex" + j.ToString()];
                       this.Items[i].Exercises.Add(new Exercise() { ID = j.ToString(), Name = arr2[0], Reps = Convert.ToInt32(arr2[1]), Sets = Convert.ToInt32(arr2[2]), Weight = Convert.ToInt32(arr2[3]) });
                   }

                }
                //App.ViewModel.Items[App.index1].Exercises.Add(new Exercise() { ID = (App.ViewModel.Items[App.index1].Exercises.Count).ToString() });
            }
             
            this.IsDataLoaded = true;
             
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}