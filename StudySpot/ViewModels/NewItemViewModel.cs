using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using StudySpot.Models;
using Xamarin.Forms;

namespace StudySpot.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;
        private string location;
        private string taskcode;
        private string colour;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

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

        public string Location
        {
            get => location;
            set => SetProperty(ref location, value);
        }
        public string TaskCode
        {
            get => taskcode;
            set => SetProperty(ref taskcode, value);
        }
        public string Colour
        {
            get => colour;
            set => SetProperty(ref colour, value);
        }


        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("ItemsPage");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description,
                Location = Location,
                TaskCode = TaskCode,
                Colour = Colour
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack Culprit
            await Shell.Current.GoToAsync("ItemsPage");
        }
    }
}
