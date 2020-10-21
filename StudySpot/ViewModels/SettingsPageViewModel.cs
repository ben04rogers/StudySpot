using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using Xamarin.Forms;
using StudySpot.Views;

namespace StudySpot.ViewModels
{
    class SettingsPageViewModel : BaseViewModel
    {
        public Command ChangeBgRed { get; }
        public Command ChangeBgYellow { get; }
        public Command ChangeBgGreen { get; }
        public Command ChangeBgBlue { get; }
        public Command LogoutCommand { get; }



        public SettingsPageViewModel()
        {
            Title = "Home";
            ChangeBgRed = new Command(ChangeBgColorRed);
            ChangeBgYellow = new Command(ChangeBgColorYellow);
            ChangeBgGreen = new Command(ChangeBgColorGreen);
            ChangeBgBlue = new Command(ChangeBgColorBlue);
            LogoutCommand = new Command(OnLogoutClicked);

        }

        string bgcolor;
        public string BgColorChoice
        {
            get => bgcolor;
            set
            {
                SetProperty(ref bgcolor, value); //MvvmHelpers Implementation
                OnPropertyChanged(nameof(BgColorChoice));
            }
        }

        async void ChangeBgColorRed()
        {
            string colorchoice = "F95F62";
            await Shell.Current.GoToAsync($"//HomePage?bgcolor={colorchoice}");
        }
        async void ChangeBgColorYellow()
        {
            string colorchoice = "FFD185";
            await Shell.Current.GoToAsync($"//HomePage?bgcolor={colorchoice}");
        }
        async void ChangeBgColorGreen()
        {
            string colorchoice = "13CE66";
            await Shell.Current.GoToAsync($"//HomePage?bgcolor={colorchoice}");
        }
        async void ChangeBgColorBlue()
        {
            string colorchoice = "00A6FF";
            await Shell.Current.GoToAsync($"//HomePage?bgcolor={colorchoice}");
        }

        private void OnLogoutClicked(object obj)
        {
            // Logout Command

        }



    }
}
