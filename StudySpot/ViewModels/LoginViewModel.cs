using StudySpot.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MvvmHelpers;


namespace StudySpot.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public String Email { get; set; }
        public String Password { get; set; }
        public Command LoginCommand { get; }
        public Command SignUpCommand { get; }
        public Command ForgotPassword { get; }
        public Command checkLogin { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            SignUpCommand = new Command(OnSignUpClicked);
            ForgotPassword = new Command(OnForgotPasswordClicked);

            checkLogin = new Command(CheckLoginDetails);
        }

        private void OnLoginClicked(object obj)
        {
            // Check entry filled and navigate to new shell after login
            CheckLoginDetails();
        }

        private void OnSignUpClicked(object obj)
        {
            // Navigate to new shell after login
            Application.Current.MainPage = new SignUpPage();
        }

        async void OnForgotPasswordClicked()
        {
            await Application.Current.MainPage.DisplayAlert("Reset Passwsord", "Would you like to reset your password?", "Yes");
        }

        async void CheckLoginDetails()
        {

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Oops", "Please enter email and password", "OK");
            }
            else
            {
                Application.Current.MainPage = new AppShell();
            }

        }
    }

}
