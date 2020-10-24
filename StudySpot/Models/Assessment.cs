using System;
using System.Collections.Generic;
using System.Text;

namespace StudySpot.Models
{
    public class Assessment
    {
        public string Id { get; set; }
        public string Unit { get; set; }
        public string UnitColour { get; set; }
        public string AssessmentName { get; set; }
        public DateTime DueDate { get; set; }
    }
}
