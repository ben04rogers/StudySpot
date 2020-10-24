using System;
using Xamarin.Forms;
using MvvmHelpers;
using System.Collections.ObjectModel;
using StudySpot.Models;

namespace StudySpot.ViewModels
{

    public class Unit1PageViewModel : BaseViewModel
    {

        public Command Staffdetail { get; }

        public String PlatformImage { get; set; }

        public Unit1PageViewModel()
        {
            
            // Staff Details Button
            //Staffdetail = new Command(DisplayStaffDetails);
        }

        



    }
}