using System.Data.Entity;
using Blog.Models;

namespace Blog.Data
{
    public class DataContext :DbContext
    {
        public DbSet<Post> Posts {get; set;}
    }
}