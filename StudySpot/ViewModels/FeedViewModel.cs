using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using StudySpot.Models;
using Xamarin.Forms;

namespace StudySpot.ViewModels
{
    public class FeedViewModel : BaseViewModel
    {
        // Fields

        // Properties
        public ObservableCollection<Announcement> GetImportantAnnouncements { get; private set; }
        public ObservableCollection<Announcement> GetReminderAnnouncements { get; private set; }
        public ObservableCollection<Grade> GetGradesFeed { get; private set; }
        public Command<string> GoToAnnouncements { get; }

        // Constructor
        public FeedViewModel()
        {
            // Initialise data
            Title = "My feed";
            GetImportantAnnouncements = new ObservableCollection<Announcement>();
            GetReminderAnnouncements = new ObservableCollection<Announcement>();
            GetGradesFeed = new ObservableCollection<Grade>();
            GetData();

            // Button click method with parameter
            GoToAnnouncements = new Command<string>(onAnnouncementClick);
        }

        private void GetData()
        {
            // Get newest announcement of each unit with type important
            // MAX(Date), Type = Important, Group by Unit
            GetImportantAnnouncements.Add(new Announcement
            {
                Unit = "CAB303",
                UnitColour = "Blue",
                Date = "28 Jul",
                Title = "Room Change",
                Description = "Should ignore",
                Type = "Should ignore"
            });
            GetImportantAnnouncements.Add(new Announcement
            {
                Unit = "IAB305",
                UnitColour = "Red",
                Date = "10 Aug",
                Title = "Due Date",
                Description = "Should ignore",
                Type = "Should ignore"
            });
            GetImportantAnnouncements.Add(new Announcement
            {
                Unit = "IAB303",
                UnitColour = "LimeGreen",
                Date = "15 Aug",
                Title = "Room Change",
                Description = "Should ignore",
                Type = "Should ignore"
            });
            GetImportantAnnouncements.Add(new Announcement
            {
                Unit = "CAB420",
                UnitColour = "Orange",
                Date = "1 Aug",
                Title = "Quiz 5",
                Description = "Should ignore",
                Type = "Should ignore"
            });

            // Get newest announcement of each unit with type reminder
            // MAX(Date), Type = Reminder, Group by Unit
            GetReminderAnnouncements.Add(new Announcement
            {
                Unit = "CAB303",
                Date = "15 Aug",
                Title = "Assignment 1",
                Description = "Should ignore",
                Type = "Should ignore"
            });
            GetReminderAnnouncements.Add(new Announcement
            {
                Unit = "IAB305",
                Date = "10 Aug",
                Title = "Due Date",
                Description = "Should ignore",
                Type = "Should ignore"
            });
            GetReminderAnnouncements.Add(new Announcement
            {
                Unit = "IAB303",
                Date = "12 Aug",
                Title = "Assignment 2 release",
                Description = "Should ignore",
                Type = "Should ignore"
            });
            GetReminderAnnouncements.Add(new Announcement
            {
                Unit = "CAB420",
                Date = "5 Aug",
                Title = "Quiz question",
                Description = "Should ignore",
                Type = "Should ignore"
            });

            // Get newest grades of each unit
            // MAX(Date), Group by Unit
            GetGradesFeed.Add(new Grade
            {
                Unit = "CAB303",
                AssessmentName = "Quiz 4",
                Result = "85%"
            });
            GetGradesFeed.Add(new Grade
            {
                Unit = "IAB305"
            });
            GetGradesFeed.Add(new Grade
            {
                Unit = "IAB303",
                AssessmentName = "Assignment 1",
                Result = "95%"
            });
            GetGradesFeed.Add(new Grade
            {
                Unit = "CAB420",
                AssessmentName = "Problem Solving Task 1",
                Result = "70%"
            });
        }

        // Methods
        private async void onAnnouncementClick(string announcementType)
        {
            // Test
            string newObj = announcementType;
            // Navigate to announcements page view
            await Shell.Current.GoToAsync("AnnouncementsPage");
        }
    }
}
