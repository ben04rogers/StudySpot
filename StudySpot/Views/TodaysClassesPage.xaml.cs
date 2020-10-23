﻿using System;
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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodaysClassesPage : ContentPage
    {
        TodaysClassesPageViewModel _viewModel;

        public TodaysClassesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TodaysClassesPageViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}