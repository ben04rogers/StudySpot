using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using StudySpot.Models;
using System.Collections.ObjectModel;


namespace StudySpot.ViewModels
{
    public class TodaysClassesPageViewModel : BaseViewModel
    {
        public ObservableCollection<TodaysClass> TodaysClasses { get; set; }

        public TodaysClassesPageViewModel()
        {
            SetupData();

            Title = "Todays Classes";
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
                    Platform = "Zoom ID: 937109249"
                },
                new TodaysClass
                {
                    UnitCode = "IAB330",
                    Time = "11:00",
                    TimePeriod = "AM",
                    LessonType = "Online Tutorial",
                    Platform = "Microsoft Teams"
                },
                new TodaysClass
                {
                    UnitCode = "IAB330",
                    Time = "11:00",
                    TimePeriod = "AM",
                    LessonType = "Online Tutorial",
                    Platform = "Microsoft Teams"
                }
            };
        }
    }
}
