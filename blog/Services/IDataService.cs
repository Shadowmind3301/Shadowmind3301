using System;
using System.Collections.Generic;
using Blog.Models;

namespace Blog.Services
{
    public interface IDataService : IDisposable
    {
        Post GetPostById(int id);
        void SavePost(Post post);
        void DeletePost(int id);
        ICollection<Post> GetAllPosts();
    }
}
