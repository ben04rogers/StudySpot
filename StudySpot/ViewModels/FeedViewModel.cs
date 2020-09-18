using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using StudySpot.Models;
using Xamarin.Forms;

namespace StudySpot.ViewModels
{
    public class FeedViewModel : BaseViewModel
    {
        // Fields
        private List<string> announcementText;
        private int announcementTextIndex;

        // Properties
        public string AnnouncementText
        {
            get
            {
                // Get announcement at index (index incrementing with each Binding call)
                announcementTextIndex++; // Initial = -1
                string text = announcementText[announcementTextIndex];
                return text;
            }
        }
        public Command<string> GoToAnnouncements { get; }

        // Constructor
        public FeedViewModel()
        {
            // Initialise
            announcementText = new List<string>();
            announcementTextIndex = -1;
            // Button click method with parameter
            GoToAnnouncements = new Command<string>(onAnnouncementClick);

            // Get announcement texts
            announcementText.Add("28 Jul | Room Change (get from Model)");
            announcementText.Add("10 Aug | Due Date (get from Model)");
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
