using System;
using Xamarin.Forms;
using MvvmHelpers;
using System.Collections.ObjectModel;
using StudySpot.Models;

namespace StudySpot.ViewModels
{

    public class StaffPageViewModel : BaseViewModel
    {

        public Command Staffdetail { get; }


        public StaffPageViewModel()
        {
            
            // Staff Details Button
            //Staffdetail = new Command(DisplayStaffDetails);
        }

        



    }
}