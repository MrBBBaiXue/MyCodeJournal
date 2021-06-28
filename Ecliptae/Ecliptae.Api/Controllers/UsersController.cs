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
    public class UsersController : Controller
    {
        private IUsersServices _usersServices;
        public UsersController(IUsersServices UsersServices)
        {
            _usersServices = UsersServices;
        }
        [HttpGet("newJson")]
        public string Get()
        {
            var u = new User();
            var r = new Random();
            u.NewGuid();
            u.Name = u.GUID[5].ToString() + u.GUID[10].ToString() + u.GUID[15].ToString() + u.GUID[20].ToString();
            u.Hash = (r.Next() % 1e7).GetHashCode().ToString();
            u.Balance = 999.99;
            u.Level = 5;
            return JsonConvert.SerializeObject(u);
        }
        [HttpGet]
        public async Task<IEnumerable<string>> GetUsersAsync()
        {
            return await _usersServices.GetUsers();
        }
        [HttpGet("name={name}")]
        public async Task<string> GetUserByNameAsync(string name)
        {
            return await _usersServices.GetUserByName(name);
        }
        [HttpGet("guid={guid}")]
        public async Task<string> GetUserByGuidAsync(string guid)
        {
            return await _usersServices.GetUserByGuid(guid);
        }
        [HttpPut]
        public async Task PutUserInf(string userObj)
        {
            await _usersServices.PutUserInf(userObj);
        }
        [HttpPost()]
        public async Task PostNewUserAsync(string userObj)
        {
            await _usersServices.PostNewUser(userObj);
        }
        [HttpDelete("name={name}")]
        public async Task DeleteByName(string name)
        {
            await _usersServices.DeleteByName(name);
        }
    }
}
