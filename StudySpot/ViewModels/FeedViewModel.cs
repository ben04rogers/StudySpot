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
        public ObservableCollection<Assessment> GetDueDateFeed { get; private set; }
        public ObservableCollection<Grade> GetGradesFeed { get; private set; }
        public Command<string> GoToAnnouncements { get; }
        public Command<string> GoToDueDates { get; }
        public Command<string> GoToGrades { get; }

        // Constructor
        public FeedViewModel()
        {
            // Initialise data
            Title = "My feed";
            GetImportantAnnouncements = new ObservableCollection<Announcement>();
            GetReminderAnnouncements = new ObservableCollection<Announcement>();
            GetDueDateFeed = new ObservableCollection<Assessment>();
            GetGradesFeed = new ObservableCollection<Grade>();

            // Get Data
            GetImportantData();
            GetReminderData();
            GetDueDateData();
            GetGradeData();

            // Button click method with parameter
            GoToAnnouncements = new Command<string>(onAnnouncementClick); 
            GoToDueDates = new Command<string>(onDueDateClick);
        }

        private void GetImportantData()
        {
            // Get newest announcement of each unit with type important
            // MAX(Date), Type = Important, Group by Unit
            GetImportantAnnouncements.Add(new Announcement
            {
                Unit = "CAB303",
                UnitColour = "Blue",
                Date = "28 Jul",
                Title = "Room Change"
            });
            GetImportantAnnouncements.Add(new Announcement
            {
                Unit = "IAB305",
                UnitColour = "Red",
                Date = "10 Aug",
                Title = "Due Date"
            });
            GetImportantAnnouncements.Add(new Announcement
            {
                Unit = "IAB303",
                UnitColour = "LimeGreen",
                Date = "15 Aug",
                Title = "Room Change"
            });
            GetImportantAnnouncements.Add(new Announcement
            {
                Unit = "CAB420",
                UnitColour = "Orange",
                Date = "1 Aug",
                Title = "Quiz 5"
            });
        }
        private void GetReminderData()
        {
            // Get newest announcement of each unit with type reminder
            // MAX(ResultDate), Type = Reminder, Group by Unit
            GetReminderAnnouncements.Add(new Announcement
            {
                Unit = "CAB303",
                UnitColour = "Blue",
                Date = "15 Aug",
                Title = "Assignment 1"
            });
            GetReminderAnnouncements.Add(new Announcement
            {
                Unit = "IAB305",
                UnitColour = "Red",
                Date = "10 Aug",
                Title = "Due Date"
            });
            GetReminderAnnouncements.Add(new Announcement
            {
                Unit = "IAB303",
                UnitColour = "LimeGreen",
                Date = "12 Aug",
                Title = "Assignment 2 release"
            });
            GetReminderAnnouncements.Add(new Announcement
            {
                Unit = "CAB420",
                UnitColour = "Orange",
                Date = "5 Aug",
                Title = "Quiz question"
            });
        }
        private void GetDueDateData()
        {
            // Get closest duedate for each unit
            // MIN(CurrentDate - DueDate), Group by Unit
            GetDueDateFeed.Add(new Assessment
            {
                Unit = "CAB303",
                UnitColour = "Blue",
                AssessmentName = "Assignment 1",
                DueDate = "1 Oct"
            });
            GetDueDateFeed.Add(new Assessment
            {
                Unit = "IAB305",
                UnitColour = "Red",
                AssessmentName = "PST2",
                DueDate = "21 Aug"
            });
            GetDueDateFeed.Add(new Assessment
            {
                Unit = "IAB303",
                UnitColour = "LimeGreen",
                AssessmentName = "Research Task",
                DueDate = "5 Oct"
            });
            GetDueDateFeed.Add(new Assessment
            {
                Unit = "CAB420",
                UnitColour = "Orange",
                AssessmentName = "Quiz 7",
                DueDate = "13 Aug"
            });
        }
        private void GetGradeData()
        {
            // Get newest grades of each unit
            // MAX(ResultDate), Group by Unit
            GetGradesFeed.Add(new Grade
            {
                Unit = "CAB303",
                UnitColour = "Blue",
                AssessmentName = "Quiz 4",
                Result = "85%"
            });
            GetGradesFeed.Add(new Grade
            {
                Unit = "IAB305",
                UnitColour = "Red",
                AssessmentName = "None",
                Result = "N/A"
            });
            GetGradesFeed.Add(new Grade
            {
                Unit = "IAB303",
                UnitColour = "LimeGreen",
                AssessmentName = "Assignment 1",
                Result = "95%"
            });
            GetGradesFeed.Add(new Grade
            {
                Unit = "CAB420",
                UnitColour = "Orange",
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
        private async void onDueDateClick(string announcementType)
        {
            // Test
            string newObj = announcementType;
            // Navigate to announcements page view
            await Shell.Current.GoToAsync("TasksPage");
        }
    }
}
