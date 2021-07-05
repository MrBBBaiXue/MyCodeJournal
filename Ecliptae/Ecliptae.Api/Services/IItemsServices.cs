using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecliptae.Lib;

namespace Ecliptae.Api.Services
{
    public interface IItemsServices
    {
        // GET
        public Task<IEnumerable<Item>> GetAllItems();
        public Task<IEnumerable<string>> GetItemsByOwner(User user);
        public Task<Item> GetItemByGuid(string guid);
        public Task<string> GetItemByName(string name);
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
