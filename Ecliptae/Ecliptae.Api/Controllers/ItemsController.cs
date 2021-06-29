using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecliptae.Api.Services;
using Ecliptae.Lib;
using Newtonsoft.Json;


namespace Ecliptae.Api.Controllers
{
    [Route("/ecliptae/[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private IItemsServices _itemsServices;
        public ItemsController(IItemsServices itemsServices)
        {
            _itemsServices = itemsServices;
        }


        [HttpGet]
        public async Task<IEnumerable<string>> GetAllItemsAsync()
        {
            return await _itemsServices.GetAllItems();
        }
        [HttpGet("user")]
        public async Task<IEnumerable<string>> GetItemsByOwnerAsync(User user)
        {
            return await _itemsServices.GetItemsByOwner(user);
        }
        [HttpGet("name={name}")]
        public async Task<string> GetItemByNameAsync(string name)
        {
            return await _itemsServices.GetItemByName(name);
        }
        [HttpGet("guid={guid}")]
        public async Task<string> GetItemByGuidAsync(string guid)
        {
            return await _itemsServices.GetItemByGuid(guid);
        }



        [HttpPut]
        public async Task PutItemsInfAsync(Item item)
        {
            await _itemsServices.PutItemsInf(item);
        }



        [HttpPost]
        public async Task PostNewItemsAsync(Item item)
        {
            await _itemsServices.PostNewItems(item);
        }



        [HttpDelete]
        public async Task DeleteByObjectAsync(Item item)
        {
            await _itemsServices.DeleteByObject(item);
        }
        [HttpDelete("user")]
        public async Task DeleteByOwnerAsync(User user)
        {
            await _itemsServices.DeleteByOwner(user);
        }
        [HttpDelete("guid={guid}")]
        public async Task DeleteByGuidAsync(string guid)
        {
            await _itemsServices.DeleteByGuid(guid);
        }
        [HttpDelete("guid={guid}")]
        public async Task DeleteByNameAsync(string name)
        {
            await _itemsServices.DeleteByName(name);
        }
    }
}
