using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudySpot.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudySpot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();

            var assembly = typeof(LoginPage);

            LogoImage.Source = ImageSource.FromResource("StudySpot.assets.images.logo_transparent.png", assembly);
        }

        void LoginButton_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        void SignUpButton_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}