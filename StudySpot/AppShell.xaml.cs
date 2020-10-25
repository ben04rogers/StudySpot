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
            routes.Add("NewItemPage", typeof(NewItemPage));
            routes.Add("ItemsPage", typeof(ItemsPage));
            routes.Add("ItemDetailPage", typeof(ItemDetailPage));
            routes.Add("MessagesPage", typeof(MessagesPage));
            routes.Add("LoginPage", typeof(LoginPage));
            routes.Add("HomePage", typeof(HomePage));
            routes.Add("FeedPage", typeof(FeedPage));
            routes.Add("ChatBoxPage", typeof(ChatBoxPage));
            routes.Add("AnnouncementsPage", typeof(AnnouncementsPage));
            routes.Add("TodaysClassesPage", typeof(TodaysClassesPage));
            routes.Add("SettingsPage", typeof(SettingsPage));
            routes.Add("NotificationsPage", typeof(NotificationsPage));
            routes.Add("Unit1Page", typeof(Unit1Page));
            routes.Add("Unit2Page", typeof(Unit2Page));
            routes.Add("Unit3Page", typeof(Unit3Page));
            routes.Add("Unit4Page", typeof(Unit4Page));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

    }
}
