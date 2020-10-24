using System;
using System.Collections.Generic;
using System.Text;

namespace StudySpot.Models
{
    public class Grade : Assessment // Grade is part of assessments
    {
        public DateTime ResultDate { get; set; }
        public string Result { get; set; }
    }
}
