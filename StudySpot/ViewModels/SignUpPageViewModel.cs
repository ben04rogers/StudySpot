using StudySpot.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MvvmHelpers;

namespace StudySpot.ViewModels
{
    class SignUpPageViewModel : BaseViewModel
    {

        public Command SignUpComplete { get; }


        public SignUpPageViewModel()
        {
            SignUpComplete = new Command(OnSignUpComplete);

        }

        private void OnSignUpComplete(object obj)
        {
            // Navigate to new shell after login

            Application.Current.MainPage = new LoginPage();


        }
    }
}
