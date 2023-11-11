using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSipBiteUnite.DataBaseClasses;
using DALSipBiteUnite.DbContext;

namespace DALSipBiteUnite.Repositories
{
    public interface IShopBeerPriceRepository
    {
        void AddShopBeerPrice(ShopBeerPrice shopBeerPrice);
        void UpdateShopBeerPrice(ShopBeerPrice shopBeerPrice);
        void DeleteShopBeerPrice(int shopBeerPriceId);
        ShopBeerPrice GetShopBeerPriceById(int shopBeerPriceId);
        List<ShopBeerPrice> GetAllShopBeerPrices();
    }

    public class ShopBeerPriceRepository : IShopBeerPriceRepository
    {
        private readonly ApplicationDbContext _context;

        public ShopBeerPriceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddShopBeerPrice(ShopBeerPrice shopBeerPrice)
        {
            _context.ShopBeerPrices.Add(shopBeerPrice);
            _context.SaveChanges();
        }

        public void UpdateShopBeerPrice(ShopBeerPrice shopBeerPrice)
        {
            _context.ShopBeerPrices.Update(shopBeerPrice);
            _context.SaveChanges();
        }

        public void DeleteShopBeerPrice(int shopBeerPriceId)
        {
            var shopBeerPrice = _context.ShopBeerPrices.Find(shopBeerPriceId);
            if (shopBeerPrice != null)
            {
                _context.ShopBeerPrices.Remove(shopBeerPrice);
                _context.SaveChanges();
            }
        }

        public ShopBeerPrice GetShopBeerPriceById(int shopBeerPriceId)
        {
            return _context.ShopBeerPrices.Find(shopBeerPriceId);
        }

        public List<ShopBeerPrice> GetAllShopBeerPrices()
        {
            return _context.ShopBeerPrices.ToList();
        }
    }
}
