using System;
using Xamarin.Forms;

namespace StudySpot.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public Command GoToClasses { get; }
        public Command GoToMessages { get; }


        public HomePageViewModel()
        {
            GoToClasses = new Command(GoToClassesPage);
            GoToMessages = new Command(GoToMessagesPage);
        }

        async void GoToClassesPage()
        {
            await Shell.Current.GoToAsync($"classes");
        }

        async void GoToMessagesPage()
        {
            await Shell.Current.GoToAsync($"messages");
        }

    }
}
