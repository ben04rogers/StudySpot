using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using StudySpot.Models;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using Xamarin.Forms;
using StudySpot.Views;
using Xamarin.Essentials;
using System.Dynamic;
using System.Diagnostics;
using System.Threading.Tasks;


namespace StudySpot.ViewModels
{
    public class TodaysClassesPageViewModel : BaseViewModel
    {
        public ObservableCollection<TodaysClass> TodaysClasses { get; set; }
        public Command ClassDetails { get; }

        // Todays Classes(X) Label
        private String _todaysClassesLabel;
        public String TodaysClassesLabel
        {
            get => _todaysClassesLabel;
            set
            {
                SetProperty(ref _todaysClassesLabel, value);
                OnPropertyChanged(nameof(TodaysClassesLabel));
            }
        }

        public TodaysClassesPageViewModel()
        {
            // Load Mock Data
            TodaysClasses = new ObservableCollection<TodaysClass>();

            // Load Data
            GetData();

            Title = "Todays Classes";

            // Class Details Button
            ClassDetails = new Command(DisplayClassDetails);
        }

        TodaysClass todaysclass;
        public TodaysClass SelectedTodaysClass
        {
            get => todaysclass;
            set
            {
                SetProperty(ref todaysclass, value); //MvvmHelpers Implementation
                OnPropertyChanged(nameof(SelectedTodaysClass));
            }
        }

        async void DisplayClassDetails()
        {
            if (SelectedTodaysClass != null)
            {
                
                await Application.Current.MainPage.DisplayAlert("Join via ", "" + SelectedTodaysClass.Platform + "\n" + SelectedTodaysClass.Link, "Copy to clipboard");
                await Clipboard.SetTextAsync(SelectedTodaysClass.Link);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Nothing Selected!", "OK");
                return;
            }
        }

        private async void GetData()
        {
            IsBusy = true;

            try
            {
                TodaysClasses.Clear();

                var todaysclasses = await DataStore2.GetItemsAsync(true);
                foreach (var todaysclass in todaysclasses)
                {
                    TodaysClasses.Add(todaysclass);
                }

                // Count number of classes today
                TodaysClassesLabel = $"Todays Classes ({TodaysClasses.Count})";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
