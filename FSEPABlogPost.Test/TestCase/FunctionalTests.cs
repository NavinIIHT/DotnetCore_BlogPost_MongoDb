using FSEPABlogPost.BusinessLayers.Services;
using FSEPABlogPost.BusinessLayers.Services.Repository;
using FSEPABlogPost.DataLayers;
using FSEPABlogPost.Entities;
using FSEPABlogPost.Test.TestCase.Utlities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FSEPABlogPost.Test.TestCase
{
    public class FunctionalTests
    {
        //injecting IBlogPostService interface to access all method.
        //mocking IBlogPostRepository to access all Repository method
        private readonly ITestOutputHelper _output;
        private readonly IBlogPostServices _services;
        public readonly Mock<IBlogPostRepository> mockservice = new Mock<IBlogPostRepository>();
        private readonly Mock<IOptions<Mongosettings>> _mockOptions;
        private readonly Mock<IMongoDatabase> _mockDB;
        private readonly Mock<IMongoClient> _mockClient;
        public FunctionalTests(ITestOutputHelper output)
        {
            _output = output;
            _services = new BlogPostServices(mockservice.Object);
            _mockOptions = new Mock<IOptions<Mongosettings>>();
            _mockDB = new Mock<IMongoDatabase>();
            _mockClient = new Mock<IMongoClient>();
        }
        /// <summary>
        /// creating static constructor for creating test output in text file 
        /// </summary>
        static FunctionalTests()
        {
            if (!File.Exists("../../../../output_revised.txt"))
                try
                {
                    File.Create("../../../../output_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_revised.txt");
                File.Create("../../../../output_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// using this test method retriving all post as list
        /// </summary>
        /// <returns>post list and if list is present return true and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_Get_GetAllPost()
        {
            // Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            // Act
            try
            {
                mockservice.Setup(blogRepo => blogRepo.GetAllPost());
                var result = await _services.GetAllPost();
                if (result != null)
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
                await File.AppendAllTextAsync("../../../../output_revised.txt","Test_Get_GetAllPost="+ res.ToString() + "\n");
                return false;
            }
            // Assert
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
            await File.AppendAllTextAsync("../../../../output_revised.txt","Test_Get_GetAllPost="+ res.ToString() + "\n");
            return res;
        }

        /// <summary>
        /// using this method create new BlogPost
        /// </summary>
        /// <returns>return true if post is created and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_Post_CreateBlogPost()
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
            //Act
            try
            {
                mockservice.Setup(blogRepo => blogRepo.Create(blogPost));
                var result = await _services.Create(blogPost);
                if (result != null)
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
                await File.AppendAllTextAsync("../../../../output_revised.txt","Test_Post_CreateBlogPost="+ res.ToString() + "\n");
                return false;
            }
            //Assert
            //writing tset boolean output in text file, that is present in project directory.
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await File.AppendAllTextAsync("../../../../output_revised.txt",
                "Test_Post_CreateBlogPost="
                + res.ToString() + "\n");
            return res;
        }
        /// <summary>
        /// using this method get a single BlogPost
        /// </summary>
        /// <returns>return true if post is exists and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_Get_GetOnePostById()
        {
            // Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var blogpostId = "5ef6ee674fefa83a0cf69415";
            // Act
            try
            {
                mockservice.Setup(blogRepo => blogRepo.GetPostById(blogpostId));
                var result = await _services.GetPostById(blogpostId);
                if (result != null)
                {
                    res = false;
                }
            }
            catch(Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await File.AppendAllTextAsync("../../../../output_revised.txt", "Test_Get_GetOnePostById=" + res.ToString() + "\n");
                return false;
            }
            // Assert
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
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Test_Get_GetOnePostById=" + res.ToString() + "\n");
            return res;
        }

        /// <summary>
        /// using this method create a commnet on BlogPost
        /// </summary>
        /// <returns>return true if comment inserted and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_Post_CreateBlogPostComment()
        {
            // Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var postId = "5ef312a0f05009584c12a93f";
            var comments = new Comment()
            {
                CommentMsg = "Post Title Comments -1 ",
                PostId = "5ef312a0f05009584c12a93f"
            };
            // Act
            try
            {
                mockservice.Setup(blogRepo => blogRepo.Comments(postId, comments));
                var result = await _services.Comments(postId, comments);
                if (result != null)
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
                await File.AppendAllTextAsync("../../../../output_revised.txt","Test_Post_CreateBlogPostComment="+ res.ToString() + "\n");
                return false;
            }
            // Assert
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
            await File.AppendAllTextAsync("../../../../output_revised.txt","Test_Post_CreateBlogPostComment="+ res.ToString() + "\n");
            return false;
        }

        /// <summary>
        /// using this method get a list of comment related BlogPost
        /// </summary>
        /// <returns>return true if comment is exists and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_Get_GetAllCommentById()
        {
            // Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var postId = "5ef312a0f05009584c12a93f";
            // Act
            try
            {
                mockservice.Setup(blogRepo => blogRepo.GetAllComments(postId));
                var result = await _services.GetAllComments(postId);
                if (result != null)
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
                await File.AppendAllTextAsync("../../../../output_revised.txt","Test_Get_GetAllCommentById="+ res.ToString() + "\n");
                return false;
            }

            // Assert
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
            await File.AppendAllTextAsync("../../../../output_revised.txt","Test_Get_GetAllCommentById="+ res.ToString() + "\n");
            return true;
        }
        /// <summary>
        /// If the constructor is invoked successfully, the object will be created successfully.
        /// </summary>
        [Fact]
        public async Task<bool> MongoDBContext_Constructor_Success()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var settings = new Mongosettings()
            {
                Connection = "mongodb://user:password@127.0.0.1:27017/guestbook",
                DatabaseName = "FSEPABlogPost"
            };

            _mockOptions.Setup(s => s.Value).Returns(settings);
            _mockClient.Setup(c => c
            .GetDatabase(_mockOptions.Object.Value.DatabaseName, null))
                .Returns(_mockDB.Object);
            //Act
            try
            {
                var context = new MongoDBContext(_mockOptions.Object);
                if (context != null)
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
                await File.AppendAllTextAsync("../../../../output_revised.txt", "MongoDBContext_Constructor_Success=" + res.ToString() + "\n");
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
            await File.AppendAllTextAsync("../../../../output_revised.txt", "MongoDBContext_Constructor_Success="+ res.ToString() + "\n");
            return res;
        }
        /// <summary>
        /// Unit test cases for the GetCollection method
        /// A test for -ve scenario i.e when the collection name is passed as empty.
        /// </summary>
        [Fact]
        public async Task<bool> MongoDBContext_GetCollection_NameEmpty_Failure()
        {

            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var settings = new Mongosettings()
            {
                Connection = "mongodb://user:password@127.0.0.1:27017/guestbook",
                DatabaseName = "FSEPABlogPost"
            };

            _mockOptions.Setup(s => s.Value).Returns(settings);
            _mockClient.Setup(c => c
            .GetDatabase(_mockOptions.Object.Value.DatabaseName, null))
                .Returns(_mockDB.Object);

            //Act
            try
            {
                var context = new MongoDBContext(_mockOptions.Object);
                var myCollection = context.GetCollection<BlogPost>("");
                if (context != null)
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
               await File.AppendAllTextAsync("../../../../output_revised.txt", "MongoDBContext_GetCollection_NameEmpty_Failure="+ res.ToString() + "\n");
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
            await File.AppendAllTextAsync("../../../../output_revised.txt", "MongoDBContext_GetCollection_NameEmpty_Failure=" + res.ToString() + "\n");
            return res;
        }
        /// <summary>
        /// A test for +ve scenario i.e when a valid collection name is passed.
        /// Here we will verify if the GetCollection method returns proper collection.
        /// </summary>
        [Fact]
        public async Task<bool> MongoDBContext_GetCollection_ValidName_Success()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var settings = new Mongosettings()
            {
                Connection = "mongodb://user:password@127.0.0.1:27017/guestbook",
                DatabaseName = "FSEPABlogPost"
            };
            _mockOptions.Setup(s => s.Value).Returns(settings);
            _mockClient.Setup(c => c.GetDatabase(_mockOptions.Object.Value.DatabaseName, null)).Returns(_mockDB.Object);
            //Act
            try
            {
                var context = new MongoDBContext(_mockOptions.Object);
                var myCollection = context.GetCollection<BlogPost>("BlogPost");
                if (context != null)
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
               await File.AppendAllTextAsync("../../../../output_revised.txt", "MongoDBContext_GetCollection_ValidName_Success="+ res.ToString() + "\n");
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
           await File.AppendAllTextAsync("../../../../output_revised.txt", "MongoDBContext_GetCollection_ValidName_Success="+ res.ToString() + "\n");
           return res;
        }
    }
}