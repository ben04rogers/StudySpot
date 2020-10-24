using System;
using System.Collections.Generic;

using Xamarin.Forms;
using StudySpot.Models;
using StudySpot.Views;
using StudySpot.ViewModels;

namespace StudySpot.Views
{
    public partial class TasksPage : ContentPage
    {
        TasksPageViewModel _viewModel;
        public TasksPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new TasksPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

    }
    
}
