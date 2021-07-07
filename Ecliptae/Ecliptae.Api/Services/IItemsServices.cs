using Ecliptae.Lib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecliptae.Api.Services
{
    public interface IItemsServices
    {
        // GET
        public Task<IEnumerable<Item>> GetAllItems();
        public Task<IEnumerable<Item>> GetItemsByOwner(User user);
        public Task<Item> GetItemByGuid(string guid);
        public Task<Item> GetItemByName(string name);
        // PUT
        public Task PutItemsInf(Item item);
        // POST
        public Task PostNewItems(Item item);
        // DELETE
        public Task DeleteByOwner(User user);
        public Task DeleteByObject(Item item);
        public Task DeleteByGuid(string guid);
        public Task DeleteByName(string name);
    }
}
