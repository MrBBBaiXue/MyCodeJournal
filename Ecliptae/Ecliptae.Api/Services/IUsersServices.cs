using Ecliptae.Lib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecliptae.Api.Services
{
    public interface IUsersServices
    {
        // GET
        public Task<IEnumerable<User>> GetUsers();
        public Task<string> GetUserByGuid(string guid);
        public Task<string> GetUserByName(string name);
        // PUT
        public Task PutUserInf(User user);
        // POST
        public Task PostNewUser(User user);
        // DELETE
        public Task DeleteByName(string name);
        public Task DeleteByGuid(string guid);
        public Task DeleteByObject(User user);
    }
}
