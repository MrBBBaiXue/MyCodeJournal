using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecliptae.Lib;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecliptae.Api.Services;
using System.Net.Http;
using System.Web;

namespace Ecliptae.Api.Services
{
    public class UsersServices : IUsersServices
    {
        public async Task DeleteByGuid(string guid)
        {
            await Task.Run(() =>
            {
                try
                {
                    var r = SQL.Delete(new TablesDesc(Tables.Users), "guid", guid);
                    if (r == 0)
                    {
                        throw new Exception("This User is not exists");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        public async Task DeleteByName(string name)
        {
            await Task.Run(() =>
            {
                try
                {
                    var r = SQL.Delete(new TablesDesc(Tables.Users), "name", name);
                    if (r == 0)
                    {
                        throw new Exception("This User is not exists");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        public async Task DeleteByObject(string userObj)
        {
            await Task.Run(() =>
            {
                var user = JsonConvert.DeserializeObject<User>(userObj);
                try
                {
                    var r = SQL.Delete(new TablesDesc(Tables.Users), "guid", user.GUID);
                    if(r == 0)
                    {
                        throw new Exception("This User is not exists");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        public Task<string> GetUserByGuid(string guid)
        {
            return Task.Run(() =>
            {
                try
                {
                    var reader = SQL.Retrieve(new TablesDesc(Tables.Users), "guid", guid);
                    var user = new User();
                    if (reader.Read())
                    {
                        user.GUID = guid;
                        user.Name = reader["name"].ToString();
                        user.Hash = reader["password"].ToString();
                        user.Balance = Convert.ToDouble(reader["balance"]);
                        user.Level = Convert.ToInt32(reader["level"]);
                    }
                    else
                    {
                        throw new Exception("Not Found The User");
                    }
                    return JsonConvert.SerializeObject(user);
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            });
        }

        public Task<string> GetUserByName(string name)
        {
            return Task.Run(() =>
            {
                try
                {
                    var reader = SQL.Retrieve(new TablesDesc(Tables.Users), "name", name);
                    var user = new User();
                    if (reader.Read())
                    {
                        user.GUID = reader["guid"].ToString();
                        user.Name = reader["name"].ToString();
                        user.Hash = reader["password"].ToString();
                        user.Balance = Convert.ToDouble(reader["balance"]);
                        user.Level = Convert.ToInt32(reader["level"]);
                    }
                    else
                    {
                        throw new Exception("Not Found The User");
                    }
                    return JsonConvert.SerializeObject(user);
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            });
        }

        public Task<IEnumerable<string>> GetUsers()
        {
            return Task.Run(() =>
            {
                List<string> retList = new List<string>();
                try
                {
                    var reader = SQL.Retrieve(new TablesDesc(Tables.Users));
                    while (reader.Read())
                    {
                        var user = new User();
                        user.GUID = reader["guid"].ToString();
                        user.Name = reader["name"].ToString();
                        user.Hash = reader["password"].ToString();
                        user.Balance = Convert.ToDouble(reader["balance"]);
                        user.Level = Convert.ToInt32(reader["level"]);
                        Console.WriteLine(JsonConvert.SerializeObject(user));
                        retList.Add(JsonConvert.SerializeObject(user));
                    }
                    return retList.AsEnumerable();
                }
                catch (Exception e)
                {
                    retList.Add(e.Message);
                    return retList.AsEnumerable();
                }
            });
        }

        public Task<bool> LoginAuthentication(string name, string passwordHashcode)
        {
            return Task.Run(() =>
            {
                try
                {
                    var reader = SQL.Retrieve(new TablesDesc(Tables.Users), "name", name);
                    if (reader.Read())
                    {
                        if (reader["password"].ToString() == passwordHashcode)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        throw new Exception("Not Found The User");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            });
        }

        public Task PostNewUser(string userObj)
        {
            return Task.Run(() =>
            {
                try
                {
                    var newUser = JsonConvert.DeserializeObject<User>(userObj);
                    var r = SQL.Insert(
                        new TablesDesc(Tables.Users),
                        new object[]
                        {
                            newUser.GUID,
                            newUser.Name,
                            newUser.Hash,
                            newUser.Balance,
                            newUser.Level
                        });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        public Task PutUserInf(string newJsonObj)
        {
            return Task.Run(() =>
            {
                try
                {
                    var user = JsonConvert.DeserializeObject<User>(newJsonObj);
                    var t = new TablesDesc(Tables.Users);
                    var reader = SQL.Retrieve(t, "guid", user.GUID);
                    if (reader.Read())
                    {
                        if (user.Name != reader["name"].ToString())
                        {
                            var r = SQL.Update(t, "guid", user.GUID, "name", user.Name);
                        }
                        if (user.Hash != reader["password"].ToString())
                        {
                            var r = SQL.Update(t, "guid", user.GUID, "password", user.Hash);
                        }
                        if (user.Balance.ToString() != reader["balance"].ToString())
                        {
                            var r = SQL.Update(t, "guid", user.GUID, "balance", user.Balance);
                        }
                        if (user.Level.ToString() != reader["level"].ToString())
                        {
                            var r = SQL.Update(t, "guid", user.GUID, "level", user.Level);
                        }
                    }
                    else
                    {
                        throw new Exception("Not Found The User");
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
