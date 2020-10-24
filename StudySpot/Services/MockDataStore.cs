using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudySpot.Models;

namespace StudySpot.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item 
                { 
                    Id = Guid.NewGuid().ToString(), 
                    Text = "Study Session", 
                    Description="Study at home for IAB303 for 2hours before the upcoming Exam",
                    Colour = "#13CE66",
                    TaskCode = "CAB303"
                },
                new Item 
                { 
                    Id = Guid.NewGuid().ToString(), 
                    Text = "ID Card", 
                    Description="Pickup ID Card from HIQ",
                    Colour = "#000000",
                    TaskCode = "General"
                },
                new Item 
                { 
                    Id = Guid.NewGuid().ToString(), 
                    Text = "Start on Assignment 1 Report", 
                    Description="Get started on the Introduction and Research by this Weekend",
                    Colour = "#F95F62",
                    TaskCode = "IAB305"
                },
                new Item
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Do Quiz 13 (30/10)",
                    Description="Nothing just a reminder",
                    Colour = "#FFBA5C",
                    TaskCode = "CAB420"
                },
                new Item
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Study Session for Exam upcoming",
                    Description="Remember to go over the lecture and tutorial slides",
                    Colour = "#FFBA5C",
                    TaskCode = "CAB420"
                },
                new Item 
                { 
                    Id = Guid.NewGuid().ToString(), 
                    Text = "Fourth item", 
                    Description="This is an item description.",
                    Colour = "#13CE66",
                    TaskCode = "IAB303"
                }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}