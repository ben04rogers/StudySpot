using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using StudySpot.Models;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;
using System.Collections.Specialized;

namespace StudySpot.ViewModels
{
    [QueryProperty("Unit", "unit")]
    [QueryProperty("Type", "type")]
    public class AnnouncementsViewModel : BaseViewModel
    {
        // Fields
        private bool isImportantSelected;
        private ObservableCollection<Announcement> importantAnnouncements;
        private ObservableCollection<Announcement> reminderAnnouncements;

        // Properties
        // URL Queries
        private string unit;
        public string Unit
        {
            get => unit;
            set
            {
                unit = value;
                // Top nav bar subtitle has OnPropertyChanged()
                TopNavSubtitle = value;

                // Get Data
                GetData();
            }
        }
        public string Type
        {
            set
            {
                // Swap to appropriate announcement type tab
                if (value == "Important")
                {
                    toImportant();
                }
                else if (value == "Reminder")
                {
                    toReminders();
                }
            }
        }

        // Viewmodel
        private ObservableCollection<Announcement> announcementsList;
        public ObservableCollection<Announcement> GetAnnouncements
        {
            get => announcementsList;
            set
            {
                SetProperty(ref announcementsList, value);
                OnPropertyChanged(nameof(GetAnnouncements)); // Update listview
            }
        }
        public bool IsImportantSelected {
            get => isImportantSelected;
            set
            {
                SetProperty(ref isImportantSelected, value);
                OnPropertyChanged(nameof(IsImportantSelected)); // Update buttons
            }
        }
        public ICommand ChangeToImportant { get; }
        public ICommand ChangeToReminders { get; }
        public ICommand MakeRead { get; }

        // Constructor
        public AnnouncementsViewModel()
        {
            // Initialise data
            Title = "Announcements";
            announcementsList = new ObservableCollection<Announcement>();
            importantAnnouncements = new ObservableCollection<Announcement>();
            reminderAnnouncements = new ObservableCollection<Announcement>();

            // Default - important announcements
            GetAnnouncements = importantAnnouncements;
            isImportantSelected = true;

            // Button click methods
            ChangeToImportant = new Command(toImportant);
            ChangeToReminders = new Command(toReminders);
            MakeRead = new Command<object>(makeRead);
        }

        // Methods
        private async void GetData()
        {
            // Get announcement text
            // Unit = url get param, Type = Important
            try
            {
                importantAnnouncements.Clear();
                reminderAnnouncements.Clear();

                // All Announcements
                IEnumerable<Announcement> announcements = await DataStoreAnnouncement.GetItemsAsync(true);

                // Query qnnouncements
                // Get unit predicate
                // Important
                IEnumerable<Announcement> queryImportant = announcements
                    .Where(a => a.Type == "Important" && a.Unit == Unit)
                    .OrderByDescending(c => c.Date);
                // Reminders
                IEnumerable<Announcement> queryReminders = announcements
                    .Where(a => a.Type == "Reminder" && a.Unit == Unit)
                    .OrderByDescending(c => c.Date);

                foreach (Announcement announcement in queryImportant)
                {
                    importantAnnouncements.Add(announcement);
                }
                foreach (Announcement announcement in queryReminders)
                {
                    reminderAnnouncements.Add(announcement);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        // Button methods
        private void toImportant()
        {
            GetData();
            IsImportantSelected = true;
            GetAnnouncements = importantAnnouncements;
        }
        private void toReminders()
        {
            GetData();
            IsImportantSelected = false;
            GetAnnouncements = reminderAnnouncements;
        }
        private async void makeRead(object tappedItem)
        {
            Announcement announcement = (Announcement)tappedItem;

            // Check if announcement is unread
            if (announcement.Unread == true)
            {
                // Update database
                announcement.Unread = false;
                await DataStoreAnnouncement.UpdateItemAsync(announcement);

                // Update UI
                if (IsImportantSelected)
                {
                    toImportant();
                }
                else
                {
                    toReminders();
                }
            }
        }
    }
}
