using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSipBiteUnite.DataBaseClasses;
using DALSipBiteUnite.DbContext;

namespace DALSipBiteUnite.Repositories
{
    public interface IShopRepository
    {
        void AddShop(Shop shop);
        void UpdateShop(Shop shop);
        void DeleteShop(int shopId);
        Shop GetShopById(int shopId);
        List<Shop> GetAllShops();
    }

    public class ShopRepository : IShopRepository
    {
        private readonly ApplicationDbContext _context;

        public ShopRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddShop(Shop shop)
        {
            _context.Shops.Add(shop);
            _context.SaveChanges();
        }

        public void UpdateShop(Shop shop)
        {
            _context.Shops.Update(shop);
            _context.SaveChanges();
        }

        public void DeleteShop(int shopId)
        {
            var shop = _context.Shops.Find(shopId);
            if (shop != null)
            {
                _context.Shops.Remove(shop);
                _context.SaveChanges();
            }
        }

        public Shop GetShopById(int shopId)
        {
            return _context.Shops.Find(shopId);
        }

        public List<Shop> GetAllShops()
        {
            return _context.Shops.ToList();
        }
    }
}
