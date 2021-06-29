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
    public class CommentsServices : ICommentsServices
    {
        public Task DeleteByGuid(string guid)
        {
            return Task.Run(() =>
            {
                try
                {
                    var r = SQL.Delete(new TablesDesc(Tables.Comments), "guid", guid);
                    if (r == 0)
                    {
                        throw new Exception("This Comment is not exists");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        public Task DeleteByItem(string itemGuid)
        {
            return Task.Run(() =>
            {
                try
                {
                    var r = SQL.Delete(new TablesDesc(Tables.Comments), "item", itemGuid);
                    if (r == 0)
                    {
                        throw new Exception("This Comment is not exists");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }


        public Task DeleteByObject(Comment comment)
        {
            return Task.Run(() =>
            {
                try
                {
                    var r = SQL.Delete(new TablesDesc(Tables.Comments), "guid", comment.GUID);
                    if (r == 0)
                    {
                        throw new Exception("This Comment is not exists");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        public Task DeleteByOwner(string ownerGuid)
        {
            return Task.Run(() =>
            {
                try
                {
                    var r = SQL.Delete(new TablesDesc(Tables.Comments), "owner", ownerGuid);
                    if (r == 0)
                    {
                        throw new Exception("This Comment is not exists");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        public Task<IEnumerable<string>> GetAllComments()
        {
            return Task.Run(() =>
            {
                List<string> commentList = new List<string>();
                try
                {
                    var reader = SQL.Retrieve(new TablesDesc(Tables.Comments));
                    while (reader.Read())
                    {
                        var c = new Comment()
                        {
                            GUID = reader["guid"].ToString(),
                            Content = reader["content"].ToString(),
                            Item = reader["item"].ToString(),
                            Owner = reader["owner"].ToString(),
                            Star = Convert.ToInt32(reader["star"])
                        };
                        commentList.Add(JsonConvert.SerializeObject(c));
                    }
                    return commentList.AsEnumerable();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    commentList.Add(e.Message);
                    return commentList.AsEnumerable();
                }
            });
        }

        public Task<string> GetCommentByGuid(string guid)
        {
            return Task.Run(() =>
            {
                try
                {
                    var reader = SQL.Retrieve(new TablesDesc(Tables.Comments), "guid", guid);
                    if (reader.Read())
                    {
                        var c = new Comment()
                        {
                            GUID = reader["guid"].ToString(),
                            Content = reader["content"].ToString(),
                            Item = reader["item"].ToString(),
                            Owner = reader["owner"].ToString(),
                            Star = Convert.ToInt32(reader["star"])
                        };
                        return JsonConvert.SerializeObject(c);
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

        public Task<IEnumerable<string>> GetCommentsByItem(string itemGuid)
        {
            return Task.Run(() =>
            {
                List<string> commentList = new List<string>();
                try
                {
                    var reader = SQL.Retrieve(new TablesDesc(Tables.Comments), "item", itemGuid);
                    while (reader.Read())
                    {
                        var c = new Comment()
                        {
                            GUID = reader["guid"].ToString(),
                            Content = reader["content"].ToString(),
                            Item = reader["item"].ToString(),
                            Owner = reader["owner"].ToString(),
                            Star = Convert.ToInt32(reader["star"])
                        };
                        commentList.Add(JsonConvert.SerializeObject(c));
                    }
                    return commentList.AsEnumerable();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    commentList.Add(e.Message);
                    return commentList.AsEnumerable();
                }
            });
        }

        public Task<IEnumerable<string>> GetCommentsByOwner(string ownerGuid)
        {
            return Task.Run(() =>
            {
                List<string> commentList = new List<string>();
                try
                {
                    var reader = SQL.Retrieve(new TablesDesc(Tables.Comments), "owner", ownerGuid);
                    while (reader.Read())
                    {
                        var c = new Comment()
                        {
                            GUID = reader["guid"].ToString(),
                            Content = reader["content"].ToString(),
                            Item = reader["item"].ToString(),
                            Owner = reader["owner"].ToString(),
                            Star = Convert.ToInt32(reader["star"])
                        };
                        commentList.Add(JsonConvert.SerializeObject(c));
                    }
                    return commentList.AsEnumerable();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    commentList.Add(e.Message);
                    return commentList.AsEnumerable();
                }
            });
        }

        public Task PostNewComments(Comment comment)
        {
            return Task.Run(() =>
            {
                try
                {
                    var r = SQL.Insert(new TablesDesc(Tables.Comments),
                        new object[]{
                            comment.GUID,
                            comment.Owner,
                            comment.Item,
                            comment.Content,
                            comment.Star
                        });
                    if(r == 0)
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

        public Task PutCommentsInf(Comment comment)
        {
            return Task.Run(() =>
            {
                try
                {
                    var t = new TablesDesc(Tables.Comments);
                    var reader = SQL.Retrieve(t, "guid", comment.GUID);
                    if (reader.Read())
                    {
                        if (comment.Owner != reader["owner"].ToString())
                        {
                            var r = SQL.Update(t, "guid", comment.GUID, "owner", comment.Owner);
                            if (r == 0)
                            {
                                throw new Exception("ChangeFault");
                            }
                        }
                        if (comment.Star.ToString() != reader["star"].ToString())
                        {
                            var r = SQL.Update(t, "guid", comment.GUID, "star", comment.Star);
                            if (r == 0)
                            {
                                throw new Exception("ChangeFault");
                            }
                        }
                        if (comment.Item != reader["item"].ToString())
                        {
                            var r = SQL.Update(t, "guid", comment.GUID, "item", comment.Item);
                            if (r == 0)
                            {
                                throw new Exception("ChangeFault");
                            }
                        }
                        if (comment.Content != reader["content"].ToString())
                        {
                            var r = SQL.Update(t, "guid", comment.GUID, "content", comment.Content);
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
