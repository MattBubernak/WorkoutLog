﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Collections.ObjectModel;


namespace WorkoutLog2.ViewModels
{
    public class Exercise : INotifyPropertyChanged
    {
        public Exercise()
        {
            Name = "Untitled";
            Sets = 3;
            Reps = 8;
            Weight = 0;
        }
        private string _id;
        /// <summary>
        /// Sample ViewModel property; this property is used to identify the object.
        /// </summary>
        /// <returns></returns>
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        private string _name;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        private int _weight;
        public int Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (value != _weight)
                {
                    _weight = value;
                    NotifyPropertyChanged("Weight");
                }
            }
        }

        private int _reps;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public int Reps
        {
            get
            {
                return _reps;
            }
            set
            {
                if (value != _reps)
                {
                    _reps = value;
                    NotifyPropertyChanged("Reps");
                }
            }
        }

        private int _sets;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public int Sets
        {
            get
            {
                return _sets;
            }
            set
            {
                if (value != _sets)
                {
                    _sets = value;
                    NotifyPropertyChanged("Sets");
                }
            }
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