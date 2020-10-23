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
        public Command<object> GoToUnit { get; }

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
            Units = new ObservableCollection<Unit>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            // Setup New User
            NewUser();

            // Top Welcome greeting
            String greeting = $"Welcome {user.FirstName},";
            Title = greeting;

            // Buttons
            GoToSettings = new Command(GoToSettingsPage);
            GoToTodaysClasses = new Command(GoToTodaysClassesPage);
            GoToMessages = new Command(GoToMessagesPage);
            GoToUnit = new Command<object>(GoToUnitPage);


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
                Units.Clear();

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

                var units = await DataStore4.GetItemsAsync(true);
                foreach (var unit in units)
                {
                    Units.Add(unit);
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

       
        private async void GoToUnitPage(object unitobject)
        {
            // Convert to Unit Object
            Unit unit = (Unit)unitobject; 

            if (unit.Id == "1")
            {
                await Shell.Current.GoToAsync("Unit1Page");

            }
            else if (unit.Id == "2")
            {
                await Shell.Current.GoToAsync("Unit2Page");

            }
            else if (unit.Id == "3")
            {
                await Shell.Current.GoToAsync("Unit3Page");

            }
            else if (unit.Id == "4")
            {
                await Shell.Current.GoToAsync("Unit4Page");
            }

        }

        // Mock Data for testing 

        void NewUser()
        {
            user = new Student
            {
                FirstName = "James",
                LastName = "Smith",
                Id = "1",
                Email = "james@gmail.com",
                Password = "testpassword123"
            };
        }
    }
}
