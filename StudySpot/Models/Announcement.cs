﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StudySpot.Models
{
    public class Announcement
    {
        public string Id { get; set; }
        public string Unit { get; set; }
        public string UnitColour { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Unread { get; set; } // "true", "false"
    }
}
