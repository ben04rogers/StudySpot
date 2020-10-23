using System;
using Xamarin.Forms;
using MvvmHelpers;
using System.Collections.ObjectModel;
using StudySpot.Models;

namespace StudySpot.ViewModels
{
    
    public class MessagesViewModel : BaseViewModel
    {
        public Command GoToChatBox { get; }

        public ObservableCollection<Message> RecentMessages { get; set; }

        public Student user;
       
        public String MessagesCount { get; set; }

        public MessagesViewModel()
        {
            Title = "My Messages";
            // Test data
            SetupData();

            // Messages Count Label
            String MessagesCountLabel = $"Messages ({RecentMessages.Count})";
            MessagesCount = MessagesCountLabel;


            GoToChatBox = new Command(GoToChatBoxPage);


        }
        public static void Init() { }

        async void GoToChatBoxPage()
        {
            await Shell.Current.GoToAsync("ChatBoxPage");
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
                  new Message
                {
                    Sender = "BOB SMITH",
                    UnitCode = "CAB301",
                    UnitColor = "#FFD185",
                    Content = "Room Change for tutorial today",
                    UserImageName = "bobsmith.png",
                    MessageStatus = "#00A6FF"
                },
                 new Message
                {
                    Sender = "JOSH HAAN",
                    UnitCode = "CAB303",
                    UnitColor = "#13CE66",
                    Content = "Great work! Looks great",
                    UserImageName = "joshhaan.png",
                    MessageStatus = "#00A6FF"
                },
                new Message
                {
                    Sender = "JAKE THOMPSON",
                    UnitCode = "IAB330",
                    UnitColor = "#F95F62",
                    Content = "Please refer to CRA for more details",
                    UserImageName = "jakethompson.png",
                    MessageStatus = "#"
                }


            };
        }
    }
}
