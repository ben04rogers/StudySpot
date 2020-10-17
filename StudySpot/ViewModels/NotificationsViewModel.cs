using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using StudySpot.Models;
using Xamarin.Forms;

namespace StudySpot.ViewModels
{
    class NotificationsViewModel : BaseViewModel
    {
        // Properties (Settings)
        public string Important { get; set; }
        public string Reminder { get; set; }
        public string DueDates { get; set; }
        public string DueDateReminder { get; set; }
        public string Grades { get; set; }
        public string Tasks { get; set; }
        public string Teams { get; set; }
        public string PrivateMessages { get; set; }

        // Constructor
        public NotificationsViewModel()
        {
            Title = "Notifications";

            // Defaults (or gotten from phone)
            Important = "True";
            Reminder = "False";
            DueDates = "True";
            DueDateReminder = "True";
            Grades = "False";
            Tasks = "False";
            Teams = "True";
            PrivateMessages = "True";
        }
    }
}
