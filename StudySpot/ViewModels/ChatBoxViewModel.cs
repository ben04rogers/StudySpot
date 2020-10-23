using System;
using Xamarin.Forms;
using MvvmHelpers;
using System.Collections.ObjectModel;
using StudySpot.Models;

namespace StudySpot.ViewModels
{

    public class ChatBoxViewModel : BaseViewModel
    {
        public Student user;
        public ObservableCollection<Message> RecentMessages { get; set; }
        public ChatBoxViewModel()
        {
            SetupData();
            String greeting = $"{user.FirstName} {user.LastName},";
            Title = greeting;

            



        }

        void SetupData()
        {

            user = new Student
            {
                FirstName = "James",
                LastName = "Smith",
                Id = "1",
                Email = "james@gmail.com",
                Password = "testpassword123"
            };

            RecentMessages = new ObservableCollection<Message>()
            {
                 new Message
                {
                    Sender = "JAMES ROSS",
                    UnitCode = "CAB202",
                    UnitColor = "#00A6FF",
                    Content = "Assignment marks are available...",
                    UserImageName = "jamesross.png",
                    MessageStatus = "#00A6FF"
                },
            };
        }



    }
}
