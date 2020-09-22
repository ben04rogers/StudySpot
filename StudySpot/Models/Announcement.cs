using System;
using System.Collections.Generic;
using System.Text;

namespace StudySpot.Models
{
    enum type
    {
        Important, Reminder
    }

    public class Announcement
    {
        //public string Unit { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public string Type { get; set; }
    }
}
