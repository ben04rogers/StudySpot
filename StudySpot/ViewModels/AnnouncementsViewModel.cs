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
            // Initialise
            GetAnnouncements = new ObservableCollection<Announcement>();

            GetData();
        }

        // Methods
        void GetData()
        {
            // Get announcement text
            GetAnnouncements.Add(new Announcement
            {
                Date = "21 Jul",
                Title = "Annoucement 1",
                Description = "Lorem Ipsum"
            });
            GetAnnouncements.Add(new Announcement
            {
                Date = "28 Jul",
                Title = "Annoucement 2",
                Description = "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum"
            });
        }
    }
}
