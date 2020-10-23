using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using StudySpot.Models;
using StudySpot.Views;
using StudySpot.ViewModels;

namespace StudySpot.Views
{
    public partial class HomePage : ContentPage
    {
        HomePageViewModel _viewModel;

        public HomePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new HomePageViewModel();
        }

        void RecentMesssagesList_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
        
    }
}
