// <copyright file="ShopBeerPriceRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DALSipBiteUnite.Repositories
{
    using DALSipBiteUnite.DataBaseClasses;
    using DALSipBiteUnite.DbContext;

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
