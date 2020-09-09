using System.ComponentModel;
using Xamarin.Forms;
using StudySpot.ViewModels;

namespace StudySpot.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}