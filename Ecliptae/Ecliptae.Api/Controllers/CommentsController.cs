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
    public class CommentsController : Controller
    {
        private ICommentsServices _commentsServices;
        public CommentsController(ICommentsServices commentsServices)
        {
            _commentsServices = commentsServices;
        }



        [HttpGet("test")]
        public string Get()
        {
            //var u = JsonConvert.DeserializeObject<User>("{\"Name\":\"ADMIN\",\"Hash\":\"admin\",\"Balance\":99999999.0,\"Level\":5,\"GUID\":\"00000000-00000000-00000000-00000000\"}");
            //return JsonConvert.SerializeObject(u);
            var u = new Item();
            var r = new Random();
            u.NewGuid();
            u.Description = "zwlzwlzwl ballballu bangbang wo";
            u.Name = u.GUID[5].ToString() + u.GUID[10].ToString() + u.GUID[15].ToString() + u.GUID[20].ToString();
            u.Owner = r.Next() % 2 == 0 ? "00000000-00000000-00000000-00000000" : "4fg896eq-eqg741ws-qew7yh46a-gqe8746b";
            u.Price = r.NextDouble();
            u.Storage = r.Next() % 10000 + 1;
            return JsonConvert.SerializeObject(u);
        }



        [HttpGet]
        public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
        {
            return await _commentsServices.GetAllComments();
        }
        [HttpGet("owner={ownerGuid}")]
        public async Task<IEnumerable<Comment>> GetCommentsByOwnerAsync(string ownerGuid)
        {
            return await _commentsServices.GetCommentsByOwner(ownerGuid);
        }
        [HttpGet("item={itemGuid}")]
        public async Task<IEnumerable<Comment>> GetCommentsByItemAsync(string itemGuid)
        {
            return await _commentsServices.GetCommentsByOwner(itemGuid);
        }
        [HttpGet("guid={guid}")]
        public async Task<Comment> GetCommentsByGuidAsync(string guid)
        {
            return await _commentsServices.GetCommentByGuid(guid);
        }



        [HttpPut]
        public async Task PutCommentsInfAsync(Comment comment)
        {
            await _commentsServices.PutCommentsInf(comment);
        }



        [HttpPost]
        public async Task PostNewCommentsAsync(Comment comment)
        {
            await _commentsServices.PostNewComments(comment);
        }



        [HttpDelete]
        public async Task DeleteByObjectAsync(Comment comment)
        {
            await _commentsServices.DeleteByObject(comment);
        }
        [HttpDelete("owner={ownerGuid}")]
        public async Task DeleteByObjectAsync(string ownerGuid)
        {
            await _commentsServices.DeleteByOwner(ownerGuid);
        }
        [HttpDelete("item={itemGuid}")]
        public async Task DeleteByItemAsync(string itemGuid)
        {
            await _commentsServices.DeleteByItem(itemGuid);
        }
        [HttpDelete("guid={guid}")]
        public async Task DeleteByGuidAsync(string guid)
        {
            await _commentsServices.DeleteByGuid(guid);
        }
    }
}
