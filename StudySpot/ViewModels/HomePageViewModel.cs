using System;
using Xamarin.Forms;
using MvvmHelpers;
using System.Collections.ObjectModel;
using StudySpot.Models;

namespace StudySpot.ViewModels
{
    [QueryProperty("Email", "email")]
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<TodaysClass> TodaysClasses { get; set; }
        public ObservableCollection<Student> StudentUser { get; set; }
        public ObservableCollection<Message> RecentMessages { get; set; }

        public Command GoToTodaysClasses { get; }
        public Command GoToMessages { get; }

        public HomePageViewModel()
        {
            // Test data
            SetupData();

            Title = "Home";

            GoToTodaysClasses = new Command(GoToTodaysClassesPage);
            GoToMessages = new Command(GoToMessagesPage);
        }

        async void GoToTodaysClassesPage()
        {
            await Shell.Current.GoToAsync("TodaysClassesPage");
        }

        async void GoToMessagesPage()
        {
            await Shell.Current.GoToAsync("MessagesPage");
        }

        string email;
        public string Email
        {
            get => email;
            set
            {
                SetProperty(ref email, Uri.UnescapeDataString(value)); //MvvmHelpers Implementation
                OnPropertyChanged(nameof(Email));

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

            StudentUser = new ObservableCollection<Student>()
            {
                new Student
                {
                    FirstName = "Ben",
                    LastName = "Rogers",
                    Id = "1",
                    Email = "ben@rogers.com",
                    Password = "testpassword123"
                }
            };

            RecentMessages = new ObservableCollection<Message>()
            {
                new Message
                {
                    Sender = "LECTURER JAMES",
                    UnitCode = "IAB303",
                    Content = "Please refer to CRA for more details"
                },
                new Message
                {
                    Sender = "TUTOR JAKES ROSS",
                    UnitCode = "CAB202",
                    Content = "Assignment marks are available..."
                },
                new Message
                {
                    Sender = "TUTOR BOB SMITH",
                    UnitCode = "CAB301",
                    Content = "Great work! Looks great"
                }
            };
        }
    }
}
