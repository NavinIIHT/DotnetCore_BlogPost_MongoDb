using FSEPABlogPost.DataLayers;
using FSEPABlogPost.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FSEPABlogPost.BusinessLayers.Services.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        //Creating field or object or dbcontext and all collection
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<BlogPost> _dbCollection;
        private IMongoCollection<Comment> _dbCommentsCollection;

        //Injecting mongoContext in constructor
        public BlogPostRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<BlogPost>(typeof(BlogPost).Name);
            _dbCommentsCollection = _mongoContext.GetCollection<Comment>(typeof(Comment).Name);
        }

        /// <summary>
        /// Add new Commnet BlogPosst in MongoDb
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="comments"></param>
        /// <returns>Comment object if create Comments is ok(200)</returns>
        public async Task<Comment> Comments(string postId, Comment comments)
        {
            try
            {
                if (postId == null && comments == null)
                {
                    throw new ArgumentNullException(typeof(Comment).Name + "Object and Id is Null");
                }
                _dbCommentsCollection = _mongoContext.GetCollection<Comment>(typeof(Comment).Name);
                await _dbCommentsCollection.InsertOneAsync(comments);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return comments;
        }
        /// <summary>
        /// Create new BlogPost in MongoDb
        /// </summary>
        /// <param name="blogPost"></param>
        /// <returns> BlogPost object if create method is ok(200)</returns>
        public async Task<BlogPost> Create(BlogPost blogPost)
        {
            try
            {
                if (blogPost == null)
                {
                    throw new ArgumentNullException(typeof(BlogPost).Name + "Object is Null");
                }
                _dbCollection = _mongoContext.GetCollection<BlogPost>(typeof(BlogPost).Name);
                await _dbCollection.InsertOneAsync(blogPost);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blogPost;
        }
        /// <summary>
        /// get All comments for specific post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Comment>> GetAllComments(string postId)
        {
            try
            {
                var list = _mongoContext.GetCollection<Comment>("Comment")
                .Find(c => c.PostId == postId)
                .SortByDescending(e => e.CommentedDate);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get list of all Blogpost
        /// </summary>
        /// <returns>All BlogPost</returns>
        public async Task<IEnumerable<BlogPost>> GetAllPost()
        {
            try
            {
                var list = _mongoContext.GetCollection<BlogPost>("BlogPost")
                .Find(Builders<BlogPost>.Filter.Empty, null)
                .SortByDescending(e => e.PostedDate);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get one BlogPost by id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns> single post</returns>
        public async Task<BlogPost> GetPostById(string postId)
        {
            try
            {
                var objectId = new ObjectId(postId);
                FilterDefinition<BlogPost> filter = Builders<BlogPost>.Filter.Eq("PostId", objectId);
                _dbCollection = _mongoContext.GetCollection<BlogPost>(typeof(BlogPost).Name);
                return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}