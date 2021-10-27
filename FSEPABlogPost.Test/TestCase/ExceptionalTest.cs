using FSEPABlogPost.BusinessLayers.Services;
using FSEPABlogPost.BusinessLayers.Services.Repository;
using FSEPABlogPost.Entities;
using FSEPABlogPost.Test.TestCase.Utlities;
using Moq;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FSEPABlogPost.Test.TestCase
{
    public class ExceptionalTest
    {
        //injecting IBlogPostService interface to access all method.
        private readonly ITestOutputHelper _output;
        private readonly IBlogPostServices _services;
        //mocking IBlogPostRepository to access all Repository method
        public readonly Mock<IBlogPostRepository> mockservice = new Mock<IBlogPostRepository>();
        public ExceptionalTest(ITestOutputHelper output)
        {
            _services = new BlogPostServices(mockservice.Object);
            _output = output;
        }

        /// <summary>
        /// creating static constructor for creating test output in text file 
        /// </summary>
        static ExceptionalTest()
        {
            if (!File.Exists("../../../../output_exception_revised.txt"))
                try
                {
                    File.Create("../../../../output_exception_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_exception_revised.txt");
                File.Create("../../../../output_exception_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// Create new post if object null throw error
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> CreateNewPost_Null_Failure()
        {
            // Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var blogPost = new BlogPost()
            {
                Title = "Post-Title",
                Abstract = "Post Abstract-1",
                Description = "Post Description -1"
            };
            blogPost = null;
            //Act 
            try
            {
                mockservice.Setup(blogRepo => blogRepo.Create(blogPost));
                var result = await _services.Create(blogPost);
                if (result == null)
                {
                    res = true;
                }
            }
            catch(Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "CreateNewPost_Null_Failure=" + res + "\n");
                return false;
            }
            //writing tset boolean output in text file, that is present in project directory
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "CreateNewPost_Null_Failure=" + res + "\n");
            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> CreateNewComment_Null_Failure()
        {
            // Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string PostId = "5ef312a0f05009584c12a93f";
            var comments = new Comment()
            {
                CommentMsg = "Post Title Comments -1 ",
                PostId = "5ef312a0f05009584c12a93f"
            };
            comments = null;
            //Act 
            try
            {
                mockservice.Setup(blogRepo => blogRepo.Comments(PostId, comments));
                var result = await _services.Comments(PostId, comments);
                if (result == null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "CreateNewComment_Null_Failure=" + res + "\n");
                return false;
            }
            //writing tset boolean output in text file, that is present in project directory
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "CreateNewComment_Null_Failure=" + res + "\n");
            return res;
        }
    }
}
