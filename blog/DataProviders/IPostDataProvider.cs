using System.Collections.Generic;
using Blog.Models;

namespace Blog.DataProviders
{
    public interface IPostDataProvider
    {
        Post GetPostById(int? id);
        void SavePost(Post post);
        void DeletePost(int id);
        ICollection<Post> GetAllPosts();
    }
}
