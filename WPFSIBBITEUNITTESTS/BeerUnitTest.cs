using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DALSipBiteUnite.DataBaseClasses;
using DALSipBiteUnite.DbContext;
using DALSipBiteUnite.Repositories;
using FluentAssertions;


namespace Tests.Tests.BeerTests
{[TestClass]

    public class BeerTests

    {

 
        private async Task<ApplicationDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Beers.CountAsync() < 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Beers.Add(
                      new Beer()
                      {
                          BeerType = "Lvivske",
                          BeerDescription = "Smachne duze",
                          BeerPhotoURL = Guid.NewGuid().ToString(),
                          BeerName = "Kozel",
                          BeerProducer = "Stepan",
                          BeerId = i
                      });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [TestMethod]
        public async Task BeerRepository_Add_ReturnsBool()
        {
            //Arrange
            var beerId = 1;
            //Arrange
            var beer = new Beer()
            {
                BeerType = "Lvivske",
                BeerDescription = "Smachne duze",
                BeerPhotoURL = Guid.NewGuid().ToString(),
                BeerName = "Kozel",
                BeerProducer = "Vanya",
                BeerId = beerId

            };
            var dbContext = await GetDbContext();
            var beerRepository = new BeerRepository(dbContext);

            //Act
            var result = beerRepository.AddBeer(beer);

            //Assert
            result.Should().BeTrue();
        }

      

        [TestMethod]
        public async Task BeerRepository_GetAll_ReturnsList()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var beerRepository = new BeerRepository(dbContext);

            //Act
            var result = beerRepository.GetAllBeers();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Beer>>();
        }

        [TestMethod]
        public async Task BeerRepository_SuccessfulDelete_ReturnsTrue()
        {
            var beerId = 1;
            //Arrange
            var beer = new Beer()
            {
                BeerType = "Lvivske",
                BeerDescription = "Smachne duze",
                BeerPhotoURL = Guid.NewGuid().ToString(),
                BeerName = "Kozel",
                BeerProducer = "Vanya",
                BeerId = beerId

            };
            var dbContext = await GetDbContext();
            var beerRepository = new BeerRepository(dbContext);

            //Act
            beerRepository.AddBeer(beer);
            var result = beerRepository.DeleteBeer(beerId);
            var count = await beerRepository.GetCountAsync();

            //Assert
            result.Should().BeTrue();
            count.Should().Be(0);
        }

        [TestMethod]
        public async Task  ClubRepository_GetCountAsync_ReturnsInt()
        {
            //Arrange
            var beerId = 1;
            //Arrange
            var beer = new Beer()
            {
                BeerType = "Lvivske",
                BeerDescription = "Smachne duze",
                BeerPhotoURL = Guid.NewGuid().ToString(),
                BeerName = "Kozel",
                BeerProducer = "Vanya",
                BeerId = beerId

            };
            var dbContext = await GetDbContext();
            var beerRepository = new BeerRepository(dbContext);

            //Act
            beerRepository.AddBeer(beer);
            var result = await beerRepository.GetCountAsync();

            //Assert
            result.Should().Be(1);
        }


    }
}
