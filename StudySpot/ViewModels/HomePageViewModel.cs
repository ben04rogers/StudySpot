using System;
using Xamarin.Forms;
using MvvmHelpers;

namespace StudySpot.ViewModels
{
    [QueryProperty("Email", "email")]
    public class HomePageViewModel : BaseViewModel
    {
        public Command GoToClasses { get; }
        public Command GoToMessages { get; }


        public HomePageViewModel()
        {
            Title = "Home";

            GoToClasses = new Command(GoToClassesPage);
            GoToMessages = new Command(GoToMessagesPage);
        }

        async void GoToClassesPage()
        {
            await Shell.Current.GoToAsync("ClassesPage");
        }

        async void GoToMessagesPage()
        {
            await Shell.Current.GoToAsync("MessagesPage");
        }

        string email;
        public string Email
        {
            get => email;
            set
            {
                SetProperty(ref email, Uri.UnescapeDataString(value)); //MvvmHelpers Implementation
                OnPropertyChanged(nameof(Email));

            }
        }

    }
}
