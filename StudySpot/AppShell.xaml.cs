using System;
using System.Collections.Generic;
using StudySpot.ViewModels;
using StudySpot.Views;
using Xamarin.Forms;

namespace StudySpot
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {
            routes.Add("TasksPage", typeof(TasksPage));
            routes.Add("MessagesPage", typeof(MessagesPage));
            routes.Add("LoginPage", typeof(LoginPage));
            routes.Add("HomePage", typeof(HomePage));
            routes.Add("FeedPage", typeof(FeedPage));
            routes.Add("AnnouncementsPage", typeof(AnnouncementsPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

    }
}
