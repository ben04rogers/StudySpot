using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudySpot.Models;

namespace StudySpot.Services
{
    public class UnitsDataStore : IDataStore<Unit>
    {
        readonly List<Unit> items;

        public UnitsDataStore()
        {
            items = new List<Unit>()
            {
                new Unit { Id = "1", UnitName="Microprocessors and Digital Systems", UnitCode="CAB202", Description="C programming", Color="#00A6FF"},
                new Unit { Id = "2", UnitName="Mobile Application Development", UnitCode="IAB330", Description="Xamarin Forms and MVVM", Color="#F95F62"},
                new Unit { Id = "3", UnitName="Networks", UnitCode="CAB303", Description="Computer Networks", Color="#13CE66"},
                new Unit { Id = "4", UnitName="Algorithms and Complexity", UnitCode="CAB301", Description="Fundamental Principles of Software Algorithms", Color="#FFD185"},

            };
        }

        public async Task<bool> AddItemAsync(Unit item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Unit item)
        {
            var oldItem = items.Where((Unit arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Unit arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Unit> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Unit>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
