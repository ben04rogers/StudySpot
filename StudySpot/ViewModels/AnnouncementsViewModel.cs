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
        public ObservableCollection<Announcement> GetAnnouncements { get; private set; }

        // Constructor
        public AnnouncementsViewModel()
        {
            // Initialise data
            Title = "Announcements";
            TopNavSubtitle = "CAB303";
            GetAnnouncements = new ObservableCollection<Announcement>();

            GetData();
        }

        // Methods
        private void GetData()
        {
            // Get announcement text
            GetAnnouncements.Add(new Announcement
            {
                Unit = "CAB303",
                UnitColour = "Blue",
                Date = "21 Jul",
                Title = "Annoucement 1",
                Description = "Lorem Ipsum",
                Type = "Important"
            });
            GetAnnouncements.Add(new Announcement
            {
                Unit = "CAB303",
                UnitColour = "Blue",
                Date = "28 Jul",
                Title = "Annoucement 2",
                Description = "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum " +
                "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem " +
                "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum",
                Type = "Important"
            });
        }
    }
}
