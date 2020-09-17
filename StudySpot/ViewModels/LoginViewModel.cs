using StudySpot.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StudySpot.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Navigate to new shell after login

            Application.Current.MainPage = new AppShell();
        }
    }
}
