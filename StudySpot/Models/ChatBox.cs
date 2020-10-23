using System;
using System.Collections.Generic;
using System.Text;

namespace StudySpot.Models
{
    public class ChatBox
    {
        public string Id { get; set; }
        public string Sender { get; set; }
        public string UnitCode { get; set; }
        public string UnitColor { get; set; }
        public string Content { get; set; }
        public string UserImageName { get; set; }
        public string MessageStatus { get; set; }
    }
}
