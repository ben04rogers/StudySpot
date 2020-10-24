using System;
using System.Diagnostics;
using System.Threading.Tasks;
using StudySpot.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StudySpot.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        private string colour;
        private string taskcode;
        private string location;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public string Colour
        {
            get => colour;
            set => SetProperty(ref colour, value);
        }
        public string TaskCode
        {
            get => taskcode;
            set => SetProperty(ref taskcode, value);
        }
        public string Location
        {
            get => location;
            set => SetProperty(ref location, value);
        }


        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
                Colour = item.Colour;
                TaskCode = item.TaskCode;
                Location = item.Location;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
