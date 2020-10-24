using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudySpot.Models;

namespace StudySpot.Services
{
    public class NotificationsDataStore : IDataStore<Notifications>
    {
        readonly List<Notifications> items;

        public NotificationsDataStore()
        {
            items = new List<Notifications>()
            {
                new Notifications
                {
                    Id = Guid.NewGuid().ToString(),
                    // Defaults (or gotten from phone)
                    Important = "True",
                    Reminder = "False",
                    DueDates = "True",
                    DueDateReminder = "True",
                    Grades = "False",
                    Tasks = "False",
                    Teams = "True",
                    PrivateMessages = "True"
                }
            };
        }

        public async Task<bool> AddItemAsync(Notifications item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Notifications item)
        {
            var oldItem = items.Where((Notifications arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Notifications arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Notifications> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Notifications>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
