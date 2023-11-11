using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSipBiteUnite.DataBaseClasses;
using DALSipBiteUnite.DbContext;

namespace DALSipBiteUnite.Repositories
{
    public interface IFoodRepository
    {
        void AddFood(Food food);
        void UpdateFood(Food food);
        void DeleteFood(int foodId);
        Food GetFoodById(int foodId);
        List<Food> GetAllFoods();
    }

    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddFood(Food food)
        {
            _context.Foods.Add(food);
            _context.SaveChanges();
        }

        public void UpdateFood(Food food)
        {
            _context.Foods.Update(food);
            _context.SaveChanges();
        }

        public void DeleteFood(int foodId)
        {
            var food = _context.Foods.Find(foodId);
            if (food != null)
            {
                _context.Foods.Remove(food);
                _context.SaveChanges();
            }
        }

        public Food GetFoodById(int foodId)
        {
            return _context.Foods.Find(foodId);
        }

        public List<Food> GetAllFoods()
        {
            return _context.Foods.ToList();
        }
    }
}
