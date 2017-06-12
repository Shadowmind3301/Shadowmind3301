using System;
using System.Collections.Generic;
using Blog.Models;
using Blog.Services;

namespace Blog.DataProviders
{
    public class PostDataProvider : IPostDataProvider
    {

        private readonly Func<IDataService> _dataServiceCreator;
        public PostDataProvider(Func<IDataService> dataServiceCreator)
        {
            _dataServiceCreator = dataServiceCreator;

        }

        public Post GetPostById(int? id)
        {
            using (var dataService = _dataServiceCreator())
            {
                return dataService.GetPostById(id.Value);
            }
        }

        public void SavePost(Post post)
        {
            using (var dataService = _dataServiceCreator())
            {
                dataService.SavePost(post);
            }
        }

        public void DeletePost(int id)
        {
            using (var dataService = _dataServiceCreator())
            {
                dataService.DeletePost(id);
            }
        }

        public ICollection<Post> GetAllPosts()
        {
            using (var dataService = _dataServiceCreator())
            {
                return dataService.GetAllPosts();
            }
        }
    }
}