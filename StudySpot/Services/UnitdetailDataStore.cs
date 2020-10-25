using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudySpot.Models;

namespace StudySpot.Services
{
    public class UnitdetailDataStore : IDataStore<Unitdetail>
    {
        readonly List<Unitdetail> items;

        public UnitdetailDataStore()
        {
            items = new List<Unitdetail>()
            {
                new Unitdetail { Id = Guid.NewGuid().ToString(), Staffname="WILL SMITH", Unitname="CAB202", Staffimage="willsmith.png"},
                new Unitdetail { Id = Guid.NewGuid().ToString(), Staffname="LUCAS PODOLSKI", Unitname="CAB301", Staffimage="lucaspodolski.png"},
                new Unitdetail { Id = Guid.NewGuid().ToString(), Staffname="DAVID PARKER", Unitname="CAB303", Staffimage="davidparker.png"},
                

            };
        }





        public Task<bool> AddItemAsync(Unitdetail item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Unitdetail> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Unitdetail>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Unitdetail item)
        {
            throw new NotImplementedException();
        }
    }


}
