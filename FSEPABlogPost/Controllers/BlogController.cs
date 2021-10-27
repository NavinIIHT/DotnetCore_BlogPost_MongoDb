using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSEPABlogPost.BusinessLayers.Services;
using FSEPABlogPost.BusinessLayers.Services.Repository;
using FSEPABlogPost.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSEPABlogPost.Controllers
{
    /// <summary>
    /// Route for accessing Api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        /// <summary>
        /// creating a referance object of IBlogPostRepository
        /// </summary>
        private readonly IBlogPostServices _blogPostServices;

        /// <summary>
        /// injecting IBlogPostRepository in consructor to access all methods
        /// </summary>
        public BlogController(IBlogPostServices blogPostServices)
        {
            _blogPostServices = blogPostServices;
        }

        //Get All BlogPost on Load of API or calling this method
        // GET: api/Blog/GetBlogPost
        [HttpGet]
        public async Task<IEnumerable<BlogPost>> GetBlogPost()
        {
            return await _blogPostServices.GetAllPost();
        }
        /// <summary>
        /// Create New BlogPost and save in MongoDb Collection
        /// </summary>
        /// <param name="blogPost"></param>
        /// <returns></returns>
        // POST: api/Blog/PostBlogPost
        [HttpPost]
		[Route("PostBlogPost")]
        public async Task<IActionResult> PostBlogPost([FromBody] BlogPost blogPost)
        {
            //Do code here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a BlogPost from MongoDb Collection
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        // GET: api/Blog/PostById/1
        [HttpGet("Get Post")]
        [Route("PostById/{postId}")]
        public async Task<IActionResult> GetBlogPostById([FromRoute] string postId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get BlogPostComments from MongoDb Collection
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        // GET: api/Blog/CommentById/1
        [HttpGet("Get Comments")]
        [Route("CommentById/{postId}")]
        public async Task<IActionResult> GetBlogPostCommentById([FromRoute] string postId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Crate new Comment on BlogPost and save in MongoDb
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        // POST: api/Blog/PostBlogPostComment
        [HttpPost]
		[Route("PostBlogPostComment")]
        public async Task<IActionResult> PostBlogPostComment([FromRoute] string postId, [FromBody] Comment comment)
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}