using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Blog.Models;
using Blog.Data;

namespace Blog.Services
{
    public class DataService : IDataService
    {
        private readonly DataContext _dataContext;

        public DataService()
        {
            _dataContext = new DataContext();

        }
        public Post GetPostById(int id)
        {
            return _dataContext.Posts.Single(n => n.Id == id);
        }
        public void SavePost(Post post)
        {
            if (post.Id <= 0)
                _dataContext.Posts.Add(post);
            else
                _dataContext.Posts.AddOrUpdate(post);

            _dataContext.SaveChanges();
        }

        public void DeletePost(int id)
        {
            var removePost = _dataContext.Posts.Single(n => n.Id == id);
            _dataContext.Posts.Remove(removePost);
            _dataContext.SaveChanges();
        }

        public ICollection<Post> GetAllPosts()
        {
            return _dataContext.Posts.Select(n => n).ToList();
        }
        
        public void Dispose()
        {
            _dataContext?.Dispose();
        }
        
    }
}