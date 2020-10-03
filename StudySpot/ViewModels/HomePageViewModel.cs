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


        // Button commands
        public Command GoToTodaysClasses { get; }
        public Command GoToMessages { get; }
        public Command GoToUnit1 { get; }
        public Command GoToUnit2 { get; }
        public Command GoToUnit3 { get; }
        public Command GoToUnit4 { get; }

        public HomePageViewModel()
        {
            // Test data
            SetupData();

            Title = "Home";

            GoToTodaysClasses = new Command(GoToTodaysClassesPage);
            GoToMessages = new Command(GoToMessagesPage);
            GoToUnit1 = new Command(GoToUnit1Page);
            GoToUnit2 = new Command(GoToUnit2Page);
            GoToUnit3 = new Command(GoToUnit3Page);
            GoToUnit4 = new Command(GoToUnit4Page);
        }
        // 'My Units' Buttons 
        async void GoToTodaysClassesPage()
        {
            await Shell.Current.GoToAsync("TodaysClassesPage");
        }

        async void GoToMessagesPage()
        {
            await Shell.Current.GoToAsync("MessagesPage");
        }

        async void GoToUnit1Page()
        {
            await Shell.Current.GoToAsync("Unit1Page");
        }

        async void GoToUnit2Page()
        {
            await Shell.Current.GoToAsync("Unit2Page");
        }
        async void GoToUnit3Page()
        {
            await Shell.Current.GoToAsync("Unit3Page");
        }
        async void GoToUnit4Page()
        {
            await Shell.Current.GoToAsync("Unit4Page");
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
                    Platform = "Zoom ID: 937109249",
                    UnitColor = "#13CE66"
                },
                new TodaysClass
                {
                    UnitCode = "IAB330",
                    Time = "11:00",
                    TimePeriod = "AM",
                    LessonType = "Online Tutorial",
                    Platform = "Microsoft Teams",
                    UnitColor = "#F95F62"

                },
                new TodaysClass
                {
                    UnitCode = "CAB202",
                    Time = "11:00",
                    TimePeriod = "AM",
                    LessonType = "Online Tutorial",
                    Platform = "Microsoft Teams",
                    UnitColor = "#00A6FF"

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
                    Sender = "TUTOR JAKES ROSS",
                    UnitCode = "CAB202",
                    UnitColor = "#00A6FF",
                    Content = "Assignment marks are available..."
                },
                  new Message
                {
                    Sender = "TUTOR BOB SMITH",
                    UnitCode = "CAB301",
                    UnitColor = "#FFD185",
                    Content = "Room Change for tutorial today"
                },
                 new Message
                {
                    Sender = "TUTOR BOB SMITH",
                    UnitCode = "CAB303",
                    UnitColor = "#13CE66",
                    Content = "Great work! Looks great"
                },
                new Message
                {
                    Sender = "LECTURER JAMES",
                    UnitCode = "IAB330",
                    UnitColor = "#F95F62",
                    Content = "Please refer to CRA for more details"
                }
               
               
            };
        }
    }
}
