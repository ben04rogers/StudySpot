using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudySpot.Models;

namespace StudySpot.Services
{
    public class TodaysClassesDataStore : IDataStore<TodaysClass>
    {
        readonly List<TodaysClass> items;

        public TodaysClassesDataStore()
        {
            items = new List<TodaysClass>()
            {
                new TodaysClass { Id = Guid.NewGuid().ToString(), UnitCode = "CAB303", Time="9:00", TimePeriod="AM", LessonType="Online Workshop", Platform="Zoom", Link="9201291021", UnitColor="#13CE66", ImageName="zoom.png"},
                new TodaysClass { Id = Guid.NewGuid().ToString(), UnitCode = "IAB330", Time="11:00", TimePeriod="AM", LessonType="Online Workshop", Platform="Zoom", Link="https://teams.microsoft.com/IAB330", UnitColor="#F95F62", ImageName="msteams.png"},
                new TodaysClass { Id = Guid.NewGuid().ToString(), UnitCode = "CAB202", Time="12:00", TimePeriod="PM", LessonType="Online Workshop", Platform="Zoom", Link="https://teams.microsoft.com/CAB202", UnitColor="#00A6FF", ImageName="msteams.png"}
            };
        }

        public async Task<bool> AddItemAsync(TodaysClass item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(TodaysClass item)
        {
            var oldItem = items.Where((TodaysClass arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((TodaysClass arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<TodaysClass> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<TodaysClass>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
