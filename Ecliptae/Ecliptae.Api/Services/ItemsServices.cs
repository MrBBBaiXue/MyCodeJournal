using Ecliptae.Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ecliptae.Api.Services
{
    public class ItemsServices : IItemsServices
    {
        public Task DeleteByGuid(string guid)
        {
            return Task.Run(() =>
            {
                try
                {
                    var r = SQL.Delete(new TablesDesc(Tables.Items), "guid", guid);
                    if(r == 0)
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

        public Task DeleteByName(string name)
        {
            return Task.Run(() =>
            {
                try
                {
                    var r = SQL.Delete(new TablesDesc(Tables.Items), "name", name);
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

        public Task DeleteByObject(Item item)
        {
            return Task.Run(() =>
            {
                try
                {
                    var r = SQL.Delete(new TablesDesc(Tables.Items), "guid", item.GUID);
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
                    var r = SQL.Delete(new TablesDesc(Tables.Items), "owner", user.GUID);
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

        public Task<IEnumerable<string>> GetAllItems()
        {
            return Task.Run(() =>
            {
                List<string> itemsList = new List<string>();
                try
                {
                    var reader = SQL.Retrieve(new TablesDesc(Tables.Items));
                    while (reader.Read())
                    {
                        var item = new Item()
                        {
                            Owner = reader["owner"].ToString(),
                            GUID = reader["guid"].ToString(),
                            Storage = Convert.ToInt32(reader["storage"]),
                            Description = reader["description"].ToString(),
                            Name = reader["name"].ToString(),
                            Price = Convert.ToDouble(reader["price"])
                        };
                        itemsList.Add(JsonConvert.SerializeObject(item));
                    }
                    return itemsList.AsEnumerable();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    itemsList.Add(e.Message);
                    return itemsList.AsEnumerable();
                }
            });
        }

        public Task<string> GetItemByGuid(string guid)
        {
            return Task.Run(() =>
            {
                try
                {
                    var reader = SQL.Retrieve(new TablesDesc(Tables.Items), "guid", guid);
                    Item item;
                    if (reader.Read())
                    {
                        item = new Item()
                        {
                            Owner = reader["owner"].ToString(),
                            GUID = reader["guid"].ToString(),
                            Storage = Convert.ToInt32(reader["storage"]),
                            Description = reader["description"].ToString(),
                            Name = reader["name"].ToString(),
                            Price = Convert.ToDouble(reader["price"])
                        };
                    }
                    else
                    {
                        throw new Exception("NotFound");
                    }
                    return JsonConvert.SerializeObject(item);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return e.Message;
                }
            });
        }

        public Task<string> GetItemByName(string name)
        {
            return Task.Run(() =>
            {
                try
                {
                    var reader = SQL.Retrieve(new TablesDesc(Tables.Items), "name", name);
                    Item item;
                    if (reader.Read())
                    {
                        item = new Item()
                        {
                            Owner = reader["owner"].ToString(),
                            GUID = reader["guid"].ToString(),
                            Storage = Convert.ToInt32(reader["storage"]),
                            Description = reader["description"].ToString(),
                            Name = reader["name"].ToString(),
                            Price = Convert.ToDouble(reader["price"])
                        };
                    }
                    else
                    {
                        throw new Exception("NotFound");
                    }
                    return JsonConvert.SerializeObject(item);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return e.Message;
                }
            });
        }

        public Task<IEnumerable<string>> GetItemsByOwner(User user)
        {
            return Task.Run(() =>
            {
                List<string> itemsList = new List<string>();
                try
                {
                    var reader = SQL.Retrieve(new TablesDesc(Tables.Items), "owner", user.GUID);
                    while (reader.Read())
                    {
                        var item = new Item()
                        {
                            Owner = reader["owner"].ToString(),
                            GUID = reader["guid"].ToString(),
                            Storage = Convert.ToInt32(reader["storage"]),
                            Description = reader["description"].ToString(),
                            Name = reader["name"].ToString(),
                            Price = Convert.ToDouble(reader["price"])
                        };
                        itemsList.Add(JsonConvert.SerializeObject(item));
                    }
                    return itemsList.AsEnumerable();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    itemsList.Add(e.Message);
                    return itemsList.AsEnumerable();
                }
            });
        }

        public Task PostNewItems(Item item)
        {
            return Task.Run(() =>
            {
                try
                {
                    var v = SQL.Insert(new TablesDesc(Tables.Items),
                        new object[]
                        {
                            item.GUID,
                            item.Name,
                            item.Description,
                            item.Price,
                            item.Storage,
                            item.Owner
                        });
                    if(v == 0)
                    {
                        throw new Exception("Something went wrong unpredictably");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        public Task PutItemsInf(Item item)
        {
            return Task.Run(() =>
            {
                try
                {
                    var t = new TablesDesc(Tables.Items);
                    var reader = SQL.Retrieve(t, "guid", item.GUID);
                    if (reader.Read())
                    {
                        if (reader["name"].ToString() != item.Name)
                        {
                            var r = SQL.Update(t, "guid", item.GUID, "name", item.Name);
                            if (r == 0)
                            {
                                throw new Exception("ChangeFault");
                            }
                        }
                        if (reader["description"].ToString() != item.Description)
                        {
                            var r = SQL.Update(t, "guid", item.GUID, "description", item.Description);
                            if (r == 0)
                            {
                                throw new Exception("ChangeFault");
                            }
                        }
                        if (reader["price"].ToString() != item.Price.ToString())
                        {
                            var r = SQL.Update(t, "guid", item.GUID, "price", item.Price);
                            if (r == 0)
                            {
                                throw new Exception("ChangeFault");
                            }
                        }
                        if (reader["storage"].ToString() != item.Storage.ToString())
                        {
                            var r = SQL.Update(t, "guid", item.GUID, "storage", item.Storage);
                            if (r == 0)
                            {
                                throw new Exception("ChangeFault");
                            }
                        }
                        if (reader["owner"].ToString() != item.Owner)
                        {
                            var r = SQL.Update(t, "guid", item.GUID, "owner", item.Owner);
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
