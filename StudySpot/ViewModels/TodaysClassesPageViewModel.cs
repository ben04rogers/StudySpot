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


namespace StudySpot.ViewModels
{
    public class TodaysClassesPageViewModel : BaseViewModel
    {
        public ObservableCollection<TodaysClass> TodaysClasses { get; set; }

        public Command ClassDetails { get; }
        public String ClassCountMessage { get; set; }

        public TodaysClassesPageViewModel()
        {
            SetupData();

            Title = "Todays Classes";

            // Todays Class Count Message 
            String ClassCountMessageLabel = $"You have {TodaysClasses.Count} classes today";
            ClassCountMessage = ClassCountMessageLabel;

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


        // Dummy Data to test with
        void SetupData()
        {
            TodaysClasses = new ObservableCollection<TodaysClass>()
            {
                new TodaysClass
                {
                    UnitCode = "CAB303",
                    Time = "9:00",
                    TimePeriod = "AM",
                    LessonType = "Online Workshop",
                    Platform = "Zoom",
                    Link = "9201291021",
                    UnitColor = "#13CE66"
                },
                new TodaysClass
                {
                    UnitCode = "IAB330",
                    Time = "11:00",
                    TimePeriod = "AM",
                    LessonType = "Online Tutorial",
                    Platform = "Microsoft Teams",
                    Link = "https://teams.microsoft.com/IAB330",
                    UnitColor = "#F95F62"

                },
                new TodaysClass
                {
                    UnitCode = "CAB202",
                    Time = "11:00",
                    TimePeriod = "AM",
                    LessonType = "Online Tutorial",
                    Platform = "Microsoft Teams",
                    Link = "https://teams.microsoft.com/CAB202",
                    UnitColor = "#00A6FF"

                }
            };
        }
    }
}
