using FSEPABlogPost.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FSEPABlogPost.BusinessLayers.Services.Repository
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> Create(BlogPost blogPost);
        Task<BlogPost> GetPostById(string postId);
        Task<IEnumerable<BlogPost>> GetAllPost();
        Task<IEnumerable<Comment>> GetAllComments(string postId);
        Task <Comment>Comments(string postId, Comment comments);
    }
}
