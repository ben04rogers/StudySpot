using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudySpot.Models;

namespace StudySpot.Services
{
    public class MessagesDataStore : IDataStore<Message>
    {
        readonly List<Message> items;

        public MessagesDataStore()
        {
            items = new List<Message>()
            {
                new Message {
                    Id = Guid.NewGuid().ToString(), 
                    Sender="JAMES ROSS", UnitCode="CAB202", 
                    UnitColor="#00A6FF", Content="Assignment marks are available...", 
                    UserImageName="jamesross.png"},
                new Message { 
                    Id = Guid.NewGuid().ToString(), 
                    Sender="BOB SMITH", 
                    UnitCode="CAB301", 
                    UnitColor="#FFD185", 
                    Content="Room Change for tutorial today. This is a long message to show that it automatically cuts off", 
                    UserImageName="bobsmith.png"},
                new Message { 
                    Id = Guid.NewGuid().ToString(),
                    Sender="JOSH HAAN", UnitCode="CAB303", 
                    UnitColor="#13CE66", 
                    Content="Great work! Looks great", 
                    UserImageName="joshhaan.png"},
                new Message { 
                    Id = Guid.NewGuid().ToString(), 
                    Sender="JAKE THOMPSON", 
                    UnitCode="IAB330", 
                    UnitColor="#F95F62", 
                    Content="Please refer to CRA for more details", 
                    UserImageName="jakethompson.png"},

            };
        }

        public async Task<bool> AddItemAsync(Message item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Message item)
        {
            var oldItem = items.Where((Message arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Message arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Message> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Message>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
