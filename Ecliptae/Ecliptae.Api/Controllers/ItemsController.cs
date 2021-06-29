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



        [HttpGet("newJson")]
        public string Get()
        {
            //var u = JsonConvert.DeserializeObject<User>("{\"Name\":\"ADMIN\",\"Hash\":\"admin\",\"Balance\":99999999.0,\"Level\":5,\"GUID\":\"00000000-00000000-00000000-00000000\"}");
            //return JsonConvert.SerializeObject(u);
            var u = new Item();
            var r = new Random();
            u.NewGuid();
            u.Description = "zwlzwlzwl ballballu bangbang wo";
            u.Name = u.GUID[5].ToString() + u.GUID[10].ToString() + u.GUID[15].ToString() + u.GUID[20].ToString();
            u.Owner = r.Next() % 2 == 0 ? "00000000-00000000-00000000-00000000" : "4fg896eq-eqg741ws-qew7yh46a-gqe8746b";
            u.Price = r.NextDouble();
            u.Storage = r.Next() % 10000 + 1;
            return JsonConvert.SerializeObject(u);
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
        [HttpDelete("name={name}")]
        public async Task DeleteByNameAsync(string name)
        {
            await _itemsServices.DeleteByName(name);
        }
    }
}
