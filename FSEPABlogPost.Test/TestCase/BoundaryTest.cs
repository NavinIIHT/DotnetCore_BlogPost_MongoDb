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
    public class BoundaryTest
    {
        //injecting IBlogPostService interface to access all method
        private readonly IBlogPostServices _services;
        private readonly ITestOutputHelper _output;
        //mocking IBlogPostRepository to access all Repository method
        public readonly Mock<IBlogPostRepository> mockservice = new Mock<IBlogPostRepository>();
        public BoundaryTest(ITestOutputHelper output)
        {
            _services = new BlogPostServices(mockservice.Object);
            _output = output;
        }

        /// <summary>
        /// creating static constructor for creating text file if not exists.
        /// </summary>
        static BoundaryTest()
        {
            if (!File.Exists("../../../../output_boundary_revised.txt"))
                try
                {
                    File.Create("../../../../output_boundary_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_boundary_revised.txt");
                File.Create("../../../../output_boundary_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// validate BlogPostId
        /// </summary>
        /// <returns>return true if postId is exists write output in text file</returns>
        [Fact]
        public async Task<bool> Testfor_ValidatePostId()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string postid = "5ef312a0f05009584c12a93f";
            //Assigning values for new post
            var blogPost = new BlogPost()
            {
                PostId = "5ef312a0f05009584c12a93f",
                Abstract = "Abstract of post",
                Title = "Post Title",
                Description = "Post Description goes here"
            };
            //Act
            try
            {
                mockservice.Setup(repo => repo.Create(blogPost)).ReturnsAsync(blogPost);
                var result = await _services.Create(blogPost);
                if (result.PostId == postid)
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
                await File.AppendAllTextAsync("../../../../output_boundary_revised.txt",
                    "Testfor_ValidatePostId=" + res + "\n");
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
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt","Testfor_ValidatePostId=" + res + "\n");
            return res;
        }

        /// <summary>
        /// validate BlogPost Title Property
        /// </summary>
        /// <returns>return true if Title is not null and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_ValidateBlogPost_TitleProperty_Empty()
        {
            //Arrange
            bool res = false;
            string postid = "5ef312a0f05009584c12a93f";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Assigning values for new post
            var blogPost = new BlogPost()
            {
                PostId = postid,
                Abstract = "Abstract of post",
                Title = "Post Title",
                Description = "Post Description goes here"
            };
            try
            {
                //Act
                mockservice.Setup(repo => repo.Create(blogPost)).ReturnsAsync(blogPost);
                var result = await _services.Create(blogPost);
                if (result.Title != null)
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
                await File.AppendAllTextAsync("../../../../output_boundary_revised.txt",
                    "Test_ValidateBlogPost_TitleProperty_Empty=" + res + "\n");
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
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt",
                    "Test_ValidateBlogPost_TitleProperty_Empty=" + res + "\n");
            return res;
        }
        /// <summary>
        /// validate BlogPost Abstract Property
        /// </summary>
        /// <returns>return true if Abstract is not null and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_ValidateBlogPost_AbstractProperty_Empty()
        {
            //Arrange
            bool res = false;
            string postid = "5ef312a0f05009584c12a93f";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Assigning values for new post
            var blogPost = new BlogPost()
            {
                PostId = postid,
                Abstract = "Abstract of post",
                Title = "Post Title",
                Description = "Post Description goes here"
            };
            try
            {
                //Act
                mockservice.Setup(repo => repo.Create(blogPost)).ReturnsAsync(blogPost);
                var result = await _services.Create(blogPost);
                if (result.Abstract != null)
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
                await File.AppendAllTextAsync("../../../../output_boundary_revised.txt",
                    "Test_ValidateBlogPost_AbstractProperty_Empty=" + res + "\n");
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
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt",
                    "Test_ValidateBlogPost_AbstractProperty_Empty=" + res + "\n");
            return res;
        }
        /// <summary>
        /// validate BlogPost Description Property
        /// </summary>
        /// <returns>return true if Description is not null and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_ValidateBlogPost_DescriptionProperty_Empty()
        {
            //Arrange
            bool res = false;
            string postid = "5ef312a0f05009584c12a93f";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Assigning values for new post
            var blogPost = new BlogPost()
            {
                PostId = postid,
                Abstract = "Abstract of post",
                Title = "Post Title",
                Description = "Post Description goes here"
            };
            //Act
            try
            {
                mockservice.Setup(repo => repo.Create(blogPost)).ReturnsAsync(blogPost);
                var result = await _services.Create(blogPost);
                if (result.Description != null)
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
                await File.AppendAllTextAsync("../../../../output_boundary_revised.txt",
                    "Test_ValidateBlogPost_DescriptionProperty_Empty=" + res + "\n");
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
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt",
                    "Test_ValidateBlogPost_DescriptionProperty_Empty=" + res + "\n");
            return res;
        }
        /// <summary>
        /// validate Comment CommentMsg Property
        /// </summary>
        /// <returns>return true if CommentMsg is not null and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_ValidateComment_CommentMsgProperty_Empty()
        {
            //Arrange
            bool res = false;
            string postid = "5ef312a0f05009584c12a93f";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Assigning values for new post
            var comment = new Comment()
            {
                CommentMsg = "Comment -1 "
            };
            //Act
            try
            {
                mockservice.Setup(repo => repo.Comments(postid, comment)).ReturnsAsync(comment);
                var result = await _services.Comments(postid, comment);
                if (result.CommentMsg != null)
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
                await File.AppendAllTextAsync("../../../../output_boundary_revised.txt",
                    "Test_ValidateComment_CommentMsgProperty_Empty=" + res +"\n");
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
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt",
                    "Test_ValidateComment_CommentMsgProperty_Empty=" + res + "\n");
            return res;
        }
    }
}