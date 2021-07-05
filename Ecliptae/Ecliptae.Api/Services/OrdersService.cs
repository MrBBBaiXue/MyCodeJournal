using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecliptae.Lib;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecliptae.Api.Services;
using System.Net.Http;
using System.Web;

namespace Ecliptae.Api.Services
{
    public class OrdersService : IOrdersService
    {
        public Task DeleteByGuid(string guid)
        {
            return Task.Run(() =>
            {
                try
                {
                    var r = SQL.Delete(new TablesDesc(Tables.Orders), "guid", guid);
                    if (r == 0)
                    {
                        throw new Exception("NotFound");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        public Task DeleteByObject(Order order)
        {
            return Task.Run(() =>
            {
                try
                {
                    var r = SQL.Delete(new TablesDesc(Tables.Orders), "guid", order.GUID);
                    if (r == 0)
                    {
                        throw new Exception("NotFound");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        public Task DeleteByOwner(User user)
        {
            return Task.Run(() =>
            {
                try
                {
                    var r = SQL.Delete(new TablesDesc(Tables.Orders), "owner", user.GUID);
                    if (r == 0)
                    {
                        throw new Exception("NotFound");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        public Task<IEnumerable<Order>> GetAllOrders()
        {
            return Task.Run(() =>
            {
                List<Order> retList = new List<Order>();
                try
                {
                    var reader = SQL.Retrieve(new TablesDesc(Tables.Orders));
                    while (reader.Read())
                    {
                        var order = new Order();
                        order.GUID = reader["guid"].ToString();
                        order.Owner = reader["owner"].ToString();
                        Console.WriteLine(reader["info"].ToString());
                        order.Items = reader["info"].ToString() == "No info." ? 
                        new ObservableCollection<OrderItem>() : 
                        JsonConvert.DeserializeObject<ObservableCollection<OrderItem>>(reader["info"].ToString());
                        retList.Add(order);
                    }
                    return retList.AsEnumerable();
                }
                catch (Exception e)
                {
                    return retList.AsEnumerable();
                }
            });
        }

        public Task<string> GetOrderByGuid(string guid)
        {
            return Task.Run(() =>
            {
                try
                {
                    var reader = SQL.Retrieve(new TablesDesc(Tables.Orders), "guid", guid);
                    var order = new Order();
                    if (reader.Read())
                    {
                        order.GUID = reader["guid"].ToString();
                        order.Owner = reader["owner"].ToString();
                        order.Items = reader["info"].ToString() == "No info." ?
                        new ObservableCollection<OrderItem>() :
                        JsonConvert.DeserializeObject<ObservableCollection<OrderItem>>(reader["info"].ToString());
                        return JsonConvert.SerializeObject(order);
                    }
                    else
                    {
                        throw new Exception("NotFound");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return e.Message;
                }
            });
        }

        public Task<IEnumerable<Order>> GetOrdersByOwner(User user)
        {
            return Task.Run(() =>
            {
                List<Order> retList = new List<Order>();
                try
                {
                    var reader = SQL.Retrieve(new TablesDesc(Tables.Orders), "owner", user.GUID);
                    while (reader.Read())
                    {
                        var order = new Order();
                        order.GUID = reader["guid"].ToString();
                        order.Owner = reader["owner"].ToString();
                        order.Items = reader["info"].ToString() == "No info." ?
                        new ObservableCollection<OrderItem>() :
                        JsonConvert.DeserializeObject<ObservableCollection<OrderItem>>(reader["info"].ToString());
                        retList.Add(order);
                    }
                    return retList.AsEnumerable();
                }
                catch (Exception e)
                {
                    return retList.AsEnumerable();
                }
            });
        }

        public Task PostNewOrder(Order order)
        {
            return Task.Run(() =>
            {
                try
                {
                    var reader = SQL.Retrieve(new TablesDesc(Tables.Users), "guid", order.Owner);
                    var r = SQL.Insert(new TablesDesc(Tables.Orders),
                        new object[] {
                            order.GUID,
                            order.Owner,
                            JsonConvert.SerializeObject(order.Items)
                        });
                    if (r == 0)
                    {
                        throw new Exception("Something went wrong unpredictably");
                    }

                    if (reader.Read())
                    {
                        foreach (var item in order.Items)
                        {
                            var u = SQL.Update(new TablesDesc(Tables.Users), 
                                "guid", 
                                order.Owner, 
                                "balance", 
                                Convert.ToDouble(reader["balance"]) - item.Item.Price * item.Count);
                            if (u == 0)
                            {
                                throw new Exception("Balance deduction failed");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("NotFoundUser");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        public Task PutOrderInfo(Order order)
        {
            return Task.Run(() =>
            {
                try
                {
                    var t = new TablesDesc(Tables.Orders);
                    var reader = SQL.Retrieve(t, "guid", order.GUID);
                    if (reader.Read())
                    {
                        if (reader["owner"].ToString() != order.Owner)
                        {
                            var r = SQL.Update(t, "guid", order.GUID, "owner", order.Owner);
                            if (r == 0)
                            {
                                throw new Exception("ChangeFault");
                            }
                        }
                        if (reader["info"].ToString() != JsonConvert.SerializeObject(order.Items))
                        {
                            var r = SQL.Update(t, "guid", order.GUID, "info", JsonConvert.SerializeObject(order.Items));
                            if (r == 0)
                            {
                                throw new Exception("ChangeFault");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("NotFound");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }
    }
}
