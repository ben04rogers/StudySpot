using System;
using Xamarin.Forms;
using MvvmHelpers;
using System.Collections.ObjectModel;
using StudySpot.Models;

namespace StudySpot.ViewModels
{

    public class Unit1PageViewModel : BaseViewModel
    {

        // button command
        public Command Staff1detail { get; }
        public Command Staff2detail { get; }

        public Command Staff3detail { get; }

        public Unit1PageViewModel()
        {
            Staff1detail = new Command(GoToStaff1DetailPage);
            Staff2detail = new Command(GoToStaff2DetailPage);
            Staff3detail = new Command(GoToStaff3DetailPage);

        }

        async void GoToStaff1DetailPage()
        {
            await Shell.Current.GoToAsync("Staff1Page");
        }

        async void GoToStaff2DetailPage()
        {
            await Shell.Current.GoToAsync("Staff2Page");
        }

        async void GoToStaff3DetailPage()
        {
            await Shell.Current.GoToAsync("Staff3Page");
        }


    }
}