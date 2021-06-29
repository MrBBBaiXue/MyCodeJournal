using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecliptae.Lib;

namespace Ecliptae.Api.Services
{
    public interface ICommentsServices
    {
        // GET
        public Task<IEnumerable<string>> GetAllComments();
        public Task<IEnumerable<string>> GetCommentsByOwner(string ownerGuid);
        public Task<IEnumerable<string>> GetCommentsByItem(string itemGuid);
        public Task<string> GetCommentByGuid(string guid);
        // PUT
        public Task PutCommentsInf(Comment comment);
        // POST
        public Task PostNewComments(Comment comment);
        // DELETE
        public Task DeleteByOwner(string ownerGuid);
        public Task DeleteByObject(Comment comment);
        public Task DeleteByItem(string itemGuid);
        public Task DeleteByGuid(string guid);
    }
}
