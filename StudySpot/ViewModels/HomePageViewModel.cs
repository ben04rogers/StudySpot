using System;
using Xamarin.Forms;
using MvvmHelpers;
using System.Collections.ObjectModel;
using StudySpot.Models;

namespace StudySpot.ViewModels
{
    [QueryProperty("BgColorChoice", "bgcolor")]
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<TodaysClass> TodaysClasses { get; set; }
        public ObservableCollection<Message> RecentMessages { get; set; }
        public ObservableCollection<Unit> Units { get; set; }

        public Student user;
        public String TodaysClassesLabel { get; set; }
        public String MessagesCount { get; set; }
        public String TodaysClassesCount { get; set; }

        // Button commands
        public Command GoToSettings { get; }
        public Command GoToTodaysClasses { get; }
        public Command GoToMessages { get; }
        public Command GoToUnit1 { get; }
        public Command GoToUnit2 { get; }
        public Command GoToUnit3 { get; }
        public Command GoToUnit4 { get; }

        public HomePageViewModel()
        {
            // Setup Mock Data
            SetupData();

            // Top Welcome greeting
            String greeting = $"Welcome {user.FirstName},";
            Title = greeting;

            // Todays Classes Count Label
            String ClassCountLabel = $"Todays Classes ({TodaysClasses.Count})";
            TodaysClassesLabel = ClassCountLabel;

            // Messages Count Label
            String MessagesCountLabel = $"Messages ({RecentMessages.Count})";
            MessagesCount = MessagesCountLabel;

            // Messages Count (red indicator at top)
            TodaysClassesCount = TodaysClasses.Count.ToString();

            GoToSettings = new Command(GoToSettingsPage);
            GoToTodaysClasses = new Command(GoToTodaysClassesPage);
            GoToMessages = new Command(GoToMessagesPage);
            GoToUnit1 = new Command(GoToUnit1Page);
            GoToUnit2 = new Command(GoToUnit2Page);
            GoToUnit3 = new Command(GoToUnit3Page);
            GoToUnit4 = new Command(GoToUnit4Page);

            // Set default background colour (if user does not select one in settings)
            BgColorChoice = "00A6FF";

        }

        string bgcolor;
        public string BgColorChoice
        {
            get => bgcolor;
            set
            {
                SetProperty(ref bgcolor, value); //MvvmHelpers Implementation
                OnPropertyChanged(nameof(BgColorChoice));
            }
        }

        async void GoToSettingsPage()
        {
            await Shell.Current.GoToAsync("SettingsPage");
        }

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


        // Mock Data for testing

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
                    Link = "www.test.com",
                    UnitColor = "#13CE66",
                    ImageName = "zoom.png"

                },
                new TodaysClass
                {
                    UnitCode = "IAB330",
                    Time = "11:00",
                    TimePeriod = "AM",
                    LessonType = "Online Tutorial",
                    Platform = "Microsoft Teams",
                    Link = "www.test.com",
                    UnitColor = "#F95F62",
                    ImageName = "msteams.png"
                },
                new TodaysClass
                {
                    UnitCode = "CAB202",
                    Time = "11:00",
                    TimePeriod = "AM",
                    LessonType = "Online Tutorial",
                    Platform = "Microsoft Teams",
                    Link = "www.test.com",
                    UnitColor = "#00A6FF",
                    ImageName = "msteams.png"
                },
            };

            user = new Student
            {
                FirstName = "James",
                LastName = "Smith",
                Id = "1",
                Email = "james@gmail.com",
                Password = "testpassword123"
            };

            RecentMessages = new ObservableCollection<Message>()
            {
                 new Message
                {
                    Sender = "JAMES ROSS",
                    UnitCode = "CAB202",
                    UnitColor = "#00A6FF",
                    Content = "Assignment marks are available...",
                    UserImageName = "jamesross.png"
                },
                  new Message
                {
                    Sender = "BOB SMITH",
                    UnitCode = "CAB301",
                    UnitColor = "#FFD185",
                    Content = "Room Change for tutorial today. This is a long message to show that it automatically cuts off",
                    UserImageName = "bobsmith.png"
                },
                 new Message
                {
                    Sender = "JOSH HAAN",
                    UnitCode = "CAB303",
                    UnitColor = "#13CE66",
                    Content = "Great work! Looks great",
                    UserImageName = "joshhaan.png"
                },
                new Message
                {
                    Sender = "JAKE THOMPSON",
                    UnitCode = "IAB330",
                    UnitColor = "#F95F62",
                    Content = "Please refer to CRA for more details",
                    UserImageName = "jakethompson.png"
                }
            };

            Units = new ObservableCollection<Unit>()
            {
                new Unit
                {
                    UnitName = "Microprocessors and Digital Systems",
                    UnitCode = "CAB202",
                    Description = "C programming",
                    Color = "#00A6FF",
                },
                new Unit
                {
                    UnitName = "Mobile Application Development",
                    UnitCode = "IAB330",
                    Description = "Xamarin Forms and MVVM",
                    Color = "#F95F62"
                },
                new Unit
                {
                    UnitName = "Networks",
                    UnitCode = "CAB303",
                    Description = "Computer Networks",
                    Color = "#13CE66"
                },
                new Unit
                {
                    UnitName = "Algorithms and Complexity",
                    UnitCode = "CAB301",
                    Description = "Fundamental Principles of Software Algorithms",
                    Color = "#FFD185"
                }
            };
        }
    }
}
