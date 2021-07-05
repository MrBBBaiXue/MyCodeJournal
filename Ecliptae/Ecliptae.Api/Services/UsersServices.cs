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
                        throw new Exception("This User does not exists");
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
                        throw new Exception("This User does not exists");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        public async Task DeleteByObject(User user)
        {
            await Task.Run(() =>
            {
                try
                {
                    var r = SQL.Delete(new TablesDesc(Tables.Users), "guid", user.GUID);
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

        public Task<IEnumerable<User>> GetUsers()
        {
            return Task.Run(() =>
            {
                List<User> retList = new List<User>();
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
                        retList.Add(user);
                    }
                    return retList.AsEnumerable();
                }
                catch (Exception e)
                {
                    return retList.AsEnumerable();
                }
            });
        }

        public Task PostNewUser(User newUser)
        {
            return Task.Run(() =>
            {
                try
                {
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

        public Task PutUserInf(User user)
        {
            return Task.Run(() =>
            {
                try
                {
                    var t = new TablesDesc(Tables.Users);
                    var reader = SQL.Retrieve(t, "guid", user.GUID);
                    if (reader.Read())
                    {
                        if (user.Name != reader["name"].ToString())
                        {
                            var r = SQL.Update(t, "guid", user.GUID, "name", user.Name);
                            if (r == 0)
                            {
                                throw new Exception("ChangeFault");
                            }
                        }
                        if (user.Hash != reader["password"].ToString())
                        {
                            var r = SQL.Update(t, "guid", user.GUID, "password", user.Hash);
                            if (r == 0)
                            {
                                throw new Exception("ChangeFault");
                            }
                        }
                        if (user.Balance.ToString() != reader["balance"].ToString())
                        {
                            var r = SQL.Update(t, "guid", user.GUID, "balance", user.Balance);
                            if (r == 0)
                            {
                                throw new Exception("ChangeFault");
                            }
                        }
                        if (user.Level.ToString() != reader["level"].ToString())
                        {
                            var r = SQL.Update(t, "guid", user.GUID, "level", user.Level);
                            if (r == 0)
                            {
                                throw new Exception("ChangeFault");
                            }
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
