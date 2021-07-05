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
    public class OrdersController : Controller
    {
        private IOrdersService _ordersService;
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }



        [HttpGet("test")]
        public string Get()
        {
            //var u = JsonConvert.DeserializeObject<User>("{\"Name\":\"ADMIN\",\"Hash\":\"admin\",\"Balance\":99999999.0,\"Level\":5,\"GUID\":\"00000000-00000000-00000000-00000000\"}");
            //return JsonConvert.SerializeObject(u);
            var o = new Order();
            var r = new Random();
            o.NewGuid();
            o.Owner = r.Next() % 2 == 0 ? "00000000-00000000-00000000-00000000" : "4fg896eq-eqg741ws-qew7yh46a-gqe8746b";
            for (int i = 0; i < 5; i++)
            {
                var u = new Item();
                u.NewGuid();
                u.Description = "这玩意儿一点都不好用，太烂了. 最糟糕的一次网购体验，差评！绝对差评！！！";
                u.Name = u.GUID[5].ToString() + u.GUID[10].ToString() + u.GUID[15].ToString() + u.GUID[20].ToString();
                u.Owner = o.Owner;
                u.Price = r.NextDouble();
                u.Storage = r.Next() % 10000 + 1;
                var iu = new OrderItem();
                iu.Item = u;
                iu.Count = r.Next() % 10;
                o.Items.Add(iu);
            }
            return JsonConvert.SerializeObject(o);
        }



        [HttpGet]
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _ordersService.GetAllOrders();
        }
        [HttpGet("user")]
        public async Task<IEnumerable<Order>> GetOrdersByOwnerAsync(User user)
        {
            return await _ordersService.GetOrdersByOwner(user);
        }
        [HttpGet("guid={guid}")]
        public async Task<string> GetOrderByGuidAsync(string guid)
        {
            return await _ordersService.GetOrderByGuid(guid);
        }



        [HttpPut]
        public async Task PutOrderInfoAsync(Order order)
        {
            await _ordersService.PutOrderInfo(order);
        }



        [HttpPost]
        public async Task PostNewOrderAsync(Order order)
        {
            await _ordersService.PostNewOrder(order);
        }



        [HttpDelete]
        public async Task DeleteByObjectAsync(Order order)
        {
            await _ordersService.DeleteByObject(order);
        }
        [HttpDelete("user")]
        public async Task DeleteByOwnerAsync(User user)
        {
            await _ordersService.DeleteByOwner(user);
        }
        [HttpDelete("guid={guid}")]
        public async Task DeleteByGuidAsync(string guid)
        {
            await _ordersService.DeleteByGuid(guid);
        }
    }
}
