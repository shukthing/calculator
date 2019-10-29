using Sample;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace InMemorySample
{
    public class BlogServiceTests
    {
        [Fact]
        public void Add_writes_to_database()
        {
            var options = new DbContextOptionsBuilder<BloggingContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            // Run the test against one instance of the context
            using (var context = new BloggingContext(options))
            {
                var service = new BlogService(context);
                service.Add("https://example.com",1);
                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new BloggingContext(options))
            {
                Assert.Equal(1, context.Blogs.Count());
                Assert.Equal("INV-12345", context.Blogs.Single().Url);
            }
        }

        [Fact]
        public void Find_searches_url()
        {
            var options = new DbContextOptionsBuilder<BloggingContext>()
                .UseInMemoryDatabase(databaseName: "Find_searches_inv")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new BloggingContext(options))
            {
                context.Blogs.Add(new Blog { Url = "INV-12345", Version = 1 });
                context.Blogs.Add(new Blog { Url = "INV-00001", Version = 2 });
                context.Blogs.Add(new Blog { Url = "INV-ABC", Version = 3 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new BloggingContext(options))
            {
                var service = new BlogService(context);
                var result = service.Find("ABC");
                Assert.Single(result);
            }
        }
    }
}
