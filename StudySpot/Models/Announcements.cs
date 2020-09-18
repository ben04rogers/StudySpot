using System;
using System.Collections.Generic;
using System.Text;

namespace StudySpot.Models
{
    enum type
    {
        Important, Reminder
    }

    class Announcements
    {
        public string unit { get; set; }
        public string date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string type { get; set; }
    }
}
