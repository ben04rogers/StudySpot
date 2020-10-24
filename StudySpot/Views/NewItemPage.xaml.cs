using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using StudySpot.Models;
using StudySpot.ViewModels;

namespace StudySpot.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {  
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}