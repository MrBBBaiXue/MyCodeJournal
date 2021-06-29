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
            //var u = JsonConvert.DeserializeObject<User>("{\"Name\":\"ADMIN\",\"Hash\":\"admin\",\"Balance\":99999999.0,\"Level\":5,\"GUID\":\"00000000-00000000-00000000-00000000\"}");
            //return JsonConvert.SerializeObject(u);
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
        public async Task PutUserInf(User user)
        {
            await _usersServices.PutUserInf(user);
        }



        [HttpPost]
        public async Task PostNewUserAsync(User user)
        {
            await _usersServices.PostNewUser(user);
        }



        [HttpDelete]
        public async Task DeleteUserAsync(User user)
        {
            await _usersServices.DeleteByObject(user);
        }
        [HttpDelete("name={name}")]
        public async Task DeleteByName(string name)
        {
            await _usersServices.DeleteByName(name);
        }
        [HttpDelete("guid={guid}")]
        public async Task DeleteByGuid(string guid)
        {
            await _usersServices.DeleteByGuid(guid);
        }
    }
}
