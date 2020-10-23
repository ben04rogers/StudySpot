using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using StudySpot.Models;
using Xamarin.Forms;

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
        // Queries
        public string Unit
        {
            set
            {
                // Top nav bar subtitle has OnPropertyChanged()
                TopNavSubtitle = value;
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

        // Constructor
        public AnnouncementsViewModel()
        {
            // Initialise data
            Title = "Announcements";
            announcementsList = new ObservableCollection<Announcement>();
            importantAnnouncements = new ObservableCollection<Announcement>();
            reminderAnnouncements = new ObservableCollection<Announcement>();

            // Get Data
            GetImportantData();
            GetReminderData();

            // Default - important announcements
            GetAnnouncements = importantAnnouncements;
            isImportantSelected = true;

            // Button click methods
            ChangeToImportant = new Command(toImportant);
            ChangeToReminders = new Command(toReminders);
        }

        // Methods
        private void GetImportantData()
        {
            // Get announcement text
            // Unit = url get param, Type = Important
            importantAnnouncements.Add(new Announcement
            {
                Date = "21 Jul",
                Title = "Annoucement 1",
                Description = "Lorem Ipsum"
            });
            importantAnnouncements.Add(new Announcement
            {
                Date = "28 Jul",
                Title = "Annoucement 2",
                Description = "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum " +
                "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum"
            });
        }
        private void GetReminderData()
        {
            // Get announcement text
            // Unit = url get param, Type = Important
            reminderAnnouncements.Add(new Announcement
            {
                Date = "5 Aug",
                Title = "Reminder 1",
                Description = "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum " +
                "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum"
            });
            reminderAnnouncements.Add(new Announcement
            {
                Date = "7 Aug",
                Title = "Reminder 2",
                Description = "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem"
            });
            reminderAnnouncements.Add(new Announcement
            {
                Date = "6 Aug",
                Title = "Reminder 3",
                Description = "Another Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum " +
                "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum"
            });
            reminderAnnouncements.Add(new Announcement
            {
                Date = "5 Aug",
                Title = "Reminder 4",
                Description = "Another 2 Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum " +
                "Lorem Ipsum Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum"
            });
            reminderAnnouncements.Add(new Announcement
            {
                Date = "4 Aug",
                Title = "Reminder 5",
                Description = "Another 3 Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum " +
                "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum"
            });
        }

        // Button methods
        private void toImportant()
        {
            IsImportantSelected = true;
            GetAnnouncements = importantAnnouncements;
        }
        private void toReminders()
        {
            IsImportantSelected = false;
            GetAnnouncements = reminderAnnouncements;
        }
    }
}
