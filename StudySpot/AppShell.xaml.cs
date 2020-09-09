using System;
using System.Collections.Generic;
using StudySpot.ViewModels;
using StudySpot.Views;
using Xamarin.Forms;

namespace StudySpot
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
