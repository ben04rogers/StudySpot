using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using StudySpot.Models;
using Xamarin.Forms;

namespace StudySpot.ViewModels
{
    public class AnnouncementsViewModel : BaseViewModel
    {
        // Fields

        // Properties
        public ObservableCollection<Announcement> GetImportant { get; private set; }
        public ObservableCollection<Announcement> GetReminders { get; private set; }

        // Constructor
        public AnnouncementsViewModel()
        {
            // Initialise data
            Title = "Announcements";
            TopNavSubtitle = "CAB303";
            GetImportant = new ObservableCollection<Announcement>();
            GetReminders = new ObservableCollection<Announcement>();

            GetImportantData();
            GetReminderData();
        }

        // Methods
        private void GetImportantData()
        {
            // Get announcement text
            // Unit = url get param, Type = Important
            GetImportant.Add(new Announcement
            {
                Date = "21 Jul",
                Title = "Annoucement 1",
                Description = "Lorem Ipsum"
            });
            GetImportant.Add(new Announcement
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
            GetReminders.Add(new Announcement
            {
                Date = "5 Aug",
                Title = "Reminder 1",
                Description = "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum " +
                "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum"
            });
            GetReminders.Add(new Announcement
            {
                Date = "7 Aug",
                Title = "Reminder 2",
                Description = "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem"
            });
        }
    }
}
