using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StudySpot.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            var assembly = typeof(HomePage);

            ProfileImage.Source = ImageSource.FromResource("StudySpot.assets.images.profile.png", assembly);

        }


    }
}
