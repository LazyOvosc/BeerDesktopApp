using DALSipBiteUnite.DataBaseClasses;
using DALSipBiteUnite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLSipBiteUnite.Services
{
    public interface IFoodService
    {
        void AddFood(Food food);
        void UpdateFood(Food food);
        void DeleteFood(int foodId);
        Food GetFoodById(int foodId);
        List<Food> GetAllFoods();
    }

    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public void AddFood(Food food)
        {
            _foodRepository.AddFood(food);
        }

        public void UpdateFood(Food food)
        {
            _foodRepository.UpdateFood(food);
        }

        public void DeleteFood(int foodId)
        {
            _foodRepository.DeleteFood(foodId);
        }

        public Food GetFoodById(int foodId)
        {
            return _foodRepository.GetFoodById(foodId);
        }

        public List<Food> GetAllFoods()
        {
            return _foodRepository.GetAllFoods();
        }
    }
}
