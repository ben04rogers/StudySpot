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
        private Item _selectedItem;
        public ObservableCollection<TodaysClass> TodaysClasses { get; set; }

        public Command ClassDetails { get; }

        public Command LoadItemsCommand { get; }

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
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            Title = "Todays Classes";

            // Class Details Button
            ClassDetails = new Command(DisplayClassDetails);
        }

        async Task ExecuteLoadItemsCommand()
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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
            }
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
    }
}
