using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecliptae.Api.Services
{
    public interface IUsersServices
    {
        // GET
        public Task<IEnumerable<string>> GetUsers();
        public Task<string> GetUserByGuid(string guid);
        public Task<string> GetUserByName(string name);
        public Task<bool> LoginAuthentication(string name, string passwordHashcode);
        // PUT
        public Task PutUserInf(string newJsonObj);
        // POST
        public Task PostNewUser(string userObj);
        // DELETE
        public Task DeleteByName(string name);
        public Task DeleteByGuid(string guid);
        public Task DeleteByObject(string userObj);
    }
}
