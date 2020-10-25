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

            // Button click method with parameter
            GoToAnnouncements = new Command<object>(onAnnouncementClick); 
            GoToDueDates = new Command(onDueDateClick);
            GoToGrades = new Command<string>(onGradeClick);
        }

        // ---------------- TEMP
        List<Unit> _Units;
        private async void GetData()
        {
            try
            {
                GetReminderAnnouncements.Clear();
                GetImportantAnnouncements.Clear();
                GetDueDateFeed.Clear();
                GetGradesFeed.Clear();

                // Units
                IEnumerable<Unit> units = await DataStore4.GetItemsAsync(true);
                units = units.GroupBy(a => a.UnitCode).Select(b => b.First());

                // ---------- TEMP
                _Units = units.ToList();

                // Queries - grouped by units, ordered by units, top-most relevant feed item
                // All Announcements
                IEnumerable<Announcement> announcements = await DataStoreAnnouncement.GetItemsAsync(true);
                // Important
                IEnumerable<Announcement> queryImportant = announcements.Where(a => a.Type == "Important")
                    .GroupBy(b => b.Unit).Select(group => group.OrderByDescending(c => c.Date).First())
                    .OrderBy(a => a.Unit);
                // Reminders
                IEnumerable<Announcement> queryReminders = announcements.Where(a => a.Type == "Reminder")
                    .GroupBy(b => b.Unit).Select(group => group.OrderByDescending(c => c.Date).First())
                    .OrderBy(a => a.Unit);

                // All Assessments
                IEnumerable<Grade> assessments = await DataStoreAssessment.GetItemsAsync(true);
                // Grades - result date is not empty (default), most recent
                IEnumerable<Grade> queryGrades = assessments.Where(a => a.ResultDate != DateTime.MinValue)
                    .GroupBy(b => b.Unit).Select(group => group.OrderByDescending(c => c.ResultDate).First())
                    .OrderBy(a => a.Unit);
                // Due dates - result date is empty (default), closest to current date,
                // ignoring any due dates that passed today
                IEnumerable<Assessment> queryDuedates = assessments.Where(a => a.ResultDate == DateTime.MinValue && 
                    DateTime.Compare(a.DueDate, DateTime.Today) > 0)
                    .GroupBy(b => b.Unit).Select(group => group.OrderBy(c => c.DueDate).First())
                    .OrderBy(a => a.Unit);

                // Announcements
                foreach (Announcement announcement in queryImportant)
                {
                    // Change colour from unit DB
                    announcement.UnitColour = units.LastOrDefault(a => a.UnitCode == announcement.Unit).Color;
                    GetImportantAnnouncements.Add(announcement);
                }
                foreach (Announcement announcement in queryReminders)
                {
                    // Change colour from unit DB
                    announcement.UnitColour = units.LastOrDefault(a => a.UnitCode == announcement.Unit).Color;
                    GetReminderAnnouncements.Add(announcement);
                }

                // Assessments
                foreach (Grade grade in queryGrades)
                {
                    // Change colour from unit DB
                    grade.UnitColour = units.LastOrDefault(a => a.UnitCode == grade.Unit).Color;
                    GetGradesFeed.Add(grade);
                }
                foreach (Assessment assessment in queryDuedates)
                {
                    // Change colour from unit DB
                    assessment.UnitColour = units.LastOrDefault(a => a.UnitCode == assessment.Unit).Color;
                    GetDueDateFeed.Add(assessment);
                }

                // Check if each unit has something -> if not, add a default placeholder
                foreach (Unit unit in units)
                {
                    // Default important
                    try
                    {
                        string id = GetImportantAnnouncements.Where(a => a.Unit == unit.UnitCode).First().Id;
                    }
                    catch
                    {
                        // Not found -> make default
                        GetImportantAnnouncements.Add(new Announcement()
                        {
                            Title = "None",
                            Description = "N/a",
                            Unit = unit.UnitCode,
                            UnitColour = unit.Color,
                            Type = "Important"
                        });
                    }

                    // Default reminder
                    try
                    {
                        string id = GetReminderAnnouncements.Where(a => a.Unit == unit.UnitCode).First().Id;
                    }
                    catch
                    {
                        // Not found -> make default
                        GetReminderAnnouncements.Add(new Announcement()
                        {
                            Title = "None",
                            Description = "N/a",
                            Unit = unit.UnitCode,
                            UnitColour = unit.Color,
                            Type = "Reminder"
                        });
                    }

                    // Default grade
                    try
                    {
                        string id = GetGradesFeed.Where(a => a.Unit == unit.UnitCode).First().Id;
                    }
                    catch
                    {
                        // Not found -> make default
                        GetGradesFeed.Add(new Grade()
                        {
                            AssessmentName = "None",
                            Result = "N/a",
                            ResultDate = DateTime.Today,
                            Unit = unit.UnitCode,
                            UnitColour = unit.Color
                        });
                    }

                    // Default due date
                    try
                    {
                        string id = GetDueDateFeed.Where(a => a.Unit == unit.UnitCode).First().Id;
                    }
                    catch
                    {
                        // Not found -> make default
                        GetDueDateFeed.Add(new Assessment()
                        {
                            AssessmentName = "None",
                            DueDate = DateTime.Today,
                            Unit = unit.UnitCode,
                            UnitColour = unit.Color
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
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
            await Shell.Current.GoToAsync("ItemsPage");
        }
        private async void onGradeClick(string unitCode)
        {
            // Navigate to task page view
            //await Shell.Current.GoToAsync($"Unit1Page?unit={unitCode}");

            // ---------------- TEMP
            // Placeholder get url (units page not complete)
            if (unitCode == _Units[0].UnitCode) await Shell.Current.GoToAsync($"Unit1Page?unit={_Units[0].UnitCode}");
            else if (unitCode == _Units[1].UnitCode) await Shell.Current.GoToAsync($"Unit4Page?unit={_Units[1].UnitCode}");
            else if (unitCode == _Units[2].UnitCode) await Shell.Current.GoToAsync($"Unit3Page?unit={_Units[2].UnitCode}");
            else if (unitCode == _Units[3].UnitCode) await Shell.Current.GoToAsync($"Unit2Page?unit={_Units[3].UnitCode}");
        }
    }
}
