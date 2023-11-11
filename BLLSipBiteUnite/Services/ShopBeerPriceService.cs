using DALSipBiteUnite.DataBaseClasses;
using DALSipBiteUnite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLSipBiteUnite.Services
{
    public interface IShopBeerPriceService
    {
        void AddShopBeerPrice(ShopBeerPrice shopBeerPrice);
        void UpdateShopBeerPrice(ShopBeerPrice shopBeerPrice);
        void DeleteShopBeerPrice(int shopBeerPriceId);
        ShopBeerPrice GetShopBeerPriceById(int shopBeerPriceId);
        List<ShopBeerPrice> GetAllShopBeerPrices();
    }

    public class ShopBeerPriceService : IShopBeerPriceService
    {
        private readonly IShopBeerPriceRepository _shopBeerPriceRepository;

        public ShopBeerPriceService(IShopBeerPriceRepository shopBeerPriceRepository)
        {
            _shopBeerPriceRepository = shopBeerPriceRepository;
        }

        public void AddShopBeerPrice(ShopBeerPrice shopBeerPrice)
        {
            _shopBeerPriceRepository.AddShopBeerPrice(shopBeerPrice);
        }

        public void UpdateShopBeerPrice(ShopBeerPrice shopBeerPrice)
        {
            _shopBeerPriceRepository.UpdateShopBeerPrice(shopBeerPrice);
        }

        public void DeleteShopBeerPrice(int shopBeerPriceId)
        {
            _shopBeerPriceRepository.DeleteShopBeerPrice(shopBeerPriceId);
        }

        public ShopBeerPrice GetShopBeerPriceById(int shopBeerPriceId)
        {
            return _shopBeerPriceRepository.GetShopBeerPriceById(shopBeerPriceId);
        }

        public List<ShopBeerPrice> GetAllShopBeerPrices()
        {
            return _shopBeerPriceRepository.GetAllShopBeerPrices();
        }
    }
}
