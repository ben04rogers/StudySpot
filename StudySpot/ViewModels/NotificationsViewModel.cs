using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using StudySpot.Models;
using Xamarin.Forms;
using StudySpot.Services;
using System.Linq;
using System.Threading.Tasks;

namespace StudySpot.ViewModels
{
    class NotificationsViewModel : BaseViewModel
    {

        // Properties (Settings)
        private Notifications Settings { get; set; }

        public string Important { get; set; }
        public string Reminder { get; set; }
        public string DueDates { get; set; }
        public string DueDateReminder { get; set; }
        public string Grades { get; set; }
        public string Tasks { get; set; }
        public string Teams { get; set; }
        public string PrivateMessages { get; set; }
        public ICommand SaveNotifSettings { get; }

        // Constructor
        public NotificationsViewModel()
        {
            Title = "Notifications";

            // Get stored settings data
            GetData();

            // Commands
            SaveNotifSettings = new Command(saveData);
        }

        private async void GetData()
        {
            // Get DB
            IEnumerable<Notifications> notifications = await DataStoreNotifications.GetItemsAsync(true);
            Settings = notifications.First();

            Important = Settings.Important;
            Reminder = Settings.Reminder;
            DueDates = Settings.DueDates;
            DueDateReminder = Settings.DueDateReminder;
            Grades = Settings.Grades;
            Tasks = Settings.Tasks;
            Teams = Settings.Teams;
            PrivateMessages = Settings.PrivateMessages;
        }

        private async void saveData()
        {
            // Update settings
            Settings.Important = Important;
            Settings.Reminder = Reminder;
            Settings.DueDates = DueDates;
            Settings.DueDateReminder = DueDateReminder;
            Settings.Grades = Grades;
            Settings.Tasks = Tasks;
            Settings.Teams = Teams;
            Settings.PrivateMessages = PrivateMessages;
            // Save to DB
            await DataStoreNotifications.UpdateItemAsync(Settings);

            await Shell.Current.DisplayAlert("Saved", "Your settings have been saved.", "OK");

            await Shell.Current.Navigation.PopAsync();
        }
    }
}
