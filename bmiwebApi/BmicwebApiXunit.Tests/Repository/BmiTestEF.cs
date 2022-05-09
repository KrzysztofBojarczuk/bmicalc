using bmiwebApi;
using bmiwebApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using bmiwebApi.Repositories;
using FluentAssertions;

namespace BmicwebApiXunit.Tests.Repository
{
    public class BmiTestEF
    {
        private async Task<DataContext> GetDataContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var databaseContext = new DataContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Bodies.CountAsync() <= 0)
            {
                for (int i = 1; i < 10; i++)
                {
                    databaseContext.Bodies.Add(
                        new Body()
                        {
                            Weight = 78,
                            Height = 173,
                        });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }
        [Fact]
        public async Task GetAllBodies()
        {
            //Arrange
            var body = new Body()
            {
                Weight = 78,
                Height = 173,
            };

            //Act

            var dbContext = await GetDataContext();

            var bodyRepository = new BodyRepository(dbContext);

            //Assert

            var result = bodyRepository.CreateBodyAsync(body);

            //Assert
            result.Should();
        }
        [Fact]
        public async Task GetBodyById()
        {
            //Arrange
            var bodyId = 1;
            var dbContext = await GetDataContext();
            var bodyRepository = new BodyRepository(dbContext);

            //Act

            var result = bodyRepository.GetBodyByIdAsync(bodyId);

            //Assert
            result.Should().NotBe(0);


        }
    }
}
