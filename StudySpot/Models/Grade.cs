using System;
using System.Collections.Generic;
using System.Text;

namespace StudySpot.Models
{
    public class Grade : Assessment
    {
        public string ResultDate { get; set; }
        public string Result { get; set; }
    }
}
