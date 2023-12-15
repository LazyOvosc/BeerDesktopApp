using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSipBiteUnite.DataBaseClasses;
using DALSipBiteUnite.DbContext;
using DALSipBiteUnite.Repositories;
using FluentAssertions;

namespace WPFSipBiteUniteTest
{

        [TestClass]

    public class DishesTest
    {

            private async Task<ApplicationDbContext> GetDbContext()
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;
                var databaseContext = new ApplicationDbContext(options);
                databaseContext.Database.EnsureCreated();
                if (await databaseContext.Foods.CountAsync() < 0)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        databaseContext.Foods.Add(
                          new Food()
                          {
                              FoodCategory = "Супи",
                              FoodDescription = "Смачний і запашний, а найголовніше, що український",
                              FoodId = i,
                              FoodName = "Борщ",
                              FoodPhotoURL = Guid.NewGuid().ToString()
                          });
                        await databaseContext.SaveChangesAsync();
                    }
                }
                return databaseContext;
            }


            [TestMethod]
            public async Task FoodRepository_Add_ReturnsBool()
            {
                var foodId = 1;
                var food = new Food()
                {
                    FoodCategory = "Супи",
                    FoodDescription = "Смачний і запашний, а найголовніше, що український",
                    FoodId = foodId,
                    FoodName = "Борщ",
                    FoodPhotoURL = Guid.NewGuid().ToString()
                };
                var dbContext = await GetDbContext();
                var foodRepository = new FoodRepository(dbContext);

                var result = foodRepository.AddFood(food);

                result.Should().BeTrue();
            }



            [TestMethod]
            public async Task FoodRepository_GetAll_ReturnsList()
            {
                var dbContext = await GetDbContext();
                var foodRepository = new FoodRepository(dbContext);

                var result = foodRepository.GetAllFoods();

                result.Should().NotBeNull();
                result.Should().BeOfType<List<Food>>();
            }


            [TestMethod]
            public async Task FoodRepository_SuccessfulDelete_ReturnsTrue()
            {
                var foodId = 1;
                var food = new Food()
                {
                    FoodCategory = "Супи",
                    FoodDescription = "Смачний і запашний, а найголовніше, що український",
                    FoodId = foodId,
                    FoodName = "Борщ",
                    FoodPhotoURL = Guid.NewGuid().ToString()
                };
                var dbContext = await GetDbContext();
                var foodRepository = new FoodRepository(dbContext);

                foodRepository.AddFood(food);
                var result = foodRepository.DeleteFood(foodId);
                var count = await foodRepository.GetCountAsync();

                result.Should().BeTrue();
                count.Should().Be(0);
            }


            [TestMethod]
            public async Task ClubRepositoryFood_GetCountAsync_ReturnsInt()
            {
                var foodId = 1;
                var food = new Food()
                {
                    FoodCategory = "Супи",
                    FoodDescription = "Смачний і запашний, а найголовніше, що український",
                    FoodId = foodId,
                    FoodName = "Борщ",
                    FoodPhotoURL = Guid.NewGuid().ToString()
                };
                var dbContext = await GetDbContext();
                var foodRepository = new FoodRepository(dbContext);

                foodRepository.AddFood(food);
                var result = await foodRepository.GetCountAsync();

                result.Should().Be(1);
            }

        }
    }

