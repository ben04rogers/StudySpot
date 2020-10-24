using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StudySpot.Services;
using StudySpot.Views;

namespace StudySpot
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Device.SetFlags(new string[] { "RadioButton_Experimental" });

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<TodaysClassesDataStore>();
            DependencyService.Register<MessagesDataStore>();
            DependencyService.Register<UnitsDataStore>();
            DependencyService.Register<AnnouncementsDataStore>();
            DependencyService.Register<AssessmentDataStore>();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
