using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using StudySpot.Models;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

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
        public Command<object> GoToAnnouncements { get; } // With command parameter
        public Command GoToDueDates { get; }
        public Command<string> GoToGrades { get; } // With command parameter

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
            GetData();
            GetDueDateData();
            GetGradeData();

            // Button click method with parameter
            GoToAnnouncements = new Command<object>(onAnnouncementClick); 
            GoToDueDates = new Command(onDueDateClick);
        }

        private async void GetData()
        {
            try
            {
                GetReminderAnnouncements.Clear();
                GetImportantAnnouncements.Clear();

                // All Announcements
                IEnumerable<Announcement> announcements = await DataStoreAnnouncement.GetItemsAsync(true);

                // Query qnnouncements - 
                // Important
                IEnumerable<Announcement> queryImportant = announcements.Where(a => a.Type == "Important")
                    .GroupBy(b => b.Unit).Select(group => group.OrderByDescending(c => c.Date).First())
                    .OrderBy(d => d.Unit);
                // Reminders
                IEnumerable<Announcement> queryReminders = announcements.Where(a => a.Type == "Reminder")
                    .GroupBy(b => b.Unit).Select(group => group.OrderByDescending(c => c.Date).First())
                    .OrderBy(d => d.Unit);

                foreach (Announcement announcement in queryImportant)
                {
                    GetImportantAnnouncements.Add(announcement);
                }
                foreach (Announcement announcement in queryReminders)
                {
                    GetReminderAnnouncements.Add(announcement);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
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
        private async void onAnnouncementClick(object announcementType)
        {
            Announcement announcement = (Announcement)announcementType; // Convert to announcement object
            // Navigate to announcements page
            await Shell.Current.GoToAsync($"AnnouncementsPage?unit={announcement.Unit}&type={announcement.Type}");
        }
        private async void onDueDateClick()
        {
            // Navigate to task page view
            await Shell.Current.GoToAsync("TasksPage");
        }
    }
}
