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

            // Default shell routes 

            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

            // Our navbar routes

            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(MessagesPage), typeof(MessagesPage));
            Routing.RegisterRoute(nameof(TasksPage), typeof(TasksPage));
            Routing.RegisterRoute(nameof(AnnouncementsPage), typeof(AnnouncementsPage));

            RegisterRoutes();
        }

        void RegisterRoutes()
        {
            routes.Add("classes", typeof(ClassesPage));
            routes.Add("messages", typeof(MessagesPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

    }
}
