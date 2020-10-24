using System;
using System.Collections.Generic;
using System.Text;

namespace StudySpot.Models
{
    public class Notifications
    {
        public string Id { get; set; }
        public string Important { get; set; }
        public string Reminder { get; set; }
        public string DueDates { get; set; }
        public string DueDateReminder { get; set; }
        public string Grades { get; set; }
        public string Tasks { get; set; }
        public string Teams { get; set; }
        public string PrivateMessages { get; set; }
    }
}
