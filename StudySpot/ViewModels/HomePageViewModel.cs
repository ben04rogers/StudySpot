using System;
using Xamarin.Forms;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using StudySpot.Models;
using StudySpot.Views;
using StudySpot.Services;
using System.Diagnostics;

namespace StudySpot.ViewModels
{
    [QueryProperty("BgColorChoice", "bgcolor")]
    public class HomePageViewModel : BaseViewModel
    {
        private Item _selectedItem;
        public ObservableCollection<TodaysClass> TodaysClasses { get; set; }
        public ObservableCollection<Message> RecentMessages { get; set; }
        public ObservableCollection<Unit> Units { get; set; }
        public Student user;

        // Load mock data 
        public Command LoadItemsCommand { get; }

        // Button commands
        public Command GoToSettings { get; }
        public Command GoToTodaysClasses { get; }
        public Command GoToMessages { get; }
        public Command GoToUnit1 { get; }
        public Command GoToUnit2 { get; }
        public Command GoToUnit3 { get; }
        public Command GoToUnit4 { get; }


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

        // Todays Classes Count
        private String _todaysClassesCount;
        public String TodaysClassesCount
        {
            get => _todaysClassesCount;
            set
            {
                SetProperty(ref _todaysClassesCount, value);
                OnPropertyChanged(nameof(TodaysClassesCount));
            }
        }

        // Messages Label
        private String _recentMessagesLabel;
        public String RecentMessagesLabel
        {
            get => _recentMessagesLabel;
            set
            {
                SetProperty(ref _recentMessagesLabel, value);
                OnPropertyChanged(nameof(RecentMessagesLabel));
            }
        }

        public HomePageViewModel()
        {
            TodaysClasses = new ObservableCollection<TodaysClass>();
            RecentMessages = new ObservableCollection<Message>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            // Setup Mock Data
            SetupData();

            // Top Welcome greeting
            String greeting = $"Welcome {user.FirstName},";
            Title = greeting;

            // Buttons
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

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                RecentMessages.Clear();
                TodaysClasses.Clear();

                var todaysclasses = await DataStore2.GetItemsAsync(true);
                foreach (var todaysclass in todaysclasses)
                {
                    TodaysClasses.Add(todaysclass);
                }

                var recentmessages = await DataStore3.GetItemsAsync(true);
                foreach (var recentmessage in recentmessages)
                {
                    RecentMessages.Add(recentmessage);
                }

                // Count number of classes today
                TodaysClassesLabel = $"Todays Classes ({TodaysClasses.Count})";
                TodaysClassesCount = TodaysClasses.Count.ToString();

                // Count number of recent messages
                RecentMessagesLabel = $"Messages ({RecentMessages.Count})";
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

        string bgcolor;
        public string BgColorChoice
        {
            get => bgcolor;
            set
            {
                SetProperty(ref bgcolor, value);
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
            user = new Student
            {
                FirstName = "James",
                LastName = "Smith",
                Id = "1",
                Email = "james@gmail.com",
                Password = "testpassword123"
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
