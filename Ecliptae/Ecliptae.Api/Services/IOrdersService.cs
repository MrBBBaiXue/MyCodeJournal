﻿using Ecliptae.Lib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecliptae.Api.Services
{
    public interface IOrdersService
    {
        // GET
        public Task<IEnumerable<Order>> GetAllOrders();
        public Task<IEnumerable<Order>> GetOrdersByOwner(User user);
        public Task<string> GetOrderByGuid(string guid);
        // PUT
        public Task PutOrderInfo(Order order);
        // POST
        public Task PostNewOrder(Order order);
        // DELETE
        public Task DeleteByObject(Order order);
        public Task DeleteByOwner(User user);
        public Task DeleteByGuid(string guid);
    }
}
